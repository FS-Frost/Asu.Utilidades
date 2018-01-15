using System;

namespace Asu.Utilidades.Constantes {
    /// <summary>
    /// Especifica los tipos de línea para un evento de Aegisub.
    /// </summary>
    public enum TipoLinea {
        Comment,
        Dialogue
    }

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="TipoLinea"/>.
    /// </summary>
    public static class TipoLineaInfo {
        /// <summary>
        /// Devuelve una cadena con el tipo de línea especificado.
        /// </summary>
        /// <param name="tipo">Tipo de línea.</param>
        public static string TipoLineaToString(TipoLinea tipo) {
            switch (tipo) {
                case TipoLinea.Comment:
                    return "Comment";
                default:
                    return "Dialogue";
            }
        }

        /// <summary>
        /// Devuelve el tipo de línea correspondiente a la cadena especificada.
        /// </summary>
        /// <param name="tipo">Texto con el tipo de línea.</param>
        public static TipoLinea StringToTipoLinea(string tipo) {
            switch (tipo) {
                case "Comment":
                    return TipoLinea.Comment;
                case "Dialogue":
                    return TipoLinea.Dialogue;
                default:
                    throw new InvalidOperationException("La cadena ingresada no corresponde a un tipo de línea.");
            }
        }
    }
}
