using Aplicacion.Comun.Request;
using FluentValidation;

namespace Aplicacion.Servicios
{
    public class AlquilerValidate : AbstractValidator<AlquilerRequest>
    {
        public AlquilerValidate()
        {
            RuleFor(x => x.CamaraId).GreaterThan(0).WithMessage("Debe tener id de camara");
            RuleFor(x => x.ClienteId).GreaterThan(0).WithMessage("Debe tener id de cliente");
            RuleFor(x => x.CamaraId).NotEmpty().WithMessage("No puede estar vacio"); 
            RuleFor(x => x.ClienteId).NotEmpty().WithMessage("No puede estar vacio");
            RuleFor(x => x.DiasAlquiler).GreaterThan(0).WithMessage("Debe tener id de camara");
        }
    }
}
