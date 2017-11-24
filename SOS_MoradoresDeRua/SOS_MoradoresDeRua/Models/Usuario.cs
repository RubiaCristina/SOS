using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string EMail { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string LinkRedesSociais { get; set; }
        public virtual TipoUsuario Tipo { get; set; }
        public int TipoUsuarioId { get; set; }
        public virtual Sexo Sexo { get; set; }
        public int SexoId { get; set; }
        public string Sobre { get; set; }
        public DateTime CriacaoDeConta { get; set; }     
        
        public IList<Foto> Fotos { get; set; }
        public IList<Comentario> Comentarios { get; set; }
        public IList<Denuncia> DenunciaUsuarios { get; set; }
    }
}