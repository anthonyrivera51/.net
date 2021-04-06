using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PersistenceUsers
    {
        public static List<ModelUsers> listUsers = new List<ModelUsers>();

        public PersistenceUsers() { }

        public void Guardar(ModelUsers users) {
            listUsers.Add(users);
        }

        public IEnumerable<ModelUsers> Cargar() => listUsers.ToList();

        public bool putPuntosIdentificacion(int identificacion, int puntos)
        {
            ModelUsers users = listUsers.FirstOrDefault(x => x.Identificacion == identificacion);

            if (users == null)
                return false;

            users.puntos = puntos;


            return true;
        }
    }
}
