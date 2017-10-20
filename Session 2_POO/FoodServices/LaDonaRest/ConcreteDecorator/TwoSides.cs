using System;
using LaDonaRest.Component;
using LaDonaRest.Decorator;

namespace LaDonaRest.ConcreteDecorator
{
    public class TwoSides : CasadoDecorator
    {
        public TwoSides(Casado casado) : base(casado)
        {
            Description = "\t* Dos acompañamientos a elegir entre: puré de papa, picadillo, maduros, o papitas fritas\n";
        }
        public override string GetDescription() => $"{_casado.GetDescription()} {Description}";
        public override double GetCost() => _casado.GetCost() + 800;
    }
}
