using Cervejaria.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Cervejaria.Controllers
{
    [Authorize]
    public class ItemEstoquesController : Controller
    {
        private CervejariaEntities db = new CervejariaEntities();

        // GET: ItemEstoques
        public ActionResult Index()
        {
            var itemEstoque = db.ItemEstoque.Include(i => i.Produto);
            return View(itemEstoque.ToList());
        }

        // GET: ItemEstoques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemEstoque itemEstoque = db.ItemEstoque.Find(id);
            if (itemEstoque == null)
            {
                return HttpNotFound();
            }
            return View(itemEstoque);
        }

        // GET: ItemEstoques/Create
        public ActionResult Create()
        {
            ViewBag.IdProduto = new SelectList(db.Produto, "ProdutoId", "Nome");
            return View();
        }

        // POST: ItemEstoques/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemEstoqueId,IdProduto,Quantidade")] ItemEstoque itemEstoque)
        {
            if (ModelState.IsValid)
            {
                db.ItemEstoque.Add(itemEstoque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProduto = new SelectList(db.Produto, "ProdutoId", "Nome", itemEstoque.IdProduto);
            return View(itemEstoque);
        }

        // GET: ItemEstoques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemEstoque itemEstoque = db.ItemEstoque.Find(id);
            if (itemEstoque == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProduto = new SelectList(db.Produto, "ProdutoId", "Nome", itemEstoque.IdProduto);
            return View(itemEstoque);
        }

        // POST: ItemEstoques/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemEstoqueId,IdProduto,Quantidade")] ItemEstoque itemEstoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemEstoque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProduto = new SelectList(db.Produto, "ProdutoId", "Nome", itemEstoque.IdProduto);
            return View(itemEstoque);
        }

        // GET: ItemEstoques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemEstoque itemEstoque = db.ItemEstoque.Find(id);
            if (itemEstoque == null)
            {
                return HttpNotFound();
            }
            return View(itemEstoque);
        }

        // POST: ItemEstoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemEstoque itemEstoque = db.ItemEstoque.Find(id);
            db.ItemEstoque.Remove(itemEstoque);
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
