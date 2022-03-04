using Alura.LeilaoOnline.WebApp.Dados;
using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public LeilaoApiController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = _adminService.ConsultaLeiloes();
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _adminService.ConsultaLeilaoPorId(id);
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            _adminService.CadastraLeilao(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            if (_adminService.ConsultaLeilaoPorId(leilao.Id) == null) return NotFound();
            _adminService.ModificaLeilao(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _adminService.ConsultaLeilaoPorId(id);
            if (leilao == null) return NotFound();
            _adminService.RemoveLeilao(leilao);
            return NoContent();
        }

        [HttpPost("{id}/pregao")]
        public IActionResult EndpointIniciaPregao(int id)
        {
            var leilao = _adminService.ConsultaLeilaoPorId(id);
            if (leilao == null) return NotFound();
            _adminService.IniciaPregaoDoLeilaoComId(id);
            return Ok();
        }

        [HttpDelete("{id}/pregao")]
        public IActionResult EndpointFinalizaPregao(int id)
        {
            var leilao = _adminService.ConsultaLeilaoPorId(id);
            if (leilao == null) return NotFound();
            _adminService.FinalizaPregaoDoLeilaoComId(id);
            return Ok();
        }
    }
}
