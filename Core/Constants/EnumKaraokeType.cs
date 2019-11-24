using System;

namespace Asu.Utils.Constants {
    /// <summary>
    /// Especifica los tags del formato ASS para efectos de karaoke.
    /// </summary>
    public enum KaraokeType {
        K,
        Kf,
        Ko
    }

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="KaraokeType"/>.
    /// </summary>
    public class TiposKaraokeInfo {
        /// <summary>
        /// Devuelve una cadena con la escritura textual del tipo de karaoke.
        /// </summary>
        /// <param name="type">Tipo de karaoke.</param>
        public static string KaraokeTypeToString(KaraokeType type) {
            switch (type) {
                case KaraokeType.K:
                    return "k";
                case KaraokeType.Kf:
                    return "kf";
                default:
                    return "ko";
            }
        }

        /// <summary>
        /// Devuelve el tipo de karaoke correspondiente a la cadena especificada.
        /// </summary>
        /// <param name="type">Tipo de karaoke.</param>
        public static KaraokeType StringToKaraokeType(string type) {
            switch (type) {
                case "k":
                    return KaraokeType.K;
                case "kf":
                    return KaraokeType.Kf;
                case "ko":
                    return KaraokeType.Ko;
                default:
                    throw new ArgumentOutOfRangeException("tipo", type, "El tipo de karaoke debe ser soportado por Aegisub.");
            }
        }
    }
}
