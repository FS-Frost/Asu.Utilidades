using Asu.Utilidades;
using Asu.Utilidades.Clases;
using NUnit.Framework;

namespace Asu.Tests {
    [TestFixture]
    public class TagsTests {
        #region Casos de prueba
        // Casos ordenados por: { valorIngresado, valorEsperado }.

        // Tag: a.
        // Rango: entero del 1 al 11.
        static object[] casosA = {
            new object[] {
                @"\a0",
                @"\a0" },
            new object[] {
                @"\a1",
                @"\a1" },
            new object[] {
                @"\a2.2",
                @"\a2" },
            new object[] {
                @"\a11",
                @"\a11" },
            new object[] {
                @"\a12",
                @"\a1" },
        };

        // Tag: an.
        // Rango: entero del 1 al 9.
        static object[] casosAn = {
            new object[] {
                @"\an0",
                @"\an0" },
            new object[] {
                @"\an1",
                @"\an1" },
            new object[] {
                @"\an2.2",
                @"\an2" },
            new object[] {
                @"\an11",
                @"\an1" },
            new object[] {
                @"\an12",
                @"\an1" },
        };

        // Tag: alpha, 1a, 2a, 3a, 4a.
        // Argumentos: [&H]rr[gg][bb][&]
        // Rango: rr,gg,bb -> hexadecimal del 0 al FF.
        static object[] casosAlpha = {
            // Argumentos del mínimo al máximo.
            new object[] {
                @"&H1&",
                @"&H01&" },
            new object[] {
                @"&H12&",
                @"&H12&" },
            
            // Argumentos del mínimo al máximo, sin el "&H"
            new object[] {
                @"1&",
                @"&H01&" },
            new object[] {
                @"12&",
                @"&H12&" },

            // Argumentos del mínimo al máximo, sin el "&".
            new object[] {
                @"&H1",
                @"&H01&" },
            new object[] {
                @"&H12",
                @"&H12&" },

            // Argumentos del mínimo al máximo, sin el "&H" ni el "&".
            new object[] {
                @"1",
                @"&H01&" },
            new object[] {
                @"12",
                @"&H12&" },

            // Argumentos inválidos.
            new object[] {
                @"&HFH&",
                @"&H0F&" },
            new object[] {
                @"&HHH&",
                @"&H00&" },
        };

        // Tag: b, i, s, u.
        // Rango: entero del 0 al 1.
        static object[] casosBinario = {
            // Argumento positivo.
            new object[] {
                @"1",
                @"1" },

            // Argumento con texto delante.
            new object[] {
                @"texto1",
                @"0" },

            // Argumento con texto detrás.
            new object[] {
                @"1texto",
                @"1" },

            // Argumento con espacio delante.
            new object[] {
                @"  1",
                @"1" },

            // Argumento fuera de rango.
            new object[] {
                @"2",
                @"0" },
        };

        // Tag: be, p.
        // Rango: entero positivo.
        static object[] casosEnteroPositivo = {
            // Argumento positivo.
            new object[] {
                @"0",
                @"0" },

            // Argumento con texto delante.
            new object[] {
                @"texto1",
                @"0" },

            // Argumento con texto detrás.
            new object[] {
                @"3texto",
                @"3" },

            // Argumento con espacio delante.
            new object[] {
                @"  3",
                @"3" },
        };

        // Tag: blur, fs.
        // Rango: decimal positivo.
        static object[] casosDoublePositivo = {
            // Argumento positivo.
            new object[] {
                @"1",
                @"1" },

            // Argumento positivo y decimal.
            new object[] {
                @"1.1",
                @"1.1" },

            // Argumento con texto delante.
            new object[] {
                @"texto1",
                @"0" },

            // Argumento con texto detrás.
            new object[] {
                @"1texto",
                @"1" },

            // Argumento con espacio delante.
            new object[] {
                @"  1",
                @"1" },
        };

        // Tag: bord, xbord, ybord, fax, fay, frx, fry, frz, fscx, fscy, fsp, pbo, shad, xshad, yshad.
        // Rango: decimal.
        static object[] casosDouble = {
            // Argumento positivo.
            new object[] {
                @"1",
                @"1" },

            // Argumento positivo y decimal.
            new object[] {
                @"1.1",
                @"1.1" },

            // Argumento negativo.
            new object[] {
                @"-1",
                @"-1" },

