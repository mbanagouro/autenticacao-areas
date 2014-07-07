using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace AutenticacaoAreas.Application.Services
{
    /// <summary>
    /// Classe base de autenticação (Forms Authentication)
    /// </summary>
    public abstract class Autenticacao
    {
        JavaScriptSerializer Serializer { get; set; }

        static HttpContext HttpContext
        {
            get { return HttpContext.Current; }
        }

        public Autenticacao()
        {
            Serializer = new JavaScriptSerializer();
        }

        // nome do cookie de autenticação que deve ser implementado pela classe especializada
        protected abstract string NomeCookie { get; }

        public void Autenticar(UsuarioLogado usuario)
        {
            DateTime today = DateTime.Now;
            // obtém o timeout configurado no web.config <forms timeout="30" ></forms>
            DateTime expires = today.Add(FormsAuthentication.Timeout);
            // serializa os dados do usuario para gravar em cookie
            string userData = Serializer.Serialize(usuario);
            // gera o ticket de autenticação
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usuario.Nome, today, expires, false, userData, FormsAuthentication.FormsCookiePath);
            // realiza a criptografia do ticket que será persistido no cookie
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            // cria o cookie com os dados do ticket
            HttpCookie cookie = new HttpCookie(this.NomeCookie, encryptedTicket);
            // informa se o cookie pode ser manipulado via client-side
            cookie.HttpOnly = true;
            // obtém os dados configurado no web.config <forms path="teste" requireSSL="false" domain="seusite.com.br" ></forms>
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }
            // adiciona o cookie na saída
            HttpContext.Response.Cookies.Add(cookie);
        }

        public void Deslogar()
        {
            // obtém o cookie
            HttpCookie cookie = HttpContext.Request.Cookies[this.NomeCookie];
            if (cookie != null)
            {
                // destrói o cookie
                cookie.Value = null;
                cookie.Expires = DateTime.Now.AddMonths(-1);
                HttpContext.Response.Cookies.Add(cookie);
            }
        }

        public UsuarioLogado ObterAutenticado()
        {
            UsuarioLogado usuario = null;

            // obtém o cookie
            HttpCookie cookie = HttpContext.Request.Cookies[this.NomeCookie];
            // se não existir ou for nulo, retorna null
            if (cookie == null || String.IsNullOrWhiteSpace(cookie.Value))
            {
                return usuario;
            }

            // descriptografa os dados do cookie e recria o ticket
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            // se for nulo ou inválido, retorna null
            if (ticket == null)
            {
                return usuario;
            }

            try
            {
                // deserializa os dados do usuário logado
                usuario = Serializer.Deserialize<UsuarioLogado>(ticket.UserData);
            }
            catch (Exception)
            {
                //e m caso de exception retorna null
                return null;
            }

            // se tudo OK, retorna o usuário logado.
            return usuario;
        }

        public class UsuarioLogado
        {
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
        }
    }
}