using System;
using LaDonaRest.Component;
using LaDonaRest.Decorator;

namespace LaDonaRest.ConcreteDecorator
{
    public class Starter : CasadoDecorator
    {
        public Starter(Casado casado) : base(casado)
        {
            Description = "\t* Entradita: garbanzos con cerdo, sopa negra, caldo de pollo con verduras, sopa de tomate\n";
        }
        public override string GetDescription() => $"{_casado.GetDescription()} {Description}";
        public override double GetCost() => _casado.GetCost() + 900;
    }
}
