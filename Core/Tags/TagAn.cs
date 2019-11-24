using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de alineación del formato ASS.
    /// </summary>
    public class TagAn : TagTypeInt {
        public override string Name => "an";
        public override Tags Type => Tags.An;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAn"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagAn(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagAn);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = int.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAn"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagAn(int arg) {
            Argument = arg;
        }
    }
}
