using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EjercicioMochila
{
    static class Program
    {
        const double VOLUMEN_MAXIMO = 4200;
        static void Main(string[] args)
        {
            Console.WriteLine("\nAlgortimo Greedy\n");

            List<Objeto> objetos = new List<Objeto>(10);
            objetos.Add(new Objeto(150, 20));
            objetos.Add(new Objeto(325, 40));
            objetos.Add(new Objeto(600, 50));
            objetos.Add(new Objeto(805, 36));
            objetos.Add(new Objeto(430, 25));
            objetos.Add(new Objeto(1200, 64));
            objetos.Add(new Objeto(770, 54));
            objetos.Add(new Objeto(60, 18));
            objetos.Add(new Objeto(930, 46));
            objetos.Add(new Objeto(353, 28));

            objetos.Sort();
            objetos.Reverse();
            double suma = 0;
            foreach (Objeto o in objetos)
            {
                suma = suma + o.Volumen;
                if (suma > VOLUMEN_MAXIMO) break;
                Console.Out.WriteLine(o.Volumen + " " + o.Valor + " " + o.ValorPorVol);
            }

            Console.WriteLine("\nAlgortimo Exaustivo\n");

            double count = Math.Pow(2, objetos.Count); // Cantidad de iteraciones             
            Int32[] CromosomaMaximo = new Int32[10]; 
            double valormaximo = 0;
            for (int i = 0; i < count-1; i++)
            { // Para cada una de las posibilidades incluyendo repeticion
                Int32[] cromosoma = ToBinary(i); // Convierte el indice en binario
                double sumaVolumen = 0;
                double sumaValor = 0;
                for (int j = 0; j < cromosoma.Length; j++) // Para cada item del cromosoma
                {
                    if (cromosoma[j] == 1) // Si es 1, es un elemento que va a poder llegar a entrar a la mochila
                    {
                        sumaVolumen = sumaVolumen + objetos[j].Volumen;
                        sumaValor = sumaValor + objetos[j].ValorPorVol;                        
                    }
                }
                if (sumaVolumen < VOLUMEN_MAXIMO && sumaValor > valormaximo)
                {
                    CromosomaMaximo = cromosoma;
                }                             
            }
            for (int i = 0; i < 10; i++)
            {
                if (CromosomaMaximo[i] == 1)
                {
                    Console.Out.WriteLine(objetos[i].Volumen + " " + objetos[i].Valor + " " + objetos[i].ValorPorVol);
                }


            } 
           
            Console.ReadLine(); 
       
        }       
        public static Int32[] ToBinary(int num)
        {
            string s = Convert.ToString(num, 2);
            char[] bits = s.PadLeft(10, '0').ToCharArray();
            return Array.ConvertAll(bits, x => int.Parse(x.ToString()));            
        }        
        
    }
}
