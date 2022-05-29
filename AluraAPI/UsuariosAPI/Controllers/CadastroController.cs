using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Services;
using Result = FluentResults.Result;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController: ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            Result result = _cadastroService.CadastraUsuario(createDto);

            if (result.IsFailed) return StatusCode(500);
            return Ok(result.Successes);
        }
    }
}