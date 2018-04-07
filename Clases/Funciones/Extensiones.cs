using System.Collections.Generic;
using System.Linq;

namespace Asu.Utilidades.Clases.Extensiones {
    /// <summary>
    /// Proporciona funciones de extensión para diversos tipos básicos.
    /// </summary>
    public static class Extensiones {
        /// <summary>
        /// Indica si el arreglo contiene cualquiera de los valores indicados.
        /// </summary>
        /// <param name="myArray">Arreglo a verificar.</param>
        /// <param name="array">Arreglo con valores a verificar.</param>
        /// <returns></returns>
        public static bool ContainsAny(this string[] myArray, string[] array) {
            foreach (var s in array) {
                if (myArray.Contains(s)) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Obtiene un subconjunto de elementos.
        /// </summary>
        /// <typeparam name="T">Tipo del arreglo.</typeparam>
        /// <param name="myArray">Arreglo inicial.</param>
        /// <param name="startIndex">Índice de inicio del subconjunto.</param>
        /// <param name="endIndex">Índice de fin del subconjunto.</param>
        public static T[] GetSubGroup<T>(this T[] myArray, int startIndex, int endIndex) {
            var lista = new List<T>();
            for (var i = startIndex; i < endIndex + 1; i++) {
                lista.Add(myArray[i]);
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
        public static List<T> GetSubGroup<T>(this List<T> myList, int startIndex, int endIndex) {
            return myList.ToArray().GetSubGroup(startIndex, endIndex).ToList();
        }
    }
}
