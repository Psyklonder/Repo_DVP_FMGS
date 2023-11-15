using PruebaTecnica_DVP_FMGS.DA.Entities;
using PruebaTecnica_DVP_FMGS.DTO;

namespace PruebaTecnica_DVP_FMGS.API.InfraEstructura.Mapper
{
    public static class TipoIdentificacionMapper
    {
        public static TipoIdentificacionDTO MapearConsultarTipoIdentificacion(TipoIdentificacion Response)
        {
            return new TipoIdentificacionDTO
            {
                Id = Response.Id,
                Nombre = Response.Nombre,
                Descripcion = Response.Descripcion,
                Estado = Response.Estado
            };
        }

        public static List<TipoIdentificacionDTO> MapearConsultarTipoIdentificacion(List<TipoIdentificacion> Response)
        {
            var response = new List<TipoIdentificacionDTO>();
            foreach (var tipo in Response)
            {
                response.Add(new TipoIdentificacionDTO
                {
                    Id = tipo.Id,
                    Nombre = tipo.Nombre,
                    Descripcion = tipo.Descripcion,
                    Estado = tipo.Estado
                });
            }
            return response;
        }
    }
}
