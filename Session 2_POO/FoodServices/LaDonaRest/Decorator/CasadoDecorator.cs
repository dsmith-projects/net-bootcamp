using System;
using LaDonaRest.Component;

namespace LaDonaRest.Decorator
{
    public class CasadoDecorator : Casado
    {
        protected Casado _casado;
        public CasadoDecorator(Casado casado)
        {
            _casado = casado;
        }
        public override string GetDescription() => _casado.GetDescription();
        public override double GetCost() => _casado.GetCost();
    }
}
