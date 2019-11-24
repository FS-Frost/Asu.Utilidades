using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de negrita del formato ASS.
    /// </summary>
    public class TagB : TagTypeInt {
        public override string Name => "b";
        public override Tags Type => Tags.B;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagB"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagB(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagB);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = int.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagB"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagB(int arg) {
            Argument = arg;
        }
    }
}
