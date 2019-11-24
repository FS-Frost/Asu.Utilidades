namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag alpha genérico del formato ASS.
    /// </summary>
    public class TagTypeAlpha : Tag {
        /// <summary>
        /// Obtiene o establece el argumento del tag.
        /// </summary>
        public int Argument { get; set; }

        /*
        public List<TagTypeAlpha> Interpolar(int valorFinal, int intervalos) {
            var listaInterpolada = Maths.Interpolar(Argumento, valorFinal, intervalos);
        }
        */

        /// <summary>
        /// Devuelve una cadena con fotmato: \[Nombre]&H[Argumento]&.
        /// </summary>
        public override string ToString() {
            return string.Format(@"\{0}&H{1}&", Name, Argument.ToString("X2"));
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAlpha"/> con las mismas propiedades de la instancia actual.
        /// </summary>
        public TagAlpha ToTagAlpha() {
            return new TagAlpha(Argument);
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAlpha1"/> con las mismas propiedades de la instancia actual.
        /// </summary>
        public TagAlpha1 ToTagAlpha1() {
            return new TagAlpha1(Argument);
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAlpha2"/> con las mismas propiedades de la instancia actual.
        /// </summary>
        public TagAlpha2 ToTagAlpha2() {
            return new TagAlpha2(Argument);
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAlpha3"/> con las mismas propiedades de la instancia actual.
        /// </summary>
        public TagAlpha3 ToTagAlpha3() {
            return new TagAlpha3(Argument);
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAlpha4"/> con las mismas propiedades de la instancia actual.
        /// </summary>
        public TagAlpha4 ToTagAlpha4() {
            return new TagAlpha4(Argument);
        }
    }
}
