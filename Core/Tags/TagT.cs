using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de transformación del formato ASS.
    /// </summary>
    public class TagT : Tag {
        public override string Name => "t";
        public override Tags Type => Tags.T;

        /// <summary>
        /// Obtiene o establece el tiempo inicio de la transformación.
        /// </summary>
        public int T1 { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo de fin de la transformación.
        /// </summary>
        public int T2 { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo de aceleración.
        /// </summary>
        public double Accel { get; set; }

        /// <summary>
        /// Obtiene o establece el argumento del tag.
        /// </summary>
        public string Argumento { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagT"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagT(string texto) {
            var regex = new Regex(RegularExpressions.RegexTagT);
            var match = regex.Match(texto);
            if (match.Success) {
                var regex2 = new Regex(RegularExpressions.RegexArgsT);
                var match2 = regex2.Match(match.Groups["arg"].Value);
                if (match2.Success) {
                    var t1 = match2.Groups["t1"].Value;
                    var t2 = match2.Groups["t2"].Value;
                    var accel = match2.Groups["accel"].Value;
                    Argumento = match2.Groups["arg"].Value;

                    if (t1 != "") {
                        T1 = int.Parse(t1);
                    } else {
                        T1 = 0;
                    }

                    if (t2 != "") {
                        T2 = int.Parse(t2);
                    } else {
                        T2 = 0;
                    }

                    if (accel != "") {
                        Accel = double.Parse(accel);
                    } else {
                        Accel = 0;
                    }
                } else {
                    T1 = 0;
                    T2 = 0;
                    Accel = 0;
                    Argumento = "";
                }
            }
        }

        /// <summary>
        /// Devuelve una cadena con el formato inferido dados los argumentos no nulos.
        /// Véanse <see cref="ToStringAsAccelerated"/>, <see cref="ToStringAsNormal"/>, <see cref="ToStringAsTimed"/> y <see cref="ToStringAsTimedAccelerated"/>.
        /// </summary>
        public override string ToString() {
            if (T1 == 0 && T2 == 0) {
                if (Accel == 0) {
                    return ToStringAsNormal();
                } else {
                    return ToStringAsAccelerated();
                }
            } else {
                if (Accel == 0) {
                    return ToStringAsTimed();
                } else {
                    return ToStringAsTimedAccelerated();
                }
            }
        }

        /// <summary>
        /// Devuelve una cadena con formato: \t(t1,t2,argumento).
        /// </summary>
        public string ToStringAsTimed() {
            return string.Format("\\{0}({1},{2},{3})", Name, T1, T2, Argumento);
        }

        /// <summary>
        /// Devuelve una cadena con formato: \t(accel, argumento).
        /// </summary>
        public string ToStringAsAccelerated() {
            return string.Format("\\{0}({1},{2})", Name, Accel, Argumento);
        }

        /// <summary>
        /// Devuelve una cadena con formato: \t(argumento).
        /// </summary>
        public string ToStringAsNormal() {
            return string.Format("\\{0}({1})", Name, Argumento);
        }

        /// <summary>
        /// Devuelve una cadena con formato: \t(t1,t2,accel, argumento).
        /// </summary>
        /// <returns></returns>
        public string ToStringAsTimedAccelerated() {
            return string.Format("\\{0}({1},{2},{3},{4})", Name, T1, T2, Accel, Argumento);
        }
    }
}
