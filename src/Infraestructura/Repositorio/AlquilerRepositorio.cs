using Aplicacion.Interfaz.Repositorio;
using AutoMapper;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Infraestructura.Persistencia.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructura.Repositorio
{
    public class AlquilerRepositorio : IAlquilerRepositorio
    {
        private readonly AlquilerContext _contexto;
        private readonly IMapper _mapper;
        public AlquilerRepositorio(AlquilerContext contexto, IMapper mapper)
        {
            this._contexto = contexto;
            this._mapper = mapper;
        }
        public async Task<List<AlquilerEntidad>> Alquileres()
        {
            List<Alquiler> alquileres = await _contexto.Alquiler.ToListAsync();
            return _mapper.Map<List<AlquilerEntidad>>(alquileres);
        }
        public async Task<AlquilerEntidad> BuscarAlquilerPorId(int id)
        {
            Alquiler alquiler = await _contexto.Alquiler.FindAsync(id);
            return _mapper.Map<AlquilerEntidad>(alquiler);
        }

        public async Task<AlquilerEntidad> CrearAlquiler(AlquilerEntidad alquilerEntidad)
        {
            Alquiler alquilerDB = _mapper.Map<Alquiler>(alquilerEntidad);
            _contexto.Alquiler.Add(alquilerDB);
            var resultado =  await _contexto.SaveChangesAsync();
            if (resultado > 0)
            {
                return _mapper.Map<AlquilerEntidad>(alquilerDB);
            }
            else
            {
                alquilerDB = null;
                return _mapper.Map<AlquilerEntidad>(alquilerDB);
            }
        }
    }
}
