using Core.Application.Services.Characters.ViewModels;
using Microsoft.AspNetCore.JsonPatch;

namespace Core.Application.Services.Characters
{
    public interface ICharacterService
    {
        Task<List<GetCharactersViewModel>> GetCharacters();
        Task<GetCharacterDetailsViewModel> GetCharacterDetails(int id);
        Task<int> CreateCharacter(CreateCharacterViewModel character);
        Task UpdateCharacter(int id, JsonPatchDocument<CreateCharacterViewModel> character);
        Task SoftDeleteCharacter(int id);
    }
}
