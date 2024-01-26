using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Services.Characters.ViewModels;
using Core.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
 

namespace Core.Application.Services.Characters
{
    public class CharacterService : ICharacterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET ALL
        public async Task<List<GetCharactersViewModel>> GetCharacters()
        {
            var characters = _unitOfWork.Characters.GetQuery(filter: character => character.Deleted == null);

            return await characters
                .Select(character => (GetCharactersViewModel)character).ToListAsync();
        }

        // GET BY ID
        public async Task<GetCharacterDetailsViewModel> GetCharacterDetails(int id)
        {
            var characters = await _unitOfWork.Characters.GetByIdAsync(characters => characters.Id == id, filter: characters => characters.Deleted == null,
                includeProperties: "Pirate, Rol");

            if (characters is null)
                throw new NotFoundException(nameof(Character), id);

            return (GetCharacterDetailsViewModel)characters;
        }

        // CREATE
        public async Task<int> CreateCharacter(CreateCharacterViewModel charViewModel)
        {
            var character = new Character
            {
                FullName = charViewModel.FullName,
                Age = charViewModel.Age,
                Origin = charViewModel.Origin,
                Reward = charViewModel.Reward,
                Height = charViewModel.Height,
                ImageURL = charViewModel.ImageURL,
                PirateId = charViewModel.PirateId,
                RolId = charViewModel.RolId,
            };

            _unitOfWork.Characters.Add(character);
            await _unitOfWork.CompleteAsync();

            return character.Id;
        }

        // PATCH (Update)
        public async Task UpdateCharacter(int id, JsonPatchDocument<CreateCharacterViewModel> patchDocument)
        {
            var character = await _unitOfWork.Characters.FindAsync(character => character.Id == id,
                filter: character => character.Deleted == null);

            if (character == null)
                throw new NotFoundException(nameof(Character), id);

            var characterViewModel = new CreateCharacterViewModel
            {
                FullName = character.FullName,
                Age = character.Age,
                Origin = character.Origin,
                Reward = character.Reward,
                Height = character.Height,
                ImageURL = character.ImageURL,
                PirateId = character.PirateId,
                RolId = character.RolId,

            };

            patchDocument.ApplyTo(characterViewModel);

            character.FullName = characterViewModel.FullName;
            character.Age = characterViewModel.Age;
            character.Origin = characterViewModel.Origin;
            character.Reward = characterViewModel.Reward;
            character.Height = characterViewModel.Height;
            character.ImageURL = characterViewModel.ImageURL;

            _unitOfWork.Characters.Patch(character);
            await _unitOfWork.CompleteAsync();
        }

        //public async Task UpdateCharacter(int id, UpdateCharacterViewModel characterViewModel)
        //{
        //    var character = await _unitOfWork.Characters.FindAsync(character => character.Id == id,
        //        filter: character => character.Deleted == null);

        //    if (character == null)
        //        throw new NotFoundException(nameof(Character), id);


        //    character.FullName = characterViewModel.FullName;
        //    character.Age = characterViewModel.Age;
        //    character.Origin = characterViewModel.Origin;
        //    character.Reward = characterViewModel.Reward;
        //    character.Height = characterViewModel.Height;
        //    character.ImageURL = characterViewModel.ImageURL;

        //    _unitOfWork.Characters.Update(character);
        //    await _unitOfWork.CompleteAsync();
        //}

        // SOFT DELETE
        public async Task SoftDeleteCharacter(int id)
        {
            var character = await _unitOfWork.Characters.FindAsync(character => character.Id == id,
                filter: character => character.Deleted == null);

            if (character is null)
                throw new NotFoundException(nameof(Character), id);

            _unitOfWork.Characters.Delete(character);
            await _unitOfWork.CompleteAsync();
        }
    }
}
