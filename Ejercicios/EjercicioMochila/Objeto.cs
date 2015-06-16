﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioMochila
{
    class Objeto : IComparable<Objeto>
    {
        public double Volumen { get; set; }
        public double Valor { get; set; }
        public double ValorPorVol { get; set; }
        public Objeto(double volumen, double valor)
        {
            this.Volumen = volumen;
            this.Valor = valor;
            this.ValorPorVol = this.Valor / this.Volumen;
        }
        public int CompareTo(Objeto compareObjeto)
        {
            // A null value means that this object is greater.
            if (compareObjeto == null)
                return 1;

            else
                return this.ValorPorVol.CompareTo(compareObjeto.ValorPorVol);
        }
    }
}
