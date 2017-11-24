using SOS_MoradoresDeRua.Controllers;
using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.DAO
{
    public class MoradorDeRuaDAO
    {
        private SOSContext contexto;

        public MoradorDeRuaDAO()
        {
            this.contexto = new SOSContext();
        }

        public void Adicionar(MoradorDeRua morador)
        {
            contexto.MoradoresDeRua.Add(morador);
            morador.Pessoa.DataDePublicacao = DateTime.Now;
            contexto.SaveChanges();
        }

        public MoradorDeRua BuscaPorId(int id)
        {
            return contexto.MoradoresDeRua.Find(id);
        }

        public MoradorDeRua BuscaPorPessoaId(int id)
        {
            return contexto.MoradoresDeRua.Where(x => x.PessoaId == id).FirstOrDefault();
        }

        public IQueryable<MoradorDeRua> Busca(string busca)
        {
            return contexto.MoradoresDeRua.Where(x => x.Pessoa.Nome.Contains(busca) || x.OndeVive.Contains(busca));
        }

        public MoradorDeRua[] PegaMaisRecentes()
        {
            return contexto.MoradoresDeRua.Where(x => x.Pessoa != null).OrderByDescending(x => x.Pessoa.DataDePublicacao).Take(10).Select(x => x).ToArray();
        }

        public void Atualizar(MoradorDeRua morador)
        {
            contexto.Entry(morador).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public IList<MoradorDeRua> Morador()
        {
            return contexto.MoradoresDeRua.ToList();
        }

        public void Remover(MoradorDeRua morador)
        {
            contexto.MoradoresDeRua.Remove(morador);
            contexto.SaveChanges();
        }
    }
}