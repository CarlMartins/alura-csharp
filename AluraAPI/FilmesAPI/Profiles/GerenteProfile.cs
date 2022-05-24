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
            CreateMap<Gerente, ReadGerenteDto>();
        }
    }
}