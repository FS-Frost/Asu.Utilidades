using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de grupo de efecto del formato ASS.
    /// </summary>
    public class TagFx : TagTypeString {
        public override string Name => "fx";
        public override Tags Type => Tags.Fx;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFx"/> en base a una cadena.
        /// </summary>
        /// <param name="texto"></param>
        public TagFx(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagFx);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = match.Groups["arg"].Value;
            } else {
                Argument = "";
            }
        }
    }
}
