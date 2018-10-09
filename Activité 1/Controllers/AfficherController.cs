using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Activité_1.Models;

namespace Activité_1.Controllers
{
    public class AfficherController : Controller
    {

        

        public ActionResult Afficher()
        {
            new ListeCollection();
            ViewBag.livres = Models.Livre.Livres;
            return View();
        }

        public ActionResult Auteurs()
        {
            new ListeCollection();
            ViewBag.auteurs = Models.Auteur.Auteurs;
            return View();
        }

        public ActionResult Auteur(int? id)
        {
            
            MethodeCollection data = new MethodeCollection();
            if (id.HasValue)
            {
                if (data.GetAuteur(id.Value) != null)
                {
                    List<Livre> livrePublie = data.GetLivresAuteur(id.Value);
                    ViewBag.livrePublie = livrePublie;
                    ViewBag.auteur = data.GetAuteur(id.Value).Nom;
                }
                else
                {
                    return View("Error");
                }
            }
            else {
                return View("Error");
            }
            return View();
        }

        public ActionResult Livre(int? id)
        {
            MethodeCollection data = new MethodeCollection();
            if (id.HasValue)
            {
                if(data.GetLivre(id.Value) != null)
                {
                    ViewBag.livre = data.GetLivre(id.Value);
                    ViewBag.date = data.GetLivre(id.Value).dateParution;
                    if (!(data.GetLivre(id.Value).Disponible))
                    {
                        ViewBag.client = data.Emprunteur(id.Value);
                    }
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("Error");
            }

            return View();
        }
    }
}