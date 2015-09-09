using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioViajante
{
    public partial class FormularioPrincipal : Form
    {
        // Constantes
    
        const int VACIO = 9999;
        const int SIZE = 23;
        const string PROVINCIAS_DIR = "provincias.csv";
        const string ARGENTINA_IMG_DIR = "argentina.png";
        const string DISTANCIAS_DIR = "distancia.csv";

        enum MODO { EXHAUSTIVO, HEURISTICO, GENETICO }
        List<Provincia> Provincias { get; set; }
        List<Provincia> Recorrido { get; set; }
        MODO _modo = MODO.EXHAUSTIVO;
        Provincia _provinciaSeleccionada=null;
        
        int[,] Distancia { get; set; }
        public FormularioPrincipal()
        {            
            InitializeComponent();
            this.Provincias = GetProvincias();
            this.Distancia = GetDistanceMatrix();
            // Load Provincias
            if (this.Provincias != null && this.Distancia != null)
            {
                createImageMap();
            }else
            {
                txtProvincia.Visible= true;
                txtProvincia.Text = "ERROR";
                btnGo.Enabled = false;
                btnLimpiar.Enabled = false;
            }

        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            txtListadoProv.Text = null;
            switch (_modo)
            {
                case MODO.EXHAUSTIVO:
                    {
                        break;
                    }
                case MODO.HEURISTICO:
                    {
                        Heuristico algoritmo = new Heuristico(this.Distancia, this.Provincias);                        
                        if (_provinciaSeleccionada != null)
                        {
                            Recorrido = algoritmo.getRecorrido(_provinciaSeleccionada);
                        }
                        else
                        {
                            Recorrido = algoritmo.getBestRecorrido();
                        }                        
                        txtDistanciaRecorrida.Text = algoritmo.LongitudRecorrido.ToString();                        
                        break;
                    }
                case MODO.GENETICO:
                    {
                        break;
                    }
            }
            // Lista todas las provincias
            int i = 1;
            foreach(Provincia prov in this.Recorrido)
            {
                txtListadoProv.Text += i + "- " + prov.Nombre+ "\r\n";
                i++;
            }
            imArgentina.Invalidate();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void imArgentina_Paint(object sender, PaintEventArgs e)
        {
            imArgentina.Image = Image.FromFile(ARGENTINA_IMG_DIR);
            if (Recorrido != null)
            {                
                using (var p = new Pen(Color.Blue, 2))
                {  
                    Bitmap map = (Bitmap)imArgentina.Image;
                    Graphics g = Graphics.FromImage(map);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    for (int i = 0; i < this.Recorrido.Count-1; i++)
                    {
                        Point desde = Recorrido.ElementAt(i).CoordCapital;
                        Point hasta = Recorrido.ElementAt(i + 1).CoordCapital;
                        g.DrawLine(p, desde, hasta);
                    }
                    imArgentina.Image = map;
                }               
                
            }
        }
        private void createImageMap()
        {
            imArgentina.Image = Image.FromFile(ARGENTINA_IMG_DIR);
            foreach (Provincia prov in this.Provincias)
            {
                imArgentina.AddPolygon(prov.Nombre, prov.Frontera);
            }
        }
        private List<Provincia> GetProvincias()
        {
            List<Provincia> provincias = new List<Provincia>();
            try
            {
                using (StreamReader sr = new StreamReader(PROVINCIAS_DIR))
                {
                    string line;
                    int j = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] values = line.Split(';');
                        Provincia prov = new Provincia();

                        // ID

                        prov.ID = j;

                        // Nombre

                        prov.Nombre = values[0];

                        // Coordenadas de la capital

                        String[] coordCapital = values[1].Split(',');
                        prov.CoordCapital = new Point(int.Parse(coordCapital[0]), int.Parse(coordCapital[1]));

                        // Coordenadas Frontera

                        List<Point> fronteras = new List<Point>();
                        String[] fronteravalues = values[2].Split(',');
                        for (int i = 0; i < fronteravalues.Length; i = i + 2)
                        {
                            fronteras.Add(new Point(int.Parse(fronteravalues[i]), int.Parse(fronteravalues[i + 1])));
                        }
                        prov.Frontera = fronteras.ToArray();

                        provincias.Add(prov);
                        j++;
                    }
                }
                return provincias;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
        // Leer matriz de distancias
        private static int[,] GetDistanceMatrix()
        {
            int[,] distancia = new int[SIZE, SIZE];
            try
            {
                using (StreamReader sr = new StreamReader(DISTANCIAS_DIR))
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] values = line.Split(',');
                        for (int j = 0; j < values.Length; j++)
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

        private void rbGenetico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGenetico.Checked)
            {
                txtProvincia.Visible = false;
                this._modo = MODO.GENETICO;
            }
        }

        private void rbExhaustivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExhaustivo.Checked)
            {
                txtProvincia.Visible = false;
                this._modo = MODO.EXHAUSTIVO;
            }
        }
        private void rbHeuristico_CheckedChanged(object sender, EventArgs e)
        {            
            if (rbHeuristico.Checked)
            {
                txtProvincia.Visible = true;
                this._modo = MODO.HEURISTICO;
            }
        }
        // Seleccionar provincia
        private void imArgentina_RegionClick(int index, string key)
        {
            if (_modo == MODO.HEURISTICO)
            {
                _provinciaSeleccionada = this.Provincias.Find(x => x.Nombre.Equals(key));
                txtProvincia.Text = _provinciaSeleccionada.Nombre;
            }
        }
        private void Limpiar()
        {
            this._provinciaSeleccionada = null;
            this.txtProvincia.Text = "";
            this.txtDistanciaRecorrida.Text = "";
            this.Recorrido = null;
            this.txtListadoProv.Text = "";
            this.imArgentina.Invalidate();            
        }
        

    }
}
