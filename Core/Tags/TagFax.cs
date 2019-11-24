using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de deformación lateral horizontal del formato ASS.
    /// </summary>
    public class TagFax : TagTypeDouble {
        public override string Name => "fax";
        public override Tags Type => Tags.Fax;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFax"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFax(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagFax);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFax"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagFax(double arg) {
            Argument = arg;
        }
    }
}
