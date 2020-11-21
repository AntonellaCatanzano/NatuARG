using NatuArgWEB.Data.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NatuArgWEB.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IHttpClientFactory _clientFactory;

        public GenericRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> CreateAsync(string url, T objToCreate)
        {
            // Crea el request
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            // Si el objeto a crear no es nulo, entonces lo serializa a Json y agrega al Content del request
            if (objToCreate != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(objToCreate), Encoding.UTF8, "application/json");
            }
            else 
            {
                return false;
            }

            // Envia el request
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            // Si la respuesta es Created retorna true, sino false
            return (response.StatusCode == HttpStatusCode.Created);
        }

        public async Task<bool> DeleteAsync(string url, int Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url + Id);

            // Envia el request
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            // Si la respuesta es Created retorna true, sino false
            return (response.StatusCode == HttpStatusCode.NoContent);
        }

        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // Envia el request
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            // Si la respuesta es OK retorna la lista de objetos, sino null
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Obtiene el contenido de la respuesta
                var jsonString = await response.Content.ReadAsStringAsync();
                // Lo retorna luego de deserializarlo desde json
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
            }
            else
            {
                return null;
            }
        }

        public async Task<T> GetAsync(string url, int Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // Envia el request
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            // Si la respuesta es OK retorna el objeto, sino null
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(string url, T objToUpdate)
        {
            // Crea el request
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            // Si el objeto a crear no es nulo, entonces lo serializa a Json y agrega al Content del request
            if (objToUpdate!= null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(objToUpdate), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }

            // Envia el request
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            // Si la respuesta es Created retorna true, sino false
            return (response.StatusCode == HttpStatusCode.NoContent);
        }
    }
}
