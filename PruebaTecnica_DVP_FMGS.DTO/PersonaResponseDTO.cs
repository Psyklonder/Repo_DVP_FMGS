using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_DVP_FMGS.DTO
{
    public class PersonaResponseDTO
    {
        public long Id { get; set; }
        public string Email { get; set; } = "";
        public DateTime FechaCreacion { get; set; }
        public string NombreCompleto { get; set; } = "";
        public string? Identificacion { get; set; } = "";
    }
}
