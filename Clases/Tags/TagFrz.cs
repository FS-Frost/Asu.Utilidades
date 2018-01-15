using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de rotación perpendicular a la pantalla del formato ASS.
    /// </summary>
    public class TagFrz : TagTypeDouble {
        public override string Nombre => "frz";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFrz"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFrz(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagFrz);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFrz"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagFrz(double arg) {
            Argumento = arg;
        }
    }
}
