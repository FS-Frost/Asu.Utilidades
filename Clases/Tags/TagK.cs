using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de karaoke normal del formato ASS.
    /// </summary>
    public class TagK : TagTypeInt {
        public override string Nombre => "k";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagK"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagK(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagK);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = int.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagK"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagK(int arg) {
            Argumento = arg;
        }
    }
}
