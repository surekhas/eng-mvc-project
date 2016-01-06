using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eng_Part.Models.Database;

namespace Eng_Part.Controllers
{
    public class PartsController : Controller
    {
        private Eng_PartEntities db = new Eng_PartEntities();

        // GET: /Parts/
        public ActionResult Index()
        {
            return View(db.ModuleParts.ToList());
        }

        // GET: /Parts/Details/5
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

        // GET: /Parts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Parts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PartID,PartName,PartDesc,PartMetal,PartDimension,PartImage,PartCDate,PartMDate")] ModulePart modulepart)
        {
            if (ModelState.IsValid)
            {
                db.ModuleParts.Add(modulepart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modulepart);
        }

        // GET: /Parts/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: /Parts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PartID,PartName,PartDesc,PartMetal,PartDimension,PartImage,PartCDate,PartMDate")] ModulePart modulepart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modulepart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modulepart);
        }

        // GET: /Parts/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: /Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModulePart modulepart = db.ModuleParts.Find(id);
            db.ModuleParts.Remove(modulepart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
