using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.Models
{
    public class PessoaDesaparecida
    {
        public int Id { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public DateTime DataDeDesaparecimento { get; set; }
        public string Familiares { get; set; }
        public string Local { get; set; }
        public string Como { get; set; }
    }
}