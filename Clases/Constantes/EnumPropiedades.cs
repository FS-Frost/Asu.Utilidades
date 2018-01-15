namespace Asu.Utilidades.Constantes {
    /// <summary>
    /// Especifica propiedades del formato ASS documentadas en Aegisub.
    /// </summary>
    public enum Propiedades {
        Tipo,
        Capa,
        Inicio,
        Fin,
        Estilo,
        Actor,
        MargenIzquierdo,
        MargenDerecho,
        MargenVertical,
        Efecto,
        Contenido
    };

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="Propiedades"/>.
    /// </summary>
    public static class PropiedadesInfo {
        /// <summary>
        /// Devuelve una cadena con el nombre de la propiedad especificada.
        /// </summary>
        /// <param name="p">Propiedad de la cual obtener el nombre.</param>
        public static string PropiedadToString(Propiedades p) {
            switch (p) {
                case Propiedades.Tipo:
                    return "tipo";
                case Propiedades.Capa:
                    return "capa";
                case Propiedades.Inicio:
                    return "inicio";
                case Propiedades.Fin:
                    return "fin";
                case Propiedades.Estilo:
                    return "estilo";
                case Propiedades.Actor:
                    return "actor";
                case Propiedades.MargenIzquierdo:
                    return "margenI";
                case Propiedades.MargenDerecho:
                    return "margenD";
                case Propiedades.MargenVertical:
                    return "margenV";
                case Propiedades.Efecto:
                    return "efecto";
                case Propiedades.Contenido:
                    return "contenido";
                default:
                    return "";
            }
        }
    }
}
