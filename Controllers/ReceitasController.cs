﻿using System;
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
    public class ReceitasController : Controller
    {
        private CervejariaEntities db = new CervejariaEntities();

        // GET: Receitas
        public ActionResult Index()
        {
            return View(db.Receita.ToList());
        }

        // GET: Receitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receita.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // GET: Receitas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receitas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReceitaId,Nome,Descricao")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                db.Receita.Add(receita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
   
            return View(receita);
        }

        // GET: Receitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receita.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // POST: Receitas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReceitaId,Nome,Descricao")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receita);
        }

        // GET: Receitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receita.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receita receita = db.Receita.Find(id);
            db.Receita.Remove(receita);
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
