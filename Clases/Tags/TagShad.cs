using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de sombra total del formato ASS.
    /// </summary>
    public class TagShad : TagTypeDouble {
        public override string Nombre => "shad";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagShad"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagShad(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagShad);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagShad"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagShad(double arg) {
            Argumento = arg;
        }
    }
}
