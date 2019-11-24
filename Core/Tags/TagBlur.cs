using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de difuminado de bordes con kernel gaussiano del formato ASS.
    /// </summary>
    public class TagBlur: TagTypeDouble {
        public override string Name => "blur";
        public override Tags Type => Tags.Blur;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBlur"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagBlur(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagBlur);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBlur"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagBlur(double arg) {
            Argument = arg;
        }
    }
}
