using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Model
{
    public class TrapecioIsosceles : IFormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;
        private readonly decimal _ladoNoParalelo;

        public TrapecioIsosceles(decimal baseMayor, decimal baseMenor, decimal altura)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
            _ladoNoParalelo = (decimal)Math.Sqrt((double)(((baseMayor - baseMenor) / 2) * ((baseMayor - baseMenor) / 2) + altura * altura));
        }

        public decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) / 2) * _altura;
        }

        public decimal CalcularPerimetro()
        {
            return _baseMayor + _baseMenor + 2 * _ladoNoParalelo;
        }
    }

}
