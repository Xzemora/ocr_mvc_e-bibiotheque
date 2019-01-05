using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Activité_1.Models
{
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
