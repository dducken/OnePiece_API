using Core.Application.Services.Pirates.ViewModels;
using Microsoft.AspNetCore.JsonPatch;

namespace Core.Application.Services.Pirates
{
    public interface IPirateService
    {
        Task<List<GetPiratesViewModel>> GetPirates();
        Task<GetPirateDetailsViewModel> GetPirateDetails(int id);
        Task<int> CreatePirate(CreatePirateViewModel pirate);
        Task UpdatePirate(int id, JsonPatchDocument<CreatePirateViewModel> character);
        Task SoftDeletePirate(int id);

    }
}
