using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.Models
{
    public class SQLAmigoRepositorio:InterfazAmigo
    {

        private readonly AppDbContext contexto;
        private List<Amigo> amigosLista;

        public SQLAmigoRepositorio (AppDbContext contexto)
        {
            this.contexto = contexto;
        }
       
        public Amigo nuevoAmigo(Amigo amigo) {
            contexto.AppDbContextAmigos.Add(amigo);
            contexto.SaveChanges();
            return amigo;
        }

        public List<Amigo> getAllAmigos()
        {
            amigosLista = contexto.AppDbContextAmigos.ToList<Amigo>();
            return amigosLista;
        }

        public Amigo borrar(int Id)
        {
            Amigo amigo = contexto.AppDbContextAmigos.Find(Id);
            if (amigo != null)
            {
                contexto.AppDbContextAmigos.Remove(amigo);
                contexto.SaveChanges();
            }

            return amigo;
        }

        public Amigo dameDatosAmigo(int Id)
        {
            return contexto.AppDbContextAmigos.Find(Id);
        }

        public Amigo modificar (Amigo amigo)
        {
            var modAmigo = contexto.AppDbContextAmigos.Attach(amigo);
            modAmigo.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.SaveChanges();
            return amigo;
        }

    }
}
