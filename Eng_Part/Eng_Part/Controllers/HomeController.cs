using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eng_Part.Security;

using Eng_Part.Models.Database;
using Eng_Part.Models.ViewModels;
using Eng_Part.Models.Entity;
using System.Net;
using System.Data.Entity; // HttpStatusCode for this 

using PagedList;


namespace Eng_Part.Controllers
{
    public class HomeController : Controller
    {
        private Eng_PartEntities db = new Eng_PartEntities(); 
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UnAuthorized()
        {

            return View();
        }

        [Authorize]
        public ActionResult Welcome() {

            return View();
        }

        [AuthorizeRole("Admin")]
        public ActionResult AdminOnly()
        {
            return View();
        }

        [Authorize]
        public ActionResult CreatePart() {

            return View();
        }

        [HttpPost]
        public ActionResult CreatePart( EngParts part )
        {
            if (ModelState.IsValid)
            {
                PartManager pm = new PartManager();
                    pm.AddPart(part);
                   // RedirectToAction("ListPart");

                    return RedirectToAction("ListPart", "Home");
            }
            else
             ModelState.AddModelError("", "* Enter required fields");
          
            return View();

        }

        [AuthorizeRole("Admin")]
        public ActionResult ListPart() {


            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //return View(db.ModuleParts.ToPagedList(pageNumber, pageSize));

            return View( db.ModuleParts.ToList());
        
        }

        [Authorize]
        public ActionResult Edit(int? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModulePart modulepart = db.ModuleParts.Find(id);
            if (modulepart == null)
            {
                return HttpNotFound();
            }
            return View(modulepart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartID,PartName,PartDesc,PartMetal,PartDimension,PartImage,PartCDate,PartMDate")] ModulePart modulepart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modulepart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListPart");
            }
            return View(modulepart);
        }



        [Authorize]
        public ActionResult Details(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModulePart modulepart = db.ModuleParts.Find(id);
            if (modulepart == null)
            {
                return HttpNotFound();
            }
            return View(modulepart);
        }

        
        public ActionResult Delete(int id)
        {
            ModulePart modulepart = db.ModuleParts.Find(id);
            db.ModuleParts.Remove(modulepart);
            db.SaveChanges();
            return RedirectToAction("ListPart");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

	}//class ends 
}