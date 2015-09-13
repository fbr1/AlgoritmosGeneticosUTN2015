using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioViajante 
{
    class Genetico : Algoritmo
    {
        const int CICLOS = 200; 

        public override List<Provincia> getRecorrido()
        {
            List<Generacion> generaciones = new List<Generacion>();
            Random random = new Random();
            Generacion.rnd = random;
            Generacion generacion = new Generacion(CICLOS, ref generaciones);

            int mindistancia = 999999999;
            Individuo recorridoIndividuo = null;
            foreach (Individuo ind in generaciones.Last().Poblacion)
            {
                if(ind.FuncionObjetiva < mindistancia)
                {
                    recorridoIndividuo = ind;
                    mindistancia = ind.FuncionObjetiva;
                }
            }

            List<Provincia> recorrido = new List<Provincia>();
            foreach(Provincia prov in recorridoIndividuo.Cromosoma)
            {
                recorrido.Add(prov);
            }
            // Cierra el recorrido
            recorrido.Add(recorridoIndividuo.Cromosoma[0]);

            LongitudRecorrido = mindistancia;
            Recorrido = recorrido;                    
            
            return recorrido;
        }


    }
}
