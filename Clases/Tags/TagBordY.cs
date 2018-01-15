using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de bordes verticales del formato ASS.
    /// </summary>
    public class TagBordY : TagTypeDouble {
        public override string Nombre => "ybord";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBordY"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagBordY(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagBordY);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBordY"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagBordY(double arg) {
            Argumento = arg;
        }
    }
}
