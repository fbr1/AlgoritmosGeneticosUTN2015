using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioViajante
{
    class Exhaustivo : Algoritmo
    {
        const int VACIO = 9999;
        const int SIZE = 5;        

        public Exhaustivo(int[,] distancia, List<Provincia> provincias):base(distancia,provincias)
        {            
        }

        public override List<Provincia> getRecorrido()
        {
            throw new NotImplementedException();
        }
    }
}
