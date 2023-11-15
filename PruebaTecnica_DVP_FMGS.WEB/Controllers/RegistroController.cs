using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_DVP_FMGS.DTO;
using System.Text.Json;
using System.Text;

namespace PruebaTecnica_DVP_FMGS.WEB.Controllers
{
    public class RegistroController : Controller
    {
        private readonly IConfiguration _config;
        readonly string _apiURL = "";

        public RegistroController(IConfiguration config)
        {
            _config = config;
            _apiURL = _config["ApiURL:DVP"];
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObtenerTiposIdentificacion()
        {
            try
            {   
                using (var client = new HttpClient())
                {
                    
                    var response = client.GetAsync(_apiURL + "TipoIdentificacion/ConsultarTiposIdentificacion");
                    response.Wait();
                    var result = response.Result;
                    var read = result.Content.ReadAsStringAsync();
                    read.Wait();

                    if (result.IsSuccessStatusCode)
                    {                        
                        return Ok(read.Result);
                    }
                    else
                    {
                        return BadRequest(read.Result);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult RegistrarUsuario(CuentaRequestDTO Request)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string json = JsonSerializer.Serialize(Request);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = client.PostAsync(_apiURL + "Cuenta/CrearCuenta", data);
                    response.Wait();
                    var result = response.Result;
                    var read = result.Content.ReadAsStringAsync();
                    read.Wait();

                    if (result.IsSuccessStatusCode)
                    {
                        return Ok(Json(read.Result));
                    }
                    else
                    {
                        return BadRequest(read.Result);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
