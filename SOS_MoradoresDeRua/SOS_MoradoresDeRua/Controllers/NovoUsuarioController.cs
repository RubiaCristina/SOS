using SOS_MoradoresDeRua.DAO;
using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOS_MoradoresDeRua.Controllers
{
    public class NovoUsuarioController : Controller
    {
        public ActionResult Index()
        {
            UsuarioDAO dao = new UsuarioDAO();
            IList<Usuario> usuario = dao.Usuario();
            ViewBag.Usuarios = usuario;
            return View();
        }
        public ActionResult CriarUsuario()
        {
            return View();
        }
        public ActionResult Adiciona(Usuario usuario, HttpPostedFileBase file)
        {
            UsuarioDAO dao = new UsuarioDAO();
            dao.Adicionar(usuario);            
            return RedirectToAction("../Master/Login");
        }
    }
}