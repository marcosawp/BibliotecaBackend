using AppService.Interface;
using DTO.CopiaLibro;
using DTO.Libro;
using DTO.SolicitudPrestamo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudPrestamoController : ControllerBase
    {
        private readonly ISolicitudPrestamoService _service;

        public SolicitudPrestamoController(ISolicitudPrestamoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> InsertarSolicitudPrestamo([FromBody] SolicitudPrestamoCreateDTO request)
        {
            var result = await _service.InsertarSolicitudPrestamo(request.IdUsuario, request.IdCopiaLibro);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<SolicitudPrestamoListDTO>>> getSolicitudPrestamo()
        {
            var result = await _service.getSolicitudPrestamo();
            return Ok(result);
        }
    }
}
