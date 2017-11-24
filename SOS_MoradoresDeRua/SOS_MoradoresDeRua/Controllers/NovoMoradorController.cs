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
    public class NovoMoradorController : Controller
    {
        public ActionResult Index()
        {
            MoradorDeRuaDAO dao = new MoradorDeRuaDAO();
            IList<MoradorDeRua> morador = dao.Morador(); 
            ViewBag.Morador = morador;
            return View();
        }
        public ActionResult CriarMoradorDeRua()
        {
            return View();
        }
        public ActionResult Adiciona(MoradorDeRua morador, HttpPostedFileBase file)
        {
            MoradorDeRuaDAO dao = new MoradorDeRuaDAO();
            dao.Adicionar(morador);
            FotoDAO foto = new FotoDAO();
            Foto f = new Foto
            {
                Data = DateTime.Now,
                PessoaId = morador.Pessoa.Id,
                UsuarioId = (int) Session["usuarioLogado"],
                TipoFotografia = file.ContentType
            };
            byte[] content = new byte[file.ContentLength];
            file.InputStream.Read(content, 0, file.ContentLength);
            f.Fotografia = content;
            foto.Adicionar(f);
            return RedirectToAction("../Master/MoradoresDeRua");
        }
        public ActionResult Busca()
        {
            PessoaDAO dao = new PessoaDAO();
            IList<Pessoa> morador = dao.Pessoas();
            ViewBag.Morador = morador;
            return View();
        }
    }
}