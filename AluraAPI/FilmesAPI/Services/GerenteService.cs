using System.Collections.Generic;
using System.Linq;
using AluraAPI.Data;
using AluraAPI.Data.Dtos.Gerente;
using AluraAPI.Models;
using AutoMapper;

namespace AluraAPI.Services
{
    public class GerenteService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public ReadGerenteDto AdicionaGerente(CreateGerenteDto createGerenteDto)
        {
            var gerente = _mapper.Map<Gerente>(createGerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public List<ReadGerenteDto> RecuperaGerentes()
        {
            List<Gerente> gerentes = _context.Gerentes.ToList();

            if (gerentes.Count > 0) return _mapper.Map<List<ReadGerenteDto>>(gerentes);
            return null;
        }

        public ReadGerenteDto RecuperaGerentePorId(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente != null)
            {
                return _mapper.Map<ReadGerenteDto>(gerente);
            }

            return null;
        }
    }
}