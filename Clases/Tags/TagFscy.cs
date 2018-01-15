using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de escala vertical de fuente del formato ASS.
    /// </summary>
    public class TagFscy : TagTypeDouble {
        public override string Nombre => "fscy";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFscy"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFscy(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagFscy);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFscy"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagFscy(double arg) {
            Argumento = arg;
        }
    }
}
