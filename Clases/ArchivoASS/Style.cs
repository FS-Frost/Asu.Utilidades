using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases.ArchivoASS {
    /// <summary>
    /// Representa un estilo de línea en formato ASS.
    /// </summary>
    public class Style {
        #region Propiedades
        /// <summary>
        /// Obtiene o establece el nombre del estilo.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la fuente del estilo.
        /// </summary>
        public string FontName { get; set; }

        /// <summary>
        /// Obtiene o establece el tamaño de la fuente con presición de dos decimales.
        /// </summary>
        public double FontSize { get; set; }

        /// <summary>
        /// Obtiene o establece el color primario del estilo.
        /// </summary>
        public TagTypeColor PrimaryColour { get; set; }

        /// <summary>
        /// Obtiene o establece el color secundario del estilo, que se aplica con karaokes de tipo kf.
        /// </summary>
        public TagTypeColor SecondaryColour { get; set; }

        /// <summary>
        /// Obtiene o establece el color de bordes del estilo.
        /// </summary>
        public TagTypeColor OutlineColour { get; set; }

        /// <summary>
        /// Obtiene o establece el color de sombra del estilo.
        /// </summary>
        public TagTypeColor BackColour { get; set; }

        /// <summary>
        /// Obtiene o establece el valor alfa primario del estilo.
        /// </summary>
        public int PrimaryAlpha { get; set; }

        /// <summary>
        /// Obtiene o establece el valor alfa secundario del estilo.
        /// </summary>
        public int SecondaryAlpha { get; set; }

        /// <summary>
        /// Obtiene o establece el valor alfa de bordes del estilo.
        /// </summary>
        public int OutlineAlpha { get; set; }

        /// <summary>
        /// Obtiene o establece el  el valor alfa de sombra del estilo.
        /// </summary>
        public int BackAlpha { get; set; }

        /// <summary>
        /// Indica si el estilo está en negrita.
        /// </summary>
        public bool Bold { get; set; }

        /// <summary>
        /// Indica si el estilo está en cursiva.
        /// </summary>
        public bool Italic { get; set; }

        /// <summary>
        /// Indica si el estilo está subrayado.
        /// </summary>
        public bool Underline { get; set; }

        /// <summary>
        /// Indica si el estilo está tachado.
        /// </summary>
        public bool StrikeOut { get; set; }

        /// <summary>
        /// Obtiene o establece la escala porcentual de la fuente en el eje X.
        /// </summary>
        public double ScaleX { get; set; }

        /// <summary>
        /// Obtiene o establece la escala porcentual de la fuente en el eje Y.
        /// </summary>
        public double ScaleY { get; set; }

        /// <summary>
        /// Obtiene o establece el espaciado de la fuente.
        /// </summary>
        public int Spacing { get; set; }

        /// <summary>
        /// Obtiene o establece el ángulo de inclinación de la fuente.
        /// </summary>
        public int Angle { get; set; }

        /// <summary>
        /// Indica si se utiliza caja opaca sobre el estilo.
        /// </summary>
        public bool BorderStyle { get; set; }

        /// <summary>
        /// Obtiene o establece el tamaño del borde con presición de dos decimales.
        /// </summary>
        public double Outline { get; set; }

        /// <summary>
        /// Obtiene o establece el tamaño de la sombra con presición de dos decimales.
        /// </summary>
        public double Shadow { get; set; }

        /// <summary>
        /// Obtiene o establece la alineación del estilo.
        /// </summary>
        public Alineaciones Alignment { get; set; }

        /// <summary>
        /// Obtiene o establece el margen izquierdo del estilo.
        /// </summary>
        public int MarginL { get; set; }

        /// <summary>
        /// Obtiene o establece el margen derecho del estilo.
        /// </summary>
        public int MarginR { get; set; }

        /// <summary>
        /// Obtiene o establece el margen vertical del estilo.
        /// </summary>
        public int MarginV { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de codificación de la fuente.
        /// </summary>
        public Codificaciones Encoding { get; set; }
        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Style"/>.
        /// </summary>
        public Style() {
            Name = "Default";
            FontName = "Arial";
            FontSize = 20;
            PrimaryColour = new TagTypeColor("&HFFFFFF&");
            SecondaryColour = new TagTypeColor("&H0000FF&");
            OutlineColour = new TagTypeColor("&H000000&");
            BackColour = new TagTypeColor("&H000000&");
            PrimaryAlpha = 0;
            SecondaryAlpha = 0;
            OutlineAlpha = 0;
            BackAlpha = 0;
            Bold = false;
            Italic = false;
            Underline = false;
            StrikeOut = false;
            ScaleX = 100;
            ScaleY = 100;
            Spacing = 0;
            Angle = 0;
            BorderStyle = false;
            Outline = 2;
            Shadow = 0;
            Alignment = Alineaciones.CentroCentro;
            MarginL = 10;
            MarginR = 10;
            MarginV = 10;
            Encoding = Codificaciones.Predeterminado;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Style"/> con una cadena como base.
        /// </summary>
        /// <param name="texto">Texto conteniendo el estilo.</param>
        public Style(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexStyle);
            var match = regex.Match(texto);

            if (match.Success) {
                Name = match.Groups["name"].Value;
                FontName = match.Groups["fontName"].Value;
                FontSize = double.Parse(match.Groups["fontSize"].Value);
                PrimaryColour = new TagTypeColor(match.Groups["color1"].Value);
                SecondaryColour = new TagTypeColor(match.Groups["color2"].Value);
                OutlineColour = new TagTypeColor(match.Groups["color3"].Value);
                BackColour = new TagTypeColor(match.Groups["color4"].Value);
                PrimaryAlpha = Maths.HexToInt(match.Groups["alpha1"].Value);
                SecondaryAlpha = Maths.HexToInt(match.Groups["alpha2"].Value);
                OutlineAlpha = Maths.HexToInt(match.Groups["alpha3"].Value);
                BackAlpha = Maths.HexToInt(match.Groups["alpha4"].Value);

                Bold = false;
                if (match.Groups["bold"].Value == "-1") {
                    Bold = true;
                }

                Italic = false;
                if (match.Groups["italic"].Value == "-1") {
                    Italic = true;
                }

                Underline = false;
                if (match.Groups["underline"].Value == "-1") {
                    Underline = true;
                }

                StrikeOut = false;
                if (match.Groups["strikeout"].Value == "-1") {
                    StrikeOut = true;
                }

                Bold = false;
                if (match.Groups["bold"].Value == "-1") {
                    Bold = true;
                }

                ScaleX = double.Parse(match.Groups["scaleX"].Value);
                ScaleY = double.Parse(match.Groups["scaleX"].Value);
                Spacing = int.Parse(match.Groups["spacing"].Value);
                Angle = int.Parse(match.Groups["angle"].Value);

                BorderStyle = false;
                if (match.Groups["borderStyle"].Value == "3") {
                    StrikeOut = true;
                }

                Outline = double.Parse(match.Groups["outline"].Value);
                Shadow = double.Parse(match.Groups["shadow"].Value);
                Alignment = AlineacionesInfo.StringToAlineacion(match.Groups["alignment"].Value);
                MarginL = int.Parse(match.Groups["marginL"].Value);
                MarginR = int.Parse(match.Groups["marginR"].Value);
                MarginV = int.Parse(match.Groups["marginV"].Value);
                Encoding = CodificacionesInfo.StringToCodificacion(match.Groups["encoding"].Value);
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Style"/>, copiando las propiedades de otra instancia.
        /// </summary>
        /// <param name="style">Estilo a copiar.</param>
        public Style(Style style) {
            Name = style.Name;
            FontName = style.FontName;
            FontSize = style.FontSize;
            PrimaryColour = style.PrimaryColour;
            SecondaryColour = style.SecondaryColour;
            OutlineColour = style.OutlineColour;
            BackColour = style.BackColour;
            PrimaryAlpha = style.PrimaryAlpha;
            SecondaryAlpha = style.SecondaryAlpha;
            OutlineAlpha = style.OutlineAlpha;
            BackAlpha = style.BackAlpha;
            Bold = style.Bold;
            Italic = style.Italic;
            Underline = style.Underline;
            StrikeOut = style.StrikeOut;
            ScaleX = style.ScaleX;
            ScaleY = style.ScaleY;
            Spacing = style.Spacing;
            Angle = style.Angle;
            BorderStyle = style.BorderStyle;
            Outline = style.Outline;
            Shadow = style.Shadow;
            Alignment = style.Alignment;
            MarginL = style.MarginL;
            MarginR = style.MarginR;
            MarginV = style.MarginV;
            Encoding = style.Encoding;
        }

        /// <summary>
        /// Devuelve una cadena con el estilo preparado para un script ASS: "Style: Default,Arial,20...".
        /// </summary>
        public override string ToString() {
            var _Bold = 0;
            var _Italic = 0;
            var _Underline = 0;
            var _StrikeOut = 0;
            var _BorderStyle = 1;
            var _Alignment = 5;
            var _Encoding = 1;
            var _Color1 = "";
            var _Color2 = "";
            var _Color3 = "";
            var _Color4 = "";

            if (Bold) {
                _Bold = -1;
            }
            
            if (Italic) {
                _Italic = -1;
            }
            
            if (Underline) {
                _Underline = -1;
            }
            
            if (StrikeOut) {
                _StrikeOut = -1;
            }
            
            if (BorderStyle) {
                _BorderStyle = 3;
            }

            _Alignment = AlineacionesInfo.AlineacionToInt(Alignment);
            _Encoding = (int) Encoding;
            
            _Color1 = string.Format("&H{0:00}{1:00}{2:00}{3:00}", 
                Maths.IntToHex(PrimaryAlpha), 
                Maths.IntToHex(PrimaryColour.Blue), 
                Maths.IntToHex(PrimaryColour.Green), 
                Maths.IntToHex(PrimaryColour.Red));

            _Color2 = string.Format("&H{0:00}{1:00}{2:00}{3:00}", 
                Maths.IntToHex(SecondaryAlpha), 
                Maths.IntToHex(SecondaryColour.Blue), 
                Maths.IntToHex(SecondaryColour.Green), 
                Maths.IntToHex(SecondaryColour.Red));

            _Color3 = string.Format("&H{0:00}{1:00}{2:00}{3:00}", 
                Maths.IntToHex(OutlineAlpha), 
                Maths.IntToHex(OutlineColour.Blue), 
                Maths.IntToHex(OutlineColour.Green), 
                Maths.IntToHex(OutlineColour.Red));

            _Color4 = string.Format("&H{0:00}{1:00}{2:00}{3:00}", 
                Maths.IntToHex(BackAlpha), 
                Maths.IntToHex(BackColour.Blue), 
                Maths.IntToHex(BackColour.Green), 
                Maths.IntToHex(BackColour.Red));

            return string.Format("Style: {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22}", Name, FontName, FontSize, _Color1, _Color2, _Color3, _Color4, _Bold, _Italic, _Underline, _StrikeOut, ScaleX, ScaleY, Spacing, Angle, _BorderStyle, Outline, Shadow, _Alignment, MarginL, MarginR, MarginV, _Encoding);
        }
    }
}
