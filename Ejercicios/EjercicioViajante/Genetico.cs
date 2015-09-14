using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

namespace EjercicioViajante 
{
    class Genetico : Algoritmo
    {
        const int CICLOS = 400;
        const int ITERACIONES = 1000;

        public override List<Provincia> getRecorrido()
        {
            return null;
        }
        public List<Provincia> getRecorrido(BackgroundWorker bw)
        {
            Random random = new Random();
            //List<Generacion> generaciones = new List<Generacion>();            
            //Generacion.rnd = random;
            //Generacion generacion = new Generacion(CICLOS, ref generaciones);
            //int mindistancia = 999999999;


            int distanciaMin = int.MaxValue;
            Individuo individuo = null;
            List<Generacion> mejorgeneraciones = null;

            object sync = new object();

            Parallel.For<Tuple<int,Individuo, List<Generacion>>>(0, ITERACIONES,
                () => new Tuple<int, Individuo, List<Generacion>>(int.MaxValue,null, null),
                (j, loopState, localState) =>
            {
                if (bw.CancellationPending) loopState.Break();

                int mindistancia = int.MaxValue;
                Individuo recorridoIndividuo = null;
                List<Generacion> bestgeneraciones = null;
                List<Generacion> generaciones = new List<Generacion>();
                Generacion generacion = new Generacion(CICLOS, ref generaciones);
                foreach (Individuo ind in generaciones.Last().Poblacion)
                {
                    if (ind.FuncionObjetiva < mindistancia)
                    {
                        recorridoIndividuo = ind;
                        mindistancia = ind.FuncionObjetiva;
                        bestgeneraciones = generaciones;
                    }
                }
                if (mindistancia < localState.Item1)
                {
                    return new Tuple<int, Individuo, List<Generacion>>(mindistancia, recorridoIndividuo,bestgeneraciones);
                }
                else
                {
                    return localState;
                }
                    
                },
                localState =>
                {
                    lock (sync)
                    {
                        if (localState.Item1 < distanciaMin)
                        {
                            distanciaMin = localState.Item1;
                            individuo = localState.Item2;
                            mejorgeneraciones = localState.Item3;
                        }
                    }
                }
            );



            //for (int j = 0; j < 100; j++)
            //{
            //    if (bw.CancellationPending) break;
            //    List<Generacion> generaciones = new List<Generacion>();                
            //    Generacion generacion = new Generacion(CICLOS, ref generaciones);
            //    foreach (Individuo ind in generaciones.Last().Poblacion)
            //    {
            //        if (ind.FuncionObjetiva < mindistancia)
            //        {
            //            recorridoIndividuo = ind;
            //            mindistancia = ind.FuncionObjetiva;
            //            bestgeneraciones = generaciones;
            //        }
            //    }
            //}


            List <Provincia> recorrido = new List<Provincia>();
            foreach(Provincia prov in individuo.Cromosoma)
            {
                recorrido.Add(prov);
            }
            // Cierra el recorrido
            recorrido.Add(individuo.Cromosoma[0]);

            LongitudRecorrido = distanciaMin;
            Recorrido = recorrido;
            string stream = "Iteracion;Suma;Maximo;Promedio;Minimo" + Environment.NewLine;
            int i = 0;
            System.IO.StreamWriter file = new System.IO.StreamWriter("test.csv");
            foreach (Generacion gen in mejorgeneraciones)
            {
                i++;
                stream = stream + i + ";" + gen.Suma + ";" + gen.Maximo + ";" + gen.Suma / Generacion.POBLACION_SIZE + ";" + gen.Minimo;

                file.WriteLine(stream);
                stream = "";
            }
            file.Close();

            return recorrido;
        }


    }
}
