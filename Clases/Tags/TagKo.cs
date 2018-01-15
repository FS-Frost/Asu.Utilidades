using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de karaoke "ko" del formato ASS.
    /// </summary>
    public class TagKo : TagTypeInt {
        public override string Nombre => "ko";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagKo"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagKo(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagKo);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = int.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagKo"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagKo(int arg) {
            Argumento = arg;
        }
    }
}
