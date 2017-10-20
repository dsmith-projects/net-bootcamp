using System;
using LaDonaRest.Component;

namespace LaDonaRest.ConcreteComponent
{
    public class BasicCasado : Casado
    {
        public BasicCasado()
        {
            Description = "CASADO BÁSICO >> *** pequeño ***\n\n\t* Refresco\n\t* Arroz\n\t* Frijoles\n\t* Carne\n\t* Ensalada\n";
        }

        public override double GetCost()
        {
            return 2500;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }
}
