namespace Asu.Utils.Constants {
    /// <summary>
    /// Especifica matrices de colores a usar en un script ASS.
    /// </summary>
    public enum YCbCrMatrix {
        None,
        TV_601,
        PC_601,
        TV_709,
        PC_709,
        TV_FCC,
        PC_FCC,
        TV_240M,
        PC_240M
    }

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="YCbCrMatrix"/>.
    /// </summary>
    public static class YCbCrMatrixInfo {
        /// <summary>
        /// Devuelve una cadena con el nombre de la la matriz YCbCr especificada.
        /// </summary>
        /// <param name="matrix">Matriz de la cual obtener el nombre.</param>
        public static string YCbCrMatrixToString(YCbCrMatrix matrix) {
            switch (matrix) {
                case YCbCrMatrix.TV_601:
                    return "TV 601";
                case YCbCrMatrix.PC_601:
                    return "PC 601";
                case YCbCrMatrix.TV_709:
                    return "TV 709";
                case YCbCrMatrix.PC_709:
                    return "PC 709";
                case YCbCrMatrix.TV_FCC:
                    return "TV FCC";
                case YCbCrMatrix.PC_FCC:
                    return "PC FCC";
                case YCbCrMatrix.TV_240M:
                    return "TV 240M";
                case YCbCrMatrix.PC_240M:
                    return "PC 240M";
                default:
                    return "None";
            }
        }

        /// <summary>
        /// Devuelve la matriz YCbCr correspondiente a la cadena especificada.
        /// </summary>
        /// <param name="codificacion">Texto con la matriz.</param>
        public static YCbCrMatrix StringToYCbCrMatrix(string matrix) {
            switch (matrix) {
                case "TV 601":
                    return YCbCrMatrix.TV_601;
                case "PC 601":
                    return YCbCrMatrix.PC_601;
                case "TV 709":
                    return YCbCrMatrix.TV_709;
                case "PC 709":
                    return YCbCrMatrix.PC_709;
                case "TV FCC":
                    return YCbCrMatrix.TV_709;
                case "PC FCC":
                    return YCbCrMatrix.PC_FCC;
                case "TV 240M":
                    return YCbCrMatrix.TV_240M;
                case "PC 240M":
                    return YCbCrMatrix.PC_240M;
                default:
                    return YCbCrMatrix.None;
            }
        }
    }
}