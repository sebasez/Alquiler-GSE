using AutoMapper;
using Dominio.Entidades;
using Infraestructura.Persistencia.Modelos;

namespace Infraestructura.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Alquiler, AlquilerEntidad>()
                .ForMember(dest => dest.Id, source => source.MapFrom(s => s.Id))
                .ForMember(dest => dest.CamaraEntidadId, source => source.MapFrom(s => s.CamaraId))
                .ForMember(dest => dest.ClienteEntidadId, source => source.MapFrom(s => s.ClienteId))
                .ForMember(dest => dest.FechaEntrega, source => source.MapFrom(s => s.FechaEntrega))
                .ReverseMap();

            CreateMap<Camara, CamaraEntidad>()
                .ForMember(dest => dest.Id, source => source.MapFrom(s => s.Id))
                .ReverseMap();

            CreateMap<Cliente, ClienteEntidad>()
                .ForMember(dest => dest.Id, source => source.MapFrom(s => s.Id))
                .ReverseMap();

            CreateMap<Estado, EstadoEntidad>()
               .ForMember(dest => dest.Id, source => source.MapFrom(s => s.Id))
               .ReverseMap();

            CreateMap<Marca, MarcaEntidad>()
               .ForMember(dest => dest.Id, source => source.MapFrom(s => s.Id))
               .ReverseMap();

            CreateMap<Modelo, ModeloEntidad>()
               .ForMember(dest => dest.Id, source => source.MapFrom(s => s.Id))
               .ReverseMap();

            CreateMap<Pelicula, PeliculaEntidad>()
               .ForMember(dest => dest.Id, source => source.MapFrom(s => s.Id))
               .ReverseMap();
        }
    }
}
