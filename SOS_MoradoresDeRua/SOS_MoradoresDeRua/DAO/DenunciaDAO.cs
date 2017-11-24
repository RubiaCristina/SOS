using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.DAO
{
    public class DenunciaDAO
    {
        private SOSContext contexto;

        public DenunciaDAO()
        {
            this.contexto = new SOSContext();
        }

        public Denuncia BuscaPorId(int id)
        {
            return contexto.Denuncias.Find(id);
        }

        public void Adicionar(Denuncia denuncia)
        {
            contexto.Denuncias.Add(denuncia);
            contexto.SaveChanges();
        }

        public void Atualizar(Denuncia denuncia)
        {
            contexto.Entry(denuncia).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public IList<Denuncia> Denuncias()
        {
            return contexto.Denuncias.ToList();
        }

        public void Remover(Denuncia denuncia)
        {
            contexto.Denuncias.Remove(denuncia);
            contexto.SaveChanges();
        }
    }
}