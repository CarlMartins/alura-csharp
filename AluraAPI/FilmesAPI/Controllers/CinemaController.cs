using System.Collections.Generic;
using System.Linq;
using AluraAPI.Data;
using AluraAPI.Data.Dtos.Cinema;
using AluraAPI.Models;
using AluraAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AluraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto createCinemaDto = _cinemaService.AdicionaCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = createCinemaDto.Id }, createCinemaDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> cinemasDtos = _cinemaService.RecuperaCinemas(nomeDoFilme);
            
            if(cinemasDtos != null) return Ok(cinemasDtos);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto cinemaDto = _cinemaService.RecuperaCinemasPorId(id);

            if (cinemaDto != null) return Ok(cinemaDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            UpdateCinemaDto updateCinemaDto = _cinemaService.AtualizaCinema(id, cinemaDto);

            if (updateCinemaDto != null) return NoContent();
            return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Cinema cinema = _cinemaService.DeletaCinema(id);

            if (cinema != null) return NoContent();
            return NotFound();
        }

    }
}