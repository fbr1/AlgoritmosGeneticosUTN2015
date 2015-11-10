using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPrisionero
{
    class Match
    {
        
        public String CadenaX { get; set; }
        public String CadenaY { get; set; }
        public int[] Resultado { get; set; }
        public Match(String cadenaX, String cadenaY, int[] resultado)
        {
            this.CadenaX = cadenaX;
            this.CadenaY = cadenaY;
            this.Resultado = resultado;
        }
    }
}
