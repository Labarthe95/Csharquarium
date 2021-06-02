using System;
using System.Collections.Generic;
using System.Text;

namespace Csharquarium
{
    public class Aquarium
    {
        private List<EtreVivant> _algue = new List<EtreVivant>();                                   //Liste d'algues
        private Dictionary<string, Carnivore> _carnivore = new Dictionary<string, Carnivore>();     //Liste de Carnivore
        private Dictionary<string, Herbivore> _herbivore = new Dictionary<string, Herbivore>();     //Liste de herbivore
        public List<string> _keyList = new List<string>();                                          //Liste de clés (= nom herbivore/carnivore dans                                                                                                 dictionnaire)
        public int NbPoisson                                                                        //Propriété qui donne NB Poisson
        {
            get { return _herbivore.Count +_carnivore.Count; }
        }
        public int NbAlgue                                                                          //Propriété qui donne NB Algue
        { 
            get { return _algue.Count; }
        }
        public void AddAlgue(EtreVivant algue)                                                      //Méthode pour ajouter une algue à l'aquarium
        {
            _algue.Add(algue);
        }
        public void AddCarnivore(Carnivore carnivore)                                               //Méthode pour ajouter un carnivore à l'aquarium
        {
            if (_carnivore.ContainsValue(carnivore)) throw new ContainerException();
            _carnivore.Add(carnivore.Nom, carnivore);
        }
        public void AddHerbivore(Herbivore herbivore)                                               //Méthode pour ajouter un herbivore à l'aquarium
        {
            if (_herbivore.ContainsValue(herbivore)) throw new ContainerException();
            _herbivore.Add(herbivore.Nom, herbivore);
        }
        public void FairePasserTemps()                                                              //Méthode qui fait passer un tour
        {
            Console.WriteLine($"Dans mon aquarium, il y a {NbAlgue} algue(s) et {NbPoisson} poisson(s).");
            Console.WriteLine();
            Console.WriteLine("Voici les poissons carnivores:");
            foreach (KeyValuePair<string, Carnivore> kvp in _carnivore)
            {
                Console.WriteLine($"- Ce poisson est un(e) {kvp.Value.Espèce}. Il s'appelle {kvp.Value.Nom} et est de sexe {kvp.Value.Sexe}, il a {kvp.Value.PV} PV");
            }
            Console.WriteLine();
            Console.WriteLine("Voici les poissons herbivores:");
            foreach (KeyValuePair<string, Herbivore> kvp in _herbivore)
            {
                Console.WriteLine($"- Ce poisson est un(e) {kvp.Value.Espèce}. Il s'appelle {kvp.Value.Nom} et est de sexe {kvp.Value.Sexe}, il a {kvp.Value.PV} PV");
            }
            Console.WriteLine();
            #region Manger
            #region Carnivore
            foreach (KeyValuePair <string, Carnivore> kvp in _carnivore)              //Pour chaque carnivore
            {
                Random rand = new Random();
                int regime = rand.Next(0, 2);                                         //Choisit au hasard si va manger carnivore ou herbivore
                if (regime == 0)                                                      //Mange Carnivore
                {
                    _keyList.AddRange(_carnivore.Keys);                               //Ajouter les noms (clés) de mes carnivores à ma liste de clés
                    if (NbPoisson <= 1) throw new ArgumentNullException("Il n'y a plus de poisson à manger");
                    string randomKey = _keyList[rand.Next(_keyList.Count)];           //Choisit un poisson au hasard dans ma liste de clé(nom)
                    if (randomKey == kvp.Key) throw new ArgumentException("Un poisson ne peut pas se manger lui-même");
                    if (_carnivore[randomKey].Espèce == kvp.Value.Espèce) throw new ArgumentException("Un poisson ne peut pas manger un poisson de sa propre espèce");
                    kvp.Value.Manger(randomKey, _carnivore[randomKey].Espèce);        //Appel de la méthode manger 
                    kvp.Value.PV += 5;                                                //Carnivore qui a mangé gagne 5 PV
                    _carnivore[randomKey].PV -= 4;                                    //Enlever 4 PV au poisson mangé
                    if(_carnivore[randomKey].PV <= 0) _carnivore.Remove(randomKey);   //Supprimer poisson si PV <= 0
                    _keyList.Clear();                                                 //Vider ma liste de clés (noms)
                }
                else                                                                  //Mange herbivore
                {
                    _keyList.AddRange(_herbivore.Keys);
                    if (NbPoisson <= 0) throw new ArgumentNullException("Il n'y a plus de poisson à manger");
                    string randomKey = _keyList[rand.Next(_keyList.Count)];           //Choisit un poisson au hasard dans ma liste de clé(nom)
                    kvp.Value.Manger(randomKey, _herbivore[randomKey].Espèce);        //Appel de la méthode pour manger
                    kvp.Value.PV += 5;                                                //Carnivore qui a mangé gagne 5PV
                    _herbivore[randomKey].PV -= 4;                                    //Enlever 4 PV au poisson mangé
                    if(_herbivore[randomKey].PV <= 0) _herbivore.Remove(randomKey);   //Supprimer poisson si PV <= 0
                    _keyList.Clear();                                                 //Vider ma liste de clés
                }
            }
            Console.WriteLine($"Il reste {NbPoisson} poissons dans l'aquarium.");
            Console.WriteLine();
            #endregion
            #region Herbivore
            foreach (KeyValuePair<string, Herbivore> kvp in _herbivore)               //Pour chaque herbivore
            {
                Random rand = new Random();
                if (_algue.Count <= 0) throw new ArgumentNullException("Il n'y a plus d'algue à manger");
                int index = rand.Next(0, _algue.Count);                               //Choisir une algue au hasard
                _algue[index].PV -= 2;                                                //Enlever 2 PV à algue
                if (_algue[index].PV <= 0) _algue.RemoveAt(index);                    //Supprimer algue si PV =< 0
                kvp.Value.Manger();                                                   //Appel de la méthode manger
                kvp.Value.PV += 3;                                                    //Herbivore qui a mangé gagne 3 PV
            }
            Console.WriteLine($"Il reste {_algue.Count} algue(s) dans l'aquarium.");
            Console.WriteLine();
            #endregion
            #endregion
            foreach (EtreVivant item in _algue)                                       //Pour toutes les algues
            {
                item.PV = item.PV + 1;                                                //Ajouter 1PV
            }
            foreach (KeyValuePair<string, Carnivore> kvp in _carnivore)               //Pour tous les carnivores
            {
                kvp.Value.PV = kvp.Value.PV - 1;                                      //Enlever 1PV
                if (kvp.Value.PV <= 0) _carnivore.Remove(kvp.Key);                    //Supprimer carnivore si PV <= 0
            }           
            foreach (KeyValuePair<string, Herbivore> kvp in _herbivore)               //Pour tous les herbivores
            {
                kvp.Value.PV = kvp.Value.PV - 1;                                      //Enlever 1PV
                if (kvp.Value.PV <= 0) _herbivore.Remove(kvp.Key);                    //Supprimer herbivore si PV <= 0
            }
        }

    }
}
