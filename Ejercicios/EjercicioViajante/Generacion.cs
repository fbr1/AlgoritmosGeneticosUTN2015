using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EjercicioViajante
{
    class Generacion
    {
        // Constantes
        public const int POBLACION_SIZE = 50;
        public const int NRO_ELITE = 2; // Multiplo de 2

        //Variables de Clase 
        public static double PROB_CROSSOVER { get; set; }
        public static double PROB_MUTACION { get; set; }


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
        public Generacion(int ciclos,ref List<Generacion> generaciones)
        {            
            // Si es la primera vez que se crea el objeto
            if (generaciones.Count == 0)
            {
                // Crea el objeto y lo agrega a generaciones                
                Generacion gen = new Generacion();
                generaciones.Add(gen);
                // Crea nueva generacion ya con una existente en generaciones
                Generacion nuevaGeneracion= new Generacion(ciclos,ref generaciones);
            }
            else
            {
                if(generaciones.Count<ciclos){
                    // Crea nueva generacion pasando la poblacion de la ultima en la lista para realizar la seleccion-crossover-mutacion
                    Generacion gen = new Generacion(generaciones.Last().Poblacion);
                    generaciones.Add(gen);
                    Generacion nuevaGeneracion = new Generacion(ciclos,ref generaciones);
                }                
            }
            // Hasta que el numero de ciclos se complete
        }        
        public Generacion()
        {
            GenerarPoblacion();
        }
        public Generacion(Individuo[] poblacion)
        {            
            this.Poblacion = poblacion;
         
            // Selection

            Individuo[] seleccionados = Seleccion(poblacion);

            // Crossover

            Individuo[] nuevaGeneracion = CrossOver(seleccionados);

            // Mutation

            Mutacion(nuevaGeneracion);

            //TODO elitismo

            // Elitismo            

            Individuo[] copia = new Individuo[poblacion.Length];
            Array.Copy(poblacion, copia, poblacion.Length);


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
                else if ((copia[i].Fitness != max1.Fitness) && (copia[i].Fitness > max2.Fitness))
                {
                    max2 = copia[i];
                }
            }
            nuevaGeneracion[48] = max1;
            nuevaGeneracion[49] = max2;

            this.Poblacion = nuevaGeneracion;
            this.GenerarPoblacion();
            //Debug.WriteLine(this.Minimo+" "+ this.Maximo);
        }
            
        
        private Individuo[] Seleccion(Individuo[] poblacion)
        {
            // Genera fitnesAcumulado para simular la seleccion por ruleta
            double[] fitnessAcumulado = new double[POBLACION_SIZE];
            fitnessAcumulado[0] = poblacion[0].Fitness;

            for (int i = 1; i < POBLACION_SIZE; i++)
            {
                fitnessAcumulado[i] = fitnessAcumulado[i - 1] + poblacion[i].Fitness;
            }

            Individuo[] seleccionados = new Individuo[POBLACION_SIZE];

            // Selecciona que padre van a hacer crossover y en que orden
            for (int i = 0; i < POBLACION_SIZE; i++)
            {

                double random_number = RandomThreadSafe.NextDouble() * fitnessAcumulado[fitnessAcumulado.Length - 1];

                // Busca coincidencia de el numero buscado al azar dentro de fitness acumulado
                int indice = Array.BinarySearch(fitnessAcumulado, random_number);
                if (indice < 0)
                {
                    indice = Math.Abs(indice + 1);
                }
                seleccionados[i] = poblacion[indice];
            }
            return seleccionados;
        }
        private Individuo[] CrossOver(Individuo[] seleccionados)
        {
            Individuo[] nuevaGeneracion = new Individuo[POBLACION_SIZE];
            GenerarPoblacion(nuevaGeneracion);

            for (int i = 0; i < POBLACION_SIZE - NRO_ELITE; i += 2)
            {
                // Si se da la chance de crossover
                if (RandomThreadSafe.NextDouble() <= PROB_CROSSOVER)
                {
                    int indicePrimerPadre = i;
                    int indiceSegundoPadre = i + 1;
                    // Para cada hijo 
                    for (int j = i; j < i + 2; j++)
                    {
                        Provincia primerGen = seleccionados[indicePrimerPadre].Cromosoma[0];
                        Provincia gen = primerGen;
                        // Mientras no se haya vuelto al primer gen
                        do
                        {
                            // Asigna gen del segundo padre correspondiente al indice del gen del primer padre
                            nuevaGeneracion[j].Cromosoma[gen.ID] = seleccionados[indiceSegundoPadre].Cromosoma[gen.ID];
                            // Encuentra gen en el primer padre que tiene el mismo valor que el recien encontrado en el segundo padre

                            for (int k = 0; k < Individuo.CROMOSOMA_SIZE; k++)
                            {
                                if (seleccionados[indicePrimerPadre].Cromosoma[k] == seleccionados[indiceSegundoPadre].Cromosoma[gen.ID])
                                {
                                    gen = seleccionados[indicePrimerPadre].Cromosoma[k];
                                    break;
                                }
                            }

                        } while (primerGen != gen);
                        // Rellena las posiciones restantes con los genes del segundo padre
                        for (int k = 0; k < Individuo.CROMOSOMA_SIZE; k++)
                        {
                            if (nuevaGeneracion[j].Cromosoma[k] == null)
                            {
                                nuevaGeneracion[j].Cromosoma[k] = seleccionados[indiceSegundoPadre].Cromosoma[k];
                            }
                        }
                        // Intercambia los padres
                        int indiceTemp = indicePrimerPadre;
                        indicePrimerPadre = indiceSegundoPadre;
                        indiceSegundoPadre = indiceTemp;
                    }
                }
                else
                {
                    // Si la chance no genera crossover los padres pasan a ser hijos
                    nuevaGeneracion[i] = seleccionados[i];
                    nuevaGeneracion[i + 1] = seleccionados[i + 1];
                }
            }
            return nuevaGeneracion;
        }
        private void Mutacion(Individuo[] nuevaGeneracion)
        {
            for (int i = 0; i < POBLACION_SIZE - NRO_ELITE; i++)
            {
                if (RandomThreadSafe.NextDouble() < PROB_MUTACION)
                {
                    int numeroAleatorio1 = RandomThreadSafe.Next(0, Individuo.CROMOSOMA_SIZE);
                    int numeroAleatorio2 = RandomThreadSafe.Next(0, Individuo.CROMOSOMA_SIZE);
                    Provincia temp = nuevaGeneracion[i].Cromosoma[numeroAleatorio1];
                    nuevaGeneracion[i].Cromosoma[numeroAleatorio1] = nuevaGeneracion[i].Cromosoma[numeroAleatorio2];
                    nuevaGeneracion[i].Cromosoma[numeroAleatorio2] = temp;
                }
            }            
        }
        private void GenerarPoblacion(Individuo[] poblacion)
        {
            for (int i = 0; i < poblacion.Length; i++)
            {
                poblacion[i] = new Individuo();
            }
        }
        public void GenerarPoblacion()
        {   
            // Si no esta generando la población inicial
            if (this.Poblacion == null)
            {
                Individuo[] poblacion = new Individuo[POBLACION_SIZE];
                for (int i = 0; i < poblacion.Length; i++)
                {
                    poblacion[i] = new Individuo(0);
                }
                this.Poblacion = poblacion;
            }
            else
            {   
                for (int i = 0; i < POBLACION_SIZE - NRO_ELITE; i++)
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
            for (int i = 0; i < POBLACION_SIZE - NRO_ELITE; i++)
            {
                this.Poblacion[i].Fitness = 1-(this.Poblacion[i].FuncionObjetiva / this.Suma);
            } 
            
        }
       // Mutacion inversa
       /* private void Mutar(int[] cromosoma, Random Generacion.rnd)
        {
            // Generar dos indices aleatorios
            int comienzo = 0;
            int fin = 0;

            do
            {
                comienzo = Generacion.rnd.Next(0, cromosoma.Length);
                fin = Generacion.rnd.Next(0, cromosoma.Length);
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
