using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rejestr_PawełPieniak.Models;

namespace Rejestr_PawełPieniak.Controllers
{
    public class OsobyZaginionesController : Controller
    {
        private PersonDataEntities db = new PersonDataEntities();

        

        // GET: OsobyZaginiones
        public PartialViewResult GetPersonDate(String selectedPersons = "All")
        {
            IEnumerable<OsobyZaginione> data = db.OsobyZaginione;
            if (selectedPersons != "All")
            {
                Gender selected = (Gender)Enum.Parse(typeof(Gender), selectedPersons);
                data = db.OsobyZaginione.Where(p => p.Gender == selected);
                //return PartialView(db.OsobyZaginione.Where(p => p.Name == selectedPersons).ToList());
            }
            return PartialView(data);
        }

        public ActionResult Index(string selectedPersons = "All")
        {
            return View((object)selectedPersons);
        }

        // GET: OsobyZaginiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OsobyZaginione osobyZaginione = db.OsobyZaginione.Find(id);
            if (osobyZaginione == null)
            {
                return HttpNotFound();
            }
            return View(osobyZaginione);
        }

        public ActionResult GetMissingPersons(String selectedPersons = "All")
        {
            return View((Object)selectedPersons);
        }

        // GET: OsobyZaginiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OsobyZaginiones/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPersons,Name,LastName,DateOfBirth,DateOfDisappearance,PictureName,CityOfDisappearance,LocationOfDisappearance")] OsobyZaginione osobyZaginione)
        {
            if (ModelState.IsValid)
            {
                db.OsobyZaginione.Add(osobyZaginione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(osobyZaginione);
        }

        // GET: OsobyZaginiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OsobyZaginione osobyZaginione = db.OsobyZaginione.Find(id);
            if (osobyZaginione == null)
            {
                return HttpNotFound();
            }
            return View(osobyZaginione);
        }

        // POST: OsobyZaginiones/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPersons,Name,LastName,DateOfBirth,DateOfDisappearance,PictureName,CityOfDisappearance,LocationOfDisappearance")] OsobyZaginione osobyZaginione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osobyZaginione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(osobyZaginione);
        }

        // GET: OsobyZaginiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OsobyZaginione osobyZaginione = db.OsobyZaginione.Find(id);
            if (osobyZaginione == null)
            {
                return HttpNotFound();
            }
            return View(osobyZaginione);
        }

        // POST: OsobyZaginiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OsobyZaginione osobyZaginione = db.OsobyZaginione.Find(id);
            db.OsobyZaginione.Remove(osobyZaginione);
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
