using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de rotación perpendicular a la pantalla del formato ASS.
    /// </summary>
    public class TagFrz : TagTypeDouble {
        public override string Name => "frz";
        public override Tags Type => Tags.Frz;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFrz"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFrz(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagFrz);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFrz"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagFrz(double arg) {
            Argument = arg;
        }
    }
}
