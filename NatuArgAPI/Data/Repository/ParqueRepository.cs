using Microsoft.EntityFrameworkCore;
using NatuArgAPI.Data.Contracts;
using NatuArgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Data.Repository
{
    public class ParqueRepository : IParqueRepository
    {
        private readonly NatuArgDbContext _context;
        private readonly DbSet<Parque> _dbSet;

        public ParqueRepository(NatuArgDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Parque>();
        }

        public async Task<bool> CreateParqueAsync(Parque parque)
        {
            await _dbSet.AddAsync(parque);
            return await SaveAsync();
        }

        public async Task<bool> DeleteParqueAsync(Parque parque)
        {
            _dbSet.Remove(parque);
            return await SaveAsync();
        }

        public async Task<Parque> GetParqueAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Parque>> GetParquesAsync()
        {
            return await _dbSet.OrderBy(a => a.Nombre).ToListAsync();
        }

        public async Task<bool> ParqueExistAsync(string name)
        {
            return await _dbSet.AnyAsync(a => a.Nombre.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task<bool> ParqueExistAsync(int id)
        {
            return await _dbSet.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<bool> UpdateParqueAsync(Parque parque)
        {
            _dbSet.Update(parque);
            return await SaveAsync();
        }
    }
}
