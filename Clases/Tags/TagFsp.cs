using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de espaciado de fuente del formato ASS.
    /// </summary>
    public class TagFsp : TagTypeDouble {
        public override string Nombre => "fsp";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFsp"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFsp(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagFsp);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref=""/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagFsp(double arg) {
            Argumento = arg;
        }
    }
}
