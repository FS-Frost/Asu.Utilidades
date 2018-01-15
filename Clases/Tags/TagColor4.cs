using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de color de sombra del formato ASS.
    /// </summary>
    public class TagColor4 : TagTypeColor {
        public override string Nombre => "4c";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagColor4"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagColor4(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagColor4);
            var match = regex.Match(texto);
            if (match.Success) {
                var tag = Carteles.FiltrarColores(match.Groups["arg"].Value);
                Blue = tag.Blue;
                Green = tag.Green;
                Red = tag.Red;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagColor4"/> dados sus argumentos.
        /// </summary>
        /// <param name="blue">Factor azul de forma decimal.</param>
        /// <param name="green">Factor verde de forma decimal.</param>
        /// <param name="red">Factor rojo de forma decimal.</param>
        public TagColor4(int blue, int green, int red) {
            Blue = blue;
            Green = green;
            Red = red;
        }
    }
}
