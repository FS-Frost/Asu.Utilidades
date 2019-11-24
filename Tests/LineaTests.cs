using Asu.Utils.Core;
using NUnit.Framework;

namespace Asu.Tests {
    [TestFixture]
    public class LineaTests {
        #region Casos de prueba
        static readonly object[] casosString = {
            new object[] {
                @"Dialogue: 0,0:00:00.00,0:00:05.00,Default,,0,0,0,,Texto",
                @"Dialogue: 0,0:00:00.00,0:00:05.00,Default,,0,0,0,,Texto" },
            new object[] {
                @"Dialogue: 0,0:00:00.00,0:00:05.00,Default,,0,0,0,,TextoDialogue: 0,0:00:00.00,0:00:05.00,Default,,0,0,0,,",
                @"Dialogue: 0,0:00:00.00,0:00:05.00,Default,,0,0,0,,TextoDialogue: 0,0:00:00.00,0:00:05.00,Default,,0,0,0,," },
            new object[] {
                @"Dialogue: 1,2:22:22.22,3:33:33.33,Default - Copia,;Actor; actor2,4,5,6,;Efecto; efecto2,Texto texto",
                @"Dialogue: 1,2:22:22.22,3:33:33.33,Default - Copia,;Actor; actor2,4,5,6,;Efecto; efecto2,Texto texto" },
        };
        #endregion
        
        [Test, Category("Linea"), TestCaseSource("casosString")]
        public void LineaString(string ingresado, string esperado) {
            var lIngresado = new Line(ingresado);
            var lEsperado = new Line(esperado);
            Assert.AreEqual(lEsperado.ToString(), lIngresado.ToString());
        }

        [Test, Category("Linea")]
        public void LineaDuracion() {
            var s = @"Dialogue: 0,0:00:00.01,0:00:02.99,Default - Copia,,0,0,0,,";
            var l = new Line(s);
            Assert.AreEqual(2.98, l.Length);
        }
    }
}
