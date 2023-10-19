using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinkupEDM.AppModel;

namespace LinkUpAdmin.Views.Estados
{
    public class EstadoEnviosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: EstadoEnvios
        public ActionResult Index()
        {
            return View();
        }

        // GET: EstadoEnvios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEnvio estadoEnvio = db.EstadoEnvio.Find(id);
            if (estadoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(estadoEnvio);
        }

        // GET: EstadoEnvios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoEnvios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Estado,Estado")] EstadoEnvio estadoEnvio)
        {
            if (ModelState.IsValid)
            {
                db.EstadoEnvio.Add(estadoEnvio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoEnvio);
        }

        // GET: EstadoEnvios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEnvio estadoEnvio = db.EstadoEnvio.Find(id);
            if (estadoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(estadoEnvio);
        }

        // POST: EstadoEnvios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Estado,Estado")] EstadoEnvio estadoEnvio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoEnvio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoEnvio);
        }

        // GET: EstadoEnvios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEnvio estadoEnvio = db.EstadoEnvio.Find(id);
            if (estadoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(estadoEnvio);
        }

        // POST: EstadoEnvios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoEnvio estadoEnvio = db.EstadoEnvio.Find(id);
            db.EstadoEnvio.Remove(estadoEnvio);
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
