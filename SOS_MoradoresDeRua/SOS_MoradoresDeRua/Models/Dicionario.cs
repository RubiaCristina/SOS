using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.Models
{
    public class Dicionario
    {
        public int Id { get; set; }
        public string Palavra { get; set; }

        public IList<Comentario> Comentarios { get; set; }
    }
}