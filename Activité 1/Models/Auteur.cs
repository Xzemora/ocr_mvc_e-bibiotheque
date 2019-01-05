using System;
using System.Collections.Generic;
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
}