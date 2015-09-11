using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioViajante
{
    abstract class Algoritmo
    {
        public int LongitudRecorrido { get; set; }
        public int[,] Distancia { get; set; }

        public List<Provincia> Provincias { get; set; }
        public List<Provincia> Recorrido { get; set; }
        abstract public List<Provincia> getRecorrido();
        public Algoritmo(int[,] distancia, List<Provincia> provincias)
        {
            this.Distancia = distancia;
            this.Provincias = provincias;
        }
    }
}
