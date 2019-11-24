using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de cursiva del formato ASS.
    /// </summary>
    public class TagI : TagTypeInt {
        public override string Name => "i";
        public override Tags Type => Tags.I;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagI"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagI(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagI);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = int.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagI"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagI(int arg) {
            Argument = arg;
        }
    }
}
