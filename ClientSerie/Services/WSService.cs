using ClientSerie.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientSerie.Services
{
    public class WSService : IService
    {
        private HttpClient client;

        public WSService(string url)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url); //"http://localhost:7153/"
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<List<Serie>> GetSeriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Serie>> GetSerieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> PutSerieAsync(int id, Serie serie)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Serie>> PostSerieAsync(Serie serie)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteSerieAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
