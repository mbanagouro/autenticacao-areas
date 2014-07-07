using AutenticacaoAreas.Application.MvcExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoAreas.Areas.Cliente.Controllers
{
    [ClienteAuth]
    public class HomeController : Controller
    {
        // GET: Cliente/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}