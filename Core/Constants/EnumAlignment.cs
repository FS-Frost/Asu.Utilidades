using System;

namespace Asu.Utils.Constants {
    /// <summary>
    /// Especifica alineaciones para estilos en Aegisub.
    /// </summary>
    public enum Alignment {
        DownLeft,
        DownCenter,
        DownRight,
        CenterLeft,
        CenterCenter,
        CenterRight,
        UpLeft,
        UpCenter,
        UpRight
    }

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="Alignment"/>.
    /// </summary>
    public static class AlignmentInfo {
        /// <summary>
        /// Devuelve la numeración de la alineación indicada.
        /// </summary>
        /// <param name="alignment">Alineación de la cual obtener numeración.</param>
        public static int AlignmentToInt(Alignment alignment) {
            switch (alignment) {
                case Alignment.DownLeft:
                    return 1;
                case Alignment.DownCenter:
                    return 2;
                case Alignment.DownRight:
                    return 3;
                case Alignment.CenterLeft:
                    return 4;
                case Alignment.CenterCenter:
                    return 5;
                case Alignment.CenterRight:
                    return 6;
                case Alignment.UpLeft:
                    return 7;
                case Alignment.UpCenter:
                    return 8;
                default:
                    return 9;
            }
        }

        /// <summary>
        /// Devuelve la cadena correspondiente a la alineación indicada.
        /// </summary>
        /// <param name="alignment">Texto con la alineación.</param>
        public static Alignment StringToAlignment(string alignment) {
            switch (alignment) {
                case "1":
                    return Alignment.DownLeft;
                case "2":
                    return Alignment.DownCenter;
                case "3":
                    return Alignment.DownRight;
                case "4":
                    return Alignment.CenterLeft;
                case "5":
                    return Alignment.CenterCenter;
                case "6":
                    return Alignment.CenterRight;
                case "7":
                    return Alignment.UpLeft;
                case "8":
                    return Alignment.UpCenter;
                case "9":
                    return Alignment.UpRight;
                default:
                    throw new ArgumentOutOfRangeException("alineacion", alignment, "La alineación debe estar entre 1 y 9.");
            }
        }
    }
}
