using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de rotación vertical del formato ASS.
    /// </summary>
    public class TagFry : TagTypeDouble {
        public override string Nombre => "fry";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFry"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFry(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagFry);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = double.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFry"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagFry(double arg) {
            Argumento = arg;
        }
    }
}
