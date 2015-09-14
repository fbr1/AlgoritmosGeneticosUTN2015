using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioViajante
{
    class Individuo
    {
        // Constantes
        public const int CROMOSOMA_SIZE = 23;

        //Propiedades
        public Provincia[] Cromosoma { get; set; }

        public int ValorCromosoma { get; set; }
        public int FuncionObjetiva { get; set; }
        public double Fitness { get; set; }

        // Metodos
        public Individuo()
        {
            Cromosoma = new Provincia[CROMOSOMA_SIZE];

        }
        // Para la poblacion inicial
        public Individuo(int a)
            : this()
        {
            // Generar Cromosoma            

            double[] provincias = new double[23];

            // Genera lista aleatoria 
            for (int j = 0; j < Individuo.CROMOSOMA_SIZE; j++)
            {
                provincias[j] = RandomThreadSafe.NextDouble();
            }
            double[] provOrdenadas = new double[23];
            Array.Copy(provincias, provOrdenadas, provincias.Length);

            // Ordenar Lista
            Array.Sort(provincias);
            // Asignar provincia al indice j
            for (int j = 0; j < Individuo.CROMOSOMA_SIZE; j++)
            {
                for (int k = 0; k < Individuo.CROMOSOMA_SIZE; k++)
                {
                    if (provincias[j] == provOrdenadas[k])
                    {
                        Cromosoma[j] = Algoritmo.Provincias[k];
                        break;
                    }
                }
            }

            generarValores();
        }
        public void generarValores()
        {
            int distanciaTotal = 0;
            Provincia provinciaDesde;
            Provincia provinciaHasta;
            for (int i = 0; i < Cromosoma.Length - 1; i++)
            {
                provinciaDesde = Cromosoma[i];
                provinciaHasta = Cromosoma[i + 1];
                distanciaTotal += Algoritmo.Distancia[provinciaDesde.ID, provinciaHasta.ID];
            }
            distanciaTotal += Algoritmo.Distancia[Cromosoma[CROMOSOMA_SIZE-1].ID, Cromosoma[0].ID];

            FuncionObjetiva = distanciaTotal; 
        }

    }
}
