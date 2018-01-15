using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de escala horizontal de fuente del formato ASS.
    /// </summary>
    public class TagFscx : TagTypeDouble {
        public override string Nombre => "fscx";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFscx"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFscx(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagFscx);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFscx"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagFscx(double arg) {
            Argumento = arg;
        }
    }
}
