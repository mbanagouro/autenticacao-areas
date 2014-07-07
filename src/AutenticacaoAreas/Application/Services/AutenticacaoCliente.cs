using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutenticacaoAreas.Application.Services
{
    public class AutenticacaoCliente : Autenticacao
    {
        protected override string NomeCookie
        {
            get { return "SITE.CLIENTE.AUTH"; }
        }
    }
}