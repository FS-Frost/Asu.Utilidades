using Asu.Utils.Constants;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag genérico en formato ASS.
    /// </summary>
    public class Tag {
        /// <summary>
        /// Obtiene el nombre del tag.
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// Obtiene el tipo del tag.
        /// </summary>
        public virtual Tags Type { get; }
    }
}
