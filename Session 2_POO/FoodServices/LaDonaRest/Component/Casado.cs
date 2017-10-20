using System;
namespace LaDonaRest.Component
{
    public abstract class Casado
    {
        public string Description { get; set; }
        public abstract string GetDescription();
        public abstract double GetCost();
    }
}
