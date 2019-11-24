using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de sombra total del formato ASS.
    /// </summary>
    public class TagShad : TagTypeDouble {
        public override string Name => "shad";
        public override Tags Type => Tags.Shad;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagShad"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagShad(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagShad);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagShad"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagShad(double arg) {
            Argument = arg;
        }
    }
}
