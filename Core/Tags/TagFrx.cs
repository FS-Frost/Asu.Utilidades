using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de rotación horizontal del formato ASS.
    /// </summary>
    public class TagFrx : TagTypeDouble {
        public override string Name => "frx";
        public override Tags Type => Tags.Frx;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFrx"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFrx(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagFrx);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFrx"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagFrx(double arg) {
            Argument = arg;
        }
    }
}
