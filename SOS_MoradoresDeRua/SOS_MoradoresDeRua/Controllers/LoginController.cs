using SOS_MoradoresDeRua.DAO;
using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOS_MoradoresDeRua.Controllers
{
    public class LoginController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string login, String senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario usuario = dao.BuscaPorId(login, senha);
            if (usuario != null)
            {
                Session["usuarioLogado"] = usuario.Id;
                return RedirectToAction("../Master/Index");
            }
            else
            {
                return RedirectToAction("../Master/Login");
            }
        }
    }
}