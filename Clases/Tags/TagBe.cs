using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de difuminado de bordes del formato ASS.
    /// </summary>
    public class TagBe : TagTypeInt {
        public override string Nombre => "be";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBe"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagBe(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagBe);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = int.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagBe"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagBe(int arg) {
            Argumento = arg;
        }
    }
}
