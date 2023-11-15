using System;
using System.Collections.Generic;

namespace PruebaTecnica_DVP_FMGS.DA.Entities
{
    public partial class Usuario
    {
        public long Id { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
        public long PersonaId { get; set; }

        public virtual Persona Persona { get; set; } = null!;
    }
}
