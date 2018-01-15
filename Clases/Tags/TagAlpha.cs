using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag alpha total del formato ASS.
    /// </summary>
    public class TagAlpha : TagTypeAlpha {
        public override string Nombre => "alpha";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAlpha"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagAlpha(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagAlpha);
            var match = regex.Match(texto);
            if (match.Success) {
                var regex2 = new Regex(ExpresionesRegulares.regexAlpha);
                var match2 = regex2.Match(match.Groups["arg"].Value);
                if (match2.Success) {
                    var alpha = match2.Groups["arg"].Value;
                    if (alpha != "") {
                        Argumento = int.Parse(alpha, System.Globalization.NumberStyles.HexNumber);
                    } else {
                        Argumento = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAlpha"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagAlpha(int arg) {
            Argumento = arg;
        }
    }
}
