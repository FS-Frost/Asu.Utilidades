using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de rotación vertical del formato ASS.
    /// </summary>
    public class TagFry : TagTypeDouble {
        public override string Name => "fry";
        public override Tags Type => Tags.Fry;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFry"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFry(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagFry);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFry"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagFry(double arg) {
            Argument = arg;
        }
    }
}
