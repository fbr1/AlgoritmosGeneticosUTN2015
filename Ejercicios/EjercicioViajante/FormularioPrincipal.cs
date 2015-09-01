using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioViajante
{
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
            imArgentina.Image= Image.FromFile("argentina.jpg");
        }

        private void rbHeuristico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHeuristico.Checked)
            {

            }
        }
    }
}
