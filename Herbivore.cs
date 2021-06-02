using System;
using System.Collections.Generic;
using System.Text;

namespace Csharquarium
{
    public class Herbivore : Poisson
    {
        public PoissonHerbivore Espèce { get; set; }

        public Herbivore (string nom, string sexe, PoissonHerbivore espèce) : base(nom, sexe)
        {
            Espèce = espèce;
        }
        public void Manger()
        {
            Console.WriteLine($"Le poisson {this.Nom} qui est un {this.Espèce} a mangé une algue");
        }
    }
}
