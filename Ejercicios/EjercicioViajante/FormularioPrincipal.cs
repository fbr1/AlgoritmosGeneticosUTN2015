using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EjercicioViajante
{
    public partial class FormularioPrincipal : Form
    {       

        // Constantes

        const int VACIO = 0;
        public const int SIZE = 23;
        const string PROVINCIAS_DIR = "provincias.csv";
        const string ARGENTINA_IMG_DIR = "argentina.png";
        const string DISTANCIAS_DIR = "distancia.csv";

        // Variables para la Animación

        private int iteradorProv = 0;
        private int distanciaLinea = 0; 
        private Timer timer = new Timer();        
        Point hasta;
        Point desde;        
        double vector_unitario_x;
        double vector_unitario_y;
        private int velocidad = 10;        
        double hipotenusa;

        //        
        private BackgroundWorker bw = new BackgroundWorker();
        List<Provincia> Recorrido { get; set; }
        int DistanciaRecorrida;
        double tiempoTranscurrido;
        enum MODO { EXHAUSTIVO, HEURISTICO, GENETICO }
        MODO _modo;
        Provincia _provinciaSeleccionada=null;
        
        
        public FormularioPrincipal()
        {            
            InitializeComponent();

            // Load Provincias y Distancia
            Algoritmo.Provincias = GetProvincias();
            Algoritmo.Distancia = GetDistanceMatrix();            
            if (Algoritmo.Provincias != null && Algoritmo.Distancia != null)
            {
                createImageMap();
            }else
            {
                txtProvincia.Visible= true;
                txtProvincia.Text = "ERROR";
                btnGo.Enabled = false;
                btnLimpiar.Enabled = false;
            }
            // Modo Default
            _modo = MODO.HEURISTICO;

            // Agregar el evento para la animación
            timer.Tick += new EventHandler(OnTimer);
            timer.Interval = 1;
            timer.Enabled = false;

            // Configuracion backgroundd worker
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }       

        private void OnTimer(object sender, EventArgs e)
        {
            // Mientras haya trayectos sin dibujar
            if (iteradorProv < this.Recorrido.Count - 1)
            {
                using (var p = new Pen(Color.Blue, 2))
                {   
                    // Nuevo punto de partida
                    if (distanciaLinea == 0)                        
                    {
                        desde = Recorrido[iteradorProv].CoordCapital;
                        hasta = Recorrido[iteradorProv + 1].CoordCapital;

                        // Genera propiedades del vector entre los puntos desde y hasta
                        Point vectorAB = new Point(hasta.X - desde.X, hasta.Y - desde.Y);
                        hipotenusa = this.LengthOfHypotenuse(desde, hasta);
                        vector_unitario_x = vectorAB.X / hipotenusa;
                        vector_unitario_y = vectorAB.Y / hipotenusa;
                    }                             
                           
                    // Nuevos valores de x
                    int x = desde.X + (int)(vector_unitario_x * distanciaLinea*velocidad);
                    int y = desde.Y + (int)(vector_unitario_y * distanciaLinea*velocidad);

                    // Inicializa graphic
                    Bitmap map = (Bitmap)imArgentina.Image;
                    Graphics g = Graphics.FromImage(map);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                    // Si se llego a una provincia
                    if (distanciaLinea* velocidad > hipotenusa)
                    {
                        distanciaLinea = 0;    
                                            
                        // Agregar nombre provincia  
                        txtListadoProv.Text += iteradorProv + 1 + "- " + Recorrido[iteradorProv + 1].Nombre + "\r\n";

                        // Completa la linea                        
                        g.DrawLine(p, desde, hasta);
                        imArgentina.Image = map;
                        iteradorProv++;
                    }else
                    {
                        // Dibujar linea hasta el punto actual                        
                        g.DrawLine(p, desde, new Point(x, y));
                        imArgentina.Image = map;                        
                        distanciaLinea=distanciaLinea+1;
                    } 
                }
            }
            else
            {                
                this.StopAnimation();
            }
            
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            // Empieza a medir el tiempo
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Algoritmo algoritmo = null;
                    
            switch (_modo)
            {
                case MODO.EXHAUSTIVO:
                    {
                        algoritmo = new Exhaustivo();
                        Recorrido = ((Exhaustivo)algoritmo).getRecorrido(bw);
                        break;
                    }
                case MODO.HEURISTICO:
                    {
                        algoritmo = new Heuristico();
                        if (_provinciaSeleccionada != null)
                        {
                            Recorrido = ((Heuristico)algoritmo).getRecorrido(_provinciaSeleccionada);
                        }
                        else
                        {
                            Recorrido = algoritmo.getRecorrido();
                        }

                        break;
                    }
                case MODO.GENETICO:
                    {
                        algoritmo = new Genetico(Int32.Parse(txtCiclos.Text), Int32.Parse(txtIteraciones.Text), double.Parse(txtCrossover.Text),
                            double.Parse(txtMutacion.Text));

                        Recorrido = ((Genetico)algoritmo).getRecorrido(bw);
                        break;
                    }
            }

            // Termina medicion del tiempo
            stopwatch.Stop();

            DistanciaRecorrida = algoritmo.LongitudRecorrido;
            tiempoTranscurrido = stopwatch.Elapsed.TotalMilliseconds;

        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            bw.CancelAsync();
            txtListadoProv.Text = null;

            // Si el background worker no esta en ejecucion
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }
        // Termina el background worker
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(Recorrido != null)
            {
                txtDistanciaRecorrida.Text = DistanciaRecorrida.ToString();

                // Lista primer Provincia
                txtListadoProv.Text += 0 + "- " + Recorrido[0].Nombre + "\r\n";

                txtTiempo.Text = tiempoTranscurrido.ToString() + " ms";
                // Borra Imagen recorrido anterior
                cargarImagenArgentina();
                StopAnimation();

                // Empieza animación
                timer.Start();
            }            

            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void createImageMap()
        {
            cargarImagenArgentina();
            foreach (Provincia prov in Algoritmo.Provincias)
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
                this.flpPropiedadesGeneticos.Visible = true;
            }
        }

        private void rbExhaustivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExhaustivo.Checked)
            {
                txtProvincia.Visible = false;
                this._modo = MODO.EXHAUSTIVO;
                this.flpPropiedadesGeneticos.Visible = false;
            }
        }
        private void rbHeuristico_CheckedChanged(object sender, EventArgs e)
        {            
            if (rbHeuristico.Checked)
            {
                txtProvincia.Visible = true;
                this._modo = MODO.HEURISTICO;
                this.flpPropiedadesGeneticos.Visible = false;
            }
        }
        // Seleccionar provincia
        private void imArgentina_RegionClick(int index, string key)
        {
            if (_modo == MODO.HEURISTICO)
            {
                _provinciaSeleccionada = Algoritmo.Provincias.Find(x => x.Nombre.Equals(key));
                txtProvincia.Text = _provinciaSeleccionada.Nombre;
            }
        }
        private void Limpiar()
        {
            bw.CancelAsync();
            StopAnimation();
            this._provinciaSeleccionada = null;
            this.txtProvincia.Text = "";
            this.txtDistanciaRecorrida.Text = "";
            this.Recorrido = null;
            this.txtListadoProv.Text = "";
            this.txtTiempo.Text = "";
            cargarImagenArgentina();
        }
        private void StopAnimation()
        {
            iteradorProv = 0;
            distanciaLinea = 0;
            timer.Stop();
        }
        private double LengthOfHypotenuse(Point a, Point b)
        {
            double aSq = Math.Pow(a.X - b.X, 2); 
            double bSq = Math.Pow(a.Y - b.Y, 2); 
            return Math.Sqrt(aSq + bSq); 
        }
        private void cargarImagenArgentina()
        {
            imArgentina.Image = Image.FromFile(ARGENTINA_IMG_DIR);
            this.imArgentina.Invalidate();
        }

        private void trackBarVelocidad_Scroll(object sender, EventArgs e)
        {
            this.velocidad = trackBarVelocidad.Value;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(Recorrido != null)
            {
                this.txtListadoProv.Text = "";
                bw.CancelAsync();
                StopAnimation();
                cargarImagenArgentina();
                txtListadoProv.Text += 0 + "- " + Recorrido[0].Nombre + "\r\n";
                timer.Start();
            }
            

        }
    }
}
