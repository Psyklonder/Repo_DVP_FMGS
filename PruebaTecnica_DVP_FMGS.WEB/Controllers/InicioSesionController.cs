using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using PruebaTecnica_DVP_FMGS.WEB.Models;
using PruebaTecnica_DVP_FMGS.DTO;

namespace PruebaTecnica_DVP_FMGS.WEB.Controllers
{
    public class InicioSesionController : Controller
    {
        private readonly IConfiguration _config;
        readonly string _apiURL = "";

        public InicioSesionController(IConfiguration config)
        {
            _config = config;
            _apiURL = _config["ApiURL:DVP"];
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Iniciar sesión";
            return View();
        }

        [HttpGet]
        public IActionResult IniciarSesion(InicioSesionDTO LogIn)
        {            
            try
            {
                string token = "";
                using (var client = new HttpClient())
                {
                    string json = JsonSerializer.Serialize(LogIn);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = client.PostAsync(_apiURL + "Cuenta/ValidarInicioSesion", data);
                    response.Wait();
                    var result = response.Result;
                    var read = result.Content.ReadAsStringAsync();
                    read.Wait();

                    if (result.IsSuccessStatusCode)
                    {
                        token = read.Result;
                        return Ok(Json(token));                        
                    }
                    else
                    {
                        return Unauthorized(read.Result);                        
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
