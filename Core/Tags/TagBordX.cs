using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de bordes horizontales del formato ASS.
    /// </summary>
    public class TagBordX : TagTypeDouble {
        public override string Name => "xbord";
        public override Tags Type => Tags.BordX;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBordX"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagBordX(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagBordX);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBordX"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagBordX(double arg) {
            Argument = arg;
        }
    }
}
