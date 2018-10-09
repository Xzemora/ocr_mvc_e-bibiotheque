using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Activité_1.Models;

namespace Activité_1.Controllers
{
    public class RechercherController : Controller
    {
        // GET: Rechercher
        public ActionResult Livre(string id)
        {
            if (id != null)
            {
                MethodeCollection data = new MethodeCollection();
                List<Livre> livres = data.GetLivres();
                string recherche = id.ToLower();
                Regex regex = new Regex(@""+recherche+"");
                if (recherche != "")
                {
                    ViewBag.result = livres.Where(l => l.Titre.IndexOf(recherche, StringComparison.CurrentCultureIgnoreCase) >=0 || regex.IsMatch(l.Auteur.Nom.ToLower())).ToArray();
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