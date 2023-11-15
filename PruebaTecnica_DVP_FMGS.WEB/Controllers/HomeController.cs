using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_DVP_FMGS.WEB.Models;
using System.Diagnostics;

namespace PruebaTecnica_DVP_FMGS.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _config;
        readonly string _apiURL = "";
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _apiURL = _config["ApiURL:DVP"];
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult ConsultarPersonas()
        {
            try
            {
                using (var client = new HttpClient())
                {

                    var response = client.GetAsync(_apiURL + "Cuenta/ConsultarPersonas");
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
    }
}