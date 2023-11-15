using PruebaTecnica_DVP_FMGS.API.InfraEstructura.General;
using PruebaTecnica_DVP_FMGS.DA.Entities;
using PruebaTecnica_DVP_FMGS.DTO;

namespace PruebaTecnica_DVP_FMGS.API.InfraEstructura.Mapper
{
    public static class CuentaMapper
    {
        public static Persona MapearPersonaRequest(CuentaRequestDTO Request)
        {
            return new Persona
            {
                Nombres = Request.Nombres.Trim(),
                Apellidos = Request.Apellidos.Trim(),
                NumeroIdentificacion = Request.NumeroIdentificacion.Trim(),
                Email = Request.Email.Trim(),
                TipoIdentificacionId = Request.TipoIdentificacionId,
                Estado = true
            };
        }

        public static Usuario MapearUsuarioRequest(CuentaRequestDTO Request)
        {
            return new Usuario
            {
                Usuario1 = Request.NombreUsuario.Trim(),
                Password = Encriptacion.Encriptar(Request.Password.Trim()),
                Estado = true
            };
        }

        public static List<PersonaResponseDTO> MapearPersonaResponse(List<Persona> Response)
        {
            var response = new List<PersonaResponseDTO>();
            foreach (var item in Response)
            {
                response.Add(new PersonaResponseDTO
                {
                    Id = item.Id,
                    Email = item.Email,
                    FechaCreacion = item.FechaCreacion,
                    NombreCompleto = item.NombreCompleto,
                    Identificacion = item.Identificacion
                });
            }
            return response;
        }

        public static PersonaResponseDTO MapearPersonaResponse(Persona Response)
        {
            var response = new PersonaResponseDTO
            {
                Id = Response.Id,
                Email = Response.Email,
                FechaCreacion = Response.FechaCreacion,
                NombreCompleto = Response.NombreCompleto,
                Identificacion = Response.Identificacion
            };
            return response;
        }
    }
}
