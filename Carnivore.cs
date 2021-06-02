using System;
using System.Collections.Generic;
using System.Text;

namespace Csharquarium
{
    public class Carnivore : Poisson
    {
        public PoissonCarnivore Espèce { get; set; }

        public Carnivore (string nom, string sexe, PoissonCarnivore espèce): base(nom, sexe)
        {
            Espèce = espèce;
        }
        public void Manger(string PoissonMange, PoissonCarnivore espèce)
        {
            Console.WriteLine($"Le poisson {this.Nom} qui est un(e) {this.Espèce} a mangé {PoissonMange} qui était un(e) {espèce}");
        }
        public void Manger(string PoissonMange, PoissonHerbivore espèce)
        {
            Console.WriteLine($"Le poisson {this.Nom} qui est un(e) {this.Espèce} a mangé {PoissonMange} qui était un(e) {espèce}");
        }
    }
}
