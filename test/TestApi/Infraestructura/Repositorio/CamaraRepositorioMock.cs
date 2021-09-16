using Aplicacion.Interfaz.Repositorio;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Infraestructura.Repositorio
{
    public class CamaraRepositorioMock : ICamaraRepositorio
    {
        private readonly List<CamaraEntidad> camaraEntidad;

        public CamaraRepositorioMock()
        {
            camaraEntidad = new List<CamaraEntidad>()
            {
                new CamaraEntidad
                {
                    Id = 1,
                    TieneSoporteFlash = true,
                    Cantidad = 2,
                    ValorAlquiperPorDia = 12000,
                }
            };
        }

        public async Task<CamaraEntidad> BuscarCamaraPorId(int id)
        {
            var camara = camaraEntidad.FirstOrDefault(w => w.Id == id);
            bool camaraResult = await Task.FromResult(result: camara != null);
            return camaraResult ? camara : null;
        }

        public Task<List<CamaraEntidad>> BuscarCamarasPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CambiarEstado(int id, int idEstado)
        {
            throw new NotImplementedException();
        }

        public Task<List<CamaraEntidad>> ObtenerListaCamaras()
        {
            throw new NotImplementedException();
        }
    }
}
