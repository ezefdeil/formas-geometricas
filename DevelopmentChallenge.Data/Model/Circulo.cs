using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Model
{
    public class Circulo : IFormaGeometrica
    {
        private readonly decimal _lado;

        public Circulo(decimal ancho)
        {
            _lado = ancho;
        }

        public decimal CalcularArea()
        {
            throw new NotImplementedException();
        }

        public decimal CalcularPerimetro()
        {
            throw new NotImplementedException();
        }
    }
}
