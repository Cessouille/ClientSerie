using System.Collections.Generic;
using System.Threading.Tasks;
using ClientSerie.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientSerie.Services
{
    public interface IService
    {
        public Task<List<Serie>> GetSeriesAsync(string nomControlleur);
        public Task<ActionResult<Serie>> GetSerieAsync(string nomControlleur, int id);
        public Task<bool> PutSerieAsync(string nomControlleur, int id, Serie serie);
        public Task<ActionResult<bool>> PostSerieAsync(string nomControlleur, Serie serie);
        public Task<bool> DeleteSerieAsync(string nomControlleur, int id);
    }
}
