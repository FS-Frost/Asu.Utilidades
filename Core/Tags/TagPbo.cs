using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de corrimiento de punto inicial de dibujo del formato ASS.
    /// </summary>
    public class TagPbo : TagTypeDouble {
        public override string Name => "pbo";
        public override Tags Type => Tags.Pbo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagPbo"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagPbo(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagPbo);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagPbo"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagPbo(double arg) {
            Argument = arg;
        }
    }
}
