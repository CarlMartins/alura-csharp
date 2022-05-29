using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data;
using UsuariosAPI.Data.Requests;

namespace UsuariosAPI.Services
{
    public class LoginService
    {
        private readonly UserDbContext _context;
        private readonly SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(UserDbContext context, SignInManager<IdentityUser<int>> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            
            if (resultIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Login Falhou");
        }
    }
}