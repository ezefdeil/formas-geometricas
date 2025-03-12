using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Model
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal ancho)
        {
            _lado = ancho;
        }

        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 3;
        }
    }
}
