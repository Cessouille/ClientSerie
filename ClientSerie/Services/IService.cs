using System.Collections.Generic;
using System.Threading.Tasks;
using ClientSerie.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientSerie.Services
{
    public interface IService
    {
        public Task<List<Serie>> GetSeriesAsync(string nomControlleur);
        public Task<ActionResult<Serie>> GetSerieAsync(int id, string nomControlleur);
        public Task<IActionResult> PutSerieAsync(int id, Serie serie);
        public Task<ActionResult<Serie>> PostSerieAsync(Serie serie);
        public Task<IActionResult> DeleteSerieAsync(int id);
    }
}
