using Asu.Utils.Constants;
using System.Text.RegularExpressions;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa un tag de movimiento del formato ASS.
    /// </summary>
    public class TagMove : Tag {
        public override string Name => "move";
        public override Tags Type => Tags.Move;

        /// <summary>
        /// Obtiene o establece el factor horizontal inicial.
        /// </summary>
        public double X1 { get; set; }

        /// <summary>
        /// Obtiene o establece el factor vertical inicial.
        /// </summary>
        public double Y1 { get; set; }

        /// <summary>
        /// Obtiene o establece el factor horizontal final.
        /// </summary>
        public double X2 { get; set; }

        /// <summary>
        /// Obtiene o establece el factor vertical final.
        /// </summary>
        public double Y2 { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo de inicio de movimiento tras el inicio de línea.
        /// </summary>
        public int T1 { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo de fin del movimiento.
        /// </summary>
        public int T2 { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagMove"/>.
        /// </summary>
        public TagMove() {
            X1 = 0;
            Y1 = 0;
            X2 = 0;
            Y2 = 0;
            T1 = 0;
            T2 = 0;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagMove"/> dados sus argumentos de posición y tiempo.
        /// </summary>
        /// <param name="x1">Factor horizontal inicial.</param>
        /// <param name="y1">Factor vertical inicial.</param>
        /// <param name="x2">Factor horizontal final.</param>
        /// <param name="y2">Factor vertical final.</param>
        /// <param name="t1">Tiempo de inicio de movimiento tras el inicio de línea.</param>
        /// <param name="t2">Tiempo de fin del movimiento.</param>
        public TagMove(double x1, double y1, double x2, double y2, int t1, int t2) {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            T1 = t1;
            T2 = t2;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagMove"/> dados sus argumentos de posición.
        /// </summary>
        /// <param name="x1">Factor horizontal inicial.</param>
        /// <param name="y1">Factor vertical inicial.</param>
        /// <param name="x2">Factor horizontal final.</param>
        /// <param name="y2">Factor vertical final.</param>
        public TagMove(double x1, double y1, double x2, double y2) {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            T1 = 0;
            T2 = 0;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagMove"/> en base a una cadena.
        /// </summary>
        /// <param name="s">Cadena con el tag.</param>
        public TagMove(string s) {
            var regex = new Regex(RegularExpressions.RegexTagMove);
            var match = regex.Match(s);
            if (match.Success) {
                var separado = match.Groups["arg"].Value.Split(',');
                X1 = double.Parse(separado[0]);
                Y1 = double.Parse(separado[1]);
                X2 = double.Parse(separado[2]);
                Y2 = double.Parse(separado[3]);

                try {
                    T1 = int.Parse(separado[4]);
                }
                catch (System.Exception) {
                    T1 = 0;
                }

                try {
                    T2 = int.Parse(separado[5]);
                }
                catch (System.Exception) {
                    T2 = 0;
                }
            }
        }

        /// <summary>
        /// Devuelve una cadena con formato: \move(x1,y1,x2,y2,t1,t2). Devuelve \move(x1,y1,x2,y2) si los tiempos son nulos.
        /// </summary>
        public override string ToString() {
            if (T1 == 0 && T2 == 0) {
                return string.Format("\\{0}({1},{2},{3},{4})",
                Name, X1, Y1, X2, Y2);
            } else {
                return string.Format("\\{0}({1},{2},{3},{4},{5},{6})",
                Name, X1, Y1, X2, Y2, T1, T2);
            }
        }
    }
}
