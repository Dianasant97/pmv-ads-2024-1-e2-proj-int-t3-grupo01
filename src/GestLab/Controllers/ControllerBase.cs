using GestLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace GestLab.Controllers
{
    public class ControllerBase : Controller
    {
        public const string SessionKeyID = "_Id";
        public const string SessionKeyNome = "_Nome";
        public const string SessionKeyEmail = "_Email";
        public const string SessionKeyTipo = "_Tipo";
        protected UsuarioModel GetDadosUsuario()
        {
            var usuario = new UsuarioModel
            {
                Id = Convert.ToInt32(HttpContext.Session.GetInt32(SessionKeyID)),
                Nome = HttpContext.Session.GetString(SessionKeyNome),
                Email = HttpContext.Session.GetString(SessionKeyEmail),
                Tipo = HttpContext.Session.GetString(SessionKeyTipo)
            };

            return usuario;
        }
    }
}
