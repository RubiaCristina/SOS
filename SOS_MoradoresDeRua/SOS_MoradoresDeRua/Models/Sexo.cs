using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.Models
{
    public class Sexo
    {
        public int Id { get; set; }
        public string Opcao { get; set; }

        public IList<Pessoa> Pessoas { get; set; }
        public IList<Usuario> Usuarios { get; set; }
    }
}