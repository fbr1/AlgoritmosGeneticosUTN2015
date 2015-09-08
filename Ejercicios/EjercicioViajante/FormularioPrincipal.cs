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
            createImageMap();            
        }

        private void rbHeuristico_CheckedChanged(object sender, EventArgs e)
        {                        
            if (rbHeuristico.Checked)
            {

            }
        }
        private void createImageMap()
        {
            imArgentina.Image = Image.FromFile("argentina.png");
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias),Individuo.Provincias.USHUAIA),
                new Point[] {new Point(83, 444),new Point(86, 474), new Point(128, 472), new Point(84, 443) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.RIO_GALLEGOS),
                new Point[] { new Point(47,351),new Point(36,396),new Point(33,413),new Point(41,423),new Point(48,419),
                    new Point(52,420),new Point(49,423),new Point(49,430),new Point(56,437),new Point(70,436),
                    new Point(76,436),new Point(82,438),new Point(86,437),new Point(78,412),new Point(87,405),
                    new Point(90,392),new Point(104,375),new Point(105,366),new Point(87,350) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.RAWSON),
                new Point[] { new Point(34,299),new Point(40,337),new Point(48,351),new Point(85,349),new Point(109,326),
                    new Point(118,305),new Point(125,298),new Point(123,293),new Point(109,291),new Point(40,295) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.VIEDMA),
                new Point[] { new Point(40,295),new Point(38,285),new Point(74,253),new Point(74,231),new Point(78,234),
                    new Point(78,236),new Point(83,238),new Point(84,236),new Point(93,246),new Point(108,247),
                    new Point(128,252),new Point(127,273),new Point(134,277),new Point(127,281),new Point(111,274),
                    new Point(108,277),new Point(110,290) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.NEUQUEN),
                new Point[] { new Point(38,284),new Point(40,252),new Point(47,246),new Point(39,235),new Point(41,218),
                    new Point(46,211),new Point(58,228),new Point(61,225),new Point(73,230),new Point(73,253) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.SANTA_ROSA),
                new Point[] { new Point(72,228),new Point(76,229),new Point(83,236),new Point(96,247),new Point(110,245),
                    new Point(128,252),new Point(128,193),new Point(107,193),new Point(107,207),new Point(72,208) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.BUENOS_AIRES),
                new Point[] { new Point(135,277),new Point(127,273),new Point(129,184),new Point(147,184),new Point(160,172),
                    new Point(164,172),new Point(185,180),new Point(183,187),new Point(199,199),new Point(196,209),
                    new Point(203,215),new Point(191,240),new Point(164,249),new Point(145,250),new Point(138,244),
                    new Point(139,272), }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.SANTA_FE),
                new Point[] { new Point(134,184),new Point(148,184),new Point(159,172),new Point(163,171),new Point(157,160),
                    new Point(160,146),new Point(173,130),new Point(173,113),new Point(180,107),new Point(181,98),
                    new Point(183,96),new Point(148,95),new Point(142,127),new Point(147,134),new Point(142,148),
                    new Point(142,152),new Point(148,165) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.CORDOBA),
                new Point[] { new Point(107,193),new Point(129,192),new Point(128,184),new Point(133,184),new Point(147,165),
                    new Point(143,154),new Point(143,146),new Point(146,135),new Point(141,127),new Point(136,127),
                    new Point(137,123),new Point(134,120),new Point(120,118),new Point(110,117),new Point(107,119),
                    new Point(109,120),new Point(104,125),new Point(98,137),new Point(99,151),new Point(109,156) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.SAN_LUIS),
                new Point[] { new Point(89,207),new Point(107,207),new Point(106,170),new Point(108,166),new Point(109,162),
                    new Point(109,157),new Point(105,157),new Point(101,152),new Point(94,152),new Point(92,153),
                    new Point(84,150),new Point(78,151),new Point(78,156),new Point(83,161),new Point(80,165),
                    new Point(81,170),new Point(88,180),new Point(88,189),new Point(92,193) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.MENDOZA),
                new Point[] { new Point(47,210),new Point(47,215),new Point(59,228),new Point(60,224),new Point(74,231),
                    new Point(73,215),new Point(72,208),new Point(90,208),new Point(91,199),new Point(92,194),
                    new Point(87,191),new Point(87,182),new Point(87,180),new Point(81,171),new Point(79,164),
                    new Point(83,161),new Point(78,157),new Point(73,155),new Point(72,153),new Point(64,157),
                    new Point(57,153),new Point(51,157),new Point(52,160),new Point(47,162),new Point(48,173),
                    new Point(50,173),new Point(52,182),new Point(48,191),new Point(47,196),new Point(44,200),
                    new Point(47,206) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.SAN_JUAN),
                new Point[] { new Point(78,151),new Point(85,151),new Point(82,144),new Point(82,139),new Point(79,137),
                    new Point(80,132),new Point(75,129),new Point(65,121),new Point(58,121),new Point(60,112),
                    new Point(58,108),new Point(52,103),new Point(49,105),new Point(49,114),new Point(46,116),
                    new Point(47,122),new Point(48,128),new Point(47,130),new Point(44,129),new Point(41,137),
                    new Point(44,141),new Point(40,141),new Point(39,145),new Point(42,153),new Point(45,154),
                    new Point(43,156),new Point(48,163),new Point(50,156),new Point(58,154),new Point(64,157),
                    new Point(70,152),new Point(78,157) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.LA_RIOJA),
                new Point[] { new Point(85,150),new Point(90,153),new Point(99,151),new Point(98,136),new Point(103,126),
                    new Point(90,109),new Point(89,104),new Point(83,99),new Point(79,102),new Point(75,102),
                    new Point(71,102),new Point(69,99),new Point(67,99),new Point(65,95),new Point(65,93),
                    new Point(60,94),new Point(56,94),new Point(54,97),new Point(54,101),new Point(50,103),
                    new Point(57,108),new Point(58,111),new Point(58,119),new Point(63,121),new Point(66,120),
                    new Point(74,127),new Point(81,132),new Point(80,137) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.CATAMARCA),
                new Point[] { new Point(54,94),new Point(59,94),new Point(64,94),new Point(68,100),new Point(69,98),
                    new Point(73,101),new Point(79,102),new Point(81,99),new Point(87,100),new Point(90,103),
                    new Point(91,108),new Point(100,114),new Point(102,119),new Point(103,126),new Point(109,122),
                    new Point(107,119),new Point(110,118),new Point(109,107),new Point(104,103),new Point(105,96),
                    new Point(103,93),new Point(100,96),new Point(97,93),new Point(96,85),new Point(93,85),
                    new Point(93,83),new Point(96,82),new Point(96,78),new Point(92,76),new Point(93,72),
                    new Point(93,69),new Point(90,73),new Point(85,64),new Point(86,57),new Point(76,57),
                    new Point(73,58),new Point(64,56),new Point(61,56),new Point(61,61),new Point(64,69),
                    new Point(60,73),new Point(65,80),new Point(64,84),new Point(60,83) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.SALTA),
                new Point[] { new Point(62,55),new Point(69,58),new Point(75,57),new Point(87,57),new Point(87,61),
                    new Point(84,65),new Point(89,73),new Point(93,70),new Point(98,72),new Point(99,68),
                    new Point(103,68),new Point(113,72),new Point(115,63),new Point(127,63),new Point(141,45),
                    new Point(141,20),new Point(134,11),new Point(128,11),new Point(125,13),new Point(121,11),
                    new Point(118,13),new Point(118,16),new Point(114,20),new Point(111,15),new Point(109,13),
                    new Point(104,12),new Point(102,19),new Point(105,25),new Point(107,30),new Point(108,32),
                    new Point(114,31),new Point(116,31),new Point(117,40),new Point(113,42),new Point(114,47),
                    new Point(109,47),new Point(99,46),new Point(95,41),new Point(93,35),new Point(90,31),
                    new Point(89,33),new Point(89,42),new Point(85,43),new Point(81,39),new Point(78,37),
                    new Point(64,46),new Point(59,52) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.SAN_SALVADOR_DE_JUJUY),
                new Point[] { new Point(76,38),new Point(80,37),new Point(84,40),new Point(88,42),new Point(91,37),
                    new Point(88,32),new Point(90,30),new Point(92,33),new Point(94,38),new Point(96,40),
                    new Point(99,45),new Point(102,45),new Point(109,47),new Point(111,45),new Point(113,46),
                    new Point(113,40),new Point(117,40),new Point(117,30),new Point(114,32),new Point(107,32),
                    new Point(105,26),new Point(101,21),new Point(103,12),new Point(98,12),new Point(94,10),
                    new Point(90,6),new Point(88,10),new Point(85,14),new Point(83,17),new Point(79,19),
                    new Point(77,23),new Point(80,26) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.SAN_MIGUEL_DE_TUCUMAN),
                new Point[] { new Point(94,71),new Point(97,74),new Point(100,71),new Point(99,69),new Point(99,67),
                    new Point(102,68),new Point(107,71),new Point(112,72),new Point(115,75),new Point(107,87),
                    new Point(109,92),new Point(105,95),new Point(104,93),new Point(101,95),new Point(96,93),
                    new Point(96,85),new Point(93,85),new Point(96,78),new Point(93,75) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.SANTIAGO_DEL_ESTERO),
                new Point[] { new Point(115,65),new Point(117,62),new Point(119,64),new Point(126,64),new Point(129,62),
                    new Point(148,63),new Point(149,95),new Point(142,127),new Point(137,128),new Point(137,122),
                    new Point(135,120),new Point(127,121),new Point(123,117),new Point(119,118),new Point(110,118),
                    new Point(110,114),new Point(109,112),new Point(109,105),new Point(104,103),new Point(105,100),
                    new Point(105,95),new Point(108,93),new Point(108,89),new Point(116,76),new Point(113,73) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.RESISTENCIA),
                new Point[] { new Point(127,63),new Point(149,63),new Point(148,96),new Point(183,96),new Point(183,86),
                    new Point(191,81),new Point(182,73),new Point(179,73),new Point(165,57),new Point(147,46),
                    new Point(147,43),new Point(141,42),new Point(141,46)}
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.FORMOSA),
                new Point[] { new Point(141,41),new Point(148,46),new Point(163,52),new Point(179,72),new Point(182,72),
                    new Point(191,81),new Point(194,73),new Point(201,63),new Point(205,61),new Point(198,54),
                    new Point(195,53),new Point(189,50),new Point(187,51),new Point(176,46),new Point(173,40),
                    new Point(164,37),new Point(160,38),new Point(141,20) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.CORRIENTES),
                new Point[] { new Point(172,131),new Point(181,126),new Point(184,126),new Point(186,125),new Point(190,127),
                    new Point(194,135),new Point(195,129),new Point(203,124),new Point(201,122),new Point(204,118),
                    new Point(207,119),new Point(213,113),new Point(216,111),new Point(220,105),new Point(224,101),
                    new Point(220,93),new Point(223,87),new Point(216,91),new Point(215,90),new Point(211,91),
                    new Point(195,84),new Point(189,84),new Point(184,88),new Point(184,93),new Point(181,99),
                    new Point(180,107),new Point(173,114) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.POSADAS),
                new Point[] { new Point(222,87),new Point(219,92),new Point(224,101),new Point(227,100),new Point(233,94),
                    new Point(237,96),new Point(242,90),new Point(247,86),new Point(252,77),new Point(250,74),
                    new Point(250,70),new Point(247,63),new Point(243,63),new Point(240,63),new Point(238,66),
                    new Point(237,77),new Point(234,82),new Point(224,87) }
                );
            imArgentina.AddPolygon(Enum.GetName(typeof(Individuo.Provincias), Individuo.Provincias.PARANA),
                new Point[] { new Point(161, 147), new Point(169, 139), new Point(173, 131), new Point(182, 126),
                    new Point(185, 126), new Point(190, 127), new Point(192, 130), new Point(193, 134),
                    new Point(196, 136), new Point(196, 141), new Point(193, 145), new Point(192, 148),
                    new Point(190, 149), new Point(190, 153), new Point(189, 160), new Point(188, 167),
                    new Point(185, 170), new Point(185, 180), new Point(165, 174), new Point(158, 165),
                    new Point(158, 164), new Point(158, 157), new Point(160, 149) }
                );


        }

        private void imArgentina_Paint(object sender, PaintEventArgs e)
        {
            using (var p = new Pen(Color.Blue, 2))
            {
                Bitmap map = (Bitmap)imArgentina.Image;
                Graphics g = Graphics.FromImage(map);
                g.DrawLine(p, new Point(50, 50), new Point(100, 100));
                imArgentina.Image = map;
            }
        }

    }
}
