using System;
using LaDonaRest.Component;
using LaDonaRest.Decorator;

namespace LaDonaRest.ConcreteDecorator
{
    public class OneSide : CasadoDecorator
    {
        public OneSide(Casado casado) : base(casado)
        {
            Description = "\t* Un acompañamientos a elegir entre: puré de papa, picadillo, maduros, o papitas fritas\n";
        }
        public override string GetDescription() => $"{_casado.GetDescription()} {Description}";
        public override double GetCost() => _casado.GetCost() + 400;
    }
}
