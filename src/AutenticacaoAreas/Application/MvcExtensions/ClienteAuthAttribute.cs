using AutenticacaoAreas.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoAreas.Application.MvcExtensions
{
    public class ClienteAuthAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var usuario = new AutenticacaoCliente().ObterAutenticado();
            return (usuario != null);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string loginUrl = "~/cliente/login";
            string url = filterContext.HttpContext.Request.Url.PathAndQuery;
            string redirect = String.Format("{0}?returnUrl={1}", loginUrl, url);
            filterContext.Result = new RedirectResult(redirect);
        }
    }
}