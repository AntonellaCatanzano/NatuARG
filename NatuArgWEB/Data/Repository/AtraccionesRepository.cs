using NatuArgWEB.Data.Contracts;
using NatuArgWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NatuArgWEB.Data.Repository
{
    public class AtraccionesRepository: GenericRepository<Atraccion>, IAtraccionesRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public AtraccionesRepository(IHttpClientFactory clientFactory): base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
