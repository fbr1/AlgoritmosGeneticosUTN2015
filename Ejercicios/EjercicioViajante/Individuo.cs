using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioViajante
{
    class Individuo
    {
        public enum Provincias
        {
            BUENOS_AIRES,
            SAN_SALVADOR_DE_JUJUY,
            SALTA,
            SAN_MIGUEL_DE_TUCUMAN,
            SANTIAGO_DEL_ESTERO,
            FORMOSA,
            RESISTENCIA,
            SANTA_FE,
            CORRIENTES,
            POSADAS,
            PARANA,
            CORDOBA,
            LA_RIOJA,
            SAN_JUAN,
            SAN_LUIS,
            CATAMARCA,
            MENDOZA,
            SANTA_ROSA,
            NEUQUEN,
            VIEDMA,
            RAWSON,
            RIO_GALLEGOS,
            USHUAIA 
        }
        // Constantes
        public const int CROMOSOMA_SIZE = 23;

        //Propiedades
        public Provincias[] Cromosoma { get; set; }

        public int ValorCromosoma { get; set; }
        public double FuncionObjetiva { get; set; }
        public double Fitness { get; set; }

        // Metodos
        public Individuo()
        {
            Cromosoma = new Provincias[CROMOSOMA_SIZE];
        }
        public Individuo(Random rnd)
            : this()
        {
            // Generar Cromosoma            
            for (int i = 0; i < Cromosoma.Length; i++)
            {
                Cromosoma[i] = GetRandomEnum<Provincias>(rnd);
            }
        }
        public int CalcularDistanciaTotal(int[,] distancia)
        {
            int distanciaTotal = 0;
            int provinciaDesde;
            int provinciaHasta;
            for (int i = 0; i < Cromosoma.Length-1; i++)
            {
                provinciaDesde = (int)Cromosoma[i];
                provinciaHasta = (int)Cromosoma[i+1];
                distanciaTotal += distancia[provinciaDesde, provinciaHasta];
            }
            distanciaTotal += distancia[(int)Cromosoma[22], (int)Cromosoma[0]];

            FuncionObjetiva = distanciaTotal;
            return distanciaTotal;
        }

        // Devuelve un enum aleatorio
        static T GetRandomEnum<T>(Random rnd)
        {
            System.Array A = System.Enum.GetValues(typeof(T));
            T randomEnum = (T)A.GetValue(rnd.Next(0, A.Length));
            return randomEnum;
        }

    }
}
