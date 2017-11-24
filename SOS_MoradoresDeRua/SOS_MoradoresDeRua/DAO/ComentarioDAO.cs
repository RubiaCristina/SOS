using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.DAO
{
    public class ComentarioDAO
    {
        private SOSContext contexto;
        
        public ComentarioDAO()
        {
            this.contexto = new SOSContext();
        }

        public Comentario BuscaPorId(int id)
        {
            return contexto.Comentarios.Find(id);
        }

        public IQueryable<Comentario> BuscaPorPessoa(int id)
        {
            return contexto.Comentarios.Where(x=>x.PessoaId == id);
        }

        public IQueryable<Comentario> BuscaPorUsuario(int id)
        {
            return contexto.Comentarios.Where(x => x.UsuarioId == id);
        }

        public void Adicionar(Comentario comentario)
        {
            comentario.Data = DateTime.Now;
            contexto.Comentarios.Add(comentario);
            contexto.SaveChanges();
        }

        public void Atualizar(Comentario comentario)
        {
            contexto.Entry(comentario).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public IList<Comentario> Comentarios()
        {
            return contexto.Comentarios.ToList();
        }

        public void Remover(Comentario comentario)
        {
            contexto.Comentarios.Remove(comentario);
            contexto.SaveChanges();
        }
    }
}