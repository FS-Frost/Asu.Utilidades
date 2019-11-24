using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de color de bordes del formato ASS.
    /// </summary>
    public class TagColor3 : TagTypeColor {
        public override string Name => "3c";
        public override Tags Type => Tags.Color3;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagColor3"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagColor3(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagColor3);
            var match = regex.Match(texto);
            if (match.Success) {
                var tag = Carteles.FilterColors(match.Groups["arg"].Value);
                Blue = tag.Blue;
                Green = tag.Green;
                Red = tag.Red;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagColor3"/> dados sus argumentos.
        /// </summary>
        /// <param name="blue">Factor azul de forma decimal.</param>
        /// <param name="green">Factor verde de forma decimal.</param>
        /// <param name="red">Factor rojo de forma decimal.</param>
        public TagColor3(int blue, int green, int red) {
            Blue = blue;
            Green = green;
            Red = red;
        }
    }
}
