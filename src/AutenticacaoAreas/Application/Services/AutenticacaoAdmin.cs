using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutenticacaoAreas.Application.Services
{
    public class AutenticacaoAdmin : Autenticacao
    {
        protected override string NomeCookie
        {
            get { return "SITE.ADMIN.AUTH"; }
        }
    }
}