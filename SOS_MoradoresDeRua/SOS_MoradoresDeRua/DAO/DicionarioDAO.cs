using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.DAO
{
    public class DicionarioDAO
    { 
        private SOSContext contexto;

        public DicionarioDAO()
        {
            this.contexto = new SOSContext();
        }

        public Dicionario BuscaPorId(int id)
        {
            return contexto.Dicionarios.Find(id);
        }

        public void Adicionar(Dicionario palavra)
        {
            contexto.Dicionarios.Add(palavra);
            contexto.SaveChanges();
        }

        public void Atualizar(Dicionario palavra)
        {
            contexto.Entry(palavra).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public IList<Dicionario> Dicionarios()
        {
            return contexto.Dicionarios.ToList();
        }

        public void Remover(Dicionario palavra)
        {
            contexto.Dicionarios.Remove(palavra);
            contexto.SaveChanges();
        }
    }
}