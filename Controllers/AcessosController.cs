using Cervejaria.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace Cervejaria.Controllers
{
    public class AcessosController : Controller
    {
        private CervejariaEntities db = new CervejariaEntities();

        // GET: Acessos
        [Authorize]
        public ActionResult Index()
        {
            var acessos = db.Acesso.AsNoTracking().ToList();
            return View(acessos);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            /*código abaixo cria uma session para armazenar o nome do usuário*/
            Session["Nome"] = null;
            /*código abaixo cria uma session para armazenar o sobrenome do usuário*/
            Session["Sobrenome"] = null;
            /*retorna para a tela inicial do Home*/
            return RedirectToAction("Login", "Acessos");
        }
        /// <param name="returnURL"></param>
        /// <returns></returns>
        public ActionResult Login(string returnURL)
        {
            /*Recebe a url que o usuário tentou acessar*/
            ViewBag.ReturnUrl = returnURL;
            return View();
        }
        /// <param name = "login" ></ param >
        /// < param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Acesso login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (CervejariaEntities db = new CervejariaEntities())
                {
                    var vLogin = db.Acesso.Where(p => p.EMAIL.Equals(login.EMAIL)).FirstOrDefault();
                    /*Verificar se a variavel vLogin está vazia. 
                    Isso pode ocorrer caso o usuário não existe. 
              Caso não exista ele vai cair na condição else.*/
                    if (vLogin != null)
                    {
                        /*Código abaixo verifica se o usuário que retornou na variavel tem está 
                          ativo. Caso não esteja cai direto no else*/
                        if (Equals(vLogin.ATIVO, "S"))
                        {
                            /*Código abaixo verifica se a senha digitada no site é igual a 
                            senha que está sendo retornada 
                             do banco. Caso não cai direto no else*/
                            if (Equals(vLogin.SENHA, login.SENHA))
                            {
                                FormsAuthentication.SetAuthCookie(vLogin.EMAIL, false);
                                if (Url.IsLocalUrl(returnUrl)
                                && returnUrl.Length > 1
                                && returnUrl.StartsWith("/")
                                && !returnUrl.StartsWith("//")
                                && returnUrl.StartsWith("/\\"))
                                {
                                    return Redirect(returnUrl);
                                }
                                /*código abaixo cria uma session para armazenar o nome do usuário*/
                                Session["Nome"] = vLogin.NOME;
                                /*código abaixo cria uma session para armazenar o sobrenome do usuário*/
                                Session["Sobrenome"] = vLogin.SOBRENOME;
                                //Isso aqui serve para salvar o PERFIL do usuário em uma váriavel de sessão
                                Session["Perfil"] = vLogin.PERFIL;
                                /*retorna para a tela inicial do Home*/
                                return RedirectToAction("Index", "Home");
                            }
                            /*Else responsável da validação da senha*/
                            else
                            {
                                /*Escreve na tela a mensagem de erro informada*/
                                ModelState.AddModelError("", "Senha informada Inválida!!!");
                                /*Retorna a tela de login*/
                                return View(new Acesso());
                            }
                        }
                        /*Else responsável por verificar se o usuário está ativo*/
                        else
                        {
                            /*Escreve na tela a mensagem de erro informada*/
                            ModelState.AddModelError("", "Usuário sem Acesso para usar o sistema!!!");
                            /*Retorna a tela de login*/
                            return View(new Acesso());
                        }
                    }
                    /*Else responsável por verificar se o usuário existe*/
                    else
                    {
                        /*Escreve na tela a mensagem de erro informada*/
                        ModelState.AddModelError("", "E-mail informado inválido!!!");
                        /*Retorna a tela de login*/
                        return View(new Acesso());
                    }
                }
            }
            /*Caso os campos não esteja de acordo com a solicitação retorna a tela de login 
            com as mensagem dos campos*/
            return View(login);
        }
        // GET: Acessos/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acesso Acesso = db.Acesso.Find(id);
            if (Acesso == null)
            {
                return HttpNotFound();
            }
            return View(Acesso);
        }

        // GET: Acessos/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acessos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_LOGIN,EMAIL,SENHA,ATIVO,PERFIL,NOME,SOBRENOME")] Acesso Acesso)
        {
            if (ModelState.IsValid)
            {
                db.Acesso.Add(Acesso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Acesso);
        }

        // GET: Acessos/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acesso Acesso = db.Acesso.Find(id);
            if (Acesso == null)
            {
                return HttpNotFound();
            }
            return View(Acesso);
        }

        // POST: Acessos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_LOGIN,EMAIL,SENHA,ATIVO,PERFIL,NOME,SOBRENOME")] Acesso Acesso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Acesso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Acesso);
        }

        // GET: Acessos/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acesso Acesso = db.Acesso.Find(id);
            if (Acesso == null)
            {
                return HttpNotFound();
            }
            return View(Acesso);
        }

        // POST: Acessos/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acesso Acesso = db.Acesso.Find(id);
            db.Acesso.Remove(Acesso);
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
