using Abstracciones.Interfaces.Flujo;
using Microsoft.AspNetCore.Mvc;
using Abstracciones.Modelos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioFlujo _servicioFlujo;

        public ServicioController(IServicioFlujo servicioFlujo)
        {
            _servicioFlujo = servicioFlujo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicio>>> ListarServicios()
        {
            var servicios = await _servicioFlujo.ListarServiciosAsync();
            return Ok(servicios);
        }
    }
}
