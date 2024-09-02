using AppService.Interface;
using DTO.Libro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _service;

        public LibroController(ILibroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<LibroDTO>>> getLibros()
        {
            var result = await _service.getLibros();
            return Ok(result);
        }
    }
}
