using Asu.Utils.Constants;
using System;
using System.Text.RegularExpressions;

namespace Asu.Utils
{
    /// <summary>
    /// Representa el tiempo de una línea en formato ASS.
    /// </summary>
    public class Time
	{
        /// <summary>
        /// Obtiene o establece la hora del tiempo representado por esta instancia.
        /// Se limita y ajusta automáticamente a 9; los excesos se pierden.
        /// </summary>
        public int Hours {get; set;}

        /// <summary>
        /// Obtiene o establece los minutos del tiempo representado por esta instancia.
        /// Se limitan y ajustan automáticamente a 59, pasando cualquier exceso a las horas.
        /// </summary>
		public int Minutes {get; set;}

        /// <summary>
        /// Obtiene o establece los segundos del tiempo representado por esta instancia.
        /// Se limitan y ajustan automáticamente a 59, pasando cualquier exceso a los minutos.
        /// </summary>
		public double Seconds { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Time"/>.
        /// </summary>
        public Time() {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Time"/>, copiando las propiedades de otra instancia.
        /// </summary>
        /// <param name="t">Tiempo a copiar.</param>
        public Time(Time t) {
			Hours = t.Hours;
			Minutes = t.Minutes;
			Seconds = t.Seconds;
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Time"/> en base a las horas, minutos y segundos.
        /// </summary>
        /// <param name="h">Horas. Se limita y ajusta automáticamente a 9.</param>
        /// <param name="m">Minutos. Se limitan y ajustan automáticamente a 59.</param>
        /// <param name="s">Segundos. Se limitan y ajustan automáticamente a 59.</param>
        public Time(int h, int m, double s) {
            Hours = h;
            Minutes = m;
            Seconds = s;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Time"/> con base en los segundos totales de duración.
        /// </summary>
        /// <param name="segundos">Cantidad total de segundos.</param>
        public Time(double segundos) {
            Hours = (int)(segundos / 3600);
            Minutes = (int)(((segundos / 3600) - Hours) * 60);
            //this.segundos = (((((segundos / 3600) - horas) * 60) - minutos) * 60);
            this.Seconds = Math.Round(segundos - Hours * 3600 - Minutes * 60, 2);
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Time"/> con base a una cadena en formato ASS de tiempo: h:mm:ss:cs.
        /// </summary>
        /// <param name="texto">Cadena que contiene el tiempo.</param>
        public Time(string texto) {
            Funciones.ChangeCulture();
            var regex = new Regex(RegularExpressions.RegexTime);
            var match = regex.Match(texto);
            if (match.Success) {
                Hours = int.Parse(match.Groups["h"].Value);
                Minutes = int.Parse(match.Groups["m"].Value);
                Seconds = double.Parse(match.Groups["s"].Value);
            }
            AdjustOverplus();
        }

        /// <summary>
        /// Ajusta los excesos de segundos, minutos u horas al límite: 9:59:59.99.
        /// </summary>
        private void AdjustOverplus() {
            Seconds = Maths.Truncate(Seconds, 2);
            
            if (Seconds >= 60) {
                Seconds -= 60;
                Minutes++;
            }

            if (Minutes >= 60) {
                Minutes -= 60;
                Hours++;
            }

            if (Hours >= 9) {
                Hours = 9;
                Minutes = 59;
                Seconds = 59.99;
            }
        }

        public override bool Equals(object obj) {
            var t2 = obj as Time;
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
            AdjustOverplus();
            var s = string.Format("{0:0}:{1:00}:{2:00.00}", Hours, Minutes, Seconds);

			return s;
		}
		
		/// <summary>
		/// Devuelve la cantidad total de segundos.
		/// </summary>
		public double ToDouble() {
            AdjustOverplus();
            var d = ((Hours * 3600) + (Minutes * 60) + Seconds);
            return d;
        }

        public override int GetHashCode() {
            var hashCode = -27068153;
            hashCode = hashCode * -1521134295 + Hours.GetHashCode();
            hashCode = hashCode * -1521134295 + Minutes.GetHashCode();
            hashCode = hashCode * -1521134295 + Seconds.GetHashCode();
            return hashCode;
        }

        public static Time operator +(Time t1, Time t2) {
            return new Time(t1.ToDouble() + t2.ToDouble());
        }

        public static Time operator -(Time t1, Time t2) {
            return new Time(t1.ToDouble() - t2.ToDouble());
        }
    }
}
