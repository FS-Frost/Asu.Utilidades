using Asu.Utils.Constants;
using System.Collections.Generic;

namespace Asu.Utils.Core.AssFile {
    /// <summary>
    /// Representa una fuente adjunta a un archivo ASS.
    /// </summary>
    public class AttachedFont : AttachedFile {
        public override AttachedFileType Type => AttachedFileType.Font;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AttachedFont"/>.
        /// </summary>
        public AttachedFont() {
            Name = string.Empty;
            Data = new List<string>();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AttachedFont"/>.
        /// </summary>
        /// <param name="name">Nombre de la fuente.</param>
        /// <param name="data">Lista con los datos.</param>
        public AttachedFont(string name, List<string> data) {
            Name = name;
            Data = data;
        }
    }
}
