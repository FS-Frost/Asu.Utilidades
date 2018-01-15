using Asu.Utilidades.Constantes;
using System.Collections.Generic;

namespace Asu.Utilidades.Clases.ArchivoASS {
    /// <summary>
    /// Representa una fuente adjunta a un archivo ASS.
    /// </summary>
    public class AttachedFont : AttachedFile {
        public override AttachedFilesTypes Type => AttachedFilesTypes.Font;

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
