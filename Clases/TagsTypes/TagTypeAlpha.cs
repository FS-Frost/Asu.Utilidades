namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag alpha genérico del formato ASS.
    /// </summary>
    public class TagTypeAlpha : Tag {
        /// <summary>
        /// Obtiene o establece el argumento del tag.
        /// </summary>
        public int Argumento { get; set; }

        /// <summary>
        /// Devuelve una cadena con fotmato: \[Nombre]&H[Argumento]&.
        /// </summary>
        public override string ToString() {
            return string.Format("\\{0}&H{1}&", Nombre, Argumento.ToString("X2"));
        }
    }
}
