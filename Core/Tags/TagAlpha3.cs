using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag alpha de bordes del formato ASS.
    /// </summary>
    public class TagAlpha3 : TagTypeAlpha {
        public override string Name => "3a";
        public override Tags Type => Tags.Alpha3;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAlpha3"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagAlpha3(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagAlpha3);
            var match = regex.Match(texto);
            if (match.Success) {
                var regex2 = new Regex(RegularExpressions.RegexAlpha);
                var match2 = regex2.Match(match.Groups["arg"].Value);
                if (match2.Success) {
                    var alpha = match2.Groups["arg"].Value;
                    if (alpha != "") {
                        Argument = int.Parse(alpha, System.Globalization.NumberStyles.HexNumber);
                    } else {
                        Argument = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAlpha3"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagAlpha3(int arg) {
            Argument = arg;
        }
    }
}
