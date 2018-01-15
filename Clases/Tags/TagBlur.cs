using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de difuminado de bordes con kernel gaussiano del formato ASS.
    /// </summary>
    public class TagBlur: TagTypeDouble {
        public override string Nombre => "blur";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBlur"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagBlur(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagBlur);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBlur"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagBlur(double arg) {
            Argumento = arg;
        }
    }
}
