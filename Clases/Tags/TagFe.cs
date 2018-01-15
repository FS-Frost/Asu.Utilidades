using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de codificación del formato ASS.
    /// </summary>
    public class TagFe : TagTypeString {
        public override string Nombre => "fe";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFe"/> en base a una cadena.
        /// </summary>
        /// <param name="texto"></param>
        public TagFe(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagFe);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = match.Groups["arg"].Value;
            } else {
                Argumento = "";
            }
        }
    }
}
