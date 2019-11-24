using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de alineación (versión de legado) del formato ASS.
    /// </summary>
    public class TagA : TagTypeInt {
        public override string Name => "a";
        public override Tags Type => Tags.A;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagA"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagA(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagA);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = int.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagA"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagA(int arg) {
            Argument = arg;
        }
    }
}
