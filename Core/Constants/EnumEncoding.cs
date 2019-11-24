using System;

namespace Asu.Utils.Constants {
    /// <summary>
    /// Especifica codificaciones para fuentes en Aegisub.
    /// </summary>
    public enum Encoding {
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
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="Encoding"/>.
    /// </summary>
    public static class CodificacionesInfo {
        /// <summary>
        /// Devuelve una cadena con el nombre de la codificación especificada.
        /// </summary>
        /// <param name="codificacion">Codificación de la cual obtener el nombre.</param>
        public static string CodificacionToString(Encoding codificacion) {
            switch (codificacion) {
                case Encoding.ANSI:
                    return "ANSI";
                case Encoding.Predeterminado:
                    return "Predeterminado";
                case Encoding.Símbolo:
                    return "Símbolo";
                case Encoding.Mac:
                    return "Mac";
                case Encoding.Shift_JIS:
                    return "Shift_JIS";
                case Encoding.Hangeul:
                    return "Hangeul";
                case Encoding.Johab:
                    return "Johab";
                case Encoding.GB2312:
                    return "GB2312";
                case Encoding.Chino_BIG5:
                    return "Chino BIG5";
                case Encoding.Griego:
                    return "Griego";
                case Encoding.Turco:
                    return "Turco";
                case Encoding.Vietnamita:
                    return "Vietnamita";
                case Encoding.Hebreo:
                    return "Hebre";
                case Encoding.Árabe:
                    return "Árabe";
                case Encoding.Báltico:
                    return "Báltico";
                case Encoding.Ruso:
                    return "Ruso";
                case Encoding.Tailandés:
                    return "Tailandés";
                case Encoding.EuropaDelEste:
                    return "Europa del Este";
                default:
                    return "OEM";
            }
        }

        /// <summary>
        /// Devuelve la codificación correspondiente a la cadena especificada.
        /// </summary>
        /// <param name="codificacion">Texto con la codificación.</param>
        public static Encoding StringToCodificacion(string codificacion) {
            switch (codificacion) {
                case "0":
                    return Encoding.ANSI;
                case "1":
                    return Encoding.Predeterminado;
                case "2":
                    return Encoding.Símbolo;
                case "77":
                    return Encoding.Mac;
                case "128":
                    return Encoding.Shift_JIS;
                case "129":
                    return Encoding.Hangeul;
                case "130":
                    return Encoding.Johab;
                case "134":
                    return Encoding.GB2312;
                case "136":
                    return Encoding.Chino_BIG5;
                case "161":
                    return Encoding.Griego;
                case "162":
                    return Encoding.Turco;
                case "163":
                    return Encoding.Vietnamita;
                case "177":
                    return Encoding.Hebreo;
                case "178":
                    return Encoding.Árabe;
                case "186":
                    return Encoding.Báltico;
                case "204":
                    return Encoding.Ruso;
                case "222":
                    return Encoding.Tailandés;
                case "238":
                    return Encoding.EuropaDelEste;
                case "255":
                    return Encoding.OEM;
                default:
                    throw new ArgumentOutOfRangeException("codificacion", codificacion, "La codificación debe ser soportada por Aegisub.");
            }
        }
    }
}
