using Asu.Utils.Constants;
using System.Collections.Generic;
using System;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa una línea en formato ASS.
    /// </summary>
    public class Line {
        /// <summary>
        /// Obtiene o establece el tipo de línea.
        /// </summary>
        public LineType Type { get; set; }

        /// <summary>
        /// Obtiene o establece la capa de profundidad.
        /// </summary>
        public int Layer { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo de inicio.
        /// </summary>
        public Time Start { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo de fin.
        /// </summary>
        public Time End { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del estilo.
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// Obtiene o establece el actor.
        /// </summary>
        public string Actor { get; set; }

        /// <summary>
        /// Obtiene o establece el margen izquierdo.
        /// </summary>
        public int MarginLeft { get; set; }

        /// <summary>
        /// Obtiene o establece el margen derecho.
        /// </summary>
        public int MarginRight { get; set; }

        /// <summary>
        /// Obtiene o establece el margen vertical.
        /// </summary>
        public int MarginVertical { get; set; }

        /// <summary>
        /// Obtiene o establece el efecto.
        /// </summary>
        public string Effect { get; set; }

        /// <summary>
        /// Obtiene o establece el contenido de la línea.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Obtiene o establece la duración de la línea en segundos.
        /// </summary>
        public double Length {
            get {
                var d = End.ToDouble() - Start.ToDouble();
                return Maths.Truncate(d, 2);
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Line"/>, usando los mismos valores por defecto que Aegisub.
        /// </summary>
        public Line() {
            Type = LineType.Dialogue;
            Layer = 0;
            Start = new Time();
            End = new Time();
            Style = "Default";
            Actor = string.Empty;
            MarginLeft = 0;
            MarginRight = 0;
            MarginVertical = 0;
            Effect = string.Empty;
            Content = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Line"/> en base a una cadena.
        /// </summary>
        /// <param name="texto"></param>
        public Line(string texto) {
            // Obteniendo valores.
            var _tipo = AssFilter.FilterProperty(texto, Property.Type);
            var _capa = AssFilter.FilterProperty(texto, Property.Layer);
            var _inicio = new Time(AssFilter.FilterProperty(texto, Property.Start));
            var _fin = new Time(AssFilter.FilterProperty(texto, Property.End));
            var _estilo = AssFilter.FilterProperty(texto, Property.Style);
            var _actor = AssFilter.FilterProperty(texto, Property.Actor);
            var _margenI = AssFilter.FilterProperty(texto, Property.MarginLeft);
            var _margenD = AssFilter.FilterProperty(texto, Property.MarginRight);
            var _margenV = AssFilter.FilterProperty(texto, Property.MarginVertical);
            var _efecto = AssFilter.FilterProperty(texto, Property.Effect);
            var _contenido = AssFilter.FilterProperty(texto, Property.Content);

            // Verificando valores.

            // Tipo.
            if (_tipo != "Dialogue" && _tipo != "Comment") {
                return;
            } else {
                Type = LineTypeInfo.StringToLineType(_tipo);
            }

            // Capa.
            if (_capa == "") {
                Layer = 0;
            } else {
                Layer = int.Parse(_capa);
            }

            // Tiempos.
            if (_inicio.ToDouble() > _fin.ToDouble()) {
                throw new InvalidOperationException("El tiempo de inicio de línea debe ser menor o igual al de fin.");
            }

            // Márgenes.
            if (_margenD == "") {
                MarginRight = 0;
            } else {
                MarginRight = int.Parse(_margenD);
            }

            if (_margenI == "") {
                MarginLeft = 0;
            } else {
                MarginLeft = int.Parse(_margenI);
            }

            if (_margenV == "") {
                MarginVertical = 0;
            } else {
                MarginVertical = int.Parse(_margenV);
            }
            
            // Ingresando demás valores.
            Start = _inicio;
            End = _fin;
            Style = _estilo;
            Actor = _actor;
            Effect = _efecto;
            Content = _contenido;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Line"/>, copiando las propiedades de otra instancia.
        /// </summary>
        /// <param name="l">Linea a copiar.</param>
        public Line(Line l) {
            Type = l.Type;
            Layer = l.Layer;
            Start = l.Start;
            End = l.End;
            Style = l.Style;
            Actor = l.Actor;
            MarginLeft = l.MarginLeft;
            MarginRight = l.MarginRight;
            MarginVertical = l.MarginVertical;
            Effect = l.Effect;
            Content = l.Content;
        }

        /// <summary>
        /// Compara la instancia actual con otra. Devuelve verdadero si son iguales, y falso si difieren.
        /// </summary>
        /// <param name="obj">Linea a comparar</param>
        public override bool Equals(object obj) {
            var l2 = obj as Line;
            return ToString().Equals(l2.ToString(), System.StringComparison.CurrentCulture);

            /*
            var l2 = obj as Linea;

            var _tipo = Tipo == l2.Tipo;
            var _capa = Capa == l2.Capa;
            var _inicio = Inicio == l2.Inicio;
            var _fin = Fin == l2.Fin;
            var _estilo = Estilo == l2.Estilo;
            var _actor = Actor == l2.Actor;
            var _margenI = MargenI == l2.MargenI;
            var _margenD = MargenD == l2.MargenD;
            var _margenV = MargenV == l2.MargenV;
            var _efecto = Efecto == l2.Efecto;
            var _contenido = Contenido == l2.Contenido;

            if (_tipo && _capa && _inicio && _fin && _estilo && _actor && _margenI && _margenD && _margenV && _efecto && _contenido) {
                return true;
            } else {
                return false;
            }
            */
        }

        /// <summary>
        /// Devuelve una cadena con la línea en formato ASS.
        /// </summary>
        public override string ToString() {
            var _Tipo = LineTypeInfo.LineTypeToString(Type);

            return string.Format("{0}: {1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", _Tipo, Layer, Start, End, Style, Actor, MarginLeft, MarginRight, MarginVertical, Effect, Content);
        }

        public override int GetHashCode() {
            var hashCode = -1817798551;
            hashCode = hashCode * -1521134295 + EqualityComparer<LineType>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + Layer.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Time>.Default.GetHashCode(Start);
            hashCode = hashCode * -1521134295 + EqualityComparer<Time>.Default.GetHashCode(End);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Style);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Actor);
            hashCode = hashCode * -1521134295 + MarginLeft.GetHashCode();
            hashCode = hashCode * -1521134295 + MarginRight.GetHashCode();
            hashCode = hashCode * -1521134295 + MarginVertical.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Effect);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Content);
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            return hashCode;
        }
    }
}
