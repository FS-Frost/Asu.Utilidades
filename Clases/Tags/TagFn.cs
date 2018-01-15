using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de fuente del formato ASS.
    /// </summary>
    public class TagFn : TagTypeString {
        public override string Nombre => "fn";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFn"/> en base a una cadena.
        /// </summary>
        /// <param name="texto"></param>
        public TagFn(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagFn);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = match.Groups["arg"].Value;
            } else {
                Argumento = "";
            }
        }
    }
}