            // Argumento negativo y decimal.
            new object[] {
                @"-1.1",
                @"-1.1" },

            // Argumento con texto delante.
            new object[] {
                @"texto1",
                @"0" },

            // Argumento con texto detrás.
            new object[] {
                @"1texto",
                @"1" },

            // Argumento con espacio delante.
            new object[] {
                @"  1",
                @"1" },
        };

        // Tag: clip.
        // Argumentos: x1,y1,x2,y2 |comandos| escala,comandos.
        // Rango: x,y -> decimal; escala -> entero positivo.
        static object[] casosClip = {
            // Argumentos: rectángulo.
            new object[] {
                @"(0,0,-320.2,240)",
                @"(0,0,-320.2,240)" },

            // Argumentos: rectángulo, con espacios delante.
            new object[] {
                @"( 0, 0, -320.2, 240)",
                @"(0,0,-320.2,240)" },

            // Argumentos: rectángulo, con espacios detrás.
            new object[] {
                @"(0 ,0 ,-320.2 ,240 )",
                @"(0,0,-320.2,240)" },

            // Argumentos: comandos.
            new object[] {
                @"(m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)",
                @"(m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)"
            },

            // Argumentos: escala y comandos.
            new object[] {
                @"(1,m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)",
                @"(1,m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)"},

            // Argumentos: escala con texto detrás y comandos.
            new object[] {
                @"(1texto,m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)",
                @"(1,m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)"},

            // Argumentos: escala con texto delante y comandos.
            new object[] {
                @"(texto1,m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)",
                @"()"},

            // Argumentos: escala y comandos con espacios detrás.
            new object[] {
                @"(1,  m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)",
                @"(1,m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)"},

            // Argumentos: escala y comandos con texto detrás.
            new object[] {
                @"(1,textom 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)",
                @"()"},
        };

        // Tag: iclip.
        // Argumentos: x1,y1,x2,y2 |comandos| escala,comandos.
        // Rango: x,y -> decimal; escala -> entero positivo.
        // Tag: c, 1c, 2c, 3c, 4c. Rango hexadecimal del 0 al FF.
        static object[] casosColor = {
            // Argumentos del mínimo al máximo.
            new object[] {
                @"&H1&",
                @"&H010000&" },
            new object[] {
                @"&H12&",
                @"&H120000&" },
            new object[] {
                @"&H123&",
                @"&H120300&" },
            new object[] {
                @"&H1234&",
                @"&H123400&" },
            new object[] {
                @"&H12345&",
                @"&H123405&" },
            new object[] {
                @"&H123456&",
                @"&H123456&" },

            // Argumentos del mínimo al máximo, sin el "&H"
            new object[] {
                @"1&",
                @"&H010000&" },
            new object[] {
                @"12&",
                @"&H120000&" },
            new object[] {
                @"123&",
                @"&H120300&" },
            new object[] {
                @"1234&",
                @"&H123400&" },
            new object[] {
                @"12345&",
                @"&H123405&" },
            new object[] {
                @"123456&",
                @"&H123456&" },

            // Argumentos del mínimo al máximo, sin el "&".
            new object[] {
                @"&H1",
                @"&H010000&" },
            new object[] {
                @"&H12",
                @"&H120000&" },
            new object[] {
                @"&H123",
                @"&H120300&" },
            new object[] {
                @"&H1234",
                @"&H123400&" },
            new object[] {
                @"&H12345",
                @"&H123405&" },
            new object[] {
                @"&H123456",
                @"&H123456&" },

            // Argumentos del mínimo al máximo, sin el "&H" ni el "&".
            new object[] {
                @"1",
                @"&H010000&" },
            new object[] {
                @"12",
                @"&H120000&" },
            new object[] {
                @"123",
                @"&H120300&" },
            new object[] {
                @"1234",
                @"&H123400&" },
            new object[] {
                @"12345",
                @"&H123405&" },
            new object[] {
                @"123456",
                @"&H123456&" },
        };

        // Tag: fad.
        // Argumentos: t1,t2.
        // Rango: entero positivo.
        static object[] casosFad = {
            // Argumentos positivos.
            new object[] {
                @"\fad(1,2)",
                @"\fad(1,2)" },
            
            // Argumentos positivos y decimales.
            new object[] {
                @"\fad(1.3,4.5)",
                @"\fad(1,4)" },
            
