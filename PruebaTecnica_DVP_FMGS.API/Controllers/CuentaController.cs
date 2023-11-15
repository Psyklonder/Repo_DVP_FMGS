using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_DVP_FMGS.API.InfraEstructura.Contratos;
using PruebaTecnica_DVP_FMGS.DTO;

namespace PruebaTecnica_DVP_FMGS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {

        private readonly ICuentaRepository _repository;

        public CuentaController(ICuentaRepository Repository)
        {
            _repository = Repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCuenta([FromBody]CuentaRequestDTO Request)
        {
            try
            {
                await _repository.CrearCuenta(Request);
                return Ok("Cuenta creada satisfactoriamente");
            }
            catch (Exception error)
            {
                return NotFound(error.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarPersonas()
        {
            try
            {                
                return Ok(await _repository.ConsultarPersonas());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ValidarInicioSesion([FromBody] InicioSesionDTO Request)
        {
            try
            {
                return Ok(await _repository.ValidarInicioSesion(Request));
            }
            catch (Exception error)
            {
                return Unauthorized(error.Message);
            }
        }
    }
}
