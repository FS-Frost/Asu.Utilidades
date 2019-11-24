using Asu.Utils.Constants;
using System.Collections.Generic;

namespace Asu.Utils.Core.AssFile {
    /// <summary>
    /// Representa una imagen adjunta a un archivo ASS.
    /// </summary>
    public class AttachedGraphic : AttachedFile {
        public override AttachedFileType Type => AttachedFileType.Graphic;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AttachedGraphic"/>.
        /// </summary>
        public AttachedGraphic() {
            Name = string.Empty;
            Data = new List<string>();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AttachedGraphic"/>.
        /// </summary>
        /// <param name="name">Nombre de la imagen.</param>
        /// <param name="data">Lista con los datos.</param>
        public AttachedGraphic(string name, List<string> data) {
            Name = name;
            Data = data;
        }
    }
}
