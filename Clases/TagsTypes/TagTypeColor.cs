namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de color genérico del formato ASS.
    /// </summary>
    public class TagTypeColor : Tag {
        /// <summary>
        /// Obtiene o establece el valor del factor azul.
        /// </summary>
        public int Blue { get; set; }

        /// <summary>
        /// Obtiene o establece el valor del factor verde.
        /// </summary>
        public int Green { get; set; }

        /// <summary>
        /// Obtiene o establece el valor del factor rojo.
        /// </summary>
        public int Red { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagTypeColor"/>.
        /// </summary>
        public TagTypeColor() {
            Blue = 0;
            Green = 0;
            Red = 0;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagTypeColor"/> dados los factores azul, verde y rojo.
        /// </summary>
        /// <param name="blue">Factor azul de forma decimal.</param>
        /// <param name="green">Factor verde de forma decimal.</param>
        /// <param name="red">Factor rojo de forma decimal.</param>
        public TagTypeColor(int blue, int green, int red) {
            Blue = blue;
            Green = green;
            Red = red;
        }

        /// <summary>
        /// Contructor para textos que contengan un color en formato ASS.
        /// </summary>
        /// <param name="texto">Texto que contanga el formato <bb><gg><rr>.</param>
        public TagTypeColor(string texto) {
            var colores = Carteles.FiltrarColores(texto);
            Blue = colores.Blue;
            Green = colores.Green;
            Red = colores.Red;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagTypeColor"/>, copiando las propiedades de otra instancia.
        /// </summary>
        /// <param name="color">Color genérico a copiar.</param>
        public TagTypeColor(TagTypeColor color) {
            Blue = color.Blue;
            Green = color.Green;
            Red = color.Red;
        }

        public override bool Equals(object obj) {
            var color = obj as TagTypeColor;
            if (Blue == color.Blue && Green == color.Green && Red == color.Red) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Devuelve una cadena con formato: \[Nombre]&H[AzulHex][VerdeHex][RojoHex]&.
        /// </summary>
        public override string ToString() {
            return string.Format("\\{0}&H{1}{2}{3}&", 
                Nombre,
                Maths.IntToHex(Blue, 2),
                Maths.IntToHex(Green, 2),
                Maths.IntToHex(Red, 2)
                );
        }

        public override int GetHashCode() {
            var hashCode = -883431563;
            hashCode = hashCode * -1521134295 + Blue.GetHashCode();
            hashCode = hashCode * -1521134295 + Green.GetHashCode();
            hashCode = hashCode * -1521134295 + Red.GetHashCode();
            return hashCode;
        }
    }
}
