using NatuArgAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NatuArgAPI.Data.Contracts
{
    public interface IParqueRepository
    {
        Task<bool> CreateParqueAsync(Parque parque);
        Task<bool> DeleteParqueAsync(Parque parque);
        Task<Parque> GetParqueAsync(int id);
        Task<List<Parque>> GetParquesAsync();
        Task<bool> ParqueExistAsync(int id);
        Task<bool> ParqueExistAsync(string name);
        Task<bool> SaveAsync();
        Task<bool> UpdateParqueAsync(Parque parque);
    }
}