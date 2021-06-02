using System;

namespace Csharquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Bienvenue dans le programme de simulation de l'aquarium de M. Shingshan!");
                #region Remplir l'aquarium de poissons et algues
                #region Achat de poissons carnivores
                Carnivore c1 = new Carnivore("Carnivore1", "M", PoissonCarnivore.Poisson_Clown);
                Carnivore c2 = new Carnivore("Carnivore2", "F", PoissonCarnivore.Poisson_Clown);
                Carnivore c3 = new Carnivore("Carnivore3", "M", PoissonCarnivore.Merou);
                Carnivore c4 = new Carnivore("Carnivore4", "F", PoissonCarnivore.Merou);
                Carnivore c5 = new Carnivore("Carnivore5", "M", PoissonCarnivore.Thon);
                Carnivore c6 = new Carnivore("Carnivore6", "F", PoissonCarnivore.Thon);
                #endregion
                #region Achat de poissons herbivores
                Herbivore h1 = new Herbivore("Herbivore1", "F", PoissonHerbivore.Carpe);
                Herbivore h2 = new Herbivore("Herbivore2", "M", PoissonHerbivore.Carpe);
                Herbivore h3 = new Herbivore("Herbivore3", "F", PoissonHerbivore.Bar);
                Herbivore h4 = new Herbivore("Herbivore4", "M", PoissonHerbivore.Bar);
                Herbivore h5 = new Herbivore("Herbivore5", "F", PoissonHerbivore.Sole);
                Herbivore h6 = new Herbivore("Herbivore6", "M", PoissonHerbivore.Sole);
                #endregion
                #region Achat d'algues
                EtreVivant algue1 = new EtreVivant();
                EtreVivant algue2 = new EtreVivant();
                EtreVivant algue3 = new EtreVivant();
                EtreVivant algue4 = new EtreVivant();
                EtreVivant algue5 = new EtreVivant();
                EtreVivant algue6 = new EtreVivant();
                EtreVivant algue7 = new EtreVivant();
                EtreVivant algue8 = new EtreVivant();
                EtreVivant algue9 = new EtreVivant();
                EtreVivant algue10 = new EtreVivant();
                #endregion
                #region Mettre les poissons et algues dans l'aquarium
                Aquarium a = new Aquarium();
                a.AddAlgue(algue1);
                a.AddAlgue(algue2);
                a.AddAlgue(algue3);
                a.AddAlgue(algue4);
                a.AddAlgue(algue5);
                a.AddAlgue(algue6);
                a.AddAlgue(algue7);
                a.AddAlgue(algue8);
                a.AddAlgue(algue9);
                a.AddAlgue(algue10);
                a.AddCarnivore(c1);
                a.AddCarnivore(c2);
                a.AddCarnivore(c3);
                a.AddCarnivore(c4);
                a.AddCarnivore(c5);
                a.AddCarnivore(c6);
                a.AddHerbivore(h1);
                a.AddHerbivore(h2);
                a.AddHerbivore(h3);
                a.AddHerbivore(h4);
                a.AddHerbivore(h5);
                a.AddHerbivore(h6);
                #endregion
                #endregion
                #region Faire passer un tour
                string reponse;
                do
                {
                    Console.WriteLine("Voulez-vous faire passer un tour? oui/non");
                    reponse = Console.ReadLine();
                    while (reponse != "oui" && reponse != "non")
                    {
                        Console.WriteLine("Erreur. Veuillez réponse par oui ou non. Voulez-vous faire passer un tour à votre aquarium? oui/non");
                        reponse = Console.ReadLine();
                        Console.WriteLine();
                    }
                    Console.Clear();
                    a.FairePasserTemps();
                }
                while (reponse == "oui");
                Console.WriteLine("FIN du programme");
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
    }
}
