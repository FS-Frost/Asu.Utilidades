namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag textual genérico del formato ASS.
    /// </summary>
    public class TagTypeString: Tag {
        /// <summary>
        /// Obtiene o establece el argumento del tag.
        /// </summary>
        public string Argumento { get; set; }

        /// <summary>
        /// Devuelve una cadena con formato: \[Nombre][Argumento].
        /// </summary>
        public override string ToString() {
            return string.Format("\\{0}{1}", Nombre, Argumento);
        }
    }
}
