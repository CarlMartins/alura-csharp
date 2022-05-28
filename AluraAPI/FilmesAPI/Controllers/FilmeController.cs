using System;
using System.Collections.Generic;
using System.Linq;
using AluraAPI.Data;
using AluraAPI.Data.Dtos;
using AluraAPI.Models;
using AluraAPI.Services;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace AluraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;
        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readFilmeDto = _filmeService.AdicionaFilme(filmeDto);
           
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = readFilmeDto.Id }, readFilmeDto);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> readFilmeDtos = _filmeService.RecuperaFilmes(classificacaoEtaria);

            if (readFilmeDtos != null) return Ok(readFilmeDtos);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId([FromRoute] int id)
        {
            ReadFilmeDto readFilmeDto = _filmeService.RecuperaFilmePorId(id);

            if (readFilmeDto != null) return Ok(readFilmeDto);
            return NotFound("Filme não encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result result = _filmeService.AtualizaFilme(id, filmeDto);

            if (result.IsFailed) return NotFound(); 
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme([FromRoute] int id)
        {
            Result result = _filmeService.DeletaFilme(id);

            if (result.IsFailed) return NotFound(); 
            return NoContent();
        }
    }
}