using System.Linq;
using AluraAPI.Data;
using AluraAPI.Data.Dtos.Sessao;
using AluraAPI.Models;
using AluraAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AluraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController: ControllerBase
    {
        private readonly SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            ReadSessaoDto sessao = _sessaoService.AdicionaSessao(dto);
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new {Id = sessao.Id}, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDto sessao = _sessaoService.RecuperaSessaoPorId(id);

            if (sessao != null) return Ok(sessao);
            return NotFound();
        }
    }
}