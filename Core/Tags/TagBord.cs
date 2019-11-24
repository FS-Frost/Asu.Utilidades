using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de borde total del formato ASS.
    /// </summary>
    public class TagBord: TagTypeDouble {
        public override string Name => "bord";
        public override Tags Type => Tags.Bord;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBord"/>.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagBord(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagBord);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBord"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagBord(double arg) {
            Argument = arg;
        }
    }
}
