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
    public class SaidasController : Controller
    {
        private CervejariaEntities db = new CervejariaEntities();

        // GET: Saidas
        public ActionResult Index()
        {
            return View(db.Saida.ToList());
        }

        // GET: Saidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saida saida = db.Saida.Find(id);
            if (saida == null)
            {
                return HttpNotFound();
            }
            return View(saida);
        }

        // GET: Saidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Saidas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaidaId,IdInsumo,Quantidade,Valor")] Saida saida)
        {
            if (ModelState.IsValid)
            {
                db.Saida.Add(saida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saida);
        }

        // GET: Saidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saida saida = db.Saida.Find(id);
            if (saida == null)
            {
                return HttpNotFound();
            }
            return View(saida);
        }

        // POST: Saidas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaidaId,IdInsumo,Quantidade,Valor")] Saida saida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saida);
        }

        // GET: Saidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saida saida = db.Saida.Find(id);
            if (saida == null)
            {
                return HttpNotFound();
            }
            return View(saida);
        }

        // POST: Saidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Saida saida = db.Saida.Find(id);
            db.Saida.Remove(saida);
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
