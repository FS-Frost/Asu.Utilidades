using Asu.Utils.Constants;
using System.Collections.Generic;

namespace Asu.Utils.Core.AssFile {
    /// <summary>
    /// Representa un archivo adjunto a un archivo ASS.
    /// </summary>
    public class AttachedFile {
        /// <summary>
        /// Obtiene o establece el nombre del archivo.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece las líneas que representan los datos del archivo.
        /// </summary>
        public List<string> Data { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de archivo adjunto.
        /// </summary>
        public virtual AttachedFileType Type { get; set; }
        
        /// <summary>
        /// Devuelve una cadena cuya primera línea es el nombre del archivo, seguida por todas las líneas de datos.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            var resultado = string.Format("{0}: {1}", AttachedFilesTypesInfo.AttachedFilesTypeFileNameToString(Type), Name);

            Data.ForEach(d => {
                resultado += "\n" + d;
            });

            return resultado;
        }
    }
}
