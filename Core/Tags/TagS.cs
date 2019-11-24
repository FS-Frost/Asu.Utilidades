using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de tachado del formato ASS.
    /// </summary>
    public class TagS : TagTypeInt {
        public override string Name => "s";
        public override Tags Type => Tags.S;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagS"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el texto.</param>
        public TagS(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagS);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = int.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref=""/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagS(int arg) {
            Argument = arg;
        }
    }
}
