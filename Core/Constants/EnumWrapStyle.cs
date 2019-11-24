namespace Asu.Utils.Constants {
    /// <summary>
    /// Especifica los estilos de ajuste de línea para un archivo ASS.
    /// </summary>
    public enum WrapStyle {
        SmartWrappingTopLineWidder,
        EndLineWordWrapping,
        NoWordWrapping,
        SmartWrappingBottomLineWidder
    }

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="WrapStyle"/>.
    /// </summary>
    public static class WrapStyleInfo {
        public static string WrapStyleToString(WrapStyle style) {
            switch (style) {
                case WrapStyle.SmartWrappingTopLineWidder:
                    return "Smart";
                case WrapStyle.EndLineWordWrapping:
                    return "";
                case WrapStyle.NoWordWrapping:
                    return "";
                default:
                    return "";
            }
        }
        
        /// <summary>
        /// Devuelve el estilo de ajuste de línea correspondiente a la cadena especificada.
        /// </summary>
        /// <param name="style">Texto con el estilo.</param>
        public static WrapStyle StringToWrapStyle(string style) {
            switch (style) {
                case "0":
                    return WrapStyle.SmartWrappingTopLineWidder;
                case "1":
                    return WrapStyle.EndLineWordWrapping;
                case "2":
                    return WrapStyle.NoWordWrapping;
                default:
                    return WrapStyle.SmartWrappingBottomLineWidder;
            }
        }
    }
}
