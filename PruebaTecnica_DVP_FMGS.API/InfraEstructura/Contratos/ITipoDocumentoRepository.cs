using PruebaTecnica_DVP_FMGS.DTO;

namespace PruebaTecnica_DVP_FMGS.API.InfraEstructura.Contratos
{
    public interface ITipoIdentificacionRepository
    {
        Task<TipoIdentificacionDTO> ConsultarTipoIdentificacion(int Id);
        Task<List<TipoIdentificacionDTO>> ConsultarTipoIdentificacion();
    }
}
