using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de corrimiento de punto inicial de dibujo del formato ASS.
    /// </summary>
    public class TagPbo : TagTypeDouble {
        public override string Nombre => "pbo";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagPbo"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagPbo(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagPbo);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagPbo"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagPbo(double arg) {
            Argumento = arg;
        }
    }
}
