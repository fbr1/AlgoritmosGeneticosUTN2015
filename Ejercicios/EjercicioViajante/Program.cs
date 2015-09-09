using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
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

            Console.ReadLine();

            
        }
    }
}
