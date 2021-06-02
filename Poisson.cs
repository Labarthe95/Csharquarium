using System;
using System.Collections.Generic;
using System.Text;

namespace Csharquarium
{
    public class Poisson : EtreVivant 
    {
        public string Nom { get; private set; }
        public string Sexe { get; private set; }
        public Poisson (string nom, string sexe)
        {
            Nom = nom;
            Sexe = sexe;
        }
    }
}
