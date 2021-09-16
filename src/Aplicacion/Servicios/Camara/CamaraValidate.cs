using Aplicacion.Comun.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class CamaraValidate : AbstractValidator<CamaraRequest>
    {
        public CamaraValidate()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Birthday).NotEmpty();
        }
    }
}
