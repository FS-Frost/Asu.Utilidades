using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de desvanecimiento complejo del formato ASS.
    /// </summary>
    public class TagFade : Tag {
        public override string Nombre => "fade";

        /// <summary>
        /// Obtiene o establece el alpha 1 en decimal (0 a 255).
        /// </summary>
        public int Alpha1 { get; set; }

        /// <summary>
        /// Obtiene o establece el alpha 2 en decimal (0 a 255).
        /// </summary>
        public int Alpha2 { get; set; }

        /// <summary>
        /// Obtiene o establece el alpha 3 en decimal (0 a 255).
        /// </summary>
        public int Alpha3 { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo 1 en milisegundos.
        /// </summary>
        public int T1 { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo 2 en milisegundos.
        /// </summary>
        public int T2 { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo 3 en milisegundos.
        /// </summary>
        public int T3 { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo 4 en milisegundos.
        /// </summary>
        public int T4 { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFade"/> dados sus argumentos.
        /// </summary>
        /// <param name="alpha1">Valor alpha 1.</param>
        /// <param name="alpha2">Valor alpha 2.</param>
        /// <param name="alpha3">Valor alpha 3.</param>
        /// <param name="t1">Valor tiempo 1.</param>
        /// <param name="t2">Valor tiempo 2.</param>
        /// <param name="t3">Valor tiempo 3.</param>
        /// <param name="t4">Valor tiempo 4.</param>
        public TagFade(int alpha1, int alpha2, int alpha3, int t1, int t2, int t3, int t4) {
            Alpha1 = alpha1;
            Alpha2 = alpha2;
            Alpha3 = alpha3;
            T1 = t1;
            T2 = t2;
            T3 = t3;
            T4 = t4;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFade"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFade(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagFade);
            var match = regex.Match(texto);
            if (match.Success) {
                var regex2 = new Regex(ExpresionesRegulares.regexArgsFade);
                var match2 = regex2.Match(match.Groups["arg"].Value);
                if (match2.Success) {
                    Alpha1 = int.Parse(match2.Groups["alpha1"].Value);
                    Alpha2 = int.Parse(match2.Groups["alpha2"].Value);
                    Alpha3 = int.Parse(match2.Groups["alpha3"].Value);
                    T1 = int.Parse(match2.Groups["t1"].Value);
                    T2 = int.Parse(match2.Groups["t2"].Value);
                    T3 = int.Parse(match2.Groups["t3"].Value);
                    T4 = int.Parse(match2.Groups["t4"].Value);
                }
            } else {
                Alpha1 = 0;
                Alpha2 = 0;
                Alpha3 = 0;
                T1 = 0;
                T2 = 0;
                T3 = 0;
                T4 = 0;
            }
        }

        /// <summary>
        /// Devuelve una cadena con formato: \[Nombre]([Alpha1],[Alpha2],[Alpha3],[T1],[T2],[T3],[T4]).
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("\\{0}({1},{2},{3},{4},{5},{6},{7})", 
                Nombre, Alpha1, Alpha2, Alpha3, T1, T2, T3, T4);
        }
    }
}
