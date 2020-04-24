using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImobilidadeFinal.Repositories
{
    public class GestaoCookie
    {
        public static void CriarCookie(int IdUsuario)
        {
            HttpCookie cookieUsuario = new HttpCookie("CookieUsuario");

            cookieUsuario.Values["IdUsuario"] = IdUsuario.ToString();

            cookieUsuario.Expires = DateTime.Now.AddDays(1);

            HttpContext.Current.Response.Cookies.Add(cookieUsuario);
        }

        public static bool ApagarCookie()
        {
            HttpCookie cookieUsuario = HttpContext.Current.Request.Cookies["CookieUsuario"];

            if (cookieUsuario == null)
            {
                return false;
            }
            else
            {
                HttpContext.Current.Response.Cookies[cookieUsuario.Name].Expires =
                    DateTime.Now.AddDays(-1);
                return true;
            }
        }
    }

}