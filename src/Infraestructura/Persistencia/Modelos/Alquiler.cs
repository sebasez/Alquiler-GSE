using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Infraestructura.Persistencia.Modelos
{
    public class Alquiler
    {
        [Key]
        public int Id { get; set; }
        public int CamaraId { get; set; }
        public Camara Camara { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime? FechaRealEntrega { get; set; }
        public double ValorAlquiler { get; set; }
        public double? ValorMulta { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}
