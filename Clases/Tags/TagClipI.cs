using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag de recorte rectangular o vectorial opuesto del formato ASS.
    /// </summary>
    public class TagClipI : Tag {
        public override string Nombre => "iclip";
        /// <summary>
        /// Obtiene o establece el factor horizontal izquierdo del rectángulo.
        /// </summary>
        public double X1 { get; set; }

        /// <summary>
        /// Obtiene o establece el factor vertical izquierdo del rectángulo.
        /// </summary>
        public double Y1 { get; set; }

        /// <summary>
        /// Obtiene o establece el factor horizontal derecho del rectángulo.
        /// </summary>
        public double X2 { get; set; }

        /// <summary>
        /// Obtiene o establece el factor vertical derecho del rectángulo.
        /// </summary>
        public double Y2 { get; set; }

        /// <summary>
        /// Obtiene o establece los comandos de dibujo.
        /// </summary>
        public string DrawingCommands { get; set; }

        /// <summary>
        /// Obtiene o establece la escala del dibujo.
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagClipI"/> dados sus argumentos rectangulares.
        /// </summary>
        /// <param name="x1">Factor horizontal izquierdo.</param>
        /// <param name="y1">Factor vertical izquierdo.</param>
        /// <param name="x2">Factor horizontal derecho.</param>
        /// <param name="y2">Factor vertical derecho.</param>
        public TagClipI(double x1, double y1, double x2, double y2) {
            // Rectángulo.
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;

            // Anulando demás valores.
            DrawingCommands = "";
            Scale = 0;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagClipI"/> dados sus argumentos de dibujo.
        /// </summary>
        /// <param name="scale">Escala del dibujo.</param>
        /// <param name="drawingCommands">Comandos de dibujo.</param>
        public TagClipI(int scale, string drawingCommands) {
            // Comandos con escala.
            Scale = scale;
            DrawingCommands = drawingCommands;

            // Anulando demás valores.
            X1 = 0;
            Y1 = 0;
            X2 = 0;
            Y2 = 0;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagClipI"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagClipI(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagClipI);
            var match = regex.Match(texto);
            if (match.Success) {
                var regex2 = new Regex(ExpresionesRegulares.regexArgsClip);
                var match2 = regex2.Match(match.Groups["arg"].Value);
                if (match2.Success) {
                    var escala = match2.Groups["escala"].Value;
                    var comandos = match2.Groups["comandos"].Value;
                    var arg = match2.Groups["arg"].Value;

                    if (escala != "") {
                        Scale = int.Parse(escala);
                    } else {
                        Scale = 0;
                    }

                    if (comandos != "") {
                        DrawingCommands = comandos;
                    } else {
                        DrawingCommands = "";
                    }

                    if (arg != "") {
                        var args = arg.Split(',');
                        X1 = double.Parse(args[0]);
                        Y1 = double.Parse(args[1]);
                        X2 = double.Parse(args[2]);
                        Y2 = double.Parse(args[3]);
                    } else {
                        X1 = 0;
                        Y1 = 0;
                        X2 = 0;
                        Y2 = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Devuelve una cadena con el formato inferido dados los argumentos no nulos.
        /// Véanse <see cref="ToStringAsRectangle"/>, <see cref="ToStringAsDrawing"/> y <see cref="ToStringAsScaledDrawing"/>.
        /// </summary>
        public override string ToString() {
            if (X1 == 0 && Y1 == 0 && X2 == 0 && Y2 == 0) {
                if (Scale == 0) {
                    return ToStringAsDrawing();
                } else {
                    return ToStringAsScaledDrawing();
                }
            } else {
                return ToStringAsRectangle();
            }
        }

        /// <summary>
        /// Devuelve una cadena con formato: \iclip(x1,y1,x2,y2).
        /// </summary>
        public string ToStringAsRectangle() {
            return string.Format("\\{0}({1},{2},{3},{4})", 
                Nombre, X1, Y1, X2, Y2);
        }

        /// <summary>
        /// Devuelve una cadena con formato: \iclip(drawingCommands).
        /// </summary>
        public string ToStringAsDrawing() {
            return string.Format("\\{0}({1})",
                Nombre, DrawingCommands);
        }

        /// <summary>
        /// Devuelve una cadena con formato: \iclip(scale,drawingCommands).
        /// </summary>
        public string ToStringAsScaledDrawing() {
            return string.Format("\\{0}({1},{2})",
                Nombre, Scale, DrawingCommands);
        }
    }
}
