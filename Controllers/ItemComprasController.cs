using Cervejaria.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Cervejaria.Controllers
{
    [Authorize]
    public class ItemComprasController : Controller
    {
        private CervejariaEntities db = new CervejariaEntities();

        // GET: ItemCompras
        public ActionResult Index()
        {
            var itemCompra = db.ItemCompra.Include(i => i.Fornecedor).Include(i => i.Produto);
            return View(itemCompra.ToList());
        }

        // GET: ItemCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCompra itemCompra = db.ItemCompra.Find(id);
            if (itemCompra == null)
            {
                return HttpNotFound();
            }
            return View(itemCompra);
        }

        // GET: ItemCompras/Create
        public ActionResult Create()
        {
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "FornecedorId", "Nome");
            ViewBag.IdProduto = new SelectList(db.Produto, "ProdutoId", "Nome");
            return View();
        }

        // POST: ItemCompras/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemCompraId,IdProduto,Quantidade,Valor,IdFornecedor")] ItemCompra itemCompra)
        {
            if (ModelState.IsValid)
            {
                db.ItemCompra.Add(itemCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "FornecedorId", "Nome", itemCompra.IdFornecedor);
            ViewBag.IdProduto = new SelectList(db.Produto, "ProdutoId", "Nome", itemCompra.IdProduto);
            return View(itemCompra);
        }

        // GET: ItemCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCompra itemCompra = db.ItemCompra.Find(id);
            if (itemCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "FornecedorId", "Nome", itemCompra.IdFornecedor);
            ViewBag.IdProduto = new SelectList(db.Produto, "ProdutoId", "Nome", itemCompra.IdProduto);
            return View(itemCompra);
        }

        // POST: ItemCompras/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemCompraId,IdProduto,Quantidade,Valor,IdFornecedor")] ItemCompra itemCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFornecedor = new SelectList(db.Fornecedor, "FornecedorId", "Nome", itemCompra.IdFornecedor);
            ViewBag.IdProduto = new SelectList(db.Produto, "ProdutoId", "Nome", itemCompra.IdProduto);
            return View(itemCompra);
        }

        // GET: ItemCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCompra itemCompra = db.ItemCompra.Find(id);
            if (itemCompra == null)
            {
                return HttpNotFound();
            }
            return View(itemCompra);
        }

        // POST: ItemCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemCompra itemCompra = db.ItemCompra.Find(id);
            db.ItemCompra.Remove(itemCompra);
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
