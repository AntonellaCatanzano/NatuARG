using Microsoft.EntityFrameworkCore;
using NatuArgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Data
{
    public class NatuArgDbContext: DbContext
    {
        public NatuArgDbContext(DbContextOptions<NatuArgDbContext> options): base(options)
        {

        }

        public DbSet<Parque> Parques { get; set; }
    }
}
