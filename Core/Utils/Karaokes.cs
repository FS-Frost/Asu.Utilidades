using Asu.Utils.Core;
using Asu.Utils.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Asu.Utils {
    /// <summary>
    /// Proporciona funciones estáticas para trabajar karaokes.
    /// </summary>
    public static class Karaokes {
        /// <summary>
        /// Devuelve un <see cref="Karaoke"/> con las sílabas de romaji divididas a partir de una <see cref="Line"/>.
        /// </summary>
        /// <param name="linea">Linea cuyo contenido contenga romaji.</param>
        public static Karaoke SplitSyllabes(Line linea) {
            // Karaoke resultante.
            var karaoke = new Karaoke();

            // Palabras del karaoke.
            var palabras = linea.Content.Split(' ').ToList();

            // Dividiendo palabras.
            for (var i = 0; i < palabras.Count; i++) {
                var palabra = palabras[i];

                // Si es romaji, se divide cada sílaba.
                if (IsRomaji(palabra)) {
                    var regex = new Regex(RegularExpressions.RegexRomaji);
                    var matches = regex.Matches(palabra);

                    foreach (Match match in matches) {
                        karaoke.AgregarSilaba(0, match.Value, KaraokeType.Kf);
                    }
                } else {
                    // Si no es romaji, se agrega completa.
                    karaoke.AgregarSilaba(0, palabra, KaraokeType.Kf);
                }

                if (i != palabras.Count - 1) {
                    karaoke.Syllabes.Last().Text += " ";
                }
            }

            // Tiempo de sílabas.
            var tiempoSil = (int) Math.Round((linea.Length * 100 / karaoke.Syllabes.Count));

            // Agregando el tiempo a cada sílaba.
            karaoke.Syllabes.ForEach(sil => {
                sil.Length = tiempoSil;
            });

            // Ajustando última sílaba para completar el tiempo de línea.
            if (karaoke.Length != linea.Length * 100) {
                var delta = linea.Length - karaoke.Length / 100;

                // Por hacer: Agregar if mayor o menor.
                karaoke.Syllabes.Last().Length += (int) delta;
            }

            return karaoke;
        }

        /// <summary>
        /// Indica si el texto es romaji o no.
        /// </summary>
        /// <param name="texto">Texto a comprobar.</param>
        public static bool IsRomaji(string texto) {
            var regex = new Regex(RegularExpressions.RegexRomaji);
            var textoProcesado = texto;

            while (textoProcesado.Length > 0) {
                var match = regex.Match(textoProcesado);
                if (match.Success) {
                    textoProcesado = textoProcesado.Remove(match.Index, match.Length);
                } else {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Devuelve una lista con dos líneas correspondientes al contenido de una <see cref="Line"/> dividido en el índice indicado.
        /// </summary>
        /// <param name="lineaKaraoke"><see cref="Line"/> cuyo contenido es divisible como romaji.</param>
        /// <param name="indice">Indice de sílaba donde dividir la línea.</param>
        public static List<Line> SplitKaraoke(Line lineaKaraoke, int indice) {
            var listaLineas = new List<Line>();
            var karaoke = new Karaoke(lineaKaraoke.Content);

            var sil = (from x in karaoke.Syllabes
                       select x.Text).ToList();

            // Sílaba de inicio para la segunda, iniciando justo después de la anterior.
            var inicioSegunda = indice + 1;

            // Verificando que no se seleccione un espacio en blanco ni que sea nulo para la segunda línea,
            // a excepción de que sea la última opción.
            while (sil[inicioSegunda] == "" || sil[inicioSegunda] == " ") {
                if (inicioSegunda != sil.Count) {
                    inicioSegunda++;
                }
            }

            // Generando suma total en centésimas de segundo de tiempos de la primera línea.
            var tiempo1Double = 0.0;
            for (var i = 0; i < indice + 1; i++) {
                tiempo1Double = tiempo1Double + karaoke.Syllabes[i].Length;
            }

            // Pasando a segundos.
            tiempo1Double = tiempo1Double / 100;

            // Generando tiempo.
            var tiempo1 = new Time(tiempo1Double);

            // Generando suma total en centésimas de segundo de tiempos de la segunda línea.
            var tiempo2Double = 0.0;
            for (var i = inicioSegunda; i < sil.Count; i++) {
                tiempo2Double = tiempo2Double + karaoke.Syllabes[i].Length;
            }

            // Pasando a segundos.
            tiempo2Double = tiempo2Double / 100;

            // Generando tiempo.
            var tiempo2 = new Time(tiempo2Double);

            // Generando primera línea.
            var linea1 = new Line(lineaKaraoke) {
                Content = ""
            };

            linea1.End = tiempo1 + linea1.Start;

            // Agregando sílabas correspondientes.
            for (var i = 0; i < indice + 1; i++) {
                linea1.Content += karaoke.Syllabes[i].ToString();
            }

            // Generando segunda línea.			
            var linea2 = new Line(lineaKaraoke) {
                Content = ""
            };

            linea2.Start = linea2.End - tiempo2;

            // Agregando sílabas correspondientes.
            for (var i = inicioSegunda; i < sil.Count; i++) {
                linea2.Content += karaoke.Syllabes[i].ToString();
            }

            listaLineas.Add(linea1);
            listaLineas.Add(linea2);

            return listaLineas;
        }

        /// <summary>
        /// Devuelve una lista con N+1 líneas correspondientes al contenido de una <see cref="Line"/> dividido en los N índices indicados.
        /// </summary>
        /// <param name="lineaKaraoke"><see cref="Line"/> cuyo contenido es divisible como romaji.</param>
        /// <param name="indices">Arreglo con índices de sílabas donde dividir la línea.</param>
        public static List<Line> SplitKaraoke(Line lineaKaraoke, int[] indices) {
            var listaResultante = new List<Line>();
            var lineasDivididas = new List<Line>();
            var indicesOrdenados = (from i in indices
                                   orderby i
                                   select i).ToArray();
            var dividiendo = lineaKaraoke;

            for (var i = 0; i < indicesOrdenados.Length; i++) {
                var finPrimera = indicesOrdenados[i];
                
                if (i > 0) {
                    finPrimera -= new Karaoke(lineasDivididas.First().Content).Syllabes.Count;
                }

                lineasDivididas = SplitKaraoke(dividiendo, finPrimera);
                dividiendo = lineasDivididas.Last();
                listaResultante.Add(lineasDivididas.First());
            }

            listaResultante.Add(lineasDivididas.Last());

            return listaResultante;
        }
    }
}