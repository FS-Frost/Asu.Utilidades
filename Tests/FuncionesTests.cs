using Asu.Utils;
using Asu.Utils.Core;
using NUnit.Framework;
using System.Collections.Generic;

namespace Asu.Tests {
    [TestFixture]
    public class FuncionesTests {
        #region Casos de prueba
        static readonly object[] casosTruncar = {
            new object[] {
                0.123456789,
                0,
                0},
            new object[] {
                0.123456789,
                0.1,
                1},
            new object[] {
                0.123456789,
                0.12,
                2},
            new object[] {
                0.123456789,
                0.123,
                3},
            new object[] {
                0.123456789,
                0.1234,
                4},
            new object[] {
                0.123456789,
                0.12345,
                5},
            new object[] {
                0.123456789,
                0.123456,
                6},
            new object[] {
                0.123456789,
                0.1234567,
                7},
            new object[] {
                0.123456789,
                0.12345678,
                8},
            new object[] {
                0.123456789,
                0.123456789,
                9},
            new object[] {
                10.14,
                10.14,
                2},
        };

        static readonly object[] casosIntToHex = {
            new object[] {
                0,
                "0" },
            new object[] {
                255,
                "FF" },
        };

        static readonly object[] casosIntToHexDigitos = {
            new object[] {
                0,
                "00",
                2 },
            new object[] {
                9,
                "09",
                2 },
            new object[] {
                10,
                "0A",
                2 },
            new object[] {
                255,
                "FF",
                2 },
        };

        static readonly object[] casosHexToInt = {
            new object[] {
                "0",
                0 },
            new object[] {
                "FF",
                255 },
            new object[] {
                "0A",
                10 },
            new object[] {
                "00A",
                10 },
            new object[] {
                "",
                0 },
        };

        static readonly object[] casosFiltrarColores = {
            new object[] {
                "0C2238",
                new TagTypeColor(12, 34, 56) },
            new object[] {
                "FF",
                new TagTypeColor(255, 0, 0) },
            new object[] {
                "0C2200",
                new TagTypeColor(12, 34, 0) },
            new object[] {
                "0C2205",
                new TagTypeColor(12, 34, 5) },
            new object[] {
                "",
                new TagTypeColor(0, 0, 0) },
        };
        #endregion

        [SetUp]
        public void Iniciar() {
            Funciones.ChangeCulture();
        }

        #region Pruebas
        [Test, Category("Funciones"), TestCaseSource("casosTruncar")]
        public void FuncionesTruncar(double ingresado, double esperado, int decimales) {
            var real = Maths.Truncate(ingresado, decimales);
            Assert.AreEqual(esperado, real);
        }

        [Test, Category("Funciones"), TestCaseSource("casosIntToHex")]
        public void FuncionesIntToHex(int ingresado, string esperado) {
            var real = Maths.IntToHex(ingresado);
            Assert.AreEqual(esperado, real);
        }

        [Test, Category("Funciones"), TestCaseSource("casosIntToHexDigitos")]
        public void FuncionesIntToHexDigitos(int ingresado, string esperado, int digitos) {
            var real = Maths.IntToHex(ingresado, digitos);
            Assert.AreEqual(esperado, real);
        }

        [Test, Category("Funciones"), TestCaseSource("casosHexToInt")]
        public void FuncionesHexToInt(string ingresado, int esperado) {
            var real = Maths.HexToInt(ingresado);
            Assert.AreEqual(esperado, real);
        }

        [Test, Category("Funciones"), TestCaseSource("casosFiltrarColores")]
        public void FuncionesFiltrarColores(string ingresado, TagTypeColor esperado) {
            var real = Carteles.FilterColors(ingresado);
            Assert.AreEqual(esperado, real);
        }

        [Test, Category("Funciones")]
        public void FuncionesInterpolar() {
            var esperado = new List<int> {
                0,
                10,
                20,
                30,
                40,
                50,
                60,
                70,
                80,
                100
            };

            var real = Maths.Interpolate(0, 100, 10);
            Assert.AreEqual(esperado, real);
        }
        #endregion
    }
}
