using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de modo de dibujo del formato ASS.
    /// </summary>
    public class TagP : TagTypeInt {
        public override string Name => "p";
        public override Tags Type => Tags.P;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagP"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagP(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagP);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = int.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagP"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagP(int arg) {
            Argument = arg;
        }
    }
}
