using System.Collections.Generic;
using System.Linq;
using AluraAPI.Data;
using AluraAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AluraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId([FromRoute] int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null) return Ok(filme);

            return NotFound("Filme não encontrado");
        }

        [HttpPut]
        public IActionResult AtualizaFilme([FromBody] Filme filme)
        {
            var filmeEncontrado = _context.Filmes.FirstOrDefault(f => f.Id == filme.Id);
            if (filmeEncontrado == null) return NotFound();

            filmeEncontrado.Titulo = filme.Titulo;
            filmeEncontrado.Genero = filme.Genero;
            filmeEncontrado.Duracao = filme.Duracao;
            filmeEncontrado.Diretor = filme.Diretor;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme([FromRoute] int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }
    }
}