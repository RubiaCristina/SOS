using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.DAO
{
    public class FotoDAO
    {
        private SOSContext contexto;

        public FotoDAO()
        {
            this.contexto = new SOSContext();
        }

        public void Adicionar(Foto foto)
        {
            foto.Data = DateTime.Now;
            contexto.Fotos.Add(foto);
            contexto.SaveChanges();
        }

        public Foto BuscaPorId(int id)
        {
                return contexto.Fotos.Find(id);
        }

        public IQueryable<Foto> BuscaPorPessoa(int id)
        {
            return contexto.Fotos.Where(x=>x.PessoaId == id);
        }

        public IList<Foto> BuscaPorUsuario(int id)
        {
            return contexto.Fotos.Where(x => x.UsuarioId == id).ToList();
        }

        public void Atualizar(Foto foto)
        {
            contexto.Entry(foto).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }
        
        public void Dispose()
        {
            contexto.Dispose();
        }

        public IList<Foto> Fotos()
        {
            return contexto.Fotos.ToList();
        }
        
        public void Remover(Foto foto)
        {
            contexto.Fotos.Remove(foto);
            contexto.SaveChanges();
        }

        public static string RetornaSrcImagem(Foto foto)
        {
            string res = "data:" + foto.TipoFotografia + ";base64, ";
            res += Convert.ToBase64String(foto.Fotografia);
            return res;
        }
    }
}