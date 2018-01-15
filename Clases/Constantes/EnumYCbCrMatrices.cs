namespace Asu.Utilidades.Constantes {
    /// <summary>
    /// Especifica matrices de colores a usar en un script ASS.
    /// </summary>
    public enum YCbCrMatrices {
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
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="YCbCrMatrices"/>.
    /// </summary>
    public static class YCbCrMatricesInfo {
        /// <summary>
        /// Devuelve una cadena con el nombre de la la matriz YCbCr especificada.
        /// </summary>
        /// <param name="matriz">Matriz de la cual obtener el nombre.</param>
        public static string YCbCrMatrixToString(YCbCrMatrices matriz) {
            switch (matriz) {
                case YCbCrMatrices.TV_601:
                    return "TV 601";
                case YCbCrMatrices.PC_601:
                    return "PC 601";
                case YCbCrMatrices.TV_709:
                    return "TV 709";
                case YCbCrMatrices.PC_709:
                    return "PC 709";
                case YCbCrMatrices.TV_FCC:
                    return "TV FCC";
                case YCbCrMatrices.PC_FCC:
                    return "PC FCC";
                case YCbCrMatrices.TV_240M:
                    return "TV 240M";
                case YCbCrMatrices.PC_240M:
                    return "PC 240M";
                default:
                    return "None";
            }
        }

        /// <summary>
        /// Devuelve la matriz YCbCr correspondiente a la cadena especificada.
        /// </summary>
        /// <param name="codificacion">Texto con la matriz.</param>
        public static YCbCrMatrices StringToYCbCrMatrix(string matriz) {
            switch (matriz) {
                case "TV 601":
                    return YCbCrMatrices.TV_601;
                case "PC 601":
                    return YCbCrMatrices.PC_601;
                case "TV 709":
                    return YCbCrMatrices.TV_709;
                case "PC 709":
                    return YCbCrMatrices.PC_709;
                case "TV FCC":
                    return YCbCrMatrices.TV_709;
                case "PC FCC":
                    return YCbCrMatrices.PC_FCC;
                case "TV 240M":
                    return YCbCrMatrices.TV_240M;
                case "PC 240M":
                    return YCbCrMatrices.PC_240M;
                default:
                    return YCbCrMatrices.None;
            }
        }
    }
}