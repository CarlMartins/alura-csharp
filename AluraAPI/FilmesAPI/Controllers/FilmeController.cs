using System;
using System.Collections.Generic;
using System.Linq;
using AluraAPI.Data;
using AluraAPI.Data.Dtos;
using AluraAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AluraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public FilmeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);
            
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes
                    .Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria)
                    .ToList();
            }
            
            if (filmes != null)
            {
                List<ReadFilmeDto> readFilmeDtos = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return Ok(readFilmeDtos);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId([FromRoute] int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                
                return Ok(filmeDto);
            }

            return NotFound("Filme não encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null) return NotFound();

            _mapper.Map(filmeDto, filme);
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