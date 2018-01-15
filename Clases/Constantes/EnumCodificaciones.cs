using System;

namespace Asu.Utilidades.Constantes {
    /// <summary>
    /// Especifica codificaciones para fuentes en Aegisub.
    /// </summary>
    public enum Codificaciones {
        ANSI,
        Predeterminado,
        Símbolo,
        Mac,
        Shift_JIS,
        Hangeul,
        Johab,
        GB2312,
        Chino_BIG5,
        Griego,
        Turco,
        Vietnamita,
        Hebreo,
        Árabe,
        Báltico,
        Ruso,
        Tailandés,
        EuropaDelEste,
        OEM
    }

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="Codificaciones"/>.
    /// </summary>
    public static class CodificacionesInfo {
        /// <summary>
        /// Devuelve una cadena con el nombre de la codificación especificada.
        /// </summary>
        /// <param name="codificacion">Codificación de la cual obtener el nombre.</param>
        public static string CodificacionToString(Codificaciones codificacion) {
            switch (codificacion) {
                case Codificaciones.ANSI:
                    return "ANSI";
                case Codificaciones.Predeterminado:
                    return "Predeterminado";
                case Codificaciones.Símbolo:
                    return "Símbolo";
                case Codificaciones.Mac:
                    return "Mac";
                case Codificaciones.Shift_JIS:
                    return "Shift_JIS";
                case Codificaciones.Hangeul:
                    return "Hangeul";
                case Codificaciones.Johab:
                    return "Johab";
                case Codificaciones.GB2312:
                    return "GB2312";
                case Codificaciones.Chino_BIG5:
                    return "Chino BIG5";
                case Codificaciones.Griego:
                    return "Griego";
                case Codificaciones.Turco:
                    return "Turco";
                case Codificaciones.Vietnamita:
                    return "Vietnamita";
                case Codificaciones.Hebreo:
                    return "Hebre";
                case Codificaciones.Árabe:
                    return "Árabe";
                case Codificaciones.Báltico:
                    return "Báltico";
                case Codificaciones.Ruso:
                    return "Ruso";
                case Codificaciones.Tailandés:
                    return "Tailandés";
                case Codificaciones.EuropaDelEste:
                    return "Europa del Este";
                default:
                    return "OEM";
            }
        }

        /// <summary>
        /// Devuelve la codificación correspondiente a la cadena especificada.
        /// </summary>
        /// <param name="codificacion">Texto con la codificación.</param>
        public static Codificaciones StringToCodificacion(string codificacion) {
            switch (codificacion) {
                case "0":
                    return Codificaciones.ANSI;
                case "1":
                    return Codificaciones.Predeterminado;
                case "2":
                    return Codificaciones.Símbolo;
                case "77":
                    return Codificaciones.Mac;
                case "128":
                    return Codificaciones.Shift_JIS;
                case "129":
                    return Codificaciones.Hangeul;
                case "130":
                    return Codificaciones.Johab;
                case "134":
                    return Codificaciones.GB2312;
                case "136":
                    return Codificaciones.Chino_BIG5;
                case "161":
                    return Codificaciones.Griego;
                case "162":
                    return Codificaciones.Turco;
                case "163":
                    return Codificaciones.Vietnamita;
                case "177":
                    return Codificaciones.Hebreo;
                case "178":
                    return Codificaciones.Árabe;
                case "186":
                    return Codificaciones.Báltico;
                case "204":
                    return Codificaciones.Ruso;
                case "222":
                    return Codificaciones.Tailandés;
                case "238":
                    return Codificaciones.EuropaDelEste;
                case "255":
                    return Codificaciones.OEM;
                default:
                    throw new ArgumentOutOfRangeException("codificacion", codificacion, "La codificación debe ser soportada por Aegisub.");
            }
        }
    }
}
