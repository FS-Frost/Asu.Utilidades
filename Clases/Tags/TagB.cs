using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de negrita del formato ASS.
    /// </summary>
    public class TagB : TagTypeInt {
        public override string Nombre => "b";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagB"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagB(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagB);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = int.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagB"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagB(int arg) {
            Argumento = arg;
        }
    }
}
