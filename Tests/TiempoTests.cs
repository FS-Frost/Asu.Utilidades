using Asu.Utilidades;
using NUnit.Framework;

namespace Asu.Tests {
    [TestFixture]
    public class TiempoTests {
        #region Casos de prueba
        static object[] casosString = {
            // Normal.
            new object[] {
                "1:23:45.67",
                "1:23:45.67" },

            // Nulo.
            new object[] {
                "",
                "0:00:00.00" },
            
            // Separación decimal errónea.
            new object[] {
                "1:23:45,67",
                "1:23:45.00" },

            // Hora fuera de rango.
            new object[] {
                "12:23:45.67",
                "9:59:59.99" },

            // Minutos fuera de rango.
            new object[] {
                "1:63:45.67",
                "2:03:45.67" },

            // Segundos fuera de rango.
            new object[] {
                "1:23:75.67",
                "1:24:15.67" },

            // Centésimas de segundo fuera de rango.
            new object[] {
                "1:23:75.678",
                "1:24:15.67" },
            
            // Centésimas de segundo fuera de rango.
            new object[] {
                "0:01:10.04",
                "0:01:10.04" },
        };

        static object[] casosHMS = {
            // Normal.
            new object[] {
                new Tiempo(1, 23, 45.67),
                "1:23:45.67" },

            // Nulo.
            new object[] {
                new Tiempo(),
                "0:00:00.00" },
            
            // Hora fuera de rango.
            new object[] {
                new Tiempo(12, 23, 45.67),
                "9:59:59.99" },

            // Minutos fuera de rango.
            new object[] {
                new Tiempo(1, 63, 45.67),
                "2:03:45.67" },

            // Segundos fuera de rango.
            new object[] {
                new Tiempo(1, 23, 75.67),
                "1:24:15.67" },

            // Centésimas de segundo fuera de rango.
            new object[] {
                new Tiempo(1, 23, 75.678),
                "1:24:15.67" },
        };

        static object[] casosSumarRestar = {
            // Normal.
            new object[] {
                new Tiempo("1:11:11.11"),
                new Tiempo("2:22:22.22"),
                new Tiempo("3:33:33.33") },

            // Nulo.
            new object[] {
                new Tiempo(""),
                new Tiempo("1:23:45.67"),
                new Tiempo(1, 23, 45.67) },

            // Suma a nivel de centésimas fuera de rango.
            new object[] {
                new Tiempo("1:23:45.678"),
                new Tiempo("0:00:00.002"),
                new Tiempo(1, 23, 45.67) },
        };

        static object[] casosEquals = {
            new object[] {
                new Tiempo("1:11:11.11"),
                new Tiempo(1, 11, 11.11) },
            new object[] {
                new Tiempo(""),
                new Tiempo(0, 0, 0) },
            new object[] {
                new Tiempo(2),
                new Tiempo(0, 0, 2) },
            new object[] {
                new Tiempo(0.2),
                new Tiempo(0, 0, 0.2) },
            new object[] {
                new Tiempo(3600),
                new Tiempo(1, 0, 0) },
            new object[] {
                new Tiempo(60),
                new Tiempo(0, 1, 0) },
            new object[] {
                new Tiempo("1:23:45.678"),
                new Tiempo(1, 23, 45.67) },
            new object[] {
                new Tiempo("1:23:45.678"),
                new Tiempo(1, 23, 45.678) },

        };
        #endregion

        [SetUp]
        public void Iniciar() {
            Funciones.CambiarCultura();
        }

        [Test, Category("Tiempo"), TestCaseSource("casosString")]
        public void TiempoString(string ingresado, string esperado) {
            var tIngresado = new Tiempo(ingresado);

            // Comparación en string.
            Assert.AreEqual(esperado, tIngresado.ToString());

            // Comparación en double.
            Assert.AreEqual(new Tiempo(esperado).ToDouble(), 
                tIngresado.ToDouble());
        }

        [Test, Category("Tiempo"), TestCaseSource("casosHMS")]
        public void TiempoHMS(Tiempo ingresado, string esperado) {
            // Comparación en string.
            Assert.AreEqual(ingresado.ToString(), esperado);

            // Comparación en double.
            Assert.AreEqual(new Tiempo(esperado).ToDouble(), 
                ingresado.ToDouble());
        }

        [Test, Category("Tiempo")]
        public void TiempoDouble() {
            var t1 = new Tiempo(3720.12);
            var t2 = new Tiempo("1:02:00.12");
            Assert.AreEqual(t1.Segundos, t2.Segundos);
            Assert.AreEqual(t1.ToDouble(), t2.ToDouble());
        }

        [Test, Category("Tiempo")]
        public void TiempoTiempo() {
            var t1 = new Tiempo("1:02:00.12");
            var t2 = new Tiempo(t1);
            Assert.AreEqual(t1.ToDouble(), t2.ToDouble());
        }

        [Test, Category("Tiempo")]
        public void TiempoToString() {
            var t = new Tiempo {
                Horas = 1,
                Minutos = 23,
                Segundos = 45.678
            };
            Assert.AreEqual("1:23:45.67", t.ToString());
        }

        [Test, Category("Tiempo")]
        public void TiempoToDouble() {
            var s = "0:00:00.12";
            var t = new Tiempo(s);
            Assert.AreEqual(0.12, t.ToDouble());
        }

        [Test, Category("Tiempo"), TestCaseSource("casosEquals")]
        public void TiempoEquals(Tiempo t1, Tiempo t2) {
            Assert.IsTrue(t1.Equals(t2));
        }

        [Test, Category("Tiempo"), TestCaseSource("casosSumarRestar")]
        public void TiempoSumar(Tiempo t1, Tiempo t2, Tiempo resultado) {
            Assert.AreEqual(resultado.ToString(), (t1 + t2).ToString());
            Assert.AreEqual(resultado.ToDouble(), (t1 + t2).ToDouble());
        }

        [Test, Category("Tiempo"), TestCaseSource("casosSumarRestar")]
        public void TiempoRestar(Tiempo resultado, Tiempo t1, Tiempo t2) {
            Assert.AreEqual(resultado.ToString(), (t2 - t1).ToString());
            Assert.AreEqual(resultado.ToDouble(), (t2 - t1).ToDouble());
        }
        
        [Test, Category("Tiempo")]
        public void TiempoSumarDecimales() {
            var t1 = new Tiempo(0, 00, 00.008);
            var t2 = new Tiempo(0, 00, 00.002);
            var t3 = new Tiempo("0:00:00.00");
            Assert.AreEqual(t3.ToDouble(), (t1 + t2).ToDouble());
        }
    }
}
