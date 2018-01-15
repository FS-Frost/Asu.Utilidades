using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de karaoke paulatino del formato ASS.
    /// </summary>
    public class TagKf : TagTypeInt {
        public override string Nombre => "kf";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagKf"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagKf(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagKf);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = int.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagKf"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagKf(int arg) {
            Argumento = arg;
        }
    }
}
