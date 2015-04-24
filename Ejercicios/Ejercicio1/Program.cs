﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {
        //Constantes        
        
        const int CICLOS = 15;
        
        // Metodos
        static void Main(string[] args)
        {   
            List<Generacion> generaciones = new List<Generacion>();
            Random rnd = new Random();

            //Crea las Generaciones 
            //Creo que seria mejor usar un metodo de clase sobre la clase Generacion
            Generacion generacion = new Generacion(rnd, CICLOS, ref generaciones);

            //Muestra las sucesivas Generaciones
            foreach (Generacion gen in generaciones)
            {
                Console.WriteLine("--------------------------");
                foreach (Individuo ind in gen.Poblacion)
                {
                    Console.WriteLine(string.Join("", ind.Cromosoma));
                }
                foreach (Individuo ind in gen.Poblacion)
                {
                    Console.WriteLine(ind.Fitness);
                }  
                Console.WriteLine();
                Console.WriteLine("Suma= " + gen.Suma);
                Console.WriteLine("Promedio= " + gen.Suma / Generacion.POBLACION_SIZE);
                Console.WriteLine("Maximo= " + gen.Maximo);
                Console.WriteLine(); 
            }          

            Console.ReadLine();
        }        
    }
}
