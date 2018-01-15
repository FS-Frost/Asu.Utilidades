using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de alineación (versión de legado) del formato ASS.
    /// </summary>
    public class TagA : TagTypeInt {
        public override string Nombre => "a";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagA"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagA(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagA);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = int.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagA"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagA(int arg) {
            Argumento = arg;
        }
    }
}
