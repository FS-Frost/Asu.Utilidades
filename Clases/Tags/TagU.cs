using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de subrayado del formato ASS.
    /// </summary>
    public class TagU : TagTypeInt {
        public override string Nombre => "u";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagU"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagU(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagU);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = int.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagU"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagU(int arg) {
            Argumento = arg;
        }
    }
}
