using System;

namespace Aplicacion.Comun.Respuestas
{
    public class AlquilerRespuesta
    {
        public int Id { get; set; }
        public CamaraRespuesta CamaraRespuesta { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime? FechaRealEntrega { get; set; }
        public double ValorAlquiler { get; set; }
        public double? ValorMulta { get; set; }  
    }
}
