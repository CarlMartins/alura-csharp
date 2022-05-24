using System.Linq;
using AluraAPI.Data;
using AluraAPI.Data.Dtos.Gerente;
using AluraAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AluraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController: ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto createGerenteDto)
        {
            var gerente = _mapper.Map<Gerente>(createGerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente != null)
            {
                var gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                
                return Ok(gerenteDto);
            }

            return NotFound("Gerente não encontrado");
        }
    }
}