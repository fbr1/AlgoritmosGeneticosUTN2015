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
        const int CANT_OBJETOS = 10;
        static void Main(string[] args)
        {   
            Console.WriteLine("\nAlgortimo Greedy\n");

            List<Objeto> objetos = new List<Objeto>(10);
            objetos.Add(new Objeto(1,150, 20));
            objetos.Add(new Objeto(2,325, 40));
            objetos.Add(new Objeto(3,600, 50));
            objetos.Add(new Objeto(4,805, 36));
            objetos.Add(new Objeto(5,430, 25));
            objetos.Add(new Objeto(6,1200, 64));
            objetos.Add(new Objeto(7,770, 54));
            objetos.Add(new Objeto(8,60, 18));
            objetos.Add(new Objeto(9,930, 46));
            objetos.Add(new Objeto(10,353, 28));

            objetos.Sort();
            objetos.Reverse();
            double volumen = 0;
            double valor = 0;
            Console.Out.WriteLine("Nro\tVolumen\tValor\t");
            foreach (Objeto o in objetos)
            {
                volumen = volumen + o.Volumen;
                valor = valor + o.Valor;
                if (volumen > VOLUMEN_MAXIMO)
                {
                    volumen = volumen - o.Volumen;
                    valor = valor - o.Valor;
                    break;
                }                
                Console.Out.WriteLine(o.Numero + "\t" + o.Volumen + "\t" + o.Valor);
            }

            Console.WriteLine("\nVolumen Total: " + volumen + " , Valor Total: " + valor);
            

            Console.WriteLine("\nAlgortimo Exhaustivo\n");

            double count = Math.Pow(2, objetos.Count); // Cantidad de iteraciones             
            Int32[] CromosomaMaximo = new Int32[CANT_OBJETOS]; 
            double valormaximo = 0;
            for (int i = 0; i < count-1; i++)
            { // Para cada una de las posibilidades incluyendo repeticion
                Int32[] cromosoma = ToBinary(i,CANT_OBJETOS); // Convierte el indice en binario
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

            volumen = 0;
            valor = 0;
            Console.Out.WriteLine("Nro\tVolumen\tValor\t");
            for (int i = 0; i < CromosomaMaximo.Length; i++)
            {
                if (CromosomaMaximo[i] == 1)
                {
                    volumen = volumen + objetos[i].Volumen;
                    valor = valor + objetos[i].Valor;
                    Console.Out.WriteLine(objetos[i].Numero + "\t" + objetos[i].Volumen + "\t" + objetos[i].Valor);
                }
            }

            Console.WriteLine("\nVolumen Total: " + volumen + " , Valor Total: " + valor);
            
           
            Console.ReadLine(); 
       
        }       
        public static Int32[] ToBinary(int num,int max_size)
        {
            string s = Convert.ToString(num, 2);
            char[] bits = s.PadLeft(max_size, '0').ToCharArray();
            return Array.ConvertAll(bits, x => int.Parse(x.ToString()));            
        }        
        
    }
}
