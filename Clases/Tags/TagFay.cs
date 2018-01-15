using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de deformación lateral vertical del formato ASS.
    /// </summary>
    public class TagFay : TagTypeDouble {
        public override string Nombre => "fay";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFay"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFay(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagFay);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFay"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagFay(double arg) {
            Argumento = arg;
        }
    }
}
