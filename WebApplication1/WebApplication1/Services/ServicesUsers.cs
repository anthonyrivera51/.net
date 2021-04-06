using WebApplication1.Helpers;
using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        ModelUsers CreateUser(ModelUsers user, List<ModelUsers> listUser);
        IEnumerable<ModelUsers> GetAll(List<ModelUsers> listUser);
        ModelUsers PutPuntosIdentification(int identification, int puntos, List<ModelUsers> listUser);
    }

    public class ServicesUsers : IUserService
    {
        public ModelUsers CreateUser(ModelUsers user, List<ModelUsers> listUser)
        {
            var statusUsers = listUser.FirstOrDefault(x => x.Identificacion == user.Identificacion);
            
            if(statusUsers != null)
                throw new AppException("Usuario ya existe.");

            ModelUsers users = new ModelUsers();
            users.Nombre = user.Nombre;
            users.Apellidos = user.Apellidos;
            users.Identificacion = user.Identificacion;
            users.edad = user.edad;
            users.cargo = user.cargo;

            listUser.Add(users);

            return user;
        }

        public IEnumerable<ModelUsers> GetAll(List<ModelUsers> listUser)
        {
            return listUser.ToList();
        }

        public ModelUsers PutPuntosIdentification(int identification, int puntos, List<ModelUsers> listUser)
        {
            var users = listUser.FirstOrDefault(x => x.Identificacion == identification);

            if (users != null)
                throw new AppException("Usuario no existe.");

            users.puntos = puntos;

            listUser.Add(users);

            return users;


        }
    }
}
