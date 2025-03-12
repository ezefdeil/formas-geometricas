using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Services
{
    public class ReportService
    {


        #region Formas

        public const int CuadradoType = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        #endregion

        private readonly ResourceManager _resourceManager;
        private readonly CultureInfo _cultureInfo;
        /// <summary>
        /// Inicializa un <see cref="ReportService"/> con el idioma por defecto
        /// </summary>
        public ReportService()
        {
            _cultureInfo = CultureInfo.InvariantCulture;
            _resourceManager = new ResourceManager("DevelopmentChallenge.Services.Properties.Resources", typeof(ReportService).Assembly);
        }


        /// <summary>
        /// Inicializa un <see cref="ReportService"/> con el idioma seleccionado
        /// </summary>
        /// <param name="idioma">
        /// Código de idioma en formato estándar de .NET (por ejemplo, "es-ES" para español de España, "en-US" para inglés de EE.UU., "it-IT" para italiano de Italia).
        /// Si el código no es válido, se usará el idioma por defecto.
        /// </param>
        public ReportService(string idioma)
        {
            try
            {
                _cultureInfo = CultureInfo.GetCultureInfo(idioma);
            }
            catch (CultureNotFoundException)
            {
                Console.WriteLine("Idioma no soportado, se utilizara el idioma por defecto.");
                _cultureInfo = CultureInfo.InvariantCulture;
            }

            _resourceManager = new ResourceManager("DevelopmentChallenge.Services.Properties.Resources", typeof(ReportService).Assembly);

        }

        public string Imprimir(List<IFormaGeometrica> formas)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append($"<h1>{_resourceManager.GetString("General-ListaVacia", _cultureInfo)}</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append($"<h1>{_resourceManager.GetString("General-Titulo", _cultureInfo)}</h1>");


                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;

                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i] is Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += formas[i].CalcularArea();
                        perimetroCuadrados += formas[i].CalcularPerimetro();
                    }
                    if (formas[i] is Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += formas[i].CalcularArea();
                        perimetroCirculos += formas[i].CalcularPerimetro();
                    }
                    if (formas[i] is TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += formas[i].CalcularArea();
                        perimetroTriangulos += formas[i].CalcularPerimetro();
                    }
                }

                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, CuadradoType));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero));

                // FOOTER
                sb.Append($"{_resourceManager.GetString("General-TOTAL", _cultureInfo)}:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + _resourceManager.GetString("General-formas", _cultureInfo) + " ");
                sb.Append($"{_resourceManager.GetString("General-Perimetro", _cultureInfo)} {(perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##", _cultureInfo)} ");
                sb.Append($"{_resourceManager.GetString("General-Area", _cultureInfo)} {(areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##", _cultureInfo)}");
            }

            return sb.ToString();
        }

        private string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {TraducirForma(tipo, cantidad)} | {_resourceManager.GetString("General-Area", _cultureInfo)} {$"{area.ToString("#.##", _cultureInfo)}"} | {_resourceManager.GetString("General-Perimetro", _cultureInfo)} {$"{perimetro.ToString("#.##", _cultureInfo)}"} <br/>";
            }

            return string.Empty;
        }

        private string TraducirForma(int tipo, int cantidad)
        {
            switch (tipo)
            {
                case CuadradoType:
                    return cantidad == 1 ? _resourceManager.GetString("Forma-Cuadrado", _cultureInfo) : _resourceManager.GetString("Forma-Cuadrados", _cultureInfo);
                case Circulo:
                    return cantidad == 1 ? _resourceManager.GetString("Forma-Circulo", _cultureInfo) : _resourceManager.GetString("Forma-Circulos", _cultureInfo);
                case TrianguloEquilatero:
                    return cantidad == 1 ? _resourceManager.GetString("Forma-Triangulo", _cultureInfo) : _resourceManager.GetString("Forma-Triangulos", _cultureInfo);
            }

            return string.Empty;
        }
    }
}
