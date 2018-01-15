using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de sombra vertical del formato ASS.
    /// </summary>
    public class TagShadY : TagTypeDouble {
        public override string Nombre => "yshad";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagShadY"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagShadY(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagShadY);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagShadY"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagShadY(double arg) {
            Argumento = arg;
        }
    }
}
