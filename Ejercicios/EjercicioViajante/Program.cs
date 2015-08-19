using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioViajante
{
    class Program
    {
        const int VACIO = 9999;
        const int SIZE = 5;        
        static void Main(string[] args)
        {
            int[,] distancia;
            if ((distancia = GetDistanceMatrix()) !=null)
            {
                int[] select = new int[5];
                for(int i = 0; i < SIZE; i++)
                {
                    select[i] = 0;
                }

                RowReduction(distancia);
                ColumnReduction(distancia);

                //int k = SIZE * 2;
                int k = 0;
                int j = 0;
                while (!allVisited(select))
                {
                    showDistancia(distancia);
                    int[] edgeCost = new int[SIZE];
                    for (int i = 0; i < SIZE; i++)
                    {
                        if (select[i] == 0)
                        {
                            edgeCost[i] = CheckBounds(k, i, distancia);
                        }
                    }

                    int min = VACIO;

                    for (int i = 0; i < SIZE; i++)
                    {
                        if (select[i] == 0)
                        {
                            if (edgeCost[i] < min)
                            {
                                min = edgeCost[i];
                                k = i;
                            }
                        }
                    }

                    select[k] = 1;

                    for (int p = 0; p < SIZE; p++)
                    {
                        distancia[j, p] = VACIO;
                    }
                    for (int p = 0; p < SIZE; p++)
                    {
                        distancia[p,k] = VACIO;
                    }
                    distancia[k, j] = VACIO;
                    RowReduction(distancia);
                    ColumnReduction(distancia);
                    j++;
                }
            }            

            Console.ReadLine();

        
        }
        private static void showDistancia(int[,] distancia)
        {
            for (int i = 0; i < distancia.GetLength(0); i++)
            {
                for (int j = 0; j < distancia.GetLength(1); j++)
                {
                    Console.Out.Write(distancia[i, j] + "\t");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

        }
        private static bool allVisited(int[] select)
        {
            for(int i=0; i< SIZE; i++)
            {
                if (select[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private static int CheckBounds(int st,int des,int[,] distancia)
        {
            int[] penCost = new int[SIZE];
            penCost[0] = 0;
            int[,] reduced = new int[SIZE,SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    reduced[i, j] = distancia[i, j];
                }
            }

            for(int j = 0; j< SIZE; j++)
            {
                reduced[st, j] = VACIO;
            }
            for (int i = 0; i < SIZE; i++)
            {
                reduced[i,des] = VACIO;
            }
            showDistancia(reduced);
            RowReduction(reduced);
            ColumnReduction(reduced);
            showDistancia(reduced);
            penCost[des] = penCost[st] + 5 + 5 + distancia[st, des];
            return penCost[des];

        }
        // Reduce cada fila en un valor igual al mínimo elemento de la fila dada
        private static void RowReduction(int[,] distancia)
        {
            int row = 0;
            for(int i = 0; i< SIZE; i++)
            {
                int minRow = MinRow(distancia,i);
                if(minRow != VACIO)
                {
                    row += minRow;
                }
                for(int j=0; j < SIZE; j++)
                {
                    if (distancia[i,j] != VACIO)
                    {
                        distancia[i, j] -= minRow;
                    }
                }
            }
        }
        // Reduce cada Columna en un valor igual al mínimo elemento de la columna dada
        private static void ColumnReduction(int[,] distancia)
        {
            int col = 0;
            for (int j = 0; j < SIZE; j++)
            {
                int minCol= MinCol(distancia,j);
                if (minCol != VACIO)
                {
                    col += minCol;
                }
                for (int i = 0; i < SIZE; i++)
                {
                    if (distancia[i, j] != VACIO)
                    {
                        distancia[i, j] -= minCol;
                    }
                }
            }
        }

        // Devuelve el minimo valor de una fila
        private static int MinRow(int[,] distancia,int i) 
        {
            int minRow = distancia[i, 0];
            for(int j = 0; j < SIZE; j++)
            {
                if (distancia[i, j] < minRow)
                {
                    minRow = distancia[i, j];
                }
            }
            return minRow;
        }
        // Devuelve el minimo valor de una columna
        private static int MinCol(int[,] distancia,int j)
        {
            int minCol = distancia[0, j];
            for (int i = 0; i < SIZE; i++)
            {
                if (distancia[i, j] < minCol)
                {
                    minCol = distancia[i, j];
                }
            }
            return minCol;
        }



        // Leer matriz de distancias
        private static int[,] GetDistanceMatrix()
        {
            int[,] distancia = new int[SIZE, SIZE];
            try
            {                
                using (StreamReader sr = new StreamReader("asd.csv"))
                {
                    string line;
                    int i = 0;                   
                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] values = line.Split(',');
                        for(int j = 0; j < values.Length; j++)
                        {
                            int result = 0;
                            if (int.TryParse(values[j], out result))
                            {
                                distancia[i, j] = result;
                            }
                            else
                            {
                                distancia[i, j] = VACIO;
                            }
                            
                                                           
                            
                        }
                        i++;
                    }
                }
                return distancia;         
            }
            catch (Exception e)
            {                
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
            
        }
        // Dado un número y la cantidad de bits, lo convierte a un array de bits 0 y 1
        private static int[] ToBinary(int num, int max_size)
        {
            string s = Convert.ToString(num, 2);
            char[] bits = s.PadLeft(max_size, '0').ToCharArray();
            return Array.ConvertAll(bits, x => int.Parse(x.ToString()));
        }

       


    }
}
