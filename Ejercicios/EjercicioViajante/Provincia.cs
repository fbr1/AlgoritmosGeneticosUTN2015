using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace EjercicioViajante
{
    class Provincia
    {
        public int ID { get; set; }
        public String Nombre { get; set; }
        public Point CoordCapital { get; set; }
        public Point[] Frontera { get; set; }

    }
}
