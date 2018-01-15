using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de tamaño de fuente del formato ASS.
    /// </summary>
    public class TagFs : TagTypeDouble {
        public override string Nombre => "fs";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFs"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFs(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagFs);
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
        public TagFs(double arg) {
            Argumento = arg;
        }
    }
}
