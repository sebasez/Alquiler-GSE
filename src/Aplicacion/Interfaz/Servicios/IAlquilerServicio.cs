using Aplicacion.Comun.Request;
using Aplicacion.Comun.Respuestas;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaz.Servicios
{
    public interface IAlquilerServicio
    {
        Task<RespuestaGeneral<List<AlquilerRespuesta>>> TodosAlquileres();
        Task<RespuestaGeneral<AlquilerRespuesta>> BuscarAlquilerPorId(int id);
        Task<RespuestaGeneral<AlquilerRespuesta>> CrearAlquiler(AlquilerRequest alquiler);

    }
}
