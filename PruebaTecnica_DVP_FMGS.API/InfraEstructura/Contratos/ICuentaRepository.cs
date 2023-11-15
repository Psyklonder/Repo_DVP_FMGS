using PruebaTecnica_DVP_FMGS.DTO;

namespace PruebaTecnica_DVP_FMGS.API.InfraEstructura.Contratos
{
    public interface ICuentaRepository
    {
        Task CrearCuenta(CuentaRequestDTO Request);

        Task<List<PersonaResponseDTO>> ConsultarPersonas();

        Task<PersonaResponseDTO> ValidarInicioSesion(InicioSesionDTO Request);
    }
}

