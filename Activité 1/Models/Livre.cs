using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activité_1.Models
{
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
}