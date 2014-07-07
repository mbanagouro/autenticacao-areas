using AutenticacaoAreas.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoAreas.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string login, string senha)
        {
            //realiza a validação do login

            new AutenticacaoAdmin()
                .Autenticar(new Autenticacao.UsuarioLogado
                {
                    Codigo = Guid.NewGuid().ToString(),
                    Nome = "Admin Teste",
                    Email = "admin@site.com.br"
                });

            return RedirectToRoute("Admin.Home.Index");
        }

        public ActionResult Sair()
        {
            new AutenticacaoAdmin().Deslogar();
            return RedirectToRoute("Home.Index");
        }
    }
}