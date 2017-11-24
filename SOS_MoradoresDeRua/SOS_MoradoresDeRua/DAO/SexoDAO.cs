using SOS_MoradoresDeRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua.DAO
{
    public class SexoDAO
    {
        private SOSContext contexto;

    public SexoDAO()
    {
        this.contexto = new SOSContext();
    }

    public Sexo BuscaPorId(int id)
    {
        return contexto.Sexos.Find(id);
    }

    public void Adicionar(Sexo sexo)
    {
        contexto.Sexos.Add(sexo);
        contexto.SaveChanges();
    }

    public void Atualizar(Sexo sexo)
    {
        contexto.Entry(sexo).State = System.Data.Entity.EntityState.Modified;
        contexto.SaveChanges();
    }

    public void Dispose()
    {
        contexto.Dispose();
    }

    public IList<Sexo> Sexos()
    {
        return contexto.Sexos.ToList();
    }

    public void Remover(Sexo sexo)
    {
        contexto.Sexos.Remove(sexo);
        contexto.SaveChanges();
    }
}
}