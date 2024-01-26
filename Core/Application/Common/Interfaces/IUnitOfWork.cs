using System.Threading.Tasks;
using Core.Domain.Models;

namespace Core.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Character> Characters { get; }
        IGenericRepository<Pirate> Pirates { get; }
        IGenericRepository<Fruit> Fruits { get; }
        IGenericRepository<Rol> Roles { get; }
    

        Task CompleteAsync();
    }
}