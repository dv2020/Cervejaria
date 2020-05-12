using Cervejaria.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Cervejaria.Controllers
{
    [Authorize]
    public class InsumosController : Controller
    {
        private CervejariaEntities db = new CervejariaEntities();

        // GET: Insumos
        public ActionResult Index()
        {
            return View(db.Insumo.ToList());
        }

        // GET: Insumos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo insumo = db.Insumo.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return View(insumo);
        }

        // GET: Insumos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insumos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsumoId,Nome,Valor")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                db.Insumo.Add(insumo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insumo);
        }

        // GET: Insumos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo insumo = db.Insumo.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return View(insumo);
        }

        // POST: Insumos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsumoId,Nome,Valor")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insumo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insumo);
        }

        // GET: Insumos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo insumo = db.Insumo.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return View(insumo);
        }

        // POST: Insumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insumo insumo = db.Insumo.Find(id);
            db.Insumo.Remove(insumo);
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
