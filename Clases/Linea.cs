using Asu.Utilidades.Constantes;
using System.Collections.Generic;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa una línea en formato ASS.
    /// </summary>
    public class Linea {
        /// <summary>
        /// Obtiene o establece el tipo de línea.
        /// </summary>
        public TipoLinea Tipo { get; set; }

        /// <summary>
        /// Obtiene o establece la capa de profundidad.
        /// </summary>
        public int Capa { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo de inicio.
        /// </summary>
        public Tiempo Inicio { get; set; }

        /// <summary>
        /// Obtiene o establece el tiempo de fin.
        /// </summary>
        public Tiempo Fin { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del estilo.
        /// </summary>
        public string Estilo { get; set; }

        /// <summary>
        /// Obtiene o establece el actor.
        /// </summary>
        public string Actor { get; set; }

        /// <summary>
        /// Obtiene o establece el margen izquierdo.
        /// </summary>
        public int MargenI { get; set; }

        /// <summary>
        /// Obtiene o establece el margen derecho.
        /// </summary>
        public int MargenD { get; set; }

        /// <summary>
        /// Obtiene o establece el margen vertical.
        /// </summary>
        public int MargenV { get; set; }

        /// <summary>
        /// Obtiene o establece el efecto.
        /// </summary>
        public string Efecto { get; set; }

        /// <summary>
        /// Obtiene o establece el contenido de la línea.
        /// </summary>
        public string Contenido { get; set; }

        /// <summary>
        /// Obtiene o establece la duración de la línea en segundos.
        /// </summary>
        public double Duracion {
            get {
                var d = Fin.ToDouble() - Inicio.ToDouble();
                return Maths.Truncar(d, 2);
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Linea"/>, usando los mismos valores por defecto que Aegisub.
        /// </summary>
        public Linea() {
            Tipo = TipoLinea.Dialogue;
            Capa = 0;
            Inicio = new Tiempo();
            Fin = new Tiempo();
            Estilo = "Default";
            Actor = string.Empty;
            MargenI = 0;
            MargenD = 0;
            MargenV = 0;
            Efecto = string.Empty;
            Contenido = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Linea"/> en base a una cadena.
        /// </summary>
        /// <param name="texto"></param>
        public Linea(string texto) {
            // Obteniendo valores.
            var _tipo = FiltroAss.FiltrarPropiedad(texto, Propiedades.Tipo);
            var _capa = FiltroAss.FiltrarPropiedad(texto, Propiedades.Capa);
            var _inicio = new Tiempo(FiltroAss.FiltrarPropiedad(texto, Propiedades.Inicio));
            var _fin = new Tiempo(FiltroAss.FiltrarPropiedad(texto, Propiedades.Fin));
            var _estilo = FiltroAss.FiltrarPropiedad(texto, Propiedades.Estilo);
            var _actor = FiltroAss.FiltrarPropiedad(texto, Propiedades.Actor);
            var _margenI = FiltroAss.FiltrarPropiedad(texto, Propiedades.MargenIzquierdo);
            var _margenD = FiltroAss.FiltrarPropiedad(texto, Propiedades.MargenDerecho);
            var _margenV = FiltroAss.FiltrarPropiedad(texto, Propiedades.MargenVertical);
            var _efecto = FiltroAss.FiltrarPropiedad(texto, Propiedades.Efecto);
            var _contenido = FiltroAss.FiltrarPropiedad(texto, Propiedades.Contenido);

            // Verificando valores.

            // Tipo.
            if (_tipo != "Dialogue" && _tipo != "Comment") {
                return;
            } else {
                Tipo = TipoLineaInfo.StringToTipoLinea(_tipo);
            }

            // Capa.
            if (_capa == "") {
                Capa = 0;
            } else {
                Capa = int.Parse(_capa);
            }

            // Tiempos.
            if (_inicio.ToDouble() >= _fin.ToDouble()) {
                return;
            }

            // Márgenes.
            if (_margenD == "") {
                MargenD = 0;
            } else {
                MargenD = int.Parse(_margenD);
            }

            if (_margenI == "") {
                MargenI = 0;
            } else {
                MargenI = int.Parse(_margenI);
            }

            if (_margenV == "") {
                MargenV = 0;
            } else {
                MargenV = int.Parse(_margenV);
            }
            
            // Ingresando demás valores.
            Inicio = _inicio;
            Fin = _fin;
            Estilo = _estilo;
            Actor = _actor;
            Efecto = _efecto;
            Contenido = _contenido;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Linea"/>, copiando las propiedades de otra instancia.
        /// </summary>
        /// <param name="l">Linea a copiar.</param>
        public Linea(Linea l) {
            Tipo = l.Tipo;
            Capa = l.Capa;
            Inicio = l.Inicio;
            Fin = l.Fin;
            Estilo = l.Estilo;
            Actor = l.Actor;
            MargenI = l.MargenI;
            MargenD = l.MargenD;
            MargenV = l.MargenV;
            Efecto = l.Efecto;
            Contenido = l.Contenido;
        }

        /// <summary>
        /// Compara la instancia actual con otra. Devuelve verdadero si son iguales, y falso si difieren.
        /// </summary>
        /// <param name="obj">Linea a comparar</param>
        public override bool Equals(object obj) {
            var l2 = obj as Linea;
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
            var _Tipo = TipoLineaInfo.TipoLineaToString(Tipo);

            return string.Format("{0}: {1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", _Tipo, Capa, Inicio, Fin, Estilo, Actor, MargenI, MargenD, MargenV, Efecto, Contenido);
        }

        public override int GetHashCode() {
            var hashCode = -1817798551;
            hashCode = hashCode * -1521134295 + EqualityComparer<TipoLinea>.Default.GetHashCode(Tipo);
            hashCode = hashCode * -1521134295 + Capa.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Tiempo>.Default.GetHashCode(Inicio);
            hashCode = hashCode * -1521134295 + EqualityComparer<Tiempo>.Default.GetHashCode(Fin);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Estilo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Actor);
            hashCode = hashCode * -1521134295 + MargenI.GetHashCode();
            hashCode = hashCode * -1521134295 + MargenD.GetHashCode();
            hashCode = hashCode * -1521134295 + MargenV.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Efecto);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Contenido);
            hashCode = hashCode * -1521134295 + Duracion.GetHashCode();
            return hashCode;
        }
    }
}
