using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.DAO
{
    public class PessoaDAO
    {
        private SOSContext contexto;

        public PessoaDAO()
        {
            this.contexto = new SOSContext();
        }
        
        public Pessoa BuscaPorId(int id)
        {
            return contexto.Pessoas.Find(id);
        }

        public void Adicionar(Pessoa pessoa)
        {
            pessoa.DataDePublicacao = DateTime.Now;
            contexto.Pessoas.Add(pessoa);
            contexto.SaveChanges();
        }

        public void Atualizar(Pessoa pessoa)
        {
            contexto.Entry(pessoa).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public IList<Pessoa> Pessoas()
        {
            return contexto.Pessoas.ToList();
        }

        public void Remover(Pessoa pessoa)
        {
            contexto.Pessoas.Remove(pessoa);
            contexto.SaveChanges();
        }
    }
}