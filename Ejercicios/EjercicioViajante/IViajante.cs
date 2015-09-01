using System.Collections.Generic;

namespace EjercicioViajante
{
    internal interface IViajante
    {
        List<Individuo.Provincias> getRecorrido();
        int LongitudTrayecto { get; set; }        
    }
}