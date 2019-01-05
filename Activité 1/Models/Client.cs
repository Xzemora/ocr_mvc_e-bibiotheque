using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activité_1.Models
{
    public class Client
    {
        [Required, Key]
        public string Email { get; set; }
        public string Nom { get; set; }
        private List<Livre> livreEmpruntes;
        public List<Livre> LivresEmpruntes
        {
            get { return livreEmpruntes; }
            set
            {
                livreEmpruntes = value;
                foreach (Livre livre in LivresEmpruntes)
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
}