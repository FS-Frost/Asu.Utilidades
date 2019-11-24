using System.Collections.Generic;

namespace Asu.Utils.Core.AssFile {
    /// <summary>
    /// Representa la sección [AegisubProjectGarbage] de un archivo ASS.
    /// </summary>
    public class AegisubProjectGarbage {
        /// <summary>
        /// Obtiene o establece los scripts de la última sesión.
        /// </summary>
        public string AutomationScripts { get; set; }

        /// <summary>
        /// Obtiene o establece los filtros de exportación de la última sesión.
        /// </summary>
        public string ExportFilters { get; set; }

        /// <summary>
        /// Obtiene o establece la codificación de exportación de la última sesión.
        /// </summary>
        public string ExportEncoding { get; set; }

        /// <summary>
        /// Obtiene o establece el almacén de estilos de la última sesión.
        /// </summary>
        public string LastStyleStorage { get; set; }

        /// <summary>
        /// Obtiene o establece la ruta completa o relativa del archivo de audio de la última sesión.
        /// </summary>
        public string AudioFile { get; set; }

        /// <summary>
        /// Obtiene o establece la ruta completa o relatica del archivo de video de la última sesión.
        /// </summary>
        public string VideoFile { get; set; }

        /// <summary>
        /// Obtiene o establece la ruta completa o relatica del archivo de códigos de tiempo de la última sesión.
        /// </summary>
        public string TimecodesFile { get; set; }

        /// <summary>
        /// Obtiene o establece la ruta completa o relatica del archivo de cuadros clave de la última sesión.
        /// </summary>
        public string KeyframesFile { get; set; }

        /// <summary>
        /// Obtiene o establece el porcentaje de aumento de la última sesión.
        /// </summary>
        public double VideoZoomPercent { get; set; }

        /// <summary>
        /// Obtiene o establece la posición de la barra de desplazamiento de la última sesión.
        /// </summary>
        public int ScrollPosition { get; set; }

        /// <summary>
        /// Obtiene o establece la línea activa de la última sesión.
        /// </summary>
        public int ActiveLine { get; set; }

        /// <summary>
        /// Obtiene o establece la posición o cuadro activo del video de la última sesión.
        /// </summary>
        public int VideoPosition { get; set; }

        /// <summary>
        /// Obtiene o establece el modo de relación de aspecto del video de la última sesión.
        /// </summary>
        public int VideoARMode { get; set; }

        /// <summary>
        /// Obtiene o establece el valor de relación de aspecto del video de la última sesión.
        /// </summary>
        public double VideoARValue { get; set; }

        /// <summary>
        /// Obtiene o establece la lista con otras propiedades desconocidas.
        /// </summary>
        public List<string> Others { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AegisubProjectGarbage"/>.
        /// </summary>
        public AegisubProjectGarbage() {
            AutomationScripts = string.Empty;
            ExportFilters = string.Empty;
            ExportEncoding = string.Empty;
            LastStyleStorage = string.Empty;
            AudioFile = string.Empty;
            VideoFile = string.Empty;
            TimecodesFile = string.Empty;
            KeyframesFile = string.Empty;
            VideoZoomPercent = 0;
            ScrollPosition = 0;
            ActiveLine = 0;
            VideoPosition = 0;
            VideoARMode = 0;
            VideoARValue = 0;
            Others = new List<string>();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AegisubProjectGarbage"/>, copiando las propiedades de otra instancia.
        /// </summary>
        /// <param name="aegisubProyectGarbage">Instancia a copiar.</param>
        public AegisubProjectGarbage(AegisubProjectGarbage aegisubProyectGarbage) {
            AutomationScripts = aegisubProyectGarbage.AutomationScripts;
            ExportFilters = aegisubProyectGarbage.ExportFilters;
            ExportEncoding = aegisubProyectGarbage.ExportEncoding;
            LastStyleStorage = aegisubProyectGarbage.LastStyleStorage;
            AudioFile = aegisubProyectGarbage.AudioFile;
            VideoFile = aegisubProyectGarbage.VideoFile;
            TimecodesFile = aegisubProyectGarbage.TimecodesFile;
            KeyframesFile = aegisubProyectGarbage.KeyframesFile;
            VideoZoomPercent = aegisubProyectGarbage.VideoZoomPercent;
            ScrollPosition = aegisubProyectGarbage.ScrollPosition;
            ActiveLine = aegisubProyectGarbage.ActiveLine;
            VideoPosition = aegisubProyectGarbage.VideoPosition;
            VideoARMode = aegisubProyectGarbage.VideoARMode;
            VideoARValue = aegisubProyectGarbage.VideoARValue;
            Others = aegisubProyectGarbage.Others;
        }

        /// <summary>
        /// Devuelve una cadena con toda la sección.
        /// </summary>
        public override string ToString() {
            var resultado = string.Format("[Aegisub Project Garbage]\nAutomation Scripts: {0}\nExport Filters: {1}\nExport Encoding: {2}\nAudio File: {3}\nVideo File: {4}\nTimecodes File: {5}\nVideo AR Mode: {6}\nVideo AR Value: {7}\nVideo Zoom Percent: {8}\nActive Line: {9}\nVideo Position: {10}", AutomationScripts, ExportFilters, ExportEncoding, AudioFile, VideoFile, TimecodesFile, VideoARMode, VideoARValue, VideoZoomPercent, ActiveLine, VideoPosition);

            Others.ForEach(x => {
                resultado += "\n" + x;
            });

            return resultado;
        }
    }
}
