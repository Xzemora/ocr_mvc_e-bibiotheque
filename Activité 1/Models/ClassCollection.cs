using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Activité_1.Models
{
    public class Auteur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Livre> LivresPublies { get; set; }
        
        public Auteur()
        {
            
            LivresPublies = new List<Livre>();
        }

        
        public static List<Auteur> Auteurs { get; set; }
    }

    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string dateParution;
        public DateTime DateParution
        {
            set
            {
                dateParution = value.ToString("dd MMMM yyyy",
                  CultureInfo.CreateSpecificCulture("fr-FR"));
            }
        }
        private Auteur auteur;
        public Auteur Auteur
        {
            get { return auteur; }
            set
            {
                auteur = value;
                value.LivresPublies.Add(this);
            }
        }
        public bool Disponible { get; set; }
        
        public Livre()
        {
            
            Disponible = true;
                        
           
        }
        public static List<Livre> Livres { get; set; }
    }

    public class Client
    {
        [Required, Key]
        public string Email { get; set; }
        public string Nom { get; set; }
        private List<Livre> livreEmpruntes;
        public List<Livre> LivresEmpruntes {
            get { return livreEmpruntes; }
            set
            {
                livreEmpruntes = value;
                foreach(Livre livre in LivresEmpruntes)
                {
                    livre.Disponible = false;
                }
            }
        }
        public Client()
        {
            LivresEmpruntes = new List<Livre>();
        }

        public static List<Client> Clients { get; set; }
    }





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


    public class MethodeCollection {

        private ListeCollection data;

        public MethodeCollection()
        {
            data = new ListeCollection();
        }

            
        public Livre GetLivre(int idLivre)
        {
            List<Livre> livres = Livre.Livres;
            return livres.FirstOrDefault(l => (l.Id==idLivre));
        }

        public List<Livre> GetLivres()
        {
            return Livre.Livres;
        }

        public List<Auteur> GetAuteurs()
        {
            return Auteur.Auteurs;
        }

        public Auteur GetAuteur(int idAuteur)
        {
            List<Auteur> auteurs = GetAuteurs();
            return auteurs.FirstOrDefault(a => (a.Id == idAuteur));
        }

        public List<Client> GetClients()
        {
            return Client.Clients;
        }

        public List<Livre> GetLivresAuteur(int idAuteur)
        {
            Auteur auteur = GetAuteur(idAuteur);
            return auteur.LivresPublies;
        }

        public Client Emprunteur(int idLivre)
        {

            List<Client> clients = GetClients();
            Livre livre = GetLivre(idLivre);
            return clients.FirstOrDefault(c => (c.LivresEmpruntes.Contains(livre)));

        }
      }

    
}
