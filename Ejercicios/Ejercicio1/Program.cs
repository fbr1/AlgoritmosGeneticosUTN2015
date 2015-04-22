using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {
        const double COEF = 1073741823;
        static void Main(string[] args)
        {
            int[,] matriz = new int[10, 30];
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    matriz[i, j] = rnd.Next(0, 2);
                    Console.Write(matriz[i, j]);
                }
                Console.WriteLine();

            }
            double suma = 0;
            double[] funcionespotencia = new double[10];
            double[] fitness = new double[10];
            for (int i = 0; i < 10; i++)
            {
                string numerobinario = "";

                for (int j = 0; j < 30; j++)
                {
                    numerobinario = numerobinario + matriz[i, j].ToString();
                }
                int numero = Convert.ToInt32(numerobinario, 2);
                Console.Write(numero);


                funcionespotencia[i] = Math.Pow(numero / COEF, 2);

                suma = suma + funcionespotencia[i];
                Console.WriteLine(" " + funcionespotencia[i]);

            }

            Console.WriteLine();
            Console.WriteLine("Suma= " + suma);
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                fitness[i] = funcionespotencia[i] / suma;
                Console.WriteLine(fitness[i]);
            }
            Console.ReadLine();



        }
    }
}
