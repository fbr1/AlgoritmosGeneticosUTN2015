using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioMochila
{
    class Program
    {
        const double VOLUMEN_MAXIMO = 4200;
        static void Main(string[] args)
        {
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
                if (suma > 4200) break;
                Console.Out.WriteLine(o.Volumen + " " + o.Valor + " " + o.ValorPorVol);
            }

            Console.ReadLine();
            double max = 0;
            for (int i = 1; i <= 10; i++)
            {
                int[,] subconjunto = new int[i, 2];

            }

        }
    }
}
