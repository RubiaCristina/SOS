using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int? PessoaId { get; set; }
        public byte[] Fotografia { get; set; }
        public DateTime Data { get; set; }
        public string TipoFotografia { get; set; }
    }
}