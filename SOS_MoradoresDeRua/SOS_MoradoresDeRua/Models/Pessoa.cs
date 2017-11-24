using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LocalDeOrigem { get; set; }
        public int Idade { get; set; }
        public DateTime DataDePublicacao { get; set; }
        public string Descricao { get; set; }
        public virtual Sexo Sexo { get; set; }
        public int SexoId { get; set; }

        public IList<MoradorDeRua> Moradores { get; set; }
        public IList<PessoaDesaparecida> Desaparecidos { get; set; }
        public IList<Comentario> Comentarios { get; set; }
        public IList<Foto> Fotos { get; set; }
        public IList<Denuncia> Denuncias { get; set; }
    }
}