using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class DAL
    {
        public HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44367/api/");
            return client;
        }
        public async Task<Cars> GetCar(int id)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"cars/{id}");
            var car = await response.Content.ReadAsAsync<Cars>();
            return car;
        }

        public async Task<List<Cars>> GetCars()
        {
           
            var client = GetHttpClient();
            var response = await client.GetAsync("cars");
            var clist = await response.Content.ReadAsAsync<List<Cars>>();
            return clist;
        }
    }
}
