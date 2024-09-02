using AppService.Interface;
using DTO.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> getUsuarios()
        {
            var result = await _service.getUsuarios();
            return Ok(result);
        }
    }
}
