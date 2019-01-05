using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activité_1.Models
{
    public class ListeCollection
    {
        public ListeCollection()
        {
            Auteur.Auteurs = new List<Auteur>
            {
                new Auteur { Id = 1, Nom = "Auteur1" },
                new Auteur { Id = 2, Nom = "Auteur2" },
                new Auteur { Id = 3, Nom = "Auteur3" }
            };

            Livre.Livres = new List<Livre>
            {
                new Livre { Id = 1,Titre = "Livre1", DateParution = new DateTime(2018, 01, 01), Auteur = Auteur.Auteurs[0] },
                new Livre { Id = 2,Titre = "Livre2", DateParution = new DateTime(2018, 02, 01), Auteur = Auteur.Auteurs[1] },
                new Livre { Id = 3,Titre = "Livre3", DateParution = new DateTime(2017, 06, 01), Auteur = Auteur.Auteurs[0] },
                new Livre { Id = 4,Titre = "Livre4", DateParution = new DateTime(2016, 03, 15), Auteur = Auteur.Auteurs[2] },
                new Livre { Id = 5,Titre = "Livre5", DateParution = new DateTime(2011, 12, 24), Auteur = Auteur.Auteurs[1] }
            };

            Client.Clients = new List<Client>
            {
                new Client { Email = "client1@domaine.com", Nom = "Client1", LivresEmpruntes = new List<Livre>() { Livre.Livres[1], Livre.Livres[3] }},
                new Client { Email = "client2@domaine.com", Nom = "Client2", LivresEmpruntes = new List<Livre>(){Livre.Livres[4] } }
            };

        }
    }
}