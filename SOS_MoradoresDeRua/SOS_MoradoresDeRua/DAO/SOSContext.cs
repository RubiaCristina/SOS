using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.DAO
{
    public class SOSContext : DbContext
    {
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Denuncia> Denuncias { get; set; }
        public DbSet<Dicionario> Dicionarios { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<MoradorDeRua> MoradoresDeRua { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaDesaparecida> PessoasDesaparecidas { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }        

        //public SOSContext(): base("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=\"C:\\Users\\m004\\Desktop\\S.O.S. Moradores de Rua\\SOS.mdf\";Integrated Security = True; Connect Timeout = 30")
        public SOSContext(): base("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = SOS; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")     
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}