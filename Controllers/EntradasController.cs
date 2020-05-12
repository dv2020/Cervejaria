using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cervejaria.Models;

namespace Cervejaria.Controllers
{
    [Authorize]
    public class EntradasController : Controller
    {
        private CervejariaEntities db = new CervejariaEntities();

        // GET: Entradas
        public ActionResult Index()
        {
            var entrada = db.Entrada.Include(e => e.Compra);
            return View(entrada.ToList());
        }

        // GET: Entradas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entrada.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View(entrada);
        }

        // GET: Entradas/Create
        public ActionResult Create()
        {
            ViewBag.VendaId = new SelectList(db.Compra, "CompraId", "CompraId");
            return View();
        }

        // POST: Entradas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntradaId,VendaId,Valor")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entrada.Add(entrada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VendaId = new SelectList(db.Compra, "CompraId", "CompraId", entrada.VendaId);
            return View(entrada);
        }

        // GET: Entradas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entrada.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendaId = new SelectList(db.Compra, "CompraId", "CompraId", entrada.VendaId);
            return View(entrada);
        }

        // POST: Entradas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntradaId,VendaId,Valor")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VendaId = new SelectList(db.Compra, "CompraId", "CompraId", entrada.VendaId);
            return View(entrada);
        }

        // GET: Entradas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entrada.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View(entrada);
        }

        // POST: Entradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrada entrada = db.Entrada.Find(id);
            db.Entrada.Remove(entrada);
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
