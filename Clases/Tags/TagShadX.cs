using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de sombra horizontal del formato ASS.
    /// </summary>
    public class TagShadX : TagTypeDouble {
        public override string Nombre => "xshad";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagShadX"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagShadX(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagShadX);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagShadX"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagShadX(double arg) {
            Argumento = arg;
        }
    }
}
