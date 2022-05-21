using System.Collections.Generic;
using AluraAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AluraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController: ControllerBase
    {
        private static List<Filme> _filmes = new();

        [HttpPost]
        public void AdicionaFilme([FromBody] Filme filme)
        {
            _filmes.Add(filme);
        }
    }
}