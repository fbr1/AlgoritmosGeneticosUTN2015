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
        const double PROB_MUTACION = 0.05;

        // Metodos
        static void Main(string[] args)
        {
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
            }           
            foreach (Individuo ind in individuos)
            {
                ind.Fitness = ind.FuncionObjetiva / suma;                
            }
			
            Console.WriteLine();
            Console.WriteLine("Suma= " + suma);
            Console.WriteLine();     

            foreach (Individuo ind in individuos)
            {
                Console.WriteLine(ind.Fitness);
            }

            // Seleccion
            
            Individuo[] seleccionados = new Individuo[POBLACION_SIZE];

            double[] fitnessAcumulado = new double[POBLACION_SIZE];
            fitnessAcumulado[0] = individuos[0].Fitness;

            Console.WriteLine();

            for(int i = 1; i<POBLACION_SIZE; i++){
                fitnessAcumulado[i] = fitnessAcumulado[i - 1] + individuos[i].Fitness;
                Console.WriteLine(fitnessAcumulado[i]);
            }

            Console.WriteLine();

            for(int i = 0; i<POBLACION_SIZE; i++){

                double random_number = rnd.NextDouble() * fitnessAcumulado[fitnessAcumulado.Length - 1];

                int indice = Array.BinarySearch(fitnessAcumulado,random_number);
                if(indice < 0){
                    indice = Math.Abs(indice + 1);
                }
                seleccionados[i] = individuos[indice];
                Console.WriteLine("Random Number: "+ random_number + " Fitness: " + seleccionados[i].Fitness + " Indice: " + indice); 
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

                        nuevaGeneracion[i].Cromosoma[j] = individuos[primerPadre].Cromosoma[j];
                        nuevaGeneracion[i + 1].Cromosoma[j] = individuos[segundoPadre].Cromosoma[j];                        
                    }
                    // Mutacion
                    for (int k = 0; k < 2; k++)
                    {
                        if (rnd.NextDouble() < 1)
                        {
                            int comienzo = 0;
                            int fin = 0;
                            do
                            {
                                comienzo = rnd.Next(0, Individuo.CROMOSOMA_SIZE);
                                fin = rnd.Next(0, Individuo.CROMOSOMA_SIZE);
                                if (comienzo > fin)
                                {
                                    int temp = comienzo;
                                    comienzo = fin;
                                    fin = temp;
                                }
                            } while (comienzo == fin);
                            int diferencia = fin - comienzo;
                            Console.WriteLine(comienzo + "," + fin + "," + diferencia);
                            int[] temp2 = nuevaGeneracion[i + k].Cromosoma;
                            for (int j = 0; j <= diferencia; j++)
                            {
                                
                                nuevaGeneracion[i + k].Cromosoma[comienzo + j] = temp2[fin - j];
                                Console.WriteLine((comienzo + j) + " = " + nuevaGeneracion[i + k].Cromosoma[comienzo + j] + "," + (fin - j) + " = " + temp2[fin - j]);
                            }
                            Console.WriteLine(string.Join("", temp2));                            
                            Console.WriteLine(string.Join("", nuevaGeneracion[i+k].Cromosoma));
                            Console.WriteLine("-------------------");
                        }
                    }


                }
                else
                {
                    nuevaGeneracion[i] = individuos[i];
                    nuevaGeneracion[i+1] = individuos[i+1];
                }
            }  
            

            Console.ReadLine();

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
