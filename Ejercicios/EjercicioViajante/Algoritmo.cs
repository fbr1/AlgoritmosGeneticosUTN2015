using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioViajante
{
    abstract class Algoritmo
    {
        // Variables de clase
        public static int[,] Distancia { get; set; }
        public static List<Provincia> Provincias { get; set; }
        public int LongitudRecorrido { get; set; }
        public List<Provincia> Recorrido { get; set; }
        abstract public List<Provincia> getRecorrido();        
    }
}
