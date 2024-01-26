using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Services.Pirates.ViewModels;
using Core.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Services.Pirates
{
    public class PirateService : IPirateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PirateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET ALL
        public async Task<List<GetPiratesViewModel>> GetPirates()
        {
            var pirates = _unitOfWork.Pirates.GetQuery(filter: pirate => pirate.Deleted == null);

            return await pirates
                .Select(pirate => (GetPiratesViewModel)pirate).ToListAsync();
        }

        // GET BY ID
        public async Task<GetPirateDetailsViewModel> GetPirateDetails(int id)
        {
            var pirates = await _unitOfWork.Pirates.GetByIdAsync(pirates => pirates.Id == id, 
                filter: pirates  => pirates.Deleted == null, includeProperties: "Members");

            if(pirates is null)
                throw new NotFoundException(nameof(Pirate), id);

            return (GetPirateDetailsViewModel)pirates;
          

        }

        // CREATE
        public async Task<int> CreatePirate(CreatePirateViewModel pirateVM)
        {
            var pirate = new Pirate
            {
                Name = pirateVM.Name,
                Ship = pirateVM.Ship,
                TotalReward = pirateVM.TotalReward,
                ImageURL = pirateVM.ImageURL
            };

            _unitOfWork.Pirates.Add(pirate);
            await _unitOfWork.CompleteAsync();

            return pirate.Id;

        }

        // PATCH (Update)
        public async Task UpdatePirate(int id, JsonPatchDocument<CreatePirateViewModel> patchDocument)
        {
            var pirate = await _unitOfWork.Pirates.FindAsync(pirate => pirate.Id == id,
                filter: pirate => pirate.Deleted == null);

            if (pirate == null)
                throw new NotFoundException(nameof(Pirate), id);

            var pirateViewModel = new CreatePirateViewModel
            {
                Name = pirate.Name,
                Ship = pirate.Ship,
                TotalReward = pirate.TotalReward,
                ImageURL = pirate.ImageURL

            };

            patchDocument.ApplyTo(pirateViewModel);

            pirate.Name = pirateViewModel.Name;
            pirate.Ship = pirateViewModel.Ship;
            pirate.TotalReward = pirateViewModel.TotalReward;
            pirate.ImageURL = pirateViewModel.ImageURL;

            _unitOfWork.Pirates.Patch(pirate);
            await _unitOfWork.CompleteAsync();
        }

        // SOFT DELETE
        public async Task SoftDeletePirate(int id)
        {
            var pirate = await _unitOfWork.Pirates.FindAsync(pirate => pirate.Id == id,
                filter: pirate => pirate.Deleted == null);

            if (pirate is null)
                throw new NotFoundException(nameof(Pirate), id);

            _unitOfWork.Pirates.Delete(pirate);
            await _unitOfWork.CompleteAsync();
        }
    }
}
