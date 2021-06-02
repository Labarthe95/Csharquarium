using System;
using System.Collections.Generic;
using System.Text;

namespace Csharquarium
{
    public class ContainerException : Exception
    {
        public string MessageException { get; set; }
        public ContainerException()
        {
            MessageException = "Le dictionnaire de carnivore contient déjà ce carnivore";
        }
    }
}
