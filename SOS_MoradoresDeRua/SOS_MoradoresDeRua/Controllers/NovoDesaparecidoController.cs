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
    public class NovoDesaparecidoController : Controller
    {
        public ActionResult Index()
        {
            PessoaDesaparecidaDAO dao = new PessoaDesaparecidaDAO();
            IList<PessoaDesaparecida> desaparecida = dao.Desaparecida();
            ViewBag.Desaparecida = desaparecida;
            return View();
        }
        public ActionResult CriarPessoaDesaparecida()
        {
            return View();
        }
        public ActionResult Adiciona(PessoaDesaparecida desaparecida, HttpPostedFileBase file)
        {
            PessoaDesaparecidaDAO dao = new PessoaDesaparecidaDAO();
            dao.Adicionar(desaparecida);
            FotoDAO foto = new FotoDAO();
            Foto f = new Foto
            {
                Data = DateTime.Now,
                PessoaId = desaparecida.Pessoa.Id,
                UsuarioId = (int)Session["usuarioLogado"],
                TipoFotografia = file.ContentType
            };
            byte[] content = new byte[file.ContentLength];
            file.InputStream.Read(content, 0, file.ContentLength);
            f.Fotografia = content;
            foto.Adicionar(f);
            return RedirectToAction("../Master/Desaparecidos");
        }
        public ActionResult Busca()
        {
            PessoaDAO dao = new PessoaDAO();
            IList<Pessoa> desaparecida = dao.Pessoas();
            ViewBag.Desaparecida = desaparecida;
            return View();
        }
    }
}