using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de tachado del formato ASS.
    /// </summary>
    public class TagS : TagTypeInt {
        public override string Nombre => "s";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagS"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el texto.</param>
        public TagS(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagS);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = int.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref=""/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagS(int arg) {
            Argumento = arg;
        }
    }
}
