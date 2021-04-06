using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ModelUsers
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Identificacion { get; set; }
        public int edad { get; set; }
        public string cargo { get; set; }

        public int puntos { get; set; }

        public string FullName()
        {
            return this.Nombre + " " + this.Apellidos;
        }

    }
}
