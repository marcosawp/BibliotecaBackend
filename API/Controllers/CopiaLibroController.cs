using AppService.Interface;
using DTO.CopiaLibro;
using DTO.Libro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopiaLibroController : ControllerBase
    {
        private readonly ICopiaLibroService _service;

        public CopiaLibroController(ICopiaLibroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<CopiaLibroListDTO>>> getCopiaLibros()
        {
            var result = await _service.getCopiaLibros();
            return Ok(result);
        }
    }
}
