using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class AlquilerEntidad
    {
        public int Id { get; set; }
        public int CamaraEntidadId { get; set; }
        public int DiasAlquiler { get; set; }
        public CamaraEntidad CamaraEntidad { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaEntrega { get { return FechaAlquiler.AddDays(DiasAlquiler); } }
        public DateTime? FechaRealEntrega { get; set; }
        public double ValorAlquiler { get; set; }
        public double? ValorMulta { get; set; }
        public int ClienteEntidadId { get; set; }
        public ClienteEntidad ClienteEntidad { get; set; }

    }
}
