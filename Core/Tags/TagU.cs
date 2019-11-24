using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de subrayado del formato ASS.
    /// </summary>
    public class TagU : TagTypeInt {
        public override string Name => "u";
        public override Tags Type => Tags.U;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagU"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagU(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagU);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = int.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagU"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagU(int arg) {
            Argument = arg;
        }
    }
}
