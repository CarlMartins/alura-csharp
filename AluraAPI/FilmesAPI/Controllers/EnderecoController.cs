using System.Collections.Generic;
using System.Linq;
using AluraAPI.Data;
using AluraAPI.Data.Dtos.Cinema;
using AluraAPI.Data.Dtos.Endereco;
using AluraAPI.Models;
using AluraAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AluraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readEnderecoDto = _enderecoService.AdicionaEndereco(enderecoDto);
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = readEnderecoDto.Id }, readEnderecoDto);
        }

        [HttpGet]
        public IActionResult RecuperaEnderecos()
        {
            List<ReadEnderecoDto> enderecosDtos = _enderecoService.RecuperaEnderecos();

            if (enderecosDtos.Count > 0) return Ok(enderecosDtos);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            ReadEnderecoDto readCinemaDto = _enderecoService.RecuperaEnderecoPorId(id);

            if (readCinemaDto != null) return Ok(readCinemaDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readEnderecoDto = _enderecoService.AtualizaEndereco(id, enderecoDto);

            if (readEnderecoDto != null) return NoContent();
            return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Endereco endereco = _enderecoService.DeletaEndereco(id);

            if (endereco != null) return NoContent();
            return NotFound();
        }
    }
}