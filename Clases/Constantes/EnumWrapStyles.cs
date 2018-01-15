namespace Asu.Utilidades.Constantes {
    /// <summary>
    /// Especifica los estilos de ajuste de línea para un archivo ASS.
    /// </summary>
    public enum WrapStyles {
        AjusteInteligenteSuperior,
        AjusteDeFinDeLinea,
        SinAjusteDeLinea,
        AjusteInteligenteInferior
    }

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="WrapStyles"/>.
    /// </summary>
    public static class WrapStylesInfo {
        /// <summary>
        /// Devuelve el estilo de ajuste de línea correspondiente a la cadena especificada.
        /// </summary>
        /// <param name="style">Texto con el estilo.</param>
        public static WrapStyles StringToWrapStyle(string style) {
            switch (style) {
                case "0":
                    return WrapStyles.AjusteInteligenteSuperior;
                case "1":
                    return WrapStyles.AjusteDeFinDeLinea;
                case "2":
                    return WrapStyles.SinAjusteDeLinea;
                default:
                    return WrapStyles.AjusteInteligenteInferior;
            }
        }
    }
}
