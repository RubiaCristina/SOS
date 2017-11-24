using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.Models
{
    public class MoradorDeRua
    {
        public int Id { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public string OndeVive { get; set; }
        public string Historia { get; set; }
        public string Necessidades { get; set; }
        public string Profissao { get; set; }
        public string Escolaridade { get; set; }
    }
}