using Microsoft.EntityFrameworkCore;
using PruebaTecnica_DVP_FMGS.API.InfraEstructura.Contratos;
using PruebaTecnica_DVP_FMGS.API.InfraEstructura.General;
using PruebaTecnica_DVP_FMGS.API.InfraEstructura.Mapper;
using PruebaTecnica_DVP_FMGS.DA.Context;
using PruebaTecnica_DVP_FMGS.DA.Entities;
using PruebaTecnica_DVP_FMGS.DTO;
using System.Net.Mail;

namespace PruebaTecnica_DVP_FMGS.API.InfraEstructura.Repositorios
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly DVPContext _db;
        public CuentaRepository(DVPContext db)
        {
            _db = db;
        }

        public async Task CrearCuenta(CuentaRequestDTO Request)
        {
            #region Validaciones
            //TIPO IDENTIFICACIÓN
            var tipoIdentificacion = await _db.TipoIdentificacion.FindAsync(Request.TipoIdentificacionId);
            if (tipoIdentificacion == null)
            {
                throw new ArgumentException($"El tipo de identificación suministrado no existe.");
            }

            //NOMBRE DE USUARIO-> SE DEBERÍA MANEJAR COMO UN CAMPO ÚNICO EN LA BASE DE DATOS (MEJORA)
            var existeNombreUsuario = await _db.Usuario.Where(x => x.Usuario1 == Request.NombreUsuario.Trim()).FirstOrDefaultAsync();
            if (existeNombreUsuario != null)
            {
                throw new ArgumentException($"El nombre de usuario suministrado= '{Request.NombreUsuario}' ya se encuentra en uso.");
            }
            #endregion

            var fechaActual = DateTime.Now;

            var persona = CuentaMapper.MapearPersonaRequest(Request);
            persona.FechaCreacion = fechaActual;

            var usuario = CuentaMapper.MapearUsuarioRequest(Request);
            usuario.FechaCreacion = fechaActual;

            await _db.Persona.AddAsync(persona);
            await _db.SaveChangesAsync();

            usuario.PersonaId = persona.Id;
            await _db.Usuario.AddAsync(usuario);
            await _db.SaveChangesAsync();
        }

        public async Task<List<PersonaResponseDTO>> ConsultarPersonas()
        {
            //LLAMADO AL PROCEDIMIENTO ALMACENADO
            var Response = await _db.Persona.FromSqlRaw("[dbo].[ConsultarPersonas]").ToListAsync();
            return CuentaMapper.MapearPersonaResponse(Response);
        }

        public async Task<PersonaResponseDTO> ValidarInicioSesion(InicioSesionDTO Request)
        {
            var usuario = await _db.Usuario.Include(x => x.Persona).Where(x => x.Usuario1 == Request.NombreUsuario.Trim() && x.Password == Encriptacion.Encriptar(Request.Password.Trim())).FirstOrDefaultAsync();
            if (usuario == null)
            {
                throw new ArgumentException("Nombre de usuario o contraseña incorrectos");
            }
            return CuentaMapper.MapearPersonaResponse(usuario.Persona);
        }
    }
}
