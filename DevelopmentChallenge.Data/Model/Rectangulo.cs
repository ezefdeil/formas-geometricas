using DevelopmentChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Model
{
    public class Rectangulo : IFormaGeometrica
    {
        private readonly decimal _ancho;
        private readonly decimal _alto;

        public Rectangulo(decimal ancho, decimal alto)
        {
            _ancho = ancho;
            _alto = alto;
        }

        public decimal CalcularArea()
        {
            return _ancho * _alto;
        }

        public decimal CalcularPerimetro()
        {
            return 2 * (_ancho + _alto);
        }
    }

}
