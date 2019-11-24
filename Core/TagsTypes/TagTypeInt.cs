namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag numérico entero genérico del formato ASS.
    /// </summary>
    public class TagTypeInt: Tag {
        /// <summary>
        /// Obtiene o establece el argumento del tag.
        /// </summary>
        public int Argument { get; set; }

        /// <summary>
        /// Devuelve una cadena con formato: \[Nombre][Argumento].
        /// </summary>
        public override string ToString() {
            return string.Format("\\{0}{1}", Name, Argument);
        }
    }
}
