using System.Collections.Generic;

namespace EjercicioViajante
{
    internal interface IViajante
    {
        List<Provincia> getRecorrido();
        int LongitudRecorrido { get; set; }
        
    }
}