using Microsoft.EntityFrameworkCore;
using PruebaTecnica_DVP_FMGS.API.InfraEstructura.Contratos;
using PruebaTecnica_DVP_FMGS.API.InfraEstructura.Mapper;
using PruebaTecnica_DVP_FMGS.DA.Context;
using PruebaTecnica_DVP_FMGS.DTO;

namespace PruebaTecnica_DVP_FMGS.API.InfraEstructura.Repositorios
{
    public class TipoIdentificacionRepository : ITipoIdentificacionRepository
    {
        private readonly DVPContext _db;
        public TipoIdentificacionRepository(DVPContext db)
        {
            _db = db;
        }
        public async Task<TipoIdentificacionDTO> ConsultarTipoIdentificacion(int Id)
        {
            var response = await _db.TipoIdentificacion.FindAsync(Id);
            #region VALIDACIONES
            if (response == null)
            {
                throw new ArgumentException($"El tipo de identificacion con el Id= {Id} no existe en la base de datos");
            }
            #endregion
            return TipoIdentificacionMapper.MapearConsultarTipoIdentificacion(response);
        }

        public async Task<List<TipoIdentificacionDTO>> ConsultarTipoIdentificacion()
        {
            var response = await _db.TipoIdentificacion.Where(x => x.Estado).ToListAsync();

            return TipoIdentificacionMapper.MapearConsultarTipoIdentificacion(response);
        }
    }
}
