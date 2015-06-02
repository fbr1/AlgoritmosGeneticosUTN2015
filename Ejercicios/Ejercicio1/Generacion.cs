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
        private double _suma = 0;
        private double _maximo = 0;    
        private double _minimo=Double.MaxValue;        

        //Properties
        public Individuo[] Poblacion { get; set; }
        public double Suma { get { return _suma; } set { _suma = value; } }    
        public double Maximo { get { return _maximo; } set { _maximo = value; } }
        public double Minimo { get { return _minimo; } set { _minimo = value; } }       
        public int Ciclos { get; set; }

        //Methods
        public Generacion(Random rnd)
        {
            GenerarPoblacion(rnd);
        }
        // Constructor para la recursividad
        // Se tendria que cambiar a un metodo de clase o algo similar, no me gusta la forma que funciona
        // Creo que en la pseudo recursividad hace pasos de mas, habría que fijarse de mejorarlo
        public Generacion(Random rnd,int ciclos,ref List<Generacion> generaciones)
        {            
            // Si es la primera vez que se crea el objeto
            if (generaciones.Count == 0)
            {
                // Crea el objeto y lo agrega a generaciones                
                Generacion gen = new Generacion(rnd);
                generaciones.Add(gen);
                // Crea nueva generacion ya con una existente en generaciones
                Generacion gen2= new Generacion(rnd,ciclos,ref generaciones);
            }
            else
            {
                if(generaciones.Count<ciclos){
                    // Crea nueva generacion pasando la poblacion de la ultima en la lista para realizar la seleccion-crossover-mutacion
                    Generacion gen = new Generacion(generaciones.Last().Poblacion, rnd);
                    generaciones.Add(gen);
                    Generacion gen2 = new Generacion(rnd, ciclos,ref generaciones);
                }                
            }
            // Hasta que el numero de ciclos se complete
        }        
        public Generacion(Individuo[] poblacion,Random rnd)
        {
            this.Poblacion = poblacion;
            Individuo[] copia = new Individuo[poblacion.Length];                
            Array.Copy(poblacion, copia, poblacion.Length);
         
            // Selection

            Individuo[] seleccionados = new Individuo[POBLACION_SIZE];

            // Genera fitnesAcumulado para simular la seleccion por ruleta
            double[] fitnessAcumulado = new double[POBLACION_SIZE];
            fitnessAcumulado[0] = poblacion[0].Fitness;            

            for (int i = 1; i < POBLACION_SIZE; i++)
            {
                fitnessAcumulado[i] = fitnessAcumulado[i - 1] + poblacion[i].Fitness;
            }       
     
            // Selecciona que padre van a hacer crossover y en que orden

            for (int i = 0; i < POBLACION_SIZE; i++)
            {

                double random_number = rnd.NextDouble() * fitnessAcumulado[fitnessAcumulado.Length - 1];

                // Busca coincidencia de el numero buscado al azar dentro de fitness acumulado
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
            // Para cada dos padres
            for (int i = 0; i < POBLACION_SIZE-2; i = i + 2)
            {
                // Si se da la chance de crossover
                if (rnd.NextDouble() <= PROB_CROSSOVER)
                {
                    int posicion = rnd.Next(0, Individuo.CROMOSOMA_SIZE);
                    int primerPadre = i;
                    int segundoPadre = i + 1;
                    for (int j = 0; j < Individuo.CROMOSOMA_SIZE; j++)
                    {
                        // Cuando se llega al punto de corte, intercambia los padres para poder mezclar los dos cromosomas
                        // El nombre de la variable no es muy representativo una vez que se realiza el cambio
                        if (posicion == j)
                        {
                            int temp = primerPadre;
                            primerPadre = segundoPadre;
                            segundoPadre = temp;
                        }

                        nuevaGeneracion[i].Cromosoma[j] = seleccionados[primerPadre].Cromosoma[j];
                        nuevaGeneracion[i + 1].Cromosoma[j] = seleccionados[segundoPadre].Cromosoma[j];
                    }                    
                }
                else
                {
                    // Si la chance no genera crossover los padres pasan a ser hijos
                    nuevaGeneracion[i] = seleccionados[i];
                    nuevaGeneracion[i + 1] = seleccionados[i + 1];
                }               
            }
            // Mutation
            for (int i = 0; i < POBLACION_SIZE-2; i++)
            {
                if (rnd.NextDouble() < PROB_MUTACION)
                {
                     Mutar(nuevaGeneracion[i].Cromosoma, rnd);
                }
            }  

            // Elitismo            
            Individuo max1 = new Individuo();
            Individuo max2 = new Individuo();
            max1.Fitness = 0;
            max2.Fitness = 0;
            for (int i = 0; i < POBLACION_SIZE; i++)
            {
                if (copia[i].Fitness > max1.Fitness)
                {
                    max2 = max1;
                    max1 = copia[i];
                }
                else if ((copia[i].Fitness != max1.Fitness) && (copia[i].Fitness > max2.Fitness)){                
                    max2 = copia[i];
                }
            }            
            nuevaGeneracion[8] = max1;
            nuevaGeneracion[9] = max2;

            this.Poblacion = nuevaGeneracion;
            this.GenerarPoblacion(rnd);
        }
            
        
        private void Mutar(int[] cromosoma, Random rnd)
        {            
            int posicion= rnd.Next(0, cromosoma.Length); 
            cromosoma[posicion] = cromosoma[posicion] == 0 ? 1 : 0;            
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
            // Si no esta generando la población inicial
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
                for (int i = 0; i < POBLACION_SIZE - 2; i++)
                {
                    this.Poblacion[i].generarValores();
                }
            }
            this.Suma = 0;
            foreach (Individuo ind in this.Poblacion)
            {                
                this.Suma = this.Suma + ind.FuncionObjetiva;
                if (ind.FuncionObjetiva > this.Maximo)
                {
                    this.Maximo = ind.FuncionObjetiva;
                }
                if (ind.FuncionObjetiva < this.Minimo)
                {
                    this.Minimo = ind.FuncionObjetiva;
                }
            }
            for (int i = 0; i < POBLACION_SIZE - 2; i++)
            {
                this.Poblacion[i].Fitness = this.Poblacion[i].FuncionObjetiva / this.Suma;
            } 
            
        }
       // Mutacion inversa
       /* private void Mutar(int[] cromosoma, Random rnd)
        {
            // Generar dos indices aleatorios
            int comienzo = 0;
            int fin = 0;

            do
            {
                comienzo = rnd.Next(0, cromosoma.Length);
                fin = rnd.Next(0, cromosoma.Length);
            } while (comienzo == fin);

            // Verificar orden
            if (comienzo > fin)
            {
                int temp = comienzo;
                comienzo = fin;
                fin = temp;
            }

            // Mutar
            int[] copia = new int[cromosoma.Length];
            Array.Copy(cromosoma, copia, cromosoma.Length);
            int diferencia = fin - comienzo;
            for (int i = 0; i < diferencia; i++)
            {
                cromosoma[comienzo + i] = copia[(fin - 1) - i];
            }
        }*/
    }  
}
