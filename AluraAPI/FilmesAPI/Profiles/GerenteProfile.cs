using System.Linq;
using AluraAPI.Data.Dtos.Gerente;
using AluraAPI.Models;
using AutoMapper;

namespace AluraAPI.Profiles
{
    public class GerenteProfile: Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                    .MapFrom(gerente => gerente.Cinemas.Select(
                        c => new {c.Id, c.Nome, c.Endereco, c.EnderecoId})));
        }
    }
}