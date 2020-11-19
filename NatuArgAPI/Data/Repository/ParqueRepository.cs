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

        public bool CreateParque(Parque parque)
        {
            _dbSet.Add(parque);
            return Save();
        }

        public bool DeleteParque(Parque parque)
        {
            _dbSet.Remove(parque);
            return Save();
        }

        public Parque GetParque(int id)
        {
            return _dbSet.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<Parque> GetParques()
        {
            return _dbSet.OrderBy(a => a.Nombre).ToList();
        }

        public bool ParqueExist(string name)
        {
            return _dbSet.Any(a => a.Nombre.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool ParqueExist(int id)
        {
            return _dbSet.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateParque(Parque parque)
        {
            _dbSet.Update(parque);
            return Save();
        }
    }
}
