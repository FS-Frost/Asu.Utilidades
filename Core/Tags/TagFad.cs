using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de desvanecimiento simple del formato ASS.
    /// </summary>
    public class TagFad : Tag {
        public override string Name => "fad";
        public override Tags Type => Tags.Fad;

        /// <summary>
        /// Obtiene o establece el tiempo de entrada en milisegundos.
        /// </summary>
        public int T1 { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo de salida en milisegundos.
        /// </summary>
        public int T2 { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFad"/> dados sus argumentos.
        /// </summary>
        /// <param name="t1">Tiempo de entrada.</param>
        /// <param name="t2">Tiempo de salida.</param>
        public TagFad(int t1, int t2) {
            T1 = t1;
            T2 = t2;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFad"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFad(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagFad);
            var match = regex.Match(texto);
            if (match.Success) {
                var regex2 = new Regex(RegularExpressions.RegexArgsFad);
                var match2 = regex2.Match(match.Groups["arg"].Value);
                if (match2.Success) {
                    T1 = int.Parse(match2.Groups["t1"].Value);
                    T2 = int.Parse(match2.Groups["t2"].Value);
                }
            } else {
                T1 = 0;
                T2 = 0;
            }
        }
        
        /// <summary>
        /// Devuelve una cadena con formato: \[Nombre]([T1],[T2]).
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("\\{0}({1},{2})", Name, T1, T2);
        }
    }
}
