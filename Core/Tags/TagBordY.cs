using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de bordes verticales del formato ASS.
    /// </summary>
    public class TagBordY : TagTypeDouble {
        public override string Name => "ybord";
        public override Tags Type => Tags.BordY;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBordY"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagBordY(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagBordY);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBordY"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagBordY(double arg) {
            Argument = arg;
        }
    }
}
