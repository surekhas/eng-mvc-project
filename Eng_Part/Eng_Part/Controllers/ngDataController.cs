using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Eng_Part.Models.Database;

namespace Eng_Part.Controllers
{
    public class ngDataController : ApiController
    {
        private Eng_PartEntities db = new Eng_PartEntities();

        // GET api/ngData
        public IQueryable<ModulePart> GetModuleParts()
        {
            return db.ModuleParts;
        }

        // GET api/ngData/5
        [ResponseType(typeof(ModulePart))]
        public IHttpActionResult GetModulePart(int id)
        {
            ModulePart modulepart = db.ModuleParts.Find(id);
            if (modulepart == null)
            {
                return NotFound();
            }

            return Ok(modulepart);
        }

        // PUT api/ngData/5
        public IHttpActionResult PutModulePart(int id, ModulePart modulepart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modulepart.PartID)
            {
                return BadRequest();
            }

            db.Entry(modulepart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModulePartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/ngData
        [ResponseType(typeof(ModulePart))]
        public IHttpActionResult PostModulePart(ModulePart modulepart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ModuleParts.Add(modulepart);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = modulepart.PartID }, modulepart);
        }

        // DELETE api/ngData/5
        [ResponseType(typeof(ModulePart))]
        public IHttpActionResult DeleteModulePart(int id)
        {
            ModulePart modulepart = db.ModuleParts.Find(id);
            if (modulepart == null)
            {
                return NotFound();
            }

            db.ModuleParts.Remove(modulepart);
            db.SaveChanges();

            return Ok(modulepart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModulePartExists(int id)
        {
            return db.ModuleParts.Count(e => e.PartID == id) > 0;
        }
    }
}