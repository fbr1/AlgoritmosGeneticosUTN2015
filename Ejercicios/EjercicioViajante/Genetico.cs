using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioViajante 
{
    class Genetico : Algoritmo
    {       

        public Genetico(int[,] distancia, List<Provincia> provincias):base(distancia,provincias)
        {
        }

        public override List<Provincia> getRecorrido()
        {
            throw new NotImplementedException();
        }


    }
}
