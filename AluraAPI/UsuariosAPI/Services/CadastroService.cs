using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(usuario);
            var identityResult = _userManager
                .CreateAsync(identityUser, createDto.Password);

            if (identityResult.Result.Succeeded)
            {
                var activationCode = _userManager
                    .GenerateEmailConfirmationTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(activationCode);
            }
            return Result.Fail("Falha ao cadastrar usuário");
        }
    }
}