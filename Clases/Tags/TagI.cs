using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de cursiva del formato ASS.
    /// </summary>
    public class TagI : TagTypeInt {
        public override string Nombre => "i";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagI"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagI(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagI);
            var match = regex.Match(texto);
            if (match.Success) {
                Argumento = int.Parse(match.Groups["arg"].Value);
            } else {
                Argumento = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagI"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagI(int arg) {
            Argumento = arg;
        }
    }
}
