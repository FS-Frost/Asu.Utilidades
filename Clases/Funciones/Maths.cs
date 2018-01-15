using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Asu.Utilidades {
    /// <summary>
    /// Proporciona funciones estáticas para trabajar números.
    /// </summary>
    public static class Maths {
        /// <summary>
        /// Devuelve un número entero desde una cadena en hexadecimal.
        /// </summary>
        /// <param name="hex">Cadena en hexadecimal.</param>
        public static int HexToInt(string hex) {
            if (hex == "") {
                return 0;
            } else {
                var n = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                return n;
            }

        }

        /// <summary>
        /// Devuelve una cadena en hexadecimal desde un número entero.
        /// </summary>
        /// <param name="n">Número entero.</param>
        public static string IntToHex(int n) {
            var h = n.ToString("X");
            return h;
        }

        /// <summary>
        /// Devuelve una cadena en hexadecimal con una cierta cantidad de dígitos desde un número entero.
        /// </summary>
        /// <param name="n">Número entero.</param>
        /// <param name="digitos">Cantidad de dígitos.</param>
        public static string IntToHex(int n, int digitos) {
            var h = n.ToString(string.Format("X{0}", digitos));
            return h;
        }

        /// <summary>
        /// Devuelve un número truncado a una cantidad de decimales sin aproximación.
        /// </summary>
        /// <param name="numero">Número a truncar.</param>
        /// <param name="decimales">Cantidad de decimales a mantener.</param>
        public static double Truncar(double numero, int decimales) {
            var expresion = string.Format(@"(-?\d+\.?\d{{1,{0}}})", decimales);

            if (decimales == 0) {
                expresion = @"(-?\d+)";
            }

            var regex = new Regex(expresion);
            var match = regex.Match(numero.ToString());

            if (match.Success) {
                return double.Parse(match.Value);
            }

            return numero;
        }

        /// <summary>
        /// Devuelve una lista con los valores interpolados entre dos números.
        /// </summary>
        /// <param name="n1">Primer número.</param>
        /// <param name="n2">Segundo número.</param>
        /// <param name="intervalos">Cantidad de intervalos a interpolar.</param>
        public static List<double> Interpolar(double n1, double n2, int intervalos) {
            // Lista para valores interpolados.
            var valoresInterpolados = new List<double>();

            // Variable para invertir lista.
            var invertir = false;

            // Variables para valores mayor y menor.
            var mayor = n2;
            var menor = n1;

            // Verificando variables.
            if (n1 > n2) {
                mayor = n1;
                menor = n2;
                invertir = true;
            }

            // Diferencia entre extremos.
            var delta = mayor - menor;

            // Incremento a sumar en cada intervalo.
            var incremento = delta / intervalos;

            // Ciclo de incremento por cada intervalo.
            var acumulado = 0.0;
            for (var i = 0; i < intervalos; i++) {
                // Valor actual acumulado.
                acumulado += menor + incremento;

                // Agregando valor a la lista.
                valoresInterpolados.Add(acumulado);
            }

            // Sobreponiendo los valores originales en los extremos de la lista.
            valoresInterpolados[0] = menor;
            valoresInterpolados[intervalos - 1] = mayor;

            // Invirtiendo lista según el orden mayor a menor de los números originales.
            if (invertir) {
                valoresInterpolados.Reverse();
            }

            return valoresInterpolados;
        }
    }
}
