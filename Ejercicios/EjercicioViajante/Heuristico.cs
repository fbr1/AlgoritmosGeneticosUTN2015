using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioViajante
{
    class Heuristico : Algoritmo
    {
        const int BIG_VALUE_DISTANCIA = 9999999;
        public Provincia ProvinciaInicial { get; set; }

        public Heuristico(int[,] distancia, List<Provincia> provincias):base(distancia,provincias)
        {
        }

        // Devuelve el recorrido minimo segun la provincia inical indicada
        public List<Provincia> getRecorrido(Provincia provinciaInicial)
        {

            List<Provincia> recorrido = new List<Provincia>();
            recorrido.Add(provinciaInicial);

            byte[] visitadas = new byte[23];
            visitadas[provinciaInicial.ID] = 1;

            Provincia ultimaVisitada = provinciaInicial;


            int cantProvincias = this.Provincias.Count;

            int longitudRecorrido = 0;

            for (int i = 0; i < cantProvincias - 1; i++)
            {
                int minDistancia = BIG_VALUE_DISTANCIA;
                int minDistanciaProvinciaId = 0;
                // Para cada una de las posibles provincias
                for (int j = 0; j < cantProvincias; j++)
                {
                    // Si no fue visitada
                    if (visitadas[j] == 0)
                    {
                        // Si la distancia a la provincia j es menor que la ultima minima distancia
                        if (Distancia[ultimaVisitada.ID, j] < minDistancia)
                        {
                            minDistancia = Distancia[ultimaVisitada.ID, j];
                            minDistanciaProvinciaId = j;
                        }
                    }
                }
                longitudRecorrido += minDistancia;

                // Pone la provincia como visitada
                visitadas[minDistanciaProvinciaId] = 1;

                ultimaVisitada = this.Provincias.Find(x => x.ID == minDistanciaProvinciaId);
                recorrido.Add(ultimaVisitada);

            }
            this.LongitudRecorrido = longitudRecorrido + Distancia[recorrido.Last().ID, provinciaInicial.ID];

            recorrido.Add(provinciaInicial);

            this.Recorrido = recorrido;
            return recorrido;

        }
        // Busca el mejor recorrido
        public override List<Provincia> getRecorrido()
        {            
            int distanciaMin = 99999999;
            List<Provincia> mejorRecorrido = null;
            foreach (Provincia prov in this.Provincias)
            {
                List<Provincia> recorrido = getRecorrido(prov);
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
