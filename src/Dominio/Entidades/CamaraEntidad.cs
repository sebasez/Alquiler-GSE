using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class CamaraEntidad
    {
        public int Id { get; set; }
        public ModeloEntidad ModeloEntidad { get; set; }
        public MarcaEntidad MarcaEntidad { get; set; }
        public bool TieneSoporteFlash { get; set; }
        public ICollection<PeliculaEntidad> PeliculasEntidad { get; set; }
        public int Cantidad { get; set; }
        public double ValorAlquiperPorDia { get; set; }
        public EstadoEntidad EstadoEntidad { get; set; }

    }
}
