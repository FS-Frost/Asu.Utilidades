using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de sombra horizontal del formato ASS.
    /// </summary>
    public class TagShadX : TagTypeDouble {
        public override string Name => "xshad";
        public override Tags Type => Tags.ShadX;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagShadX"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagShadX(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagShadX);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagShadX"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagShadX(double arg) {
            Argument = arg;
        }
    }
}
