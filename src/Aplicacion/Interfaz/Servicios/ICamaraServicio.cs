using Aplicacion.Comun.Request;
using Aplicacion.Comun.Respuestas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaz.Servicios
{
    public interface ICamaraServicio
    {
        Task<RespuestaGeneral<List<CamaraRespuesta>>> ObtenerListaCamaras();

        Task<RespuestaGeneral<List<CamaraRespuesta>>> BuscarCamarasPorNombre(string nombre);

        Task<RespuestaGeneral<CamaraRespuesta>> BuscarCamaraPorId(int id);
    }
}
