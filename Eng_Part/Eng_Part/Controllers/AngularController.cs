using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eng_Part.Models.Database;


namespace Eng_Part.Controllers
{
    public class AngularController : Controller
    {


        private Eng_PartEntities db = new Eng_PartEntities();

        //
        // GET: /Angular/
        public ActionResult ListPart()
        {
            db.ModuleParts.ToList();
            return View();
        }
	}
}