using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de bordes horizontales del formato ASS.
    /// </summary>
    public class TagBordX : TagTypeDouble {
        public override string Nombre => "xbord";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBordX"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagBordX(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagBordX);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBordX"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagBordX(double arg) {
            Argumento = arg;
        }
    }
}
