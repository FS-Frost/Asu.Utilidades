using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de deformación lateral horizontal del formato ASS.
    /// </summary>
    public class TagFax : TagTypeDouble {
        public override string Nombre => "fax";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFax"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFax(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagFax);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFax"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagFax(double arg) {
            Argumento = arg;
        }
    }
}
