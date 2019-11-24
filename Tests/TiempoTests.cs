using Asu.Utils;
using NUnit.Framework;

namespace Asu.Tests {
    [TestFixture]
    public class TiempoTests {
        #region Casos de prueba
        static readonly object[] casosString = {
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

        static readonly object[] casosHMS = {
            // Normal.
            new object[] {
                new Time(1, 23, 45.67),
                "1:23:45.67" },

            // Nulo.
            new object[] {
                new Time(),
                "0:00:00.00" },
            
            // Hora fuera de rango.
            new object[] {
                new Time(12, 23, 45.67),
                "9:59:59.99" },

            // Minutos fuera de rango.
            new object[] {
                new Time(1, 63, 45.67),
                "2:03:45.67" },

            // Segundos fuera de rango.
            new object[] {
                new Time(1, 23, 75.67),
                "1:24:15.67" },

            // Centésimas de segundo fuera de rango.
            new object[] {
                new Time(1, 23, 75.678),
                "1:24:15.67" },
        };

        static readonly object[] casosSumarRestar = {
            // Normal.
            new object[] {
                new Time("1:11:11.11"),
                new Time("2:22:22.22"),
                new Time("3:33:33.33") },

            // Nulo.
            new object[] {
                new Time(""),
                new Time("1:23:45.67"),
                new Time(1, 23, 45.67) },

            // Suma a nivel de centésimas fuera de rango.
            new object[] {
                new Time("1:23:45.678"),
                new Time("0:00:00.002"),
                new Time(1, 23, 45.67) },
        };

        static readonly object[] casosEquals = {
            new object[] {
                new Time("1:11:11.11"),
                new Time(1, 11, 11.11) },
            new object[] {
                new Time(""),
                new Time(0, 0, 0) },
            new object[] {
                new Time(2),
                new Time(0, 0, 2) },
            new object[] {
                new Time(0.2),
                new Time(0, 0, 0.2) },
            new object[] {
                new Time(3600),
                new Time(1, 0, 0) },
            new object[] {
                new Time(60),
                new Time(0, 1, 0) },
            new object[] {
                new Time("1:23:45.678"),
                new Time(1, 23, 45.67) },
            new object[] {
                new Time("1:23:45.678"),
                new Time(1, 23, 45.678) },

        };
        #endregion

        [SetUp]
        public void Iniciar() {
            Funciones.ChangeCulture();
        }

        [Test, Category("Tiempo"), TestCaseSource("casosString")]
        public void TiempoString(string ingresado, string esperado) {
            var tIngresado = new Time(ingresado);

            // Comparación en string.
            Assert.AreEqual(esperado, tIngresado.ToString());

            // Comparación en double.
            Assert.AreEqual(new Time(esperado).ToDouble(), 
                tIngresado.ToDouble());
        }

        [Test, Category("Tiempo"), TestCaseSource("casosHMS")]
        public void TiempoHMS(Time ingresado, string esperado) {
            // Comparación en string.
            Assert.AreEqual(ingresado.ToString(), esperado);

            // Comparación en double.
            Assert.AreEqual(new Time(esperado).ToDouble(), 
                ingresado.ToDouble());
        }

        [Test, Category("Tiempo")]
        public void TiempoDouble() {
            var t1 = new Time(3720.12);
            var t2 = new Time("1:02:00.12");
            Assert.AreEqual(t1.Seconds, t2.Seconds);
            Assert.AreEqual(t1.ToDouble(), t2.ToDouble());
        }

        [Test, Category("Tiempo")]
        public void TiempoTiempo() {
            var t1 = new Time("1:02:00.12");
            var t2 = new Time(t1);
            Assert.AreEqual(t1.ToDouble(), t2.ToDouble());
        }

        [Test, Category("Tiempo")]
        public void TiempoToString() {
            var t = new Time {
                Hours = 1,
                Minutes = 23,
                Seconds = 45.678
            };
            Assert.AreEqual("1:23:45.67", t.ToString());
        }

        [Test, Category("Tiempo")]
        public void TiempoToDouble() {
            var s = "0:00:00.12";
            var t = new Time(s);
            Assert.AreEqual(0.12, t.ToDouble());
        }

        [Test, Category("Tiempo"), TestCaseSource("casosEquals")]
        public void TiempoEquals(Time t1, Time t2) {
            Assert.IsTrue(t1.Equals(t2));
        }

        [Test, Category("Tiempo"), TestCaseSource("casosSumarRestar")]
        public void TiempoSumar(Time t1, Time t2, Time resultado) {
            Assert.AreEqual(resultado.ToString(), (t1 + t2).ToString());
            Assert.AreEqual(resultado.ToDouble(), (t1 + t2).ToDouble());
        }

        [Test, Category("Tiempo"), TestCaseSource("casosSumarRestar")]
        public void TiempoRestar(Time resultado, Time t1, Time t2) {
            Assert.AreEqual(resultado.ToString(), (t2 - t1).ToString());
            Assert.AreEqual(resultado.ToDouble(), (t2 - t1).ToDouble());
        }
        
        [Test, Category("Tiempo")]
        public void TiempoSumarDecimales() {
            var t1 = new Time(0, 00, 00.008);
            var t2 = new Time(0, 00, 00.002);
            var t3 = new Time("0:00:00.00");
            Assert.AreEqual(t3.ToDouble(), (t1 + t2).ToDouble());
        }
    }
}
