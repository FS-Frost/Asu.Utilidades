using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de alineación del formato ASS.
    /// </summary>
    public class TagAn : TagTypeInt {
        public override string Nombre => "an";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAn"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagAn(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagAn);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = int.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAn"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagAn(int arg) {
            Argumento = arg;
        }
    }
}
