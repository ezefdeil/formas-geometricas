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
        private const string _resourcesBaseName = "DevelopmentChallenge.Services.Properties.Resources";

        private readonly ResourceManager _resourceManager;
        private readonly CultureInfo _cultureInfo;
        /// <summary>
        /// Inicializa un <see cref="ReportService"/> con el idioma por defecto
        /// </summary>
        public ReportService() : this(string.Empty) { }


        /// <summary>
        /// Inicializa un <see cref="ReportService"/> con el idioma seleccionado
        /// </summary>
        /// <param name="idioma">
        /// Código de idioma en formato estándar de .NET (por ejemplo, "es-ES" para español de España, "en-US" para inglés de EE.UU., "it-IT" para italiano de Italia).
        /// Si el código no es válido, se usará el idioma por defecto.
        /// </param>
        public ReportService(string idioma)
        {
            if (string.IsNullOrWhiteSpace(idioma))
            {
                _cultureInfo = CultureInfo.InvariantCulture;
            }
            else
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
            }

            _resourceManager = new ResourceManager(_resourcesBaseName, typeof(ReportService).Assembly);

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


                var areaByTipoForma = new Dictionary<Type, decimal>();
                var perimetroByTipoForma = new Dictionary<Type, decimal>();

                foreach (var formaGroup in formas.GroupBy(x => x.GetType()))
                {
                    var area = formaGroup.Sum(x => x.CalcularArea());
                    var perimetro = formaGroup.Sum(x => x.CalcularPerimetro());

                    areaByTipoForma.Add(formaGroup.Key, area);
                    perimetroByTipoForma.Add(formaGroup.Key, perimetro);
                    sb.Append(ObtenerLinea(formaGroup.Count(), area, perimetro, formaGroup.Key));
                }

                // FOOTER
                sb.Append($"{_resourceManager.GetString("General-TOTAL", _cultureInfo)}:<br/>");
                sb.Append(formas.Count + " " + _resourceManager.GetString("General-formas", _cultureInfo) + " ");
                sb.Append($"{_resourceManager.GetString("General-Perimetro", _cultureInfo)} {perimetroByTipoForma.Sum(x => x.Value).ToString("#.##", _cultureInfo)} ");
                sb.Append($"{_resourceManager.GetString("General-Area", _cultureInfo)} {areaByTipoForma.Sum(x => x.Value).ToString("#.##", _cultureInfo)}");
            }

            return sb.ToString();
        }

        private string ObtenerLinea(int cantidad, decimal area, decimal perimetro, Type tipoForma)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {TraducirForma(tipoForma, cantidad)} | {_resourceManager.GetString("General-Area", _cultureInfo)} {$"{area.ToString("#.##", _cultureInfo)}"} | {_resourceManager.GetString("General-Perimetro", _cultureInfo)} {$"{perimetro.ToString("#.##", _cultureInfo)}"} <br/>";
            }

            return string.Empty;
        }

        private string TraducirForma(Type tipoForma, int cantidad)
        {
            return cantidad == 1 ? _resourceManager.GetString($"Forma-{tipoForma.Name}", _cultureInfo) : _resourceManager.GetString($"Forma-{tipoForma.Name}-Plural", _cultureInfo);
        }
    }
}
