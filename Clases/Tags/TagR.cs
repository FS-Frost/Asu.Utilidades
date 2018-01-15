using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de reinicio de estilo del formato ASS.
    /// </summary>
    public class TagR : TagTypeString {
        public override string Nombre => "r";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagR"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagR(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagR);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = match.Groups["arg"].Value;
            } else {
                Argumento = "";
            }
        }
    }
}
