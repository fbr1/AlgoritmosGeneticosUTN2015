using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {
        //Constantes        
        const int POBLACION_SIZE = 10;
        const int CICLOS = 20;
        const double PROB_CROSSOVER = 0.75;
        const double PROB_MUTACION = 1;

        // Metodos
        static void Main(string[] args)
        {
            double maximo=0;
            Individuo[] individuos = new Individuo[POBLACION_SIZE];


            // Creacion
            Random rnd = new Random();
            GenerarIndividuos(individuos,rnd);
            
            double suma = 0;

            foreach (Individuo ind in individuos)
            {
                Console.WriteLine(string.Join("",ind.Cromosoma));
            }

            foreach(Individuo ind in individuos)
            {
                suma = suma + ind.FuncionObjetiva;
                if(ind.FuncionObjetiva>maximo){
                    maximo = ind.FuncionObjetiva;
                }
            }           
            foreach (Individuo ind in individuos)
            {
                ind.Fitness = ind.FuncionObjetiva / suma;                
            }

            Console.WriteLine();
            Console.WriteLine("Suma= " + suma);            
            Console.WriteLine("Promedio= " + suma/POBLACION_SIZE);            
            Console.WriteLine("Maximo= " + maximo);
            Console.WriteLine();

            // Seleccion
            
            Individuo[] seleccionados = new Individuo[POBLACION_SIZE];

            double[] fitnessAcumulado = new double[POBLACION_SIZE];
            fitnessAcumulado[0] = individuos[0].Fitness;

            Console.WriteLine();

            for(int i = 1; i<POBLACION_SIZE; i++){
                fitnessAcumulado[i] = fitnessAcumulado[i - 1] + individuos[i].Fitness;                
            }

            Console.WriteLine();

            for(int i = 0; i<POBLACION_SIZE; i++){

                double random_number = rnd.NextDouble() * fitnessAcumulado[fitnessAcumulado.Length - 1];

                int indice = Array.BinarySearch(fitnessAcumulado,random_number);
                if(indice < 0){
                    indice = Math.Abs(indice + 1);
                }
                seleccionados[i] = individuos[indice];                
            }

            Individuo[] nuevaGeneracion = new Individuo[POBLACION_SIZE];
            GenerarIndividuos(nuevaGeneracion);

            // Crossover

            for (int i = 0; i < POBLACION_SIZE ; i=i+2)
            {                
                if (rnd.NextDouble() <= PROB_CROSSOVER)
                {
                    int posicion = rnd.Next(0, Individuo.CROMOSOMA_SIZE);                    
                    int primerPadre = i;
                    int segundoPadre = i + 1;
                    for (int j = 0; j < Individuo.CROMOSOMA_SIZE; j++)
                    {                        
                        if (posicion == j)
                        {
                            int temp = primerPadre;
                            primerPadre = segundoPadre;
                            segundoPadre = temp;
                        }

                        nuevaGeneracion[i].Cromosoma[j] = seleccionados[primerPadre].Cromosoma[j];
                        nuevaGeneracion[i + 1].Cromosoma[j] = seleccionados[segundoPadre].Cromosoma[j];                        
                    }
                    // Mutation
                    for (int k = 0; k < 2; k++)
                    {
                        if (rnd.NextDouble() < PROB_MUTACION)
                        {
                            Mutar(nuevaGeneracion[i + k].Cromosoma, rnd);
                        }
                    }
                }
                else
                {
                    nuevaGeneracion[i] = seleccionados[i];
                    nuevaGeneracion[i + 1] = seleccionados[i + 1];
                }
            }
                              

            Console.ReadLine();

        }
        static private void Mutar(int[] cromosoma,Random rnd)
        {
            // Generate two random indices
            int comienzo = 0;
            int fin = 0;
            
            do
            {
                comienzo = rnd.Next(0, cromosoma.Length);
                fin = rnd.Next(0, cromosoma.Length);                
            } while (comienzo == fin);

            // Check order
            if (comienzo > fin)
            {
                int temp = comienzo;
                comienzo = fin;
                fin = temp;
            }          
  
            // Mutation 
            int[] copia = new int[cromosoma.Length];
            Array.Copy(cromosoma, copia, cromosoma.Length);
            int diferencia = fin - comienzo;            
            for (int i = 0; i < diferencia; i++)
            {                
                cromosoma[comienzo+i] = copia[(fin -1) - i];                
            }            
        }
        static private void GenerarIndividuos(Individuo[] individuos)
        {
            for (int i = 0; i < individuos.Length; i++)
            {
                individuos[i] = new Individuo();
            }
        }
        static private void GenerarIndividuos(Individuo[] individuos, Random rnd)
        {            
            for (int i = 0; i < individuos.Length; i++)
            {
                individuos[i] = new Individuo(rnd);
            }
        }
    }
}
