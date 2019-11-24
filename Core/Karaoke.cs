using Asu.Utils.Constants;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un karaoke como contenido de una línea en formato ASS.
    /// </summary>
    public class Karaoke {
        /// <summary>
        /// Obtiene o establece la lista de sílabas que componen secuencialmente el karoake.
        /// </summary>
        public List<Syllabe> Syllabes { get; set; }
        
        /// <summary>
        /// Obtiene o establece la duración total del karaoke en centésimas de segundo.
        /// </summary>
        public int Length {
            get {
                var d = 0;
                foreach (var sil in Syllabes) {
                    d += sil.Length;
                }

                return d;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Karaoke"/>.
        /// </summary>
        public Karaoke() {
            Syllabes = new List<Syllabe>();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Karaoke"/> con base al contenido de una línea.
        /// </summary>
        /// <param name="contenido">Contenido de una línea, idealmente con grupos {} que definan las sílabas.</param>
        public Karaoke(string contenido) {
            // Uniendo grupos de la forma {}{};
            var contenidoAjustado = contenido.Replace("}{", "");

            // Obteniendo los grupos y textos.
            var elementos = FiltrarContenido(contenidoAjustado);

            // Obteniendo las sílabas.
            Syllabes = FiltrarSilabas(elementos);
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Karaoke"/>, copiando las propiedades de otra instancia.
        /// </summary>
        /// <param name="karaoke"></param>
        public Karaoke(Karaoke karaoke) {
            Syllabes = karaoke.Syllabes;
        }

        /// <summary>
        /// Devuelve una cadena representando el karaoke: {\tags}Sil1{\tags}Sil2...{\tags}SilN.
        /// </summary>
        public override string ToString() {
            var resultado = "";

            foreach (var sil in Syllabes) {
                resultado += sil;
            }
            return resultado; 
        }

        private List<string> FiltrarContenido(string contenido) {
            var regex = new Regex(RegularExpressions.RegexGroups);
            var matches = regex.Match(contenido);
            var lista = new List<string>();
            while (matches.Success) {
                lista.Add(matches.Value);
                matches = matches.NextMatch();
            }
            return lista;
        }

        private List<Syllabe> FiltrarSilabas(List<string> elementos) {
            var silabas = new List<Syllabe>();

            for (var i = 0; i < elementos.Count; i++) {
                var elementoActual = elementos[i];
                var silaba = new Syllabe();

                if (AssFilter.IsTagGroup(elementoActual)) {
                    // Si es grupo {}.
                    silaba.TagGroup = new TagGroup(elementoActual);
                } else {
                    // Si es texto.
                    if (elementoActual == string.Empty) {
                        goto Salida;
                    }

                    if (i == 0) {
                        // Si el primer elemento es un texto, es una sílaba sin tags.
                        silaba.Text = elementoActual;
                    } else {
                        // Si no es el primero, sí o sí tiene un grupo antes,
                        // por tanto el texto corresponde a esa sílaba.
                        silabas[silabas.Count - 1].Text = elementoActual;
                        goto Salida;
                    }
                }

                silabas.Add(silaba);

                Salida:
                continue;
            }

            return silabas;
        }

        /// <summary>
        /// Instancia una <see cref="Syllabe"/> y la agrega al karaoke.
        /// </summary>
        /// <param name="duracion">Duración de la sílaba.</param>
        /// <param name="texto">Texto de la sílaba.</param>
        /// <param name="tipoKaraoke">Tipo de karaoke de la sílaba.</param>
        public void AgregarSilaba(int duracion, string texto, KaraokeType tipoKaraoke) {
            var sil = new Syllabe(duracion, texto, tipoKaraoke);
            Syllabes.Add(sil);
        }

        /// <summary>
        /// Instancia una <see cref="Syllabe"/> y la agrega al karaoke.
        /// </summary>
        /// <param name="duracion">Duración de la sílaba.</param>
        /// <param name="texto">Texto de la sílaba.</param>
        /// <param name="tipoKaraoke">Tipo de karaoke de la sílaba.</param>
        /// <param name="grupoTag">Grupo de tags de la sílaba.</param>
        public void AgregarSilaba(int tiempo, string texto, KaraokeType tipoKaraoke, TagGroup grupoTag) {
            var sil = new Syllabe(tiempo, texto, tipoKaraoke, grupoTag);
            Syllabes.Add(sil);
        }

        /// <summary>
        /// Aplica el mismo tipo de karaoke a todas las sílabas.
        /// </summary>
        /// <param name="tipo"></param>
        public void Normalizar(KaraokeType tipo) {
            Syllabes.ForEach(x => {
                x.Type = tipo;
            });
        }

        public static Karaoke operator +(Karaoke k1, int t) {
            var k2 = k1;

            foreach (var sil in k2.Syllabes) {
                sil.Length += t;
            }

            return k2;
        }

        public static Karaoke operator -(Karaoke k1, int t) {
            var k2 = k1;

            foreach (var sil in k2.Syllabes) {
                sil.Length -= t;
            }

            return k2;
        }
    }
}
