using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de sombra vertical del formato ASS.
    /// </summary>
    public class TagShadY : TagTypeDouble {
        public override string Name => "yshad";
        public override Tags Type => Tags.ShadY;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagShadY"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagShadY(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagShadY);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagShadY"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagShadY(double arg) {
            Argument = arg;
        }
    }
}
