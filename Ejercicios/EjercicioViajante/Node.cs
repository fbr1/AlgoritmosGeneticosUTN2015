using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioViajante
{
    class Node : IComparable
    {
        // Variables
        public int LowerBound { get; set; }
        public int Longitud { get; set; }
        public Provincia[] Provincias { get; set; }
        public Boolean[] Bloqueado = new Boolean[FormularioPrincipal.SIZE];
        public int Nivel { get; set; } // del arbol
        public Node(Provincia[] provincias,int Longitud)
        {
            this.Longitud = Longitud;
            this.Provincias = provincias;
        }
        public void calcularLowerBound()
        {
            LowerBound = 0;
            if (Longitud == 1)
            {
                for (int i=0;i < FormularioPrincipal.SIZE;i++)
                {
                    LowerBound += minimo(i);
                }
            }
            else
            {
                Bloqueado[0] = true;
                for (int i = 1; i < Longitud; i++)
                {
                    Bloqueado[Provincias[i].ID] = true;
                    LowerBound += Algoritmo.Distancia[Provincias[i-1].ID, Provincias[i].ID];
                }                
                //LowerBound += minimo(Provincias[Longitud-1].ID);
               // Bloqueado[0] = false;
                Bloqueado[Provincias[Longitud-1].ID] = true;
                for(int i=1;i< FormularioPrincipal.SIZE; i++)
                {
                    if (!Bloqueado[i])
                    {
                        LowerBound += minimo(i);
                    }
                }
                
            }
        }
        private int minimo(int index)
        {
            int smallest = int.MaxValue;
            for(int col = 0; col < FormularioPrincipal.SIZE; col++)
            {                
                if(!Bloqueado[col] && col !=index && Algoritmo.Distancia[index,col] < smallest)
                {
                    smallest = Algoritmo.Distancia[index, col];
                }
            }
            if (smallest== int.MaxValue)
            {
                int asd = 1;
            }
            return smallest;
        }        
        public int CompareTo(object obj)
        {
            if (this == obj)
            {
                return 0;
            }
            Node other = (Node)obj;
            if(Longitud< other.Longitud)
            {
                return 1;
            }else if(Longitud> other.Longitud)
            {
                return -1;
            }else if(Longitud == other.Longitud)
            {
                if(LowerBound < other.LowerBound)
                {
                    return -1;
                }else if(LowerBound > other.LowerBound)
                {
                    return 1;
                }else if(LowerBound == other.LowerBound)
                {
                    int sumaThis = 0;
                    for(int i=0;i<Longitud; i++)
                    {
                        sumaThis += Provincias[i].ID;
                    }
                    int sumaOther = 0;
                    for (int i = 0; i < other.Longitud; i++)
                    {
                        sumaOther += other.Provincias[i].ID;
                    }
                    if (sumaThis < sumaOther)
                    {
                        return -1;
                    }else if(sumaThis > sumaOther)
                    {
                        return 1;
                    }

                }
            }
            throw new Exception("Error en la comparacion de nodos. El objeto no puede llegar a ser un nodo");
        }
        
    }
}
