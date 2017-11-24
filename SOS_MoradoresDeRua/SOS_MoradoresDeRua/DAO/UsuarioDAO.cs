using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SOS_MoradoresDeRua.DAO
{
    public class UsuarioDAO
    {
        private SOSContext contexto;

        public UsuarioDAO()
        {
            this.contexto = new SOSContext();
        }

        public void Adicionar(Usuario usuario)
        {
            if (usuario.Senha.Length < 8)
                throw new Exception("Senha com caracteres insuficientes!");

            if (!(new Regex(@"^[a-zA-Z]+[a-zA-Z0-9]*\@[a-zA-Z0-9]+(\.[a-zA-Z]+)+$")).IsMatch(usuario.EMail))
                throw new Exception("Email inválido!");

            if (!string.IsNullOrEmpty(usuario.Telefone) && !(new Regex(@"^(\+?[0-9][0-9])?\s?(\([0-9][0-9]\)|([0-9][0-9]))\s?[0-9][0-9][0-9][0-9][0-9]?(\-|\s)?[0-9][0-9][0-9][0-9]$")).IsMatch(usuario.Telefone))
                throw new Exception("Telefone inválido!");
            usuario.TipoUsuarioId = 2;
            if (contexto.Usuarios.FirstOrDefault(x => x.Login.ToLower() == usuario.Login.ToLower() || x.EMail.ToLower() == usuario.EMail.ToLower()) == null)
            {
                usuario.CriacaoDeConta = DateTime.Now;
                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();
            }
            else
            {
                throw new Exception("Nome de usuário ou e-mail já cadastrado");
            }
        }

        public Usuario BuscaPorId(string login, string senha)
        {
            using (var context = new SOSContext())
            {
                return contexto.Usuarios.FirstOrDefault(a => a.Login == login && a.Senha == senha);

            }
        }

        public Usuario BuscaId(int id)
        {
            return contexto.Usuarios.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<Usuario> Busca(string busca)
        {
            return contexto.Usuarios.Where(x => x.Nome.Contains(busca));
        }

        public Usuario[] PegaMaisRecentes()
        {
            return contexto.Usuarios.OrderByDescending(x => x.CriacaoDeConta).Take(10).ToArray();
        }

        public void Atualizar(Usuario usuario)
        {
            contexto.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public IList<Usuario> Usuario()
        {
            return contexto.Usuarios.ToList();
        }

        public void Remover(Usuario usuario)
        {
            contexto.Usuarios.Remove(usuario);
            contexto.SaveChanges();
        }
    }
}