using SOS_MoradoresDeRua.DAO;
using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOS_MoradoresDeRua.Controllers
{
    public class MasterController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CriarUser()
        {
            return View();
        }
        public ActionResult CriarMorador()
        {
            return View();
        }
        public ActionResult CriarDesaparecido()
        {
            return View();
        }
        public ActionResult Desaparecidos()
        {
            return View();
        }
        public ActionResult MoradoresDeRua()
        {
            return View();
        }
        public ActionResult Usuarios()
        {
            return View();
        }
        public ActionResult PesquisaMorador()
        {
            return View();
        }
        public ActionResult PesquisaUsuario()
        {
            return View();
        }
        public ActionResult PesquisaDesaparecido()
        {
            return View();
        }
        public ActionResult Morador()
        {
            return View();
        }
        public ActionResult Desaparecido()
        {
            return View();
        }
        public ActionResult Usuario()
        {
            return View();
        }
        public ActionResult Denuncias()
        {
            return View();
        }
        public ActionResult AdicionarFoto()
        {
            return View();
        }
        public ActionResult Sobre()
        {
            return View();
        }
        public ActionResult AdicionarFotoMetodo(int id, HttpPostedFileBase file)
        {
            var morador = new SOS_MoradoresDeRua.DAO.MoradorDeRuaDAO().BuscaPorPessoaId(id);
            var desaparecido = new SOS_MoradoresDeRua.DAO.PessoaDesaparecidaDAO().BuscaPorPessoaId(id);
            FotoDAO foto = new FotoDAO();
            Foto f = new Foto
            {
                Data = DateTime.Now,
                PessoaId = id,
                UsuarioId = (int)Session["usuarioLogado"],
                TipoFotografia = file.ContentType
            };
            byte[] content = new byte[file.ContentLength];
            file.InputStream.Read(content, 0, file.ContentLength);
            f.Fotografia = content;
            foto.Adicionar(f);
            if (morador != null)
                return RedirectToAction("Index", "Master/MoradoresDeRua");
            else if (desaparecido != null)
                return RedirectToAction("Index", "Master/Desaparecidos");
            else
                return RedirectToAction("Index", "Index");
        }
    }
}