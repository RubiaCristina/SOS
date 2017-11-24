using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.Models
{
    public class TipoUsuario
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public IList<Usuario> Usuarios { get; set; }
    }
}