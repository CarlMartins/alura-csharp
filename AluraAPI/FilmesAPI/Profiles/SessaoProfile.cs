using AluraAPI.Data.Dtos.Sessao;
using AluraAPI.Models;
using AutoMapper;

namespace AluraAPI.Profiles
{
    public class SessaoProfile: Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                    .MapFrom(dto => dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        }
    }
}