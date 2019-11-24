using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de escala horizontal de fuente del formato ASS.
    /// </summary>
    public class TagFscx : TagTypeDouble {
        public override string Name => "fscx";
        public override Tags Type => Tags.Fscx;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFscx"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFscx(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagFscx);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFscx"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagFscx(double arg) {
            Argument = arg;
        }
    }
}
