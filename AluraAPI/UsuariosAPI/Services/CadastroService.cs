using System.Linq;
using System.Web;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;

        public CadastroService(IMapper mapper, 
            UserManager<IdentityUser<int>> userManager, 
            EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
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
                var encodedActivationCode = HttpUtility.UrlEncode(activationCode);
                _emailService.EnviarEmail(new [] { identityUser.Email }, 
                    "Link de ativação", 
                    identityResult.Id, 
                    encodedActivationCode);
                return Result.Ok().WithSuccess(encodedActivationCode);
            }
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(user => user.Id == request.UsuarioId);

            var encodedActivationCode = HttpUtility.UrlEncode(request.CodigoAtivacao);

            var identityResult = _userManager
                .ConfirmEmailAsync(identityUser, encodedActivationCode).Result;

            if (identityResult.Succeeded) return Result.Ok();
            
            return Result.Fail("Falha ao ativar a conta do usuario");
        }
    }
}