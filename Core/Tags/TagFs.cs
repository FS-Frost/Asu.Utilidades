using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de tamaño de fuente del formato ASS.
    /// </summary>
    public class TagFs : TagTypeDouble {
        public override string Name => "fs";
        public override Tags Type => Tags.Fs;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFs"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFs(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagFs);
            var match = regex.Match(texto);
            if (match.Success) {
                Argument = double.Parse(match.Groups["arg"].Value);
            } else {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref=""/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagFs(double arg) {
            Argument = arg;
        }
    }
}
