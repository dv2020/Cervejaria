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
    public class ItemReceitasController : Controller
    {
        private CervejariaEntities db = new CervejariaEntities();

        // GET: ItemReceitas
        public ActionResult Index()
        {
            var itemReceita = db.ItemReceita.Include(i => i.Insumo).Include(i => i.Receita);
            return View(itemReceita.ToList());
        }

        // GET: ItemReceitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemReceita itemReceita = db.ItemReceita.Find(id);
            if (itemReceita == null)
            {
                return HttpNotFound();
            }
            return View(itemReceita);
        }

        // GET: ItemReceitas/Create
        public ActionResult Create()
        {
            ViewBag.IdInsumo = new SelectList(db.Insumo, "InsumoId", "Nome");
            ViewBag.IdReceita = new SelectList(db.Receita, "ReceitaId", "Nome");
            return View();
        }

        // POST: ItemReceitas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemReceitaId,IdReceita,IdInsumo,Quantidade")] ItemReceita itemReceita)
        {
            if (ModelState.IsValid)
            {
                db.ItemReceita.Add(itemReceita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdInsumo = new SelectList(db.Insumo, "InsumoId", "Nome", itemReceita.IdInsumo);
            ViewBag.IdReceita = new SelectList(db.Receita, "ReceitaId", "Nome", itemReceita.IdReceita);
            return View(itemReceita);
        }

        // GET: ItemReceitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemReceita itemReceita = db.ItemReceita.Find(id);
            if (itemReceita == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdInsumo = new SelectList(db.Insumo, "InsumoId", "Nome", itemReceita.IdInsumo);
            ViewBag.IdReceita = new SelectList(db.Receita, "ReceitaId", "Nome", itemReceita.IdReceita);
            return View(itemReceita);
        }

        // POST: ItemReceitas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemReceitaId,IdReceita,IdInsumo,Quantidade")] ItemReceita itemReceita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemReceita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdInsumo = new SelectList(db.Insumo, "InsumoId", "Nome", itemReceita.IdInsumo);
            ViewBag.IdReceita = new SelectList(db.Receita, "ReceitaId", "Nome", itemReceita.IdReceita);
            return View(itemReceita);
        }

        // GET: ItemReceitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemReceita itemReceita = db.ItemReceita.Find(id);
            if (itemReceita == null)
            {
                return HttpNotFound();
            }
            return View(itemReceita);
        }

        // POST: ItemReceitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemReceita itemReceita = db.ItemReceita.Find(id);
            db.ItemReceita.Remove(itemReceita);
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
