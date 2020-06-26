using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.Models
{
    public interface InterfazAmigo
    {
        Amigo dameDatosAmigo(int Id);

        List<Amigo> getAllAmigos();

        Amigo nuevoAmigo(Amigo amigo);

        Amigo modificar(Amigo modificarAmigo);
        Amigo borrar(int id);
    }
}
