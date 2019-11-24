namespace Asu.Utils.Constants {
    /// <summary>
    /// Especifica propiedades del formato ASS documentadas en Aegisub.
    /// </summary>
    public enum Property {
        Type,
        Layer,
        Start,
        End,
        Style,
        Actor,
        MarginLeft,
        MarginRight,
        MarginVertical,
        Effect,
        Content
    };

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="Property"/>.
    /// </summary>
    public static class PropertyInfo {
        /// <summary>
        /// Devuelve una cadena con el nombre de la propiedad especificada.
        /// </summary>
        /// <param name="p">Propiedad de la cual obtener el nombre.</param>
        public static string PropiedadToString(Property p) {
            switch (p) {
                case Property.Type:
                    return "tipo";
                case Property.Layer:
                    return "capa";
                case Property.Start:
                    return "inicio";
                case Property.End:
                    return "fin";
                case Property.Style:
                    return "estilo";
                case Property.Actor:
                    return "actor";
                case Property.MarginLeft:
                    return "margenI";
                case Property.MarginRight:
                    return "margenD";
                case Property.MarginVertical:
                    return "margenV";
                case Property.Effect:
                    return "efecto";
                case Property.Content:
                    return "contenido";
                default:
                    return "";
            }
        }
    }
}
