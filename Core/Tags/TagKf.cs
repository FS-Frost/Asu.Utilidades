using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de karaoke paulatino del formato ASS.
    /// </summary>
    public class TagKf : TagTypeInt {
        public override string Name => "kf";
        public override Tags Type => Tags.Kf;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagKf"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagKf(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagKf);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = int.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagKf"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagKf(int arg) {
            Argument = arg;
        }
    }
}
