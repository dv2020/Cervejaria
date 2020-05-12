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
    [Authorize(Roles = "Administrador, SuperAdmin")]
    public class AtendimentosController : Controller
    {
        private CervejariaEntities db = new CervejariaEntities();

        // GET: Atendimentos
        public ActionResult Index()
        {
            var atendimento = db.Atendimento.Include(a => a.Cliente).Include(a => a.Compra).Include(a => a.Funcionario);
            return View(atendimento.ToList());
        }

        // GET: Atendimentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendimento atendimento = db.Atendimento.Find(id);
            if (atendimento == null)
            {
                return HttpNotFound();
            }
            return View(atendimento);
        }

        // GET: Atendimentos/Create
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "ClienteId", "Nome");
            ViewBag.IdCompra = new SelectList(db.Compra, "CompraId", "CompraId");
            ViewBag.IdFuncionario = new SelectList(db.Funcionario, "FuncionarioId", "Nome");
            return View();
        }

        // POST: Atendimentos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtendimentoId,IdFuncionario,IdCliente,IdCompra")] Atendimento atendimento)
        {
            if (ModelState.IsValid)
            {
                db.Atendimento.Add(atendimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "ClienteId", "Nome", atendimento.IdCliente);
            ViewBag.IdCompra = new SelectList(db.Compra, "CompraId", "CompraId", atendimento.IdCompra);
            ViewBag.IdFuncionario = new SelectList(db.Funcionario, "FuncionarioId", "Nome", atendimento.IdFuncionario);
            return View(atendimento);
        }

        // GET: Atendimentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendimento atendimento = db.Atendimento.Find(id);
            if (atendimento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "ClienteId", "Nome", atendimento.IdCliente);
            ViewBag.IdCompra = new SelectList(db.Compra, "CompraId", "CompraId", atendimento.IdCompra);
            ViewBag.IdFuncionario = new SelectList(db.Funcionario, "FuncionarioId", "Nome", atendimento.IdFuncionario);
            return View(atendimento);
        }

        // POST: Atendimentos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtendimentoId,IdFuncionario,IdCliente,IdCompra")] Atendimento atendimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atendimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "ClienteId", "Nome", atendimento.IdCliente);
            ViewBag.IdCompra = new SelectList(db.Compra, "CompraId", "CompraId", atendimento.IdCompra);
            ViewBag.IdFuncionario = new SelectList(db.Funcionario, "FuncionarioId", "Nome", atendimento.IdFuncionario);
            return View(atendimento);
        }

        // GET: Atendimentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendimento atendimento = db.Atendimento.Find(id);
            if (atendimento == null)
            {
                return HttpNotFound();
            }
            return View(atendimento);
        }

        // POST: Atendimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atendimento atendimento = db.Atendimento.Find(id);
            db.Atendimento.Remove(atendimento);
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
