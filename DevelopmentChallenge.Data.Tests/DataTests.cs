using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Model;
using DevelopmentChallenge.Services;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            var reportService = new ReportService("es");

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                reportService.Imprimir(new List<IFormaGeometrica>()));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            var reportService = new ReportService("en");
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                reportService.Imprimir(new List<IFormaGeometrica>()));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var reportService = new ReportService("es");
            var cuadrados = new List<IFormaGeometrica> { new Cuadrado(5) };

            var resumen = reportService.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var reportService = new ReportService("en");
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = reportService.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var reportService = new ReportService("en");

            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = reportService.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var reportService = new ReportService("es");

            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = reportService.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos2EnCastellano()
        {
            var reportService = new ReportService("es");

            var formas = new List<IFormaGeometrica>
    {
        new Cuadrado(5),
        new Circulo(3),
        new TrianguloEquilatero(4),
        new Cuadrado(2),
        new TrianguloEquilatero(9),
        new Circulo(2.75m),
        new TrianguloEquilatero(4.2m),
        new Rectangulo(4, 6),
        new Rectangulo(3, 7),
        new TrapecioIsosceles(8, 4, 5),
        new TrapecioIsosceles(6, 3, 4)
    };

            var resumen = reportService.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>2 Rectángulos | Area 45 | Perimetro 40 <br/>2 Trapecios | Area 48 | Perimetro 40,31 <br/>TOTAL:<br/>11 formas Perimetro 177,98 Area 184,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos2EnItaliano()
        {
            var reportService = new ReportService("it");

            var formas = new List<IFormaGeometrica>
    {
        new Cuadrado(5),
        new Circulo(3),
        new TrianguloEquilatero(4),
        new Cuadrado(2),
        new TrianguloEquilatero(9),
        new Circulo(2.75m),
        new TrianguloEquilatero(4.2m),
        new Rectangulo(4, 6),
        new Rectangulo(3, 7),
        new TrapecioIsosceles(8, 4, 5),
        new TrapecioIsosceles(6, 3, 4)
    };

            var resumen = reportService.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Rapporto delle Forme</h1>" +
                "2 Quadrati | Area 29 | Perimetro 28 <br/>" +
                "2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>" +
                "3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>" +
                "2 Rettangoli | Area 45 | Perimetro 40 <br/>" +
                "2 Trapezi | Area 48 | Perimetro 40,31 <br/>" +
                "TOTALE:<br/>11 forme Perimetro 177,98 Area 184,65",
                resumen);
        }

    }
}
