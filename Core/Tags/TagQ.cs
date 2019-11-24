using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de ajuste de línea del formato ASS.
    /// </summary>
    public class TagQ : TagTypeInt {
        public override string Name => "q";
        public override Tags Type => Tags.Q;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagQ"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagQ(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagQ);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = int.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagQ"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagQ(int arg) {
            Argument = arg;
        }
    }
}
