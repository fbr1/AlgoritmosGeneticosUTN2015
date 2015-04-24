using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Generacion
    {
        //Constants      
        public const int POBLACION_SIZE = 10;        
        public const double PROB_CROSSOVER = 0.75;
        public const double PROB_MUTACION = 0.05;

        //Variables
        private Individuo[] _poblacion = new Individuo[POBLACION_SIZE];
        private double _suma = 0;
        private double _maximo = 0;        

        //Properties
        public Individuo[] Poblacion { get; set; }
        public double Suma { get { return _suma; } set { _suma = value; } }    
        public double Maximo { get { return _maximo; } set { _maximo = value; } }        
        public int Ciclos { get; set; }

        //Methods
        public Generacion(Random rnd)
        {
            GenerarPoblacion(rnd);
        }
        public Generacion(Random rnd,int ciclos,ref List<Generacion> generaciones)
        {
            if (generaciones.Count == 0)
            {
                generaciones = new List<Generacion>();
                Generacion gen = new Generacion(rnd);
                generaciones.Add(gen);
                Generacion gen2= new Generacion(rnd,ciclos,ref generaciones);
            }
            else
            {
                if(generaciones.Count<=ciclos){
                    Generacion gen = new Generacion(generaciones.Last().Poblacion, rnd);
                    generaciones.Add(gen);
                    Generacion gen2 = new Generacion(rnd, ciclos,ref generaciones);
                }
                else
                {
                    var g = 1;
                }
            }
        }        
        public Generacion(Individuo[] poblacion,Random rnd)
        {
            this.Poblacion = poblacion;            
            // Selection

            Individuo[] seleccionados = new Individuo[POBLACION_SIZE];

            double[] fitnessAcumulado = new double[POBLACION_SIZE];
            fitnessAcumulado[0] = poblacion[0].Fitness;            

            for (int i = 1; i < POBLACION_SIZE; i++)
            {
                fitnessAcumulado[i] = fitnessAcumulado[i - 1] + poblacion[i].Fitness;
            }            

            for (int i = 0; i < POBLACION_SIZE; i++)
            {

                double random_number = rnd.NextDouble() * fitnessAcumulado[fitnessAcumulado.Length - 1];

                int indice = Array.BinarySearch(fitnessAcumulado, random_number);
                if (indice < 0)
                {
                    indice = Math.Abs(indice + 1);
                }
                seleccionados[i] = poblacion[indice];
            }

            Individuo[] nuevaGeneracion = new Individuo[POBLACION_SIZE];
            GenerarPoblacion(nuevaGeneracion);

            // Crossover

            for (int i = 0; i < POBLACION_SIZE; i = i + 2)
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
            this.Poblacion = nuevaGeneracion;
            this.GenerarPoblacion(rnd);

        }
            
        private void Mutar(int[] cromosoma, Random rnd)
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
                cromosoma[comienzo + i] = copia[(fin - 1) - i];
            }
        }
        private void GenerarPoblacion(Individuo[] poblacion)
        {
            for (int i = 0; i < poblacion.Length; i++)
            {
                poblacion[i] = new Individuo();
            }
        }
        public void GenerarPoblacion(Random rnd)
        {            
            if (this.Poblacion == null)
            {
                Individuo[] poblacion = new Individuo[POBLACION_SIZE];
                for (int i = 0; i < poblacion.Length; i++)
                {
                    poblacion[i] = new Individuo(rnd);
                }
                this.Poblacion = poblacion;
            }
            else
            {
                foreach (Individuo ind in this.Poblacion)
                {
                    ind.generarValores();
                }
            }            

            foreach (Individuo ind in this.Poblacion)
            {
                this.Suma = this.Suma + ind.FuncionObjetiva;
                if (ind.FuncionObjetiva > this.Maximo)
                {
                    this.Maximo = ind.FuncionObjetiva;
                }
            }
            foreach (Individuo ind in this.Poblacion)
            {
                ind.Fitness = ind.FuncionObjetiva / this.Suma;
            }    
            
        }
    }  
}
