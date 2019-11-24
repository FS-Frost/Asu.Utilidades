using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de karaoke normal del formato ASS.
    /// </summary>
    public class TagK : TagTypeInt {
        public override string Name => "k";
        public override Tags Type => Tags.K;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagK"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagK(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagK);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = int.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagK"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagK(int arg) {
            Argument = arg;
        }
    }
}
