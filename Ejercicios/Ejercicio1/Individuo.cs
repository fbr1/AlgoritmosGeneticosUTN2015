using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ejercicio1
{
    class Individuo
    {
        // Constantes
        public const int CROMOSOMA_SIZE = 30;
        public const double COEF = 1073741823;

        //Propiedades
        public int[] Cromosoma { get; set; }
        
        public int ValorCromosoma { get; set; }
        public double FuncionObjetiva { get; set; }
        public double Fitness { get; set; }

        // Metodos
        public Individuo()
        {
            Cromosoma = new int[CROMOSOMA_SIZE];            
        }
        public Individuo(Random rnd):this()
        {                        
            // Generar Cromosoma            
            for (int i = 0; i < Cromosoma.Length; i++)
            {
                Cromosoma[i] = rnd.Next(0, 2);
            }
            ValorCromosoma = Convert.ToInt32(string.Join("", Cromosoma), 2);
            FuncionObjetiva = Math.Pow(ValorCromosoma / COEF, 2);
        }

    }
}
