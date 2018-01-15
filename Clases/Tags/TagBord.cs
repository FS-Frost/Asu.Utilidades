using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de borde total del formato ASS.
    /// </summary>
    public class TagBord: TagTypeDouble {
        public override string Nombre => "bord";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBord"/>.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagBord(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagBord);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBord"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagBord(double arg) {
            Argumento = arg;
        }
    }
}
