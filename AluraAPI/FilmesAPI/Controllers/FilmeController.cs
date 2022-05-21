using System.Collections.Generic;
using System.Linq;
using AluraAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AluraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> _filmes = new();
        private static int _id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = _id++;
            _filmes.Add(filme);

            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(_filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId([FromRoute] int id)
        {
            var filme = _filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null) return Ok(filme);

            return NotFound("Filme não encontrado");
        }
    }
}