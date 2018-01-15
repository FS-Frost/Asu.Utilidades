using System;

namespace Asu.Utilidades.Constantes {
    /// <summary>
    /// Especifica alineaciones para estilos en Aegisub.
    /// </summary>
    public enum Alineaciones {
        AbajoIzquierda,
        AbajoCentro,
        AbajoDerecha,
        CentroIzquierda,
        CentroCentro,
        CentroDerecha,
        ArribaIzquierda,
        ArribaCentro,
        ArribaDerecha
    }

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="Alineaciones"/>.
    /// </summary>
    public static class AlineacionesInfo {
        /// <summary>
        /// Devuelve la numeración de la alineación indicada.
        /// </summary>
        /// <param name="alineacion">Alineación de la cual obtener numeración.</param>
        public static int AlineacionToInt(Alineaciones alineacion) {
            switch (alineacion) {
                case Alineaciones.AbajoIzquierda:
                    return 1;
                case Alineaciones.AbajoCentro:
                    return 2;
                case Alineaciones.AbajoDerecha:
                    return 3;
                case Alineaciones.CentroIzquierda:
                    return 4;
                case Alineaciones.CentroCentro:
                    return 5;
                case Alineaciones.CentroDerecha:
                    return 6;
                case Alineaciones.ArribaIzquierda:
                    return 7;
                case Alineaciones.ArribaCentro:
                    return 8;
                default:
                    return 9;
            }
        }

        /// <summary>
        /// Devuelve la cadena correspondiente a la alineación indicada.
        /// </summary>
        /// <param name="alineacion">Texto con la alineación.</param>
        public static Alineaciones StringToAlineacion(string alineacion) {
            switch (alineacion) {
                case "1":
                    return Alineaciones.AbajoIzquierda;
                case "2":
                    return Alineaciones.AbajoCentro;
                case "3":
                    return Alineaciones.AbajoDerecha;
                case "4":
                    return Alineaciones.CentroIzquierda;
                case "5":
                    return Alineaciones.CentroCentro;
                case "6":
                    return Alineaciones.CentroDerecha;
                case "7":
                    return Alineaciones.ArribaIzquierda;
                case "8":
                    return Alineaciones.ArribaCentro;
                case "9":
                    return Alineaciones.ArribaDerecha;
                default:
                    throw new ArgumentOutOfRangeException("alineacion", alineacion, "La alineación debe estar entre 1 y 9.");
            }
        }
    }
}
