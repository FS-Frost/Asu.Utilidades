using System;
using System.Collections.Generic;
using System.Linq;

namespace Asu.Utils.Core.ExtensionMethods {
    /// <summary>
    /// Proporciona funciones de extensión para diversos tipos básicos.
    /// </summary>
    public static class ExtensionMethods {
        /// <summary>
        /// Indica si el arreglo contiene cualquiera de los valores indicados.
        /// </summary>
        /// <param name="self">Arreglo a verificar.</param>
        /// <param name="array">Arreglo con valores a verificar.</param>
        /// <returns></returns>
        public static bool ContainsAny<T>(this T[] self, T[] array) {
            foreach (var s in array) {
                if (self.Contains(s)) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Indica si la lista contiene cualquiera de los valores indicados.
        /// </summary>
        /// <param name="self">Lista a verificar.</param>
        /// <param name="array">Arreglo con valores a verificar.</param>
        /// <returns></returns>
        public static bool ContainsAny<T>(this List<T> self, T[] array) {
            return self.ToArray().ContainsAny(array);
        }

        /// <summary>
        /// Obtiene un subconjunto de elementos.
        /// </summary>
        /// <typeparam name="T">Tipo del arreglo.</typeparam>
        /// <param name="self">Arreglo inicial.</param>
        /// <param name="startIndex">Índice de inicio del subconjunto.</param>
        /// <param name="endIndex">Índice de fin del subconjunto.</param>
        public static T[] GetRange<T>(this T[] self, int startIndex, int endIndex) {
            var lista = new List<T>();

            for (var i = startIndex; i < endIndex + 1; i++) {
                lista.Add(self[i]);
            }

            return lista.ToArray();
        }

        /// <summary>
        /// Obtiene un subconjunto de elementos.
        /// </summary>
        /// <typeparam name="T">Tipo de la lista.</typeparam>
        /// <param name="myArray">Lista inicial.</param>
        /// <param name="startIndex">Índice de inicio del subconjunto.</param>
        /// <param name="endIndex">Índice de fin del subconjunto.</param>
        public static List<T> GetRange<T>(this List<T> self, int startIndex, int endIndex) {
            return self.ToArray().GetRange(startIndex, endIndex).ToList();
        }

        /// <summary>
        /// Indica si el número pertenece al intervalo.
        /// </summary>
        /// <param name="self">Número del cual verificar pertenencia.</param>
        /// <param name="upperBound">Límite superior del intervalo.</param>
        /// <param name="lowerBound">Límite ingerior del intervalo.</param>
        /// <param name="isOpenInterval">Indica si el intervalo es abierto o cerrado.</param>
        public static bool IsBetween(this double self, double upperBound, double lowerBound, bool isOpenInterval) {
            if (isOpenInterval) {
                return self >= lowerBound && self <= upperBound;
            }

            return self > lowerBound && self < upperBound;
        }

        /// <summary>
        /// Indica si el número pertenece al intervalo.
        /// </summary>
        /// <param name="self">Número del cual verificar pertenencia.</param>
        /// <param name="upperBound">Límite superior del intervalo.</param>
        /// <param name="lowerBound">Límite ingerior del intervalo.</param>
        /// <param name="isOpenInterval">Indica si el intervalo es abierto o cerrado.</param>
        public static bool IsBetween(this int self, int upperBound, int lowerBound, bool isOpenInterval) {
            return ((double) self).IsBetween(upperBound, lowerBound, isOpenInterval);
        }
        
        /// <summary>
        /// Obtiene la cadena con el formato aplicado bajo la lógica de <see cref="string.Format(string, object[])."/>.
        /// </summary>
        /// <param name="self">Cadena a formatear.</param>
        /// <param name="args">Argumentos del formato.</param>
        public static string DoFormat(this string self, params string[] args) {
            return string.Format(self, args);
        }

        public static string DoFormat(this int self, string format) {
            return string.Format(format, self);
        }

        public static string DoFormat(this double self, string format) {
            return string.Format(format, self);
        }

        public static string DoFormat(this long self, params object[] args) {
            return string.Format(self.ToString(), args);
        }

        public static void AddIfNew<T>(this List<T> self, T element) {
            if (!self.Contains(element)) {
                self.Add(element);
            }
        }

        public static void AddRangeIfNew<T>(this List<T> self, params T[] elements) {
            foreach (var element in elements) {
                self.AddIfNew(element);
            }
        }

        public static void AddRangeIfNew<T>(this List<T> self, List<T> elements) {
            self.AddRangeIfNew(elements.ToArray());
        }

        public static void AddRange<T>(this List<T> self, params T[] elements) {
            foreach (var element in elements) {
                self.Add(element);
            }
        }
        
        public static void RemoveRange<T>(this List<T> self, IList<T> elements) {
            foreach (var element in elements) {
                self.Remove(element);
            }
        }

        public static List<string> ToSplittedList<T>(this T self, string separator) {
            return self.ToString().Split(separator).ToList();
        }

        public static string ToSeparatedString<T>(this List<T> list, string separator) {
            var text = "";

            for (var i = 0; i < list.Count; i++) {
                var elemento = list[i].ToString();

                if (i == 0) {
                    text = elemento;
                } else {
                    text += separator + elemento;
                }
            }

            return text;
        }

        public static string ToSeparatedString<T>(this T[] array, string separator) {
            return array.ToList().ToSeparatedString(separator);
        }

        public static string[] Split(this string self, string separator) {
            return self.Split(new string[] { separator }, StringSplitOptions.None);
        }
    }
}
