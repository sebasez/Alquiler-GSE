using Aplicacion.Comun.Request;
using Aplicacion.Comun.Respuestas;
using Aplicacion.Interfaz.Repositorio;
using Aplicacion.Interfaz.Servicios;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Comun.Exceptions;
using Microsoft.AspNetCore.Http;
using Dominio.Entidades;

namespace Aplicacion.Servicios
{
    public class CamaraServicio : ICamaraServicio
    {
        private ICamaraRepositorio _repositorio;
        private IMapper _mapper;

        public CamaraServicio(ICamaraRepositorio repositorio, IMapper mapper)
        {
            this._repositorio = repositorio;
            this._mapper = mapper;
        }

        //public async Task<RespuestaGeneral<CamaraRespuesta>> BuscarOwnerPorId(int id)
        //{
        //    RespuestaGeneral<CamaraRespuesta> resultado = new RespuestaGeneral<CamaraRespuesta>();
        //    if(id < 0)
        //    {
        //        resultado.StatusCodeOperation = StatusCodes.Status400BadRequest;
        //        resultado.Exito = false;
        //        resultado.Mensaje = "El Id a buscar no es valido";
        //        resultado.Errores = new List<string>
        //        {
        //            "El Id no puede ser null",
        //            "El Id debe ser mayor a 0",
        //        };
        //        resultado.Datos = null;
        //        return resultado;
        //    }
        //    try
        //    {
        //        var resultadoBusqueda = await _repositorio.BuscarOwnerPorId(id);
        //        if(resultadoBusqueda == null)
        //        {
        //            resultado.StatusCodeOperation = StatusCodes.Status404NotFound;
        //            resultado.Exito = false;
        //            resultado.Mensaje = "Owner no encontrado";
        //            resultado.Errores = new List<string>
        //            {
        //                $"El owner con el Id {id} no fue encontrado"
        //            };
        //            resultado.Datos = null;
        //        }
        //        else
        //        {
        //            resultado.StatusCodeOperation = StatusCodes.Status200OK;
        //            resultado.Exito = true;
        //            resultado.Mensaje = "Owner encontrado";
        //            resultado.Errores = null;
        //            resultado.Datos = _mapper.Map<CamaraRespuesta>(resultadoBusqueda);
        //        }
        //    }
        //    catch(EntidadNoExisteException ex)
        //    {
        //        resultado.StatusCodeOperation = StatusCodes.Status400BadRequest;
        //        resultado.Exito = false;
        //        resultado.Mensaje = "Owner no encontrado";
        //        resultado.Errores = new List<string>
        //        {
        //            ex.Message
        //        };
        //    }
        //    return resultado;    
        //}

        //public async Task<RespuestaGeneral<List<CamaraRespuesta>>> BuscarOwnerPorNombre(string nombre)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<RespuestaGeneral<CamaraRespuesta>> CrearOwner(CamaraRequest ownerCrear)
        //{
        //    RespuestaGeneral<CamaraRespuesta> resultado = new RespuestaGeneral<CamaraRespuesta>();
        //    CamaraValidate validar = new CamaraValidate();
        //    var resultadoValidacion = validar.Validate(ownerCrear);
        //    if (resultadoValidacion.IsValid)
        //    {
        //        CamaraEntidad entidadCrear = _mapper.Map<CamaraEntidad>(ownerCrear);
        //        var ownerCreado = await _repositorio.CrearOwner(entidadCrear);
        //        if(ownerCreado == null)
        //        {
        //            resultado = new RespuestaGeneral<CamaraRespuesta>
        //            {
        //                Exito = false,
        //                Datos = null,
        //                Mensaje = "Ha ocurrido uno o varios errores",
        //                Errores = new List<string>()
        //                {
        //                    "No ha sido posible crear el Owner"
        //                },
        //                StatusCodeOperation = StatusCodes.Status400BadRequest
        //            };
        //        }
        //        else
        //        {
        //            resultado = new RespuestaGeneral<CamaraRespuesta>
        //            {
        //                Exito = true,
        //                Datos = _mapper.Map<CamaraRespuesta>(ownerCreado),
        //                Mensaje = "Owner creado con exito",
        //                Errores = null,
        //                StatusCodeOperation = StatusCodes.Status201Created
        //            };
        //        }
        //    }
        //    else
        //    {
        //        resultado = new RespuestaGeneral<CamaraRespuesta>
        //        {
        //            Exito = false,
        //            Datos = null,
        //            Errores = resultadoValidacion.Errors?.Select(s => s.ErrorMessage).ToList(),
        //            Mensaje = "Ha ocurrido uno o varios errores",
        //            StatusCodeOperation = StatusCodes.Status400BadRequest
        //        };
        //    }
        //    return resultado;
        //}

        public async Task<RespuestaGeneral<List<CamaraRespuesta>>> ObtenerListaCamaras()
        {
            var lista = await _repositorio.ObtenerListaCamaras();
            RespuestaGeneral<List<CamaraRespuesta>> repuesta = new RespuestaGeneral<List<CamaraRespuesta>>()
            {
                Exito = true,
                Mensaje = "Consulta correcta",
                Errores = null,
                Datos = _mapper.Map<List<CamaraRespuesta>>(lista),
                StatusCodeOperation = StatusCodes.Status200OK
            };
            return repuesta;
        }

        public async Task<RespuestaGeneral<List<CamaraRespuesta>>> BuscarCamarasPorNombre(string nombre)
        {
            var lista = await _repositorio.BuscarCamarasPorNombre(nombre);
            RespuestaGeneral<List<CamaraRespuesta>> repuesta = new RespuestaGeneral<List<CamaraRespuesta>>()
            {
                Exito = true,
                Mensaje = "Consulta correcta",
                Errores = null,
                Datos = _mapper.Map<List<CamaraRespuesta>>(lista),
                StatusCodeOperation = StatusCodes.Status200OK
            };
            return repuesta;
        }

        public async Task<RespuestaGeneral<CamaraRespuesta>> BuscarCamaraPorId(int id)
        {
            var camara = await _repositorio.BuscarCamaraPorId(id);
            RespuestaGeneral<CamaraRespuesta> repuesta = new RespuestaGeneral<CamaraRespuesta>();
            if (camara == null)
            {
                repuesta.Exito = true;
                repuesta.Mensaje = "Sin datos";
                repuesta.Errores = null;
                repuesta.Datos = null;
                repuesta.StatusCodeOperation = StatusCodes.Status404NotFound;
            }
            else
            {
                repuesta.Exito = true;
                repuesta.Mensaje = "Consulta correcta";
                repuesta.Errores = null;
                repuesta.Datos = _mapper.Map<CamaraRespuesta>(camara);
                repuesta.StatusCodeOperation = StatusCodes.Status200OK;
            }
            return repuesta;
        }
    }
}
