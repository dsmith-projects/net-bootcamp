using System;
using LaDonaRest.Component;

namespace LaDonaRest.ConcreteComponent
{
    public class CompleteCasado : Casado
    {
        public CompleteCasado()
        {
            Description = "CASADO COMPLETO >> *** grande ***\n\t* Refresco grande\n\t* Arroz\n\t* Frijoles\n\t* Carne\n\t* Ensalada\n\t* Maduros\n";
        }

        public override double GetCost()
        {
            return 3000;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }
}
