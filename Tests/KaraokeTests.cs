using Asu.Utils.Core;
using NUnit.Framework;

namespace Asu.Tests {
    [TestFixture]
    class KaraokeTests {
        #region Casos de prueba
        static readonly object[] casosToString = {
            // Normal.
            new object[] {
                @"Comment: 0,0:02:18.20,0:02:20.55,Romaji,,0,0,0,karaoke,{\kf21}a{\kf20}ri{\kf21}fu{\kf23}re{\kf20}ta {\kf22}mo{\kf22}no {\kf21}da{\kf24}ke{\kf41}do",
                @"{\kf21}a{\kf20}ri{\kf21}fu{\kf23}re{\kf20}ta {\kf22}mo{\kf22}no {\kf21}da{\kf24}ke{\kf41}do" },
            
            // Normal.
            new object[] {
                @"Comment: 0,0:02:18.20,0:02:20.55,Romaji,,0,0,0,karaoke,{\k1}tsu{\k2}ku{\k3}ri{\k4}mo{\k5}no{\k6} {\k7}ja{\k8}na{\k9}i{\k10} {\k11}ha{\k12}p{\k13}pi {\k14}e{\k15}n{\k16}do {\k17}he",
                @"{\k1}tsu{\k2}ku{\k3}ri{\k4}mo{\k5}no{\k6} {\k7}ja{\k8}na{\k9}i{\k10} {\k11}ha{\k12}p{\k13}pi {\k14}e{\k15}n{\k16}do {\k17}he" },
        };
        #endregion

        [Test, Category("Karaoke"), TestCaseSource("casosToString")]
        public void KaraokeToString(string ingresado, string esperado) {
            var linea = new Linea(ingresado);
            var karaoke = new Karaoke(linea.Contenido);
            Assert.AreEqual(esperado, karaoke.ToString());
        }
    }
}
