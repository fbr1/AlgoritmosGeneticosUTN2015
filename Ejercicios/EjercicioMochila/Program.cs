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
            // Carga de Datos
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
                       

            // Algoritmo greedy
            Console.WriteLine("\nAlgortimo Greedy\n"); 

            objetos.Sort();
            objetos.Reverse(); 

            double volumen = 0;
            double valor = 0;          
            for (int i = 0; i < objetos.Count; i++)
            {
                Objeto objeto = objetos.ElementAt(i);
                // Si el proximo objeto excede el maximo volumen se prueba con el siguiente mejor
                if (volumen + objeto.Volumen > VOLUMEN_MAXIMO)
                {
                    continue;
                }
                else
                {
                    volumen = volumen + objeto.Volumen;
                    valor = valor + objeto.Valor;
                }
                Console.Out.WriteLine(objeto.Numero + "\t" + objeto.Volumen + "\t" + objeto.Valor);
            }

            Console.WriteLine("\nVolumen Total: " + volumen + " , Valor Total: " + valor);

            // Algoritmo Exhaustivo

            Console.WriteLine("\n-----------------------------------------------------");
            Console.WriteLine("\nAlgortimo Exhaustivo\n");


            // Condiciones  iniciales

            double maxIteraciones = Math.Pow(2, objetos.Count);              
            Int32[] CromosomaMaximo = new Int32[objetos.Count];             
            double valormaximo = 0;


            // Para cada una de las posibilidades incluyendo repeticion
            for (int i = 0; i < maxIteraciones - 1; i++)
            {
                // Convierte el indice en binario  
                Int32[] cromosoma = ToBinary(i, objetos.Count);    
                
                double sumaVolumen = 0;
                double sumaValor = 0;

                // Para cada item del cromosoma
                for (int j = 0; j < cromosoma.Length; j++) 
                {
                    // Si es 1, es un elemento que va a poder llegar a entrar a la mochila
                    if (cromosoma[j] == 1) 
                    {
                        sumaVolumen = sumaVolumen + objetos[j].Volumen;
                        sumaValor = sumaValor + objetos[j].Valor;                        
                    }
                }
                if (sumaVolumen < VOLUMEN_MAXIMO && sumaValor > valormaximo)
                {
                    valormaximo = sumaValor;
                    CromosomaMaximo = cromosoma;
                }                             
            }   
            
            Console.WriteLine("Nro\tVolumen\tValor\t");

            volumen = 0;
            valor = 0;
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
        // Dado un número y la cantidad de bits, lo convierte a un array de bits 0 y 1
        public static Int32[] ToBinary(int num,int max_size)
        {
            string s = Convert.ToString(num, 2);
            char[] bits = s.PadLeft(max_size, '0').ToCharArray();
            return Array.ConvertAll(bits, x => int.Parse(x.ToString()));            
        }        
        
    }
}
