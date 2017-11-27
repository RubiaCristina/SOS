using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public DateTime Data { get; set; }
        public string Texto { get; set; }
        public IList<Denuncia> Denuncias{get; set;}
    }
}