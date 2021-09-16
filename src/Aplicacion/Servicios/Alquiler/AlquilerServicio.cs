using Aplicacion.Comun.Request;
using Aplicacion.Comun.Respuestas;
using Aplicacion.Interfaz.Repositorio;
using Aplicacion.Interfaz.Servicios;
using AutoMapper;
using Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class AlquilerServicio : IAlquilerServicio
    {
        private readonly IAlquilerRepositorio _alquilerRepositorio;
        private readonly AlquilerValidate _validationRules;
        private readonly ICamaraRepositorio _camaraRepositorio;
        private readonly IMapper _mapper;

        public AlquilerServicio(IAlquilerRepositorio alquilerRepositorio, ICamaraRepositorio  camaraRepositorio, AlquilerValidate validationRules, IMapper mapper)
        {
            this._alquilerRepositorio = alquilerRepositorio;
            this._camaraRepositorio = camaraRepositorio;
            this._validationRules = validationRules;
            this._mapper = mapper;
        }

        public async Task<RespuestaGeneral<AlquilerRespuesta>> BuscarAlquilerPorId(int id)
        {
            RespuestaGeneral<AlquilerRespuesta> resultado = new();
            if (id < 0)
            {
                resultado.StatusCodeOperation = StatusCodes.Status400BadRequest;
                resultado.Exito = false;
                resultado.Mensaje = "El Id del alquiler no es valido";
                resultado.Errores = new List<string>
                    {
                        "El Id no puede ser null",
                        "El Id debe corresponder a un Owner valido",
                    };
                resultado.Datos = null;
                return resultado;
            }
            try
            {
                var existeAlquiler = await _alquilerRepositorio.BuscarAlquilerPorId(id: id);
                if (existeAlquiler == null)
                {
                    return new RespuestaGeneral<AlquilerRespuesta>
                    {
                        Exito = false,
                        Mensaje = $"El alquiler no existe",
                        Errores = null,
                        Datos = null,
                        StatusCodeOperation = StatusCodes.Status400BadRequest
                    };
                }
                resultado.StatusCodeOperation = StatusCodes.Status200OK;
                resultado.Exito = true;
                resultado.Mensaje = "Consulta exitosa";
                resultado.Errores = null;
                resultado.Datos = _mapper.Map<AlquilerRespuesta>(existeAlquiler);
            }
            catch (Exception ex)
            {
                resultado.StatusCodeOperation = StatusCodes.Status400BadRequest;
                resultado.Exito = false;
                resultado.Mensaje = "Ha ocurrido un problema al consultar las properties";
                resultado.Errores = new List<string>
                    {
                        ex.Message
                    };
            }
            return resultado;
        }

        public async Task<RespuestaGeneral<AlquilerRespuesta>> CrearAlquiler(AlquilerRequest alquiler)
        {
            RespuestaGeneral<AlquilerRespuesta> resultado = new();

            var resultadoValidacion = this._validationRules.Validate(alquiler);
            if (resultadoValidacion.IsValid)
            {
                var camara = await this._camaraRepositorio.BuscarCamaraPorId(alquiler.CamaraId);
                if (camara == null)
                {
                    return new RespuestaGeneral<AlquilerRespuesta>
                    {
                        Exito = false,
                        Mensaje = $"La camara no existe no existe",
                        Errores = null,
                        Datos = null,
                        StatusCodeOperation = StatusCodes.Status400BadRequest
                    };
                }
                AlquilerEntidad entidadCrear = _mapper.Map<AlquilerEntidad>(alquiler);
                entidadCrear.FechaAlquiler = DateTime.Now;
                entidadCrear.ValorAlquiler = camara.ValorAlquiperPorDia * entidadCrear.DiasAlquiler;
                entidadCrear.CamaraEntidadId = camara.Id;
                var alquilerCreado = await _alquilerRepositorio.CrearAlquiler(entidadCrear);
                if (alquilerCreado == null)
                {
                    resultado = new RespuestaGeneral<AlquilerRespuesta>
                    {
                        Exito = false,
                        Datos = null,
                        Mensaje = "Ha ocurrido uno o varios errores",
                        Errores = new List<string>()
                            {
                                "No ha sido posible crear la Property"
                            },
                        StatusCodeOperation = StatusCodes.Status400BadRequest
                    };
                }
                else
                {
                    _ = _camaraRepositorio.CambiarEstado(camara.Id, 2);
                    resultado = new RespuestaGeneral<AlquilerRespuesta>
                    {
                        Exito = true,
                        Mensaje = "Property creada con exito",
                        Datos = _mapper.Map<AlquilerRespuesta>(alquilerCreado),
                        Errores = null,
                        StatusCodeOperation = StatusCodes.Status201Created
                    };
                }
            }
            else
            {
                resultado = new RespuestaGeneral<AlquilerRespuesta>
                {
                    Exito = false,
                    Datos = null,
                    Errores = resultadoValidacion.Errors?.Select(s => s.ErrorMessage).ToList(),
                    Mensaje = "Ha ocurrido uno o varios errores",
                    StatusCodeOperation = StatusCodes.Status400BadRequest
                };
            }
            return resultado;
        }

        public async Task<RespuestaGeneral<List<AlquilerRespuesta>>> TodosAlquileres()
        {
            RespuestaGeneral<List<AlquilerRespuesta>> resultado = new();

            var existeAlquiler = await _alquilerRepositorio.Alquileres();
            if (existeAlquiler == null)
            {
                return new RespuestaGeneral<List<AlquilerRespuesta>>
                {
                    Exito = false,
                    Mensaje = $"No existen alquileres",
                    Errores = null,
                    Datos = null,
                    StatusCodeOperation = StatusCodes.Status400BadRequest
                };
            }
            resultado.StatusCodeOperation = StatusCodes.Status200OK;
            resultado.Exito = true;
            resultado.Mensaje = "Consulta exitosa";
            resultado.Errores = null;
            resultado.Datos = _mapper.Map<List<AlquilerRespuesta>>(existeAlquiler);
            return resultado;
        }
    }
}
