using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_DVP_FMGS.DTO
{
    public class InicioSesionDTO
    {
        [Required(ErrorMessage = "El campo NombreUsuario es obligatorio.")]
        public string NombreUsuario { get; set; } = null!;
        [Required(ErrorMessage = "El campo Password es obligatorio.")]
        public string Password { get; set; } = null!;
    }
}
