using Asu.Utilidades.Constantes;
using System.Collections.Generic;

namespace Asu.Utilidades.Clases.ArchivoASS {
    /// <summary>
    /// Representa una imagen adjunta a un archivo ASS.
    /// </summary>
    public class AttachedGraphic : AttachedFile {
        public override AttachedFilesTypes Type => AttachedFilesTypes.Graphic;

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
