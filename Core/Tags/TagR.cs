using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de reinicio de estilo del formato ASS.
    /// </summary>
    public class TagR : TagTypeString {
        public override string Name => "r";
        public override Tags Type => Tags.R;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagR"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagR(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagR);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = match.Groups["arg"].Value;
            } else {
                Argument = "";
            }
        }
    }
}
