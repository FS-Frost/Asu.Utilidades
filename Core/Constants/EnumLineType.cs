using System;

namespace Asu.Utils.Constants {
    /// <summary>
    /// Especifica los tipos de línea para un evento de Aegisub.
    /// </summary>
    public enum LineType {
        Comment,
        Dialogue
    }

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="LineType"/>.
    /// </summary>
    public static class LineTypeInfo {
        /// <summary>
        /// Devuelve una cadena con el tipo de línea especificado.
        /// </summary>
        /// <param name="type">Tipo de línea.</param>
        public static string LineTypeToString(LineType type) {
            switch (type) {
                case LineType.Comment:
                    return "Comment";
                default:
                    return "Dialogue";
            }
        }

        /// <summary>
        /// Devuelve el tipo de línea correspondiente a la cadena especificada.
        /// </summary>
        /// <param name="type">Texto con el tipo de línea.</param>
        public static LineType StringToLineType(string type) {
            switch (type) {
                case "Comment":
                    return LineType.Comment;
                case "Dialogue":
                    return LineType.Dialogue;
                default:
                    throw new InvalidOperationException("La cadena ingresada no corresponde a un tipo de línea.");
            }
        }
    }
}
