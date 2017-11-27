using SOS_MoradoresDeRua.DAO;
using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOS_MoradoresDeRua.Controllers
{
    public class MoradorController : Controller
    {
        public ActionResult Index()
        {
            MoradorDeRuaDAO dao = new MoradorDeRuaDAO();
            IList<MoradorDeRua> morador = dao.Morador();
            ViewBag.Morador = morador;
            return View();
        }
        public ActionResult Remover(int id)
        {
            if (Session["usuarioLogado"] != null)
            {
                if (new SOS_MoradoresDeRua.DAO.UsuarioDAO().BuscaId((int)Session["usuarioLogado"]).TipoUsuarioId == 1)
                {
                    MoradorDeRuaDAO dao = new MoradorDeRuaDAO();
                    dao.Remover(dao.BuscaPorPessoaId(id));
                }
            }
            return RedirectToAction("../Master/MoradoresDeRua");
        }
        public ActionResult Reportar(int idMorador, string texto)
        {
            Denuncia denuncia = new Denuncia();
            denuncia.UsuarioId = (int)Session["UsuarioLogado"];
            denuncia.PessoaId = new MoradorDeRuaDAO().BuscaPorId(idMorador).PessoaId;
            denuncia.Descricao = texto;
            DenunciaDAO denunciaDao = new DenunciaDAO();
            denunciaDao.Adicionar(denuncia);
            return RedirectToAction("../Master/MoradoresDeRua");
        }
        public ActionResult Comentario(int id, string texto)
        {
            Comentario comentario = new Comentario();
            comentario.UsuarioId = (int)Session["UsuarioLogado"];
            comentario.PessoaId = new MoradorDeRuaDAO().BuscaPorId(id).PessoaId;
            var palavras = new DicionarioDAO().Dicionarios();
            foreach (var palavra in palavras)
            {
                texto = texto.Replace(palavra.Palavra, "*****");
            }
            comentario.Texto = texto;
            ComentarioDAO comentarioDao = new ComentarioDAO();
            comentarioDao.Adicionar(comentario);
            return RedirectToAction("../Master/MoradoresDeRua");
        }
        public ActionResult RemoverFoto(int id)
        {
            if (Session["usuarioLogado"] != null)
            {
                if (new SOS_MoradoresDeRua.DAO.UsuarioDAO().BuscaId((int)Session["usuarioLogado"]).TipoUsuarioId == 1)
                {
                    FotoDAO dao = new FotoDAO();
                    dao.Remover(dao.BuscaPorId(id));
                }
            }
            return RedirectToAction("../Master/MoradoresDeRua");
        }

        public ActionResult RemoverComentario(int id)
        {
            if (Session["usuarioLogado"] != null)
            {
                if (new SOS_MoradoresDeRua.DAO.UsuarioDAO().BuscaId((int)Session["usuarioLogado"]).TipoUsuarioId == 1)
                {
                    ComentarioDAO dao = new ComentarioDAO();
                    dao.Remover(dao.BuscaPorId(id));
                }
            }
            return RedirectToAction("../Master/MoradoresDeRua");
        }
    }
}