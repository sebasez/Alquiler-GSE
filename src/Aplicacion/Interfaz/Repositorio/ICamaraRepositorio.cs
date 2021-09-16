using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Interfaz.Repositorio
{
    public interface ICamaraRepositorio
    {
        Task<List<CamaraEntidad>> ObtenerListaCamaras();
        Task<List<CamaraEntidad>> BuscarCamarasPorNombre(string nombre);
        Task<CamaraEntidad> BuscarCamaraPorId(int id);
        Task<bool> CambiarEstado(int id, int idEstado);
    }
}
