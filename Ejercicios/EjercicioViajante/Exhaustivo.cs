using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;

namespace EjercicioViajante
{
    class Exhaustivo : Algoritmo
    {
        // Variables  
        private int mejorDistanciaRecorrido = int.MaxValue / 4;
        private Node mejorNodo;
        public long CantidadTotalNodos { get; set; }
        public SortedSet<Node> cola = new SortedSet<Node>();
        public override List<Provincia> getRecorrido()
        {
            throw new NotImplementedException();
        }
        public List<Provincia> getRecorrido(BackgroundWorker bw)
        {
            Boolean ongoing=false;
            if (!ongoing)
            {
                // Crear nodo raiz
                Provincia[] provincias = new Provincia[1];
                provincias[0] = Algoritmo.Provincias[0];
                Node raiz = new Node(provincias, 1);
                raiz.Nivel = 1;
                CantidadTotalNodos++;
                raiz.calcularLowerBound();
                cola.Add(raiz);
                Debug.WriteLine(raiz.LowerBound);
            }
            // Mientras que no se pida la cancelacion y la cola no este vacia
            while(!bw.CancellationPending && cola.Count > 0)
            {
                Node siguiente = (Node)cola.First();
                if(siguiente.Longitud == FormularioPrincipal.SIZE-1 && siguiente.LowerBound < mejorDistanciaRecorrido)
                {
                    mejorDistanciaRecorrido = siguiente.LowerBound;                    
                    mejorNodo = siguiente;                                       
                    Debug.WriteLine("Mejor costo " + mejorDistanciaRecorrido);
                }
                cola.Remove(siguiente);
                if(siguiente.LowerBound < mejorDistanciaRecorrido)
                {
                    int nuevoNivel = siguiente.Nivel + 1;
                    Provincia[] siguienteProvincias = siguiente.Provincias;
                    int Longitud = siguiente.Longitud;

                    for(int IndProvincia = 0; !bw.CancellationPending && IndProvincia < FormularioPrincipal.SIZE;IndProvincia++)
                    {
                        if (!EstaPresente(IndProvincia, siguienteProvincias))
                        {
                            Provincia[] nuevoRecorrido = new Provincia[Longitud + 1];
                            for(int index = 0; index < Longitud; index++)
                            {
                                nuevoRecorrido[index] = siguienteProvincias[index];
                            }
                            nuevoRecorrido[Longitud] = Algoritmo.Provincias[IndProvincia];

                            Node nuevoNodo = new Node(nuevoRecorrido, Longitud+1);
                            nuevoNodo.Nivel = nuevoNivel;
                            CantidadTotalNodos++;

                            nuevoNodo.calcularLowerBound();
                            
                            int lowerBound = nuevoNodo.LowerBound;                           
                            
                            if (lowerBound< mejorDistanciaRecorrido)
                            {
                                cola.Add(nuevoNodo);
                            }
                            else
                            {
                                nuevoNodo = null;
                            }
                        }
                    }
                }
                else
                {
                    siguiente = null;
                }
            }
            if(mejorNodo != null)
            {
                Recorrido = mejorNodo.Provincias.ToList();
                LongitudRecorrido = mejorDistanciaRecorrido;
                Recorrido.Add(Recorrido[0]);
            }            
            
            return Recorrido;
        }

        private Boolean EstaPresente(int IndiceProvincias,Provincia[] provincias)
        {
            for (int i =0;i < provincias.Length;i++)
            {
                if(provincias[i].ID == IndiceProvincias)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
