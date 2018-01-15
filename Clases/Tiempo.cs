using Asu.Utilidades.Constantes;
using System;
using System.Text.RegularExpressions;

namespace Asu.Utilidades
{
    /// <summary>
    /// Representa el tiempo de una línea en formato ASS.
    /// </summary>
    public class Tiempo
	{
        /// <summary>
        /// Obtiene o establece la hora del tiempo representado por esta instancia.
        /// Se limita y ajusta automáticamente a 9; los excesos se pierden.
        /// </summary>
        public int Horas {get; set;}

        /// <summary>
        /// Obtiene o establece los minutos del tiempo representado por esta instancia.
        /// Se limitan y ajustan automáticamente a 59, pasando cualquier exceso a las horas.
        /// </summary>
		public int Minutos {get; set;}

        /// <summary>
        /// Obtiene o establece los segundos del tiempo representado por esta instancia.
        /// Se limitan y ajustan automáticamente a 59, pasando cualquier exceso a los minutos.
        /// </summary>
		public double Segundos { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Tiempo"/>.
        /// </summary>
        public Tiempo() {
            Horas = 0;
            Minutos = 0;
            Segundos = 0;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Tiempo"/>, copiando las propiedades de otra instancia.
        /// </summary>
        /// <param name="t">Tiempo a copiar.</param>
        public Tiempo(Tiempo t) {
			Horas = t.Horas;
			Minutos = t.Minutos;
			Segundos = t.Segundos;
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Tiempo"/> en base a las horas, minutos y segundos.
        /// </summary>
        /// <param name="h">Horas. Se limita y ajusta automáticamente a 9.</param>
        /// <param name="m">Minutos. Se limitan y ajustan automáticamente a 59.</param>
        /// <param name="s">Segundos. Se limitan y ajustan automáticamente a 59.</param>
        public Tiempo(int h, int m, double s) {
            Horas = h;
            Minutos = m;
            Segundos = s;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Tiempo"/> con base en los segundos totales de duración.
        /// </summary>
        /// <param name="segundos">Cantidad total de segundos.</param>
        public Tiempo(double segundos) {
            Horas = (int)(segundos / 3600);
            Minutos = (int)(((segundos / 3600) - Horas) * 60);
            //this.segundos = (((((segundos / 3600) - horas) * 60) - minutos) * 60);
            this.Segundos = Math.Round(segundos - Horas * 3600 - Minutos * 60, 2);
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Tiempo"/> con base a una cadena en formato ASS de tiempo: h:mm:ss:cs.
        /// </summary>
        /// <param name="texto">Cadena que contiene el tiempo.</param>
        public Tiempo(string texto) {
            Funciones.CambiarCultura();
            var regex = new Regex(ExpresionesRegulares.regexTiempo);
            var match = regex.Match(texto);
            if (match.Success) {
                Horas = int.Parse(match.Groups["h"].Value);
                Minutos = int.Parse(match.Groups["m"].Value);
                Segundos = double.Parse(match.Groups["s"].Value);
            }
            AjustarExcesos();
        }

        /// <summary>
        /// Ajusta los excesos de segundos, minutos u horas al límite: 9:59:59.99.
        /// </summary>
        private void AjustarExcesos() {
            Segundos = Maths.Truncar(Segundos, 2);
            
            if (Segundos >= 60) {
                Segundos -= 60;
                Minutos++;
            }

            if (Minutos >= 60) {
                Minutos -= 60;
                Horas++;
            }

            if (Horas >= 10) {
                Horas = 9;
                Minutos = 59;
                Segundos = 59.99;
            }
        }

        public override bool Equals(object obj) {
            var t2 = obj as Tiempo;
            if (ToString() == t2.ToString() &&
                ToDouble() == t2.ToDouble()) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Devuelve una cadena con el formato: h:mm:ss:cs.
        /// </summary>
        public override string ToString() {
            AjustarExcesos();
            var s = string.Format("{0:0}:{1:00}:{2:00.00}", Horas, Minutos, Segundos);

			return s;
		}
		
		/// <summary>
		/// Devuelve la cantidad total de segundos.
		/// </summary>
		public double ToDouble() {
            AjustarExcesos();
            var d = ((Horas * 3600) + (Minutos * 60) + Segundos);
            return d;
        }

        public override int GetHashCode() {
            var hashCode = -27068153;
            hashCode = hashCode * -1521134295 + Horas.GetHashCode();
            hashCode = hashCode * -1521134295 + Minutos.GetHashCode();
            hashCode = hashCode * -1521134295 + Segundos.GetHashCode();
            return hashCode;
        }

        public static Tiempo operator +(Tiempo t1, Tiempo t2) {
            return new Tiempo(t1.ToDouble() + t2.ToDouble());
        }

        public static Tiempo operator -(Tiempo t1, Tiempo t2) {
            return new Tiempo(t1.ToDouble() - t2.ToDouble());
        }
    }
}
