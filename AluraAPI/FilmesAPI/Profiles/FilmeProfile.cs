using AluraAPI.Data.Dtos;
using AluraAPI.Models;
using AutoMapper;

namespace AluraAPI.Profiles
{
    public class FilmeProfile: Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}