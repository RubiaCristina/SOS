using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.DAO
{
    public class TipoUsuarioDAO
    {
        private SOSContext contexto;

        public TipoUsuarioDAO()
        {
            this.contexto = new SOSContext();
        }

        public void Adicionar(TipoUsuario tipo)
        {
            contexto.TiposUsuarios.Add(tipo);
            contexto.SaveChanges();
        }

        public TipoUsuario BuscaPorId(int id)
        {
            return contexto.TiposUsuarios.Find(id);
        }

        public void Atualizar(TipoUsuario tipo)
        {
            contexto.Entry(tipo).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public IList<TipoUsuario> Tipo()
        {
            return contexto.TiposUsuarios.ToList();
        }

        public void Remover(TipoUsuario tipo)
        {
            contexto.TiposUsuarios.Remove(tipo);
            contexto.SaveChanges();
        }
    }
}