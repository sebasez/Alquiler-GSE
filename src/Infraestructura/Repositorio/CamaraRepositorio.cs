using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaz.Repositorio;
using AutoMapper;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Infraestructura.Persistencia.Modelos;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Comun.Exceptions;

namespace Infraestructura.Repositorio
{
    public class CamaraRepositorio : ICamaraRepositorio
    {
        private readonly AlquilerContext _contexto;
        private readonly IMapper _mapper;

        public CamaraRepositorio(AlquilerContext contexto,IMapper mapper)
        {
            this._contexto = contexto;
            this._mapper = mapper;
        }


        public async Task<List<CamaraEntidad>> ObtenerListaCamaras()
        {
            List<Camara> camaras = await _contexto.Camara.ToListAsync();
            return _mapper.Map<List<CamaraEntidad>>(camaras);
        }

        public async Task<List<CamaraEntidad>> BuscarCamarasPorNombre(string nombre)
        {
            List<Camara> camaras = await _contexto.Camara.Include(i=>i.Marca).Where(w=>w.Marca.Nombre.Contains(nombre)).ToListAsync();
            return _mapper.Map<List<CamaraEntidad>>(camaras);
        }

        public async Task<CamaraEntidad> BuscarCamaraPorId(int id)
        {
            Camara camara = await _contexto.Camara.FindAsync(id);
            return _mapper.Map<CamaraEntidad>(camara);
        }

        public async Task<bool> CambiarEstado(int id, int idEstado)
        {
            Camara camara = await _contexto.Camara.FindAsync(id);
            camara.EstadoId = idEstado;
            var result = await _contexto.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }
    }
}
