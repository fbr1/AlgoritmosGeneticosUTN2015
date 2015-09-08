using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioViajante
{
    class Program
    {
        const int VACIO = 9999;
        const int SIZE = 23;
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormularioPrincipal());  

            int[,] distancia = GetDistanceMatrix();
                        
            if (distancia != null)
            {
                Heuristico algoritmo = new Heuristico(distancia);
                List<Individuo.Provincias> recorrido = algoritmo.getRecorrido(Individuo.Provincias.BUENOS_AIRES);
                foreach (Individuo.Provincias prov in recorrido)
                {
                    Console.WriteLine(prov.ToString());
                }
                Console.WriteLine("Longitud Total= " + algoritmo.LongitudRecorrido);
            }


            Console.ReadLine();

            
        }

        // Leer matriz de distancias
        private static int[,] GetDistanceMatrix()
        {
            int[,] distancia = new int[SIZE, SIZE];
            try
            {                
                using (StreamReader sr = new StreamReader("distance.csv"))
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
