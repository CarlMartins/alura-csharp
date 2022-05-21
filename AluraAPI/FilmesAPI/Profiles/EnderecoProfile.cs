using AluraAPI.Data.Dtos.Cinema;
using AluraAPI.Data.Dtos.Endereco;
using AluraAPI.Models;
using AutoMapper;

namespace AluraAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}