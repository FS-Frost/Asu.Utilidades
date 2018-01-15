using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de ajuste de línea del formato ASS.
    /// </summary>
    public class TagQ : TagTypeInt {
        public override string Nombre => "q";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagQ"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagQ(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagQ);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = int.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagQ"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagQ(int arg) {
            Argumento = arg;
        }
    }
}
