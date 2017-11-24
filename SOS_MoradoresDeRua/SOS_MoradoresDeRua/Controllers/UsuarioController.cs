using SOS_MoradoresDeRua.DAO;
using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOS_MoradoresDeRua.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            UsuarioDAO dao = new UsuarioDAO();
            IList<Usuario> usuario = dao.Usuario();
            ViewBag.Usuarios = usuario;
            return View();
        }
        public ActionResult Remover(int id)
        {
            if(Session["usuarioLogado"] != null)
            {
                if (new SOS_MoradoresDeRua.DAO.UsuarioDAO().BuscaId((int)Session["usuarioLogado"]).TipoUsuarioId == 1)
                {
                    UsuarioDAO dao = new UsuarioDAO();
                    dao.Remover(dao.BuscaId(id));
                }
            }
            return RedirectToAction("../Master/Usuarios");
        }
        public ActionResult Reportar(int id)
        {
            Denuncia denuncia = new Denuncia();
            denuncia.UsuarioId = (int)Session["UsuarioLogado"];
            
            denuncia.UsuarioDenunciadoId = id;
            DenunciaDAO denunciaDao = new DenunciaDAO();
            denunciaDao.Adicionar(denuncia);
            return RedirectToAction("../Master/Usuarios");
        }
    }
}