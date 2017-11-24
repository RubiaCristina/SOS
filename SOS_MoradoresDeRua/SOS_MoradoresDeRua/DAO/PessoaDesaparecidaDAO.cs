using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.DAO
{
    public class PessoaDesaparecidaDAO
    {
        private SOSContext contexto;

        public PessoaDesaparecidaDAO()
        {
            this.contexto = new SOSContext();
        }

        public void Adicionar(PessoaDesaparecida desaparecida)
        {
            if (desaparecida.DataDeDesaparecimento > DateTime.Now)
                throw new Exception("Data inválida");
            desaparecida.Pessoa.DataDePublicacao = DateTime.Now;
            contexto.PessoasDesaparecidas.Add(desaparecida);
            contexto.SaveChanges();
        }

        public PessoaDesaparecida BuscaPorId(int id)
        {
            return contexto.PessoasDesaparecidas.Find(id);
        }

        public PessoaDesaparecida BuscaPorPessoaId(int id)
        {
            return contexto.PessoasDesaparecidas.Where(x => x.PessoaId == id).FirstOrDefault();
        }

        public IQueryable<PessoaDesaparecida> Busca(string busca)
        {
            return contexto.PessoasDesaparecidas.Where(x => x.Pessoa.Nome.Contains(busca) || x.Local.Contains(busca));
        }

        public PessoaDesaparecida[] PegaMaisRecentes()
        {
            return contexto.PessoasDesaparecidas.Where(x => x.Pessoa != null).OrderByDescending(x => x.Pessoa.DataDePublicacao).Take(10).Select(x => x).ToArray();
        }

        public void Atualizar(PessoaDesaparecida desaparecida)
        {
            contexto.Entry(desaparecida).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public IList<PessoaDesaparecida> Desaparecida()
        {
            return contexto.PessoasDesaparecidas.ToList();
        }

        public void Remover(PessoaDesaparecida desaparecida)
        {
            contexto.PessoasDesaparecidas.Remove(desaparecida);
            contexto.SaveChanges();
        }
    }
}