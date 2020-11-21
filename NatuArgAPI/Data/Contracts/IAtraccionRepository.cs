using NatuArgAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NatuArgAPI.Data.Contracts
{
    public interface IAtraccionRepository
    {
        Task<bool> AtraccionExistAsync(int id);
        Task<bool> AtraccionExistAsync(string name);
        Task<bool> CreateAtraccionAsync(Atraccion atraccion);
        Task<bool> DeleteAtraccionAsync(Atraccion atraccion);
        Task<List<Atraccion>> GetAtraccionAsync();
        Task<Atraccion> GetAtraccionAsync(int id);
        Task<bool> SaveAsync();
        Task<bool> UpdateAtraccionAsync(Atraccion atraccion);
    }
}