using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPrisionero
{
    class Program
    {
        static void Main(string[] args)
        {
            Estrategia.StartCasos();
            Estrategia.StartTablaPremios();
            List<Estrategia> estrategias = Estrategia.getEstrategias(); 
            for(int i = 0; i< estrategias.Count; i++)
            {
                for (int j = i+1; j < estrategias.Count; j++)
                {
                    Estrategia estX = estrategias.ElementAt(i);
                    Estrategia estY = estrategias.ElementAt(j);
                    for (int k = 0; k < 10; k++)
                    {
                        Estrategia.Jugar(estX, estY);
                    }
                    estX.reset();
                    estY.reset();
                }
            }            
            List<Estrategia> lista = estrategias.OrderByDescending(x => x.AñosAcumulado).ToList();
            int sum = 0;
            Console.WriteLine("Cadena\tAños Acumulados\n");
            foreach (Estrategia est in lista)
            {
                Console.WriteLine(est.Cadena + "\t" + est.AñosAcumulado );
                sum += est.AñosAcumulado;
            }
            Console.ReadLine();


        }        
    }
}
