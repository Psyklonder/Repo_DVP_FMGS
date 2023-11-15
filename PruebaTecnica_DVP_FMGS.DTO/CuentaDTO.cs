using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_DVP_FMGS.DTO
{
    public class CuentaRequestDTO
    {
        //PERSONA
        [MaxLength(50, ErrorMessage = "El campo Nombres no debe exceder 50 caracteres")]
        [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
        public string Nombres { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "El campo Apellidos no debe exceder 50 caracteres")]
        [Required(ErrorMessage = "El campo Apellidos es obligatorio.")]
        public string Apellidos { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "El campo NumeroIdentificacion no debe exceder 50 caracteres")]
        [Required(ErrorMessage = "El campo NumeroIdentificacion es obligatorio.")]
        public string NumeroIdentificacion { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Correo electrónico incorrecto.")]
        [MaxLength(50, ErrorMessage = "El campo Email no debe exceder 50 caracteres")]
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El campo TipoIdentificacionId es obligatorio.")]
        public int TipoIdentificacionId { get; set; }

        //USUARIO
        [MaxLength(50, ErrorMessage = "El campo NombreUsuario no debe exceder 50 caracteres")]
        [Required(ErrorMessage = "El campo NombreUsuario es obligatorio.")]
        public string NombreUsuario { get; set; } = null!;
        [Required(ErrorMessage = "El campo Password es obligatorio.")]
        public string Password { get; set; } = null!;


    }
}
