using NatuArgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Data.Contracts
{
    public interface IParqueRepository
    {
        ICollection<Parque> GetParques();
        Parque GetParque(int id);
        bool ParqueExist(string name);
        bool ParqueExist(int id);
        bool CreateParque(Parque parque);
        bool UpdateParque(Parque parque);
        bool DeleteParque(Parque parque);
        bool Save();
    }
}