            // Argumentos negativos.
            new object[] {
                @"\fad(-1,-2)",
                @"\fad(-1,-2)" },
            
            // Argumentos negativos y decimales.
            new object[] {
                @"\fad(-1.2,-3.4)",
                @"\fad(-1,-3)" },

            // "fade" con dos argumentos, que es un "fad".
            new object[] {
                @"\fade(1,2)",
                @"\fad(1,2)" },

            // Texto tras los argumentos.
            new object[] {
                @"\fad(1texto1,2texto1)",
                @"\fad(1,2)" },
            
            // Argumentos entre espacios.
            new object[] {
                @"\fad(  1  ,  2  )",
                @"\fad(1,2)" },

        };

        // Tag: fade.
        // Argumentos: alpha1,alpha2,alpha3,t1,t2,t3,t4.
        // Rango: alpha -> hexadecimal entre 0 y FF, t -> entero.
        static object[] casosFade = {
            // Argumentos normales.
            new object[] {
                @"\fade(225,32,224,0,500,2000,2200)",
                @"\fade(225,32,224,0,500,2000,2200)" },
            
            // Argumentos positivos y decimales.
            new object[] {
                @"\fade(225,32,224,0.1,500.1,2000.1,2200.1)",
                @"\fade(225,32,224,0,500,2000,2200)" },
            
            // Argumentos negativos.
            new object[] {
                @"\fade(225,32,224,-10,-500,-2000,-2200)",
                @"\fade(225,32,224,-10,-500,-2000,-2200)" },
            
            // Texto tras los argumentos.
            new object[] {
                @"\fade(225texto,32texto,224texto,0texto,500texto,2000texto,2200)",
                @"\fade(225,32,224,0,500,2000,2200)" },
            
            // Argumentos entre espacios.
            new object[] {
                @"\fade( 225 , 32 , 224 , 0 , 500 , 2000 , 2200 )",
                @"\fade(225,32,224,0,500,2000,2200)" },

            // Argumentos inválidos.
            new object[] {
                @"\fade(texto225,texto32,texto224,texto0,texto500,texto2000,texto2200)",
                @"\fade(0,0,0,0,0,0,0)" },

        };

        // Tag: fe, fn, r. Rango: string.
        static object[] casosString = {
            new object[] {
                @"Arial",
                @"Arial" },
            new object[] {
                @"",
                @"" },
        };

        // Tag: k, kf, ko. Rango: entero.
        static object[] casosEntero = {
            // Argumento positivo.
            new object[] {
                @"1",
                @"1" },

            // Argumento decimal.
            new object[] {
                @"1.1",
                @"1" },

            // Argumento con texto delante.
            new object[] {
                @"texto1",
                @"0" },

            // Argumento con texto detrás.
            new object[] {
                @"3texto",
                @"3" },

            // Argumento con espacio delante.
            new object[] {
                @"  3",
                @"3" },

            // Argumento nulo.
            new object[] {
                @"",
                @"0" },
        };

        // Tag: move.
        // Argumentos: x1,y1,x2,y2[,t1][,t2].
        // Rango: x,y -> decimal; t -> entero.
        static object[] casosMove = {
            new object[] {
                @"\move(1,2,3,4)",
                @"\move(1,2,3,4)" },
            new object[] {
                @"\move(-1,-2,-3,-4)",
                @"\move(-1,-2,-3,-4)" },
            new object[] {
                @"\move(1.111,2.222,3.333,4.444)",
                @"\move(1.111,2.222,3.333,4.444)" },
            new object[] {
                @"\move(-1.111,-2.222,-3.333,-4.444)",
                @"\move(-1.111,-2.222,-3.333,-4.444)" }
        };

        // Tag: org, pos.
        // Argumentos: x,y.
        // Rango: decimal.
        static object[] casosPos = {
            new object[] {
                @"(1,2)",
                @"(1,2)" },
            new object[] {
                @"(-1,-2)",
                @"(-1,-2)" },
            new object[] {
                @"(1.111,2.222)",
                @"(1.111,2.222)" },
            new object[] {
                @"(-1.111,-2.222)",
                @"(-1.111,-2.222)" },
            new object[] {
                @"",
                @"(0,0)" }
        };

        // Tag: q.
        // Rango: entero entre 0 y 3.
        static object[] casosQ = {
            // Argumento positivo.
            new object[] {
                @"1",
                @"1" },

