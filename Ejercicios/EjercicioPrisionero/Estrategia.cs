using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPrisionero
{
    
    class Estrategia
    {
        static Dictionary<string, int> Casos = new Dictionary<string, int>();

        static Dictionary<string, int[]> TablaPremios = new Dictionary<string, int[]>();

        public String Cadena { get; set; }
        public Int32 AñosAcumulado { get; set; }
        public String jugadaAnteriorOriginal { get; set; }

        public List<Match> Matches { get; set; }

        public Estrategia()
        {
            this.Matches = new List<Match>();
        }
        
        public String getJugadaAnterior()
        {
            String jugadaAnterior = Cadena.Substring(0, 2);
            int asd = Casos[jugadaAnterior];
            return this.Cadena.ElementAt(Casos[jugadaAnterior]+2).ToString();
        } 

        public static void Jugar(Estrategia estX, Estrategia estY)
        {
            String accionX = estX.getJugadaAnterior();
            String accionY = estY.getJugadaAnterior();
            String decision = accionX + accionY;
            int[] resultado = TablaPremios[decision];


            // Agrega la jugada a la lista de matches           
            estX.Matches.Add(new Match(estX.Cadena, estY.Cadena, resultado));
            estX.Cadena = accionX + accionY + estX.Cadena.Substring(2, 4);
            estX.AñosAcumulado += resultado[0];

            estY.Cadena = accionY + accionX + estY.Cadena.Substring(2, 4);
            estY.AñosAcumulado += resultado[1];
            Array.Reverse(resultado);
            estY.Matches.Add(new Match(estY.Cadena, estX.Cadena, resultado)); 
            
        }
        public void reset()
        {
            this.Cadena = this.jugadaAnteriorOriginal + this.Cadena.Substring(2, 4);
        }

        public static void StartCasos()
        {
            Casos.Add("AA", 0);
            Casos.Add("AN", 1);
            Casos.Add("NA", 2);
            Casos.Add("NN", 3);
        }
        public static void StartTablaPremios()
        {
            TablaPremios.Add("AA", new int[2] { 1, 1 });
            TablaPremios.Add("AN", new int[2] { 5, 0 });
            TablaPremios.Add("NA", new int[2] { 0, 5 });
            TablaPremios.Add("NN", new int[2] { 4, 4 });
        }

        public static List<Estrategia> getEstrategias()
        {
            List<Estrategia> estrategias = new List<Estrategia>();
            // Para cada combinacion de casos
            for (int i = 0; i < 16; i++)
            {
                // Para cada posible partida anterior
                for (int j = 0; j < 4; j++)
                {
                    Estrategia est = new Estrategia();                   
                    String cadena = Convert.ToString(j, 2).PadLeft(2, '0') + Convert.ToString(i, 2).PadLeft(4, '0');
                    for (int k = 0; k < 6; k++)
                    {
                        String stringToAdd;
                        if (cadena[k] == '0')
                        {
                            stringToAdd = "A";
                        }
                        else
                        {
                            stringToAdd = "N";
                        }
                        est.Cadena += stringToAdd;
                    }
                    est.jugadaAnteriorOriginal = est.Cadena.Substring(0, 2);
                    estrategias.Add(est);
                }
            }
            return estrategias;
        }
    }
}
