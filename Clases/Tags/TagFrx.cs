using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de rotación horizontal del formato ASS.
    /// </summary>
    public class TagFrx : TagTypeDouble {
        public override string Nombre => "frx";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFrx"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFrx(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagFrx);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFrx"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagFrx(double arg) {
            Argumento = arg;
        }
    }
}
