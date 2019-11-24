namespace Asu.Utils.Constants {
    /// <summary>
    /// Especifica los tipos de archivos adjuntos en un archivo ASS.
    /// </summary>
    public enum AttachedFileType {
        Font,
        Graphic
    }

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="AttachedFileType"/>.
    /// </summary>
    public static class AttachedFilesTypesInfo {
        /// <summary>
        /// Devuelve una cadena con el nombre del tipo de archivo adjunto especificado.
        /// </summary>
        /// <param name="type">Tipo de archivo adjunto del cual obtener el nombre.</param>
        public static string AttachedFilesTypeFileNameToString(AttachedFileType type) {
            switch (type) {
                case AttachedFileType.Font:
                    return "fontname";
                default:
                    return "filename";
            }
        }
    }
}
