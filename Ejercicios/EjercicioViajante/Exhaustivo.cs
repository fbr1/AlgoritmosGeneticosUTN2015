using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioViajante
{
    class Exhaustivo 
    {
        const int VACIO = 9999;
        const int SIZE = 5;
        public Exhaustivo(int[,] distancia)
        {            
            if (distancia != null)
            {
                int[] select = new int[5];
                for (int i = 0; i < SIZE; i++)
                {
                    select[i] = 0;
                }

                int row = RowReduction(distancia);
                int col = ColumnReduction(distancia);

                int bound = row + col;
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

                    //for (int p = 0; p < SIZE; p++)
                    //{
                    //    distancia[j, p] = VACIO;
                    //}
                    //for (int p = 0; p < SIZE; p++)
                    //{
                    //    distancia[p,k] = VACIO;
                    //}
                    //distancia[k, j] = VACIO;
                    RowReduction(distancia);
                    ColumnReduction(distancia);
                    bound = row + col;
                    Console.Out.WriteLine(bound);
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
            for (int i = 0; i < SIZE; i++)
            {
                if (select[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private static int CheckBounds(int st, int des, int[,] distancia)
        {
            int[] penCost = new int[SIZE];
            penCost[0] = 0;
            int[,] reduced = new int[SIZE, SIZE];
            Array.Copy(distancia, reduced, distancia.Length);

            for (int j = 0; j < SIZE; j++)
            {
                reduced[st, j] = VACIO;
            }
            for (int i = 0; i < SIZE; i++)
            {
                reduced[i, des] = VACIO;
            }
            showDistancia(reduced);
            int row = RowReduction(reduced);
            int col = ColumnReduction(reduced);
            showDistancia(reduced);
            penCost[des] = penCost[st] + col + row + distancia[st, des];
            return penCost[des];

        }
        // Reduce cada fila en un valor igual al mínimo elemento de la fila dada
        private static int RowReduction(int[,] distancia)
        {
            int row = 0;
            for (int i = 0; i < SIZE; i++)
            {
                int minRow = MinRow(distancia, i);
                if (minRow != VACIO)
                {
                    row += minRow;
                }
                for (int j = 0; j < SIZE; j++)
                {
                    if (distancia[i, j] != VACIO)
                    {
                        distancia[i, j] -= minRow;
                    }
                }
            }
            return row;
        }
        // Reduce cada Columna en un valor igual al mínimo elemento de la columna dada
        private static int ColumnReduction(int[,] distancia)
        {
            int col = 0;
            for (int j = 0; j < SIZE; j++)
            {
                int minCol = MinCol(distancia, j);
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
            return col;
        }

        // Devuelve el minimo valor de una fila
        private static int MinRow(int[,] distancia, int i)
        {
            int minRow = distancia[i, 0];
            for (int j = 0; j < SIZE; j++)
            {
                if (distancia[i, j] < minRow)
                {
                    minRow = distancia[i, j];
                }
            }
            return minRow;
        }
        // Devuelve el minimo valor de una columna
        private static int MinCol(int[,] distancia, int j)
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
    }
}
