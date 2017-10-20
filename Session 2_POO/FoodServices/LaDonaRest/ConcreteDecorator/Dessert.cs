using System;
using LaDonaRest.Component;
using LaDonaRest.Decorator;

namespace LaDonaRest.ConcreteDecorator
{
    public class Dessert : CasadoDecorator
    {
        public Dessert(Casado casado) : base(casado)
        {
            Description = "\t* Postre: flan, arroz con leche, helados o cajeta\n";
        }
        public override string GetDescription() => $"{_casado.GetDescription()} {Description}";
        public override double GetCost() => _casado.GetCost() + 600;
    }
}
