using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de grupo de efecto del formato ASS.
    /// </summary>
    public class TagFx : TagTypeString {
        public override string Nombre => "fx";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFx"/> en base a una cadena.
        /// </summary>
        /// <param name="texto"></param>
        public TagFx(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagFx);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = match.Groups["arg"].Value;
            } else {
                Argumento = "";
            }
        }
    }
}
