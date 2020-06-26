using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.Models
{
    public class mockAmigoRepositorio: InterfazAmigo
    {
        private List<Amigo> amigoLista;

        public mockAmigoRepositorio()
        {
            amigoLista = new List<Amigo>();
            amigoLista.Add(new Amigo() { Id = 1, Nombre = "Juan", Ciudad = Provincia.Cajeme, Email = "er@com" });
            amigoLista.Add(new Amigo() { Id = 2, Nombre = "lool", Ciudad = Provincia.Obreon, Email = "weyr@comSasa" });
            amigoLista.Add(new Amigo() { Id = 3, Nombre = "pooo", Ciudad = Provincia.Sonora, Email = "er@com" });

        }

        public Amigo borrar(int Id)
        {
            Amigo amigo = amigoLista.FirstOrDefault(e => e.Id == Id);
            if (amigo !=null)
            {
                amigoLista.Remove(amigo);
            }

            return amigo;
        }

        public Amigo dameDatosAmigo(int Id)
        {

            return this.amigoLista.FirstOrDefault(e => e.Id == Id);

        }

        public List<Amigo> getAllAmigos()
        {
            return amigoLista;
        }

        public Amigo modificar(Amigo modificarAmigo)
        {
            Amigo amigo = amigoLista.FirstOrDefault(e => e.Id == modificarAmigo.Id);
            if (amigo != null)
            {
                amigo.Nombre = modificarAmigo.Nombre;
                amigo.Email = modificarAmigo.Email;
                amigo.Ciudad = modificarAmigo.Ciudad;
            }

            return amigo;
        }

        public Amigo nuevoAmigo(Amigo amigo)
        {
            amigo.Id = amigoLista.Max(a => a.Id) + 1;
            amigoLista.Add(amigo);
            return amigo;
        }
    }
}
