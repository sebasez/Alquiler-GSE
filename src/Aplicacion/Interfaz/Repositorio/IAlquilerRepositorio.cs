using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaz.Repositorio
{
    public interface IAlquilerRepositorio
    {
        Task<AlquilerEntidad> BuscarAlquilerPorId(int id);

        Task<AlquilerEntidad> CrearAlquiler(AlquilerEntidad alquilerEntidad);

        Task<List<AlquilerEntidad>> Alquileres();
    }
}
