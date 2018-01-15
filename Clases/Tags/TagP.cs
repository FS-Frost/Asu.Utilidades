using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de modo de dibujo del formato ASS.
    /// </summary>
    public class TagP : TagTypeInt {
        public override string Nombre => "p";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagP"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagP(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagP);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = int.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagP"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagP(int arg) {
            Argumento = arg;
        }
    }
}
