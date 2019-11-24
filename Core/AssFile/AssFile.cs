using Asu.Utils.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Asu.Utils.Core.AssFile {
    /// <summary>
    /// Representa un archivo ASS.
    /// </summary>
    public class AssFile {
        /// <summary>
        /// Obtiene o establece la información del script.
        /// </summary>
        public ScriptInfo ScriptInfo { get; set; }

        /// <summary>
        /// Obtiene o establece la información de la última sesión del script.
        /// </summary>
        public AegisubProjectGarbage AegisubProjectGarbage { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de fuentes adjuntas.
        /// </summary>
        public List<AttachedFont> Fonts { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de imágenes adjuntas.
        /// </summary>
        public List<AttachedGraphic> Graphics { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de estilos.
        /// </summary>
        public List<Style> Styles { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de líneas.
        /// </summary>
        public List<Line> Events { get; set; }

        /// <summary>
        /// Obtiene o establece la ruta del directorio del archivo.
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del archivo.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece la extensión del archivo.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Obtiene la ruta en disco del archivo.
        /// </summary>
        public string Path {
            get {
                return System.IO.Path.Combine(Directory, Name + Extension);
            }
        }

        /// <summary>
        /// Obtiene la cantidad de líneas del archivo.
        /// </summary>
        public int Count {
            get {
                var texto = ToString();
                var lineas = texto.Split(new string[] { "\n" }, StringSplitOptions.None);
                return lineas.Count() + 1;
            }
        }

        private const string FormatStyle = "Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding";

        private const string FormatEvent = "Format: Layer, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AssFile"/> al leer un archivo ASS.
        /// </summary>
        /// <param name="ruta">Ruta del archivo ASS.</param>
        public AssFile(string ruta) {
            Funciones.ChangeCulture();
            
            // Inicializando.
            ScriptInfo = new ScriptInfo();
            AegisubProjectGarbage = new AegisubProjectGarbage();
            Fonts = new List<AttachedFont>();
            Graphics = new List<AttachedGraphic>();
            Styles = new List<Style>();
            Events = new List<Line>();
            Directory = System.IO.Path.GetDirectoryName(ruta);
            Name = System.IO.Path.GetFileNameWithoutExtension(ruta);
            Extension = System.IO.Path.GetExtension(ruta);


            // Indicadores de categoría.
            var scriptInfoActivo = false;
            var aegisubProjectGarbageActivo = false;
            var stylesActivo = false;
            var graphicsActivo = false;
            var fontsActivo = false;
            var eventsActivo = false;
            
            // Identificadores de líneas de archivo.ass.
            var _Comment = "; ";
            var _Title = "Title: ";
            var _ScriptType = "ScriptType: ";
            var _WrapStyle = "WrapStyle: ";
            var _ScaledBorderAndShadow = "ScaledBorderAndShadow: ";
            var _PlayResX = "PlayResX: ";
            var _PlayResY = "PlayResY: ";
            var _YCbCrMatrix = "YCbCr Matrix: ";
            var _AutomationScripts = "Automation Scripts: ";
            var _ExportFilters = "Export Filters: ";
            var _ExportEncoding = "Export Encoding: ";
            var _AudioFile = "Audio File: ";
            var _VideoFile = "Video File: ";
            var _TimecodesFile = "Timecodes File: ";
            var _VideoARMode = "Video AR Mode: ";
            var _VideoARValue = "Video AR Value: ";
            var _VideoZoomPercent = "Video Zoom Percent: ";
            var _ActiveLine = "Active Line: ";
            var _VideoPosition = "Video Position: ";
            var _Style = "Style: ";
            var _filename = "filename: ";
            var _fontname = "fontname: ";
            var _LineDialogue = "Dialogue: ";
            var _LineComment = "Comment: ";

            List<string> lineas;
            try {
                lineas = File.ReadAllLines(ruta, System.Text.Encoding.ASCII).ToList();
            } catch (Exception) {
                throw;
            }

            for (var i = 0; i < lineas.Count; i++) {
                var lineaActual = lineas[i];

                switch (lineaActual) {
                    case "[Script Info]":
                        scriptInfoActivo = true;
                        goto Fin;

                    case "[Aegisub Project Garbage]":
                        scriptInfoActivo = false;
                        aegisubProjectGarbageActivo = true;
                        goto Fin;

                    case "[V4+ Styles]":
                        aegisubProjectGarbageActivo = false;
                        stylesActivo = true;
                        goto Fin;

                    case "[Graphics]":
                        stylesActivo = false;
                        graphicsActivo = true;
                        goto Fin;

                    case "[Fonts]":
                        graphicsActivo = false;
                        fontsActivo = true;
                        goto Fin;

                    case "[Events]":
                        fontsActivo = false;
                        eventsActivo = true;
                        goto Fin;

                    default:
                        break;
                }
                
                if (scriptInfoActivo) {
                    if (lineaActual.StartsWith(_Comment)) {
                        ScriptInfo.Comments.Add(lineaActual.Substring(_Comment.Length));
                    } else

                    if (lineaActual.StartsWith(_Title)) {
                        ScriptInfo.Title = lineaActual.Substring(_Title.Length);
                    } else

                    if (lineaActual.StartsWith(_ScriptType)) {
                        ScriptInfo.ScriptType = lineaActual.Substring(_ScriptType.Length);
                    } else

                    if (lineaActual.StartsWith(_WrapStyle)) {
                        ScriptInfo.WrapStyle = WrapStyleInfo.StringToWrapStyle(lineaActual.Substring(_WrapStyle.Length));
                    } else

                    if (lineaActual.StartsWith(_ScaledBorderAndShadow)) {
                        var aux = false;

                        if (lineaActual.Substring(_ScaledBorderAndShadow.Length) == "yes") {
                            aux = true;
                        }

                        ScriptInfo.ScaledBorderAndShadow = aux;
                    } else

                    if (lineaActual.StartsWith(_PlayResX)) {
                        ScriptInfo.PlayResX = int.Parse(lineaActual.Substring(_PlayResX.Length));
                    } else

                    if (lineaActual.StartsWith(_PlayResY)) {
                        ScriptInfo.PlayResY = int.Parse(lineaActual.Substring(_PlayResY.Length));
                    } else

                    if (lineaActual.StartsWith(_YCbCrMatrix)) {
                        ScriptInfo.YCbCrMatrix = YCbCrMatrixInfo.StringToYCbCrMatrix(lineaActual.Substring(_YCbCrMatrix.Length));
                    } else

                    if (lineaActual == "[Aegisub Project Garbage]") {
                        scriptInfoActivo = false;
                        aegisubProjectGarbageActivo = true;
                    } else

                    if (lineaActual != "") {
                        ScriptInfo.Others.Add(lineaActual);
                    }
                } else

                if (aegisubProjectGarbageActivo) {
                    if (lineaActual.StartsWith(_AutomationScripts)) {
                        AegisubProjectGarbage.AutomationScripts = lineaActual.Substring(_AutomationScripts.Length);
                    } else

                    if (lineaActual.StartsWith(_ExportFilters)) {
                        AegisubProjectGarbage.ExportFilters = lineaActual.Substring(_ExportFilters.Length);
                    } else

                    if (lineaActual.StartsWith(_ExportEncoding)) {
                        AegisubProjectGarbage.ExportEncoding = lineaActual.Substring(_ExportEncoding.Length);
                    } else

                    if (lineaActual.StartsWith(_AudioFile)) {
                        AegisubProjectGarbage.AudioFile = lineaActual.Substring(_AudioFile.Length);
                    } else

                    if (lineaActual.StartsWith(_VideoFile)) {
                        AegisubProjectGarbage.VideoFile = lineaActual.Substring(_VideoFile.Length);
                    } else

                    if (lineaActual.StartsWith(_TimecodesFile)) {
                        AegisubProjectGarbage.TimecodesFile = lineaActual.Substring(_TimecodesFile.Length);
                    } else

                    if (lineaActual.StartsWith(_VideoARMode)) {
                        AegisubProjectGarbage.VideoARMode = int.Parse(lineaActual.Substring(_VideoARMode.Length));
                    } else

                    if (lineaActual.StartsWith(_VideoARValue)) {
                        AegisubProjectGarbage.VideoARValue = double.Parse(lineaActual.Substring(_VideoARValue.Length));
                    } else

                    if (lineaActual.StartsWith(_VideoZoomPercent)) {
                        AegisubProjectGarbage.VideoZoomPercent = double.Parse(lineaActual.Substring(_VideoZoomPercent.Length));
                    } else

                    if (lineaActual.StartsWith(_ActiveLine)) {
                        AegisubProjectGarbage.ActiveLine = int.Parse(lineaActual.Substring(_ActiveLine.Length));
                    } else

                    if (lineaActual.StartsWith(_VideoPosition)) {
                        AegisubProjectGarbage.VideoPosition = int.Parse(lineaActual.Substring(_VideoPosition.Length));
                    } else

                    if (lineaActual == "[V4+ Styles]") {
                        aegisubProjectGarbageActivo = false;
                    } else

                    if (lineaActual != "") {
                        AegisubProjectGarbage.Others.Add(lineaActual);
                    }
                } else

                if (stylesActivo && lineaActual.StartsWith(_Style)) {
                    var style = new Style(lineaActual.Substring(_Style.Length));
                    Styles.Add(style);
                } else

                if (graphicsActivo && lineaActual.StartsWith(_filename)) {
                    var graphic = new AttachedGraphic() {
                        Name = lineaActual.Substring(_filename.Length)
                    };

                    var siguienteIndice = i + 1;
                    while (lineas[siguienteIndice] != null && lineas[siguienteIndice] != string.Empty) {
                        graphic.Data.Add(lineas[siguienteIndice]);
                        siguienteIndice++;
                    }
                    Graphics.Add(graphic);
                } else

                if (fontsActivo && lineaActual.StartsWith(_fontname)) {
                    var font = new AttachedFont() {
                        Name = lineaActual.Substring(_fontname.Length)
                    };

                    var siguienteIndice = i + 1;
                    while (lineas[siguienteIndice] != null && lineas[siguienteIndice] != string.Empty) {
                        font.Data.Add(lineas[siguienteIndice]);
                        siguienteIndice++;
                    }
                    Fonts.Add(font);
                } else

                if (eventsActivo) {
                    if (lineaActual.StartsWith(_LineDialogue) || lineaActual.StartsWith(_LineComment)) {
                        var linea = new Line(lineaActual);
                        Events.Add(linea);
                    }
                }

                Fin:
                continue;
            }
        }

        /// <summary>
        /// Devuelve una instancia de <see cref="AssFile"/> dada una ruta de acceso a un archivo ASS.
        /// </summary>
        /// <param name="ruta">Ruta del archivo ASS.</param>
        /// <returns></returns>
        public static AssFile Open(string ruta) {
            return new AssFile(ruta);
        }
        
        /// <summary>
        /// Guarda el archivo en disco.
        /// </summary>
        /// <param name="sobrescribir">Indica si el archivo se sobreescribirá de ser necesario.</param>
        public void Save(bool sobrescribir) {
            if (!sobrescribir && File.Exists(Path)) {
                throw new IOException(string.Format("El archivo {0} ya existe.", Path));
            }

            File.WriteAllText(Path, ToString());
        }
        
        /// <summary>
        /// Devuelve una cadena con todas las líneas del archivo ASS.
        /// </summary>
        public override string ToString() {
            var _Styles = "[V4+ Styles]";
            _Styles += "\n" + FormatStyle;
            Styles.ForEach(s => {
                _Styles += "\n" + s.ToString();
            });

            var _Graphics = "[Graphics]";
            Graphics.ForEach(g => {
                _Graphics += "\n" + g.ToString();
            });

            var _Fonts = "[Fonts]";
            Fonts.ForEach(f => {
                _Fonts += "\n" + f.ToString();
            });

            var _Events = "[Events]";
            _Events += "\n" + FormatEvent;
            Events.ForEach(e => {
                _Events += "\n" + e.ToString();
            });

            var resultado = ScriptInfo.ToString();
            resultado += "\n\n" + AegisubProjectGarbage.ToString();
            resultado += "\n\n" + _Styles;
            resultado += "\n\n" + _Graphics;
            resultado += "\n\n" + _Fonts;
            resultado += "\n\n" + _Events;
            resultado += "\n";

            return resultado;
        }
    }
}
