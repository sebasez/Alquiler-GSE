using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Comun.Respuestas;
using Dominio.Entidades;
using Aplicacion.Comun.Request;

namespace Aplicacion.Comun.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AlquilerRequest, AlquilerEntidad>()
                .ForMember(dest => dest.ClienteEntidadId, source => source.MapFrom(s => s.ClienteId))
                .ReverseMap();
            CreateMap<AlquilerEntidad, AlquilerRequest>();

            CreateMap<AlquilerRespuesta, AlquilerEntidad>().ReverseMap();
            CreateMap<AlquilerEntidad, AlquilerRespuesta>().ReverseMap();

            CreateMap<CamaraEntidad, CamaraRequest>().ReverseMap();
            CreateMap<CamaraRequest, CamaraEntidad>();

            CreateMap<CamaraRespuesta, CamaraEntidad>().ReverseMap();
            CreateMap<CamaraEntidad, CamaraRespuesta>();
        }
    }
}
