using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioViajante
{
    class Heuristico
    {
        public Individuo.Provincias ProvinciaInicial { get; set; }
        public int[,] Distancia { get; set; }
        public int LongitudRecorrido { get; set; }
        public List<Individuo.Provincias> Recorrido { get; set; }

        public Heuristico(int[,] distancia)
        {
            this.Distancia = distancia;
        }
        public Heuristico(int[,] distancia, Individuo.Provincias provincia) : this(distancia)
        {
            this.ProvinciaInicial = provincia;
        }

        // Devuelve el recorrido minimo segun la la provincia inical
        public List<Individuo.Provincias> getRecorrido(Individuo.Provincias provinciaInicial)
        {

            List<Individuo.Provincias> recorrido = new List<Individuo.Provincias>();
            recorrido.Add(provinciaInicial);

            byte[] visitadas = new byte[23];
            visitadas[(int)provinciaInicial] = 1;

            Individuo.Provincias ultimaVisitada = provinciaInicial;


            int cantProvincias = Enum.GetNames(typeof(Individuo.Provincias)).Length;

            int longitudRecorrido = 0;

            for (int i = 0; i < cantProvincias - 1; i++)
            {
                int minDistancia = 99999999;
                int minDistanciaProvincia = 0;
                // Para cada una de las posibles provincias
                for (int j = 0; j < cantProvincias; j++)
                {
                    // Si no fue visitada
                    if (visitadas[j] == 0)
                    {
                        // Si la distancia a la provincia j es menor que la ultima minima distancia
                        if (Distancia[(int)ultimaVisitada, j] < minDistancia)
                        {
                            minDistancia = Distancia[(int)ultimaVisitada, j];
                            minDistanciaProvincia = j;
                        }
                    }
                }
                longitudRecorrido += minDistancia;
                visitadas[minDistanciaProvincia] = 1;
                recorrido.Add((Individuo.Provincias)minDistanciaProvincia);

            }
            this.LongitudRecorrido = longitudRecorrido + Distancia[(int)recorrido.Last(), (int)provinciaInicial];

            recorrido.Add(provinciaInicial);

            this.Recorrido = recorrido;
            return recorrido;

        }
        public List<Individuo.Provincias> getBestRecorrido()
        {
            List<Individuo.Provincias> provincias = Enum.GetValues(typeof(Individuo.Provincias)).Cast<Individuo.Provincias>().ToList();
            int distanciaMin = 99999999;
            List<Individuo.Provincias> mejorRecorrido = null;
            foreach (Individuo.Provincias prov in provincias)
            {
                List<Individuo.Provincias> recorrido = getRecorrido(prov);
                if (LongitudRecorrido < distanciaMin)
                {
                    mejorRecorrido = recorrido;
                    distanciaMin = LongitudRecorrido;
                }
            }
            this.LongitudRecorrido = distanciaMin;
            return mejorRecorrido;
        }

    }
}
