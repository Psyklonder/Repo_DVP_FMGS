using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_DVP_FMGS.API.InfraEstructura.Contratos;

namespace PruebaTecnica_DVP_FMGS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TipoIdentificacionController : ControllerBase
    {
        private readonly ITipoIdentificacionRepository _tipoIdentificacionRepository;

        public TipoIdentificacionController(ITipoIdentificacionRepository tipoIdentificacionRepository)
        {

            _tipoIdentificacionRepository = tipoIdentificacionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarTipoIdentificacion(int Id)
        {
            try
            {
                return Ok(await _tipoIdentificacionRepository.ConsultarTipoIdentificacion(Id));
            }
            catch (Exception error)
            {
                return NotFound(error.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarTiposIdentificacion()
        {
            try
            {
                return Ok(await _tipoIdentificacionRepository.ConsultarTipoIdentificacion());
            }
            catch (Exception error)
            {
                return NotFound(error.Message);
            }
        }


    }
}
