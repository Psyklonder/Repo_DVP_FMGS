using System;
using System.Collections.Generic;

namespace PruebaTecnica_DVP_FMGS.DA.Entities
{
    public partial class TipoIdentificacion
    {
        public TipoIdentificacion()
        {
            Persona = new HashSet<Persona>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}
