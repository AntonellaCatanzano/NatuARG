using Microsoft.EntityFrameworkCore;
using NatuArgAPI.Data.Contracts;
using NatuArgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Data.Repository
{
    public class AtraccionRepository : IAtraccionRepository
    {
        private readonly NatuArgDbContext _context;
        private readonly DbSet<Atraccion> _dbSet;

        public AtraccionRepository(NatuArgDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Atraccion>();
        }

        public async Task<bool> CreateAtraccionAsync(Atraccion atraccion)
        {
            await _dbSet.AddAsync(atraccion);
            return await SaveAsync();
        }

        public async Task<bool> DeleteAtraccionAsync(Atraccion atraccion)
        {
            _dbSet.Remove(atraccion);
            return await SaveAsync();
        }

        public async Task<Atraccion> GetAtraccionAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Nombre.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task<Atraccion> GetAtraccionAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Atraccion>> GetAtraccionAsync()
        {
            return await _dbSet.OrderBy(a => a.Nombre).ToListAsync();
        }

        public async Task<bool> AtraccionExistAsync(string name)
        {
            return await _dbSet.AnyAsync(a => a.Nombre.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task<bool> AtraccionExistAsync(int id)
        {
            return await _dbSet.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<bool> UpdateAtraccionAsync(Atraccion atraccion)
        {
            _dbSet.Update(atraccion);
            return await SaveAsync();
        }
    }
}