            // Argumento con texto delante.
            new object[] {
                @"texto1",
                @"0" },

            // Argumento con texto detrás.
            new object[] {
                @"2texto",
                @"2" },

            // Argumento con espacio delante.
            new object[] {
                @"  3",
                @"3" },
        };
        // Tag: t.
        // Argumentos: [comentario][\tag1][\tagN]
        // Rango: comentario -> string.
        static object[] casosT = {
            new object[] {
                @"\t(\fs32)",
                @"\t(\fs32)" },
            new object[] {
                @"\t(comentario\fs32)",
                @"\t(comentario\fs32)" },
            new object[] {
                @"\t(1,2,comentario\fs32)",
                @"\t(1,2,comentario\fs32)" },
            new object[] {
                @"\t(1,2,3.4,comentario\fs32)",
                @"\t(1,2,3.4,comentario\fs32)" },
        };
        #endregion

        [SetUp]
        public void Iniciar() {
            Funciones.CambiarCultura();
        }
        
        #region Pruebas
        // Tag: a.
        [Test, Category("Tag"), Category("TagA"), TestCaseSource("casosA")]
        public void AString(string ingresado, string esperado) {
            var tag = new TagA(ingresado);
            Assert.AreEqual(esperado, tag.ToString());
        }

        // Tag: an.
        [Test, Category("Tag"), Category("TagAn"), TestCaseSource("casosAn")]
        public void AnString(string ingresado, string esperado) {
            var tag = new TagAn(ingresado);
            Assert.AreEqual(esperado, tag.ToString());
        }

        // Tag: alpha.
        [Test, Category("Tag"), Category("TagAlpha")]
        public void Alpha1Campos() {
            var tag = new TagAlpha1(25);
            Assert.AreEqual(tag.Nombre, "1a");
            Assert.AreEqual(tag.Argumento, 25);
        }

        [Test, Category("Tag"), Category("TagAlpha")]
        public void Alpha1Int() {
            var tag = new TagAlpha1(25);
            Assert.AreEqual(@"\1a&H19&", tag.ToString());
        }

