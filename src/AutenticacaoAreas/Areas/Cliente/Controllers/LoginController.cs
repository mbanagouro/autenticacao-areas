using AutenticacaoAreas.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoAreas.Areas.Cliente.Controllers
{
    public class LoginController : Controller
    {
        // GET: Cliente/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string login, string senha)
        {
            //realiza a validação do login

            new AutenticacaoCliente()
                .Autenticar(new Autenticacao.UsuarioLogado
                {
                    Codigo = Guid.NewGuid().ToString(),
                    Nome = "Cliente Teste",
                    Email = "cliente@site.com.br"
                });

            return RedirectToRoute("Cliente.Home.Index");
        }

        public ActionResult Sair()
        {
            new AutenticacaoCliente().Deslogar();
            return RedirectToRoute("Home.Index");
        }
    }
}