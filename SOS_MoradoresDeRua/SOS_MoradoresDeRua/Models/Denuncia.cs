using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.Models
{
    public class Denuncia
    {
        public int Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario UsuarioDenunciado { get; set; }
        public int? UsuarioDenunciadoId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int? PessoaId { get; set; }
        public string Descricao { get; set; }  
    }
}