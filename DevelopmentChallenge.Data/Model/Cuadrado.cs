using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Model
{
    public class Cuadrado : IFormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal ancho)
        {
            _lado = ancho;
        }

        public decimal CalcularArea()
        {
            return _lado * _lado;
            //switch (Tipo)
            //{
            //    case CuadradoType: return _lado * _lado;
            //    case Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
            //    case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
            //    default:
            //        throw new ArgumentOutOfRangeException(@"Forma desconocida");
            //}
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 4;
            
            //switch (Tipo)
            //{
            //    case CuadradoType: return _lado * 4;
            //    case Circulo: return (decimal)Math.PI * _lado;
            //    case TrianguloEquilatero: return _lado * 3;
            //    default:
            //        throw new ArgumentOutOfRangeException(@"Forma desconocida");
            //}
        }
    }
}