        [Test, Category("Tag"), Category("TagAlpha"), TestCaseSource("casosAlpha")]
        public void AlphaString(string ingresado, string esperado) {
            var nombre = @"\alpha";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagAlpha(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: 1a.
        [Test, Category("Tag"), Category("TagAlpha1"), TestCaseSource("casosAlpha")]
        public void Alpha1String(string ingresado, string esperado) {
            var nombre = @"\1a";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagAlpha1(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: 2a.
        [Test, Category("Tag"), Category("TagAlpha2"), TestCaseSource("casosAlpha")]
        public void Alpha2String(string ingresado, string esperado) {
            var nombre = @"\2a";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagAlpha2(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: 3a.
        [Test, Category("Tag"), Category("TagAlpha3"), TestCaseSource("casosAlpha")]
        public void Alpha3String(string ingresado, string esperado) {
            var nombre = @"\3a";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagAlpha3(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: 4a.
        [Test, Category("Tag"), Category("TagAlpha4"), TestCaseSource("casosAlpha")]
        public void Alpha4String(string ingresado, string esperado) {
            var nombre = @"\4a";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagAlpha4(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: b.
        [Test, Category("Tag"), Category("TagB"), TestCaseSource("casosBinario")]
        public void BString(string ingresado, string esperado) {
            var nombre = @"\b";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagB(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: be.
        [Test, Category("Tag"), Category("TagBe"), TestCaseSource("casosEnteroPositivo")]
        public void BeString(string ingresado, string esperado) {
            var nombre = @"\be";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagBe(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: blur.
        [Test, Category("Tag"), Category("TagBlur"), TestCaseSource("casosDoublePositivo")]
        public void BlurString(string ingresado, string esperado) {
            var nombre = @"\blur";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagBlur(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: bord.
        [Test, Category("Tag"), Category("TagBord"), TestCaseSource("casosDouble")]
        public void BordString(string ingresado, string esperado) {
            var nombre = @"\bord";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagBord(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: xbord.
        [Test, Category("Tag"), Category("TagBordX"), TestCaseSource("casosDouble")]
        public void BordXString(string ingresado, string esperado) {
            var nombre = @"\xbord";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagBordX(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: ybord.
        [Test, Category("Tag"), Category("TagBordY"), TestCaseSource("casosDouble")]
        public void BordYString(string ingresado, string esperado) {
            var nombre = @"\ybord";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagBordY(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: clip.
        [Test, Category("Tag"), Category("TagClip"), TestCaseSource("casosClip")]
        public void ClipString(string ingresado, string esperado) {
            var nombre = @"\clip";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagClip(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: iclip.
        [Test, Category("Tag"), Category("TagClipI"), TestCaseSource("casosClip")]
        public void ClipIString(string ingresado, string esperado) {
            var nombre = @"\iclip";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagClipI(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: c, 1c.
        [Test, Category("Tag"), Category("TagColor1"), TestCaseSource("casosColor")]
        public void Color1String(string ingresado, string esperado) {
            var nombre = @"\1c";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagColor1(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: 2c.
        [Test, Category("Tag"), Category("TagColor2"), TestCaseSource("casosColor")]
        public void Color2String(string ingresado, string esperado) {
            var nombre = @"\2c";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagColor2(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: 3c.
        [Test, Category("Tag"), Category("TagColor3"), TestCaseSource("casosColor")]
        public void Color3String(string ingresado, string esperado) {
            var nombre = @"\3c";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagColor3(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: 4c.
        [Test, Category("Tag"), Category("TagColor4"), TestCaseSource("casosColor")]
        public void Color4String(string ingresado, string esperado) {
            var nombre = @"\4c";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagColor4(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: fad.
        [Test, Category("Tag"), Category("TagFad"), TestCaseSource("casosFad")]
        public void FadString(string ingresado, string esperado) {
            var tag = new TagFad(ingresado);
            Assert.AreEqual(esperado, tag.ToString());
        }

        // Tag: fade.
        [Test, Category("Tag"), Category("TagFade"), TestCaseSource("casosFade")]
        public void FadeString(string ingresado, string esperado) {
            var tag = new TagFade(ingresado);
            Assert.AreEqual(esperado, tag.ToString());
        }
        // Tag: fax.
        [Test, Category("Tag"), Category("TagFax"), TestCaseSource("casosDouble")]
        public void FaxString(string ingresado, string esperado) {
            var nombre = @"\fax";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagFax(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: fay.
        [Test, Category("Tag"), Category("TagFay"), TestCaseSource("casosDouble")]
        public void FayString(string ingresado, string esperado) {
            var nombre = @"\fay";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagFay(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: fe.
        [Test, Category("Tag"), Category("TagFe"), TestCaseSource("casosString")]
        public void FeString(string ingresado, string esperado) {
            var nombre = @"\fe";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagFe(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: fn.
        [Test, Category("Tag"), Category("TagFn"), TestCaseSource("casosString")]
        public void FnString(string ingresado, string esperado) {
            var nombre = @"\fn";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagFn(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: frx.
        [Test, Category("Tag"), Category("TagFrx"), TestCaseSource("casosDouble")]
        public void FrxString(string ingresado, string esperado) {
            var nombre = @"\frx";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagFrx(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: fry.
        [Test, Category("Tag"), Category("TagFry"), TestCaseSource("casosDouble")]
        public void FryString(string ingresado, string esperado) {
            var nombre = @"\fry";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagFry(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: frz.
        [Test, Category("Tag"), Category("TagFrz"), TestCaseSource("casosDouble")]
        public void FrzString(string ingresado, string esperado) {
            var nombre = @"\frz";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagFrz(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: fs.
        [Test, Category("Tag"), Category("TagFs"), TestCaseSource("casosDoublePositivo")]
        public void FsString(string ingresado, string esperado) {
            var nombre = @"\fs";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagFs(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: fscx.
        [Test, Category("Tag"), Category("TagFscx"), TestCaseSource("casosDouble")]
        public void FscxString(string ingresado, string esperado) {
            var nombre = @"\fscx";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagFscx(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: fscy.
        [Test, Category("Tag"), Category("TagFscy"), TestCaseSource("casosDouble")]
        public void FscyString(string ingresado, string esperado) {
            var nombre = @"\fscy";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagFscy(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: fsp.
        [Test, Category("Tag"), Category("TagFsp"), TestCaseSource("casosDouble")]
        public void FspString(string ingresado, string esperado) {
            var nombre = @"\fsp";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagFsp(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: i.
        [Test, Category("Tag"), Category("TagI"), TestCaseSource("casosBinario")]
        public void IString(string ingresado, string esperado) {
            var nombre = @"\i";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagI(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: k.
        [Test, Category("Tag"), Category("TagK"), TestCaseSource("casosEntero")]
        public void KString(string ingresado, string esperado) {
            var nombre = @"\k";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagK(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: kf.
        [Test, Category("Tag"), Category("TagKf"), TestCaseSource("casosEntero")]
        public void KfString(string ingresado, string esperado) {
            var nombre = @"\kf";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagKf(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: ko.
        [Test, Category("Tag"), Category("TagKo"), TestCaseSource("casosEntero")]
        public void KoString(string ingresado, string esperado) {
            var nombre = @"\ko";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagKo(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: move.
        [Test, Category("Tag"), Category("TagMove"), TestCaseSource("casosMove")]
        public void MoveString(string ingresado, string esperado) {
            var tag = new TagMove(ingresado);
            Assert.AreEqual(esperado, tag.ToString());
        }

        // Tag: org.
        [Test, Category("Tag"), Category("TagOrg"), TestCaseSource("casosPos")]
        public void OrgString(string ingresado, string esperado) {
            var nombre = @"\org";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var pos = new TagOrg(ingresado2);
            Assert.AreEqual(esperado2, pos.ToString());
        }
        // Tag: p.
        [Test, Category("Tag"), Category("TagP"), TestCaseSource("casosEnteroPositivo")]
        public void PString(string ingresado, string esperado) {
            var nombre = @"\p";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagP(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: pbo.
        [Test, Category("Tag"), Category("TagPbo"), TestCaseSource("casosDouble")]
        public void PboString(string ingresado, string esperado) {
            var nombre = @"\pbo";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagPbo(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: pos.
        [Test, Category("Tag"), Category("TagPos")]
        public void PosCampos() {
            var tag = new TagPos(100, 50);
            Assert.AreEqual(tag.Nombre, "pos");
            Assert.AreEqual(tag.X, 100);
            Assert.AreEqual(tag.Y, 50);
        }

        [Test, Category("Tag"), Category("TagPos"), TestCaseSource("casosPos")]
        public void PosString(string ingresado, string esperado) {
            var nombre = @"\pos";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var pos = new TagPos(ingresado2);
            Assert.AreEqual(esperado2, pos.ToString());
        }
        
        // Tag: q.
        [Test, Category("Tag"), Category("TagQ"), TestCaseSource("casosQ")]
        public void QString(string ingresado, string esperado) {
            var nombre = @"\q";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagQ(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: r.
        [Test, Category("Tag"), Category("TagR"), TestCaseSource("casosString")]
        public void RString(string ingresado, string esperado) {
            var nombre = @"\r";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagR(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: s.
        [Test, Category("Tag"), Category("TagS"), TestCaseSource("casosBinario")]
        public void SString(string ingresado, string esperado) {
            var nombre = @"\s";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagS(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }

        // Tag: shad.
        [Test, Category("Tag"), Category("TagShad"), TestCaseSource("casosDouble")]
        public void ShadString(string ingresado, string esperado) {
            var nombre = @"\shad";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagShad(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: xshad.
        [Test, Category("Tag"), Category("TagShadX"), TestCaseSource("casosDouble")]
        public void ShadXString(string ingresado, string esperado) {
            var nombre = @"\xshad";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagShadX(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: yshad.
        [Test, Category("Tag"), Category("TagShadY"), TestCaseSource("casosDouble")]
        public void ShadYString(string ingresado, string esperado) {
            var nombre = @"\yshad";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagShadY(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        // Tag: t.
        [Test, Category("Tag"), Category("TagT"), TestCaseSource("casosT")]
        public void TString(string ingresado, string esperado) {
            var tag = new TagT(ingresado);
            Assert.AreEqual(esperado, tag.ToString());
        }

        // Tag: u.
        [Test, Category("Tag"), Category("TagU"), TestCaseSource("casosBinario")]
        public void UString(string ingresado, string esperado) {
            var nombre = @"\u";
            var ingresado2 = nombre + ingresado;
            var esperado2 = nombre + esperado;
            var tag = new TagU(ingresado2);
            Assert.AreEqual(esperado2, tag.ToString());
        }
        #endregion
    }
}
