using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Infraestructura.Persistencia.Modelos
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }
        public string NombreEstado { get; set; }

    }
}
