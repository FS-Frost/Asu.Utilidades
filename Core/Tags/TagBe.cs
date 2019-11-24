using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de difuminado de bordes del formato ASS.
    /// </summary>
    public class TagBe : TagTypeInt {
        public override string Name => "be";
        public override Tags Type => Tags.Be;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBe"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagBe(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagBe);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = int.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBe"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagBe(int arg) {
            Argument = arg;
        }
    }
}
