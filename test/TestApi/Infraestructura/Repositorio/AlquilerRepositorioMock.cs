using Aplicacion.Interfaz.Repositorio;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApi.Infraestructura.Repositorio
{
    public class AlquilerRepositorioMock : IAlquilerRepositorio
    {
        private readonly List<AlquilerEntidad> alquilerEntidad;
        public AlquilerRepositorioMock()
        {
            alquilerEntidad = new List<AlquilerEntidad>
            {
                new AlquilerEntidad
                {
                    Id = 1,
                    FechaAlquiler = new DateTime(2021,9,15),
                    DiasAlquiler = 7,
                    ValorAlquiler = 871878,
                    CamaraEntidadId = 1
                }
            };
        }

        public Task<List<AlquilerEntidad>> Alquileres()
        {
            throw new NotImplementedException();
        }

        public Task<List<AlquilerEntidad>> BuscarAlquilerPorId(int id)
        {
            throw new NotImplementedException();
        }


        public Task<AlquilerEntidad> CrearAlquiler(AlquilerEntidad alquilerEntidad)
        {
            throw new NotImplementedException();
        }

        Task<AlquilerEntidad> IAlquilerRepositorio.BuscarAlquilerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
