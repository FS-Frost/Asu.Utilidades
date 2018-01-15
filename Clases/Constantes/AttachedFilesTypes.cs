namespace Asu.Utilidades.Constantes {
    /// <summary>
    /// Especifica los tipos de archivos adjuntos en un archivo ASS.
    /// </summary>
    public enum AttachedFilesTypes {
        Font,
        Graphic
    }

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="AttachedFilesTypes"/>.
    /// </summary>
    public static class AttachedFilesTypesInfo {
        /// <summary>
        /// Devuelve una cadena con el nombre del tipo de archivo adjunto especificado.
        /// </summary>
        /// <param name="type">Tipo de archivo adjunto del cual obtener el nombre.</param>
        public static string AttachedFilesTypeFileNameToString(AttachedFilesTypes type) {
            switch (type) {
                case AttachedFilesTypes.Font:
                    return "fontname";
                default:
                    return "filename";
            }
        }
    }
}
