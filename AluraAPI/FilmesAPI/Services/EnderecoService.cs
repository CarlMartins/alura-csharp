using System.Collections.Generic;
using System.Linq;
using AluraAPI.Data;
using AluraAPI.Data.Dtos.Cinema;
using AluraAPI.Data.Dtos.Endereco;
using AluraAPI.Models;
using AutoMapper;

namespace AluraAPI.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> RecuperaEnderecos()
        {
            List<Endereco> enderecoDto = new (_context.Enderecos);

            if (enderecoDto.Count > 0) return _mapper.Map<List<ReadEnderecoDto>>(enderecoDto);
            return null;
        }

        public ReadEnderecoDto RecuperaEnderecoPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null) return _mapper.Map<ReadEnderecoDto>(endereco);
            return null;
        }


        public ReadEnderecoDto AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco != null)
            {
                _mapper.Map(enderecoDto, endereco);
                _context.SaveChanges();
                return _mapper.Map<ReadEnderecoDto>(endereco);

            }

            return null;
        }

        public Endereco DeletaEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                _context.Remove(endereco);
                _context.SaveChanges();
                return endereco;
            }

            return null;
        }
    }
}