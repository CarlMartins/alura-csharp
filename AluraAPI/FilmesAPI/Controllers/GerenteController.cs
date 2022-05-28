using System.Collections.Generic;
using System.Linq;
using AluraAPI.Data;
using AluraAPI.Data.Dtos.Gerente;
using AluraAPI.Models;
using AluraAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AluraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController: ControllerBase
    {
        private readonly GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto createGerenteDto)
        {
            ReadGerenteDto gerenteDto = _gerenteService.AdicionaGerente(createGerenteDto);
            
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = gerenteDto.Id }, gerenteDto);
        }

        [HttpGet]
        public IActionResult RecuperaGerentes()
        {
            List<ReadGerenteDto> gerentes = _gerenteService.RecuperaGerentes();

            if (gerentes.Count > 0) return Ok(gerentes);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            ReadGerenteDto gerente = _gerenteService.RecuperaGerentePorId(id);

            if (gerente != null) return Ok(gerente);
            return NotFound("Gerente não encontrado");
        }
    }
}