namespace Asu.Utilidades.Constantes {
    /// <summary>
    /// Expresiones regulares para filtrar el formato ASS.
    /// </summary>
    public static class ExpresionesRegulares {
        /// <summary>
        /// Expresión regular para capturar las sílabas de un texto en romaji.
        /// Se recupera la captura con "sil".
        /// </summary>
        public static string regexRomaji {
            get {
                return @"(?<sil>(?:sha|shi|shu|she|sho|cha|chi|chu|che|cho|tsu|kya|kyi|kyu|kye|kyo|gya|gyi|gyu|gye|gyo|sya|syu|syi|sye|syo|zya|zyu|zyi|zye|zyo|jya|jyu|jyi|jye|jyo|tya|tyi|tyu|tye|tyo|dya|dyi|dyu|dye|dyo|nya|nyi|nyu|nye|nyo|hya|hyi|hyu|hye|hyo|fya|fyi|fyu|fye|fyo|bya|byi|byu|bye|byo|pya|pyi|pyu|pye|pyo|mya|myi|myu|mye|myo|rya|ryi|ryu|rye|ryo|vya|vyi|vyu|vye|vyo|ka|ki|ku|ke|ko|ga|gi|gu|ge|go|sa|su|si|se|so|za|zu|zi|ze|zo|ja|ju|ji|je|jo|ta|ti|tu|te|to|da|di|du|de|do|na|ni|nu|ne|no|ha|hi|hu|he|ho|fa|fi|fu|fe|fo|ba|bi|bu|be|bo|pa|pi|pu|pe|po|ma|mi|mu|me|mo|ya|yi|yu|ye|yo|ra|ri|ru|re|ro|wa|wo|va|vi|vu|ve|vo|a|i|u|e|o|n|t)[^a-zA-Z\d\s:]*\s?)";
            }
        }

        /// <summary>
        /// Expresión regular para capturar los colores en hexadecimal.
        /// Se recupera la captura con "blue", "green" o "red".
        /// </summary>
        public static string regexColor {
            get {
                return @"(?:&H)?(?<blue>[A-F,a-f,0-9]{1,2})(?<green>[A-F,a-f,0-9]{1,2})?(?<red>[A-F,a-f,0-9]{1,2})?&?";
            }
        }

        /// <summary>
        /// Expresión regular para capturar los tiempos en formato h:mm:ss:cs.
        /// Se recupera la captura con "h", "m" o "s".
        /// </summary>
        public static string regexTiempo {
            get {
                // Regex para limitar al máximo: 9:59:59:99.
                //return @"(?<h>[0-9]):(?<m>[0-5][0-9]?):(?<s>[0-5][0-9](?:\.[0-9]{1,2})?)";

                // Regex para permitir excesos, que se ajustan en la clase Tiempo.
                return @"(?<h>\d+):(?<m>[0-9]{1,2}?):(?<s>[0-9]{1,2}(?:\.[0-9]{1,2})?)";
            }
        }

        /// <summary>
        /// Expresión regular para capturar los valores de un argumento alpha.
        /// Se recupera la captura con "arg".
        /// </summary>
        public static string regexAlpha {
            get {
                return "(?:&H)?(?<arg>[A-F,a-f,0-9]{1,2})&?";
            }
        }

        /// <summary>
        /// Expresión regular para capturar las propiedades de un archivo ASS.
        /// Se recupera la captura con "tipo", "capa", "inicio", "fin", "estilo", "actor", "margenI", "margenD", "margenV", "efecto" o "contenido".
        /// </summary>
        public static string regexPropiedades {
            get {
                return @"(?<tipo>(?:Dialogue|Comment)): (?<capa>\d),(?<inicio>\d*:\d{2}:\d{2}\.\d{2}),(?<fin>\d:\d{2}:\d{2}\.\d{2}),(?<estilo>[^,]*),(?<actor>[^,]*),(?<margenI>\d*),(?<margenD>\d*),(?<margenV>\d*),(?<efecto>[^,]*),(?<contenido>.*)";
            }
        }

        /// <summary>
        /// Expresión regular para capturar grupos de la forma {grupo} y texto fuera de éstos.
        /// Se recupera la captura con "grupo" o "texto".
        /// </summary>
        public static string regexGrupos {
            get {
                return @"(?<grupo>{[^{}]*})|(?<texto>[^{}]*)";
            }
        }
        
        /// <summary>
        /// Expresión regular para el tag "i", de cursiva.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagI {
            get {
                return @"(?<tag>\\i\s*(?<arg>[0-1]))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "b", de negrita.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagB {
            get {
                return @"(?<tag>\\b\s*(?<arg>[0-1]))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "u", de subrayado.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagU {
            get {
                return @"(?<tag>\\u\s*(?<arg>[0-1]))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "s", de tachado.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagS {
            get {
                return @"(?<tag>\\s\s*(?<arg>[0-1]))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "bord", de borde.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagBord {
            get {
                return @"(?<tag>\\bord\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "xbord", de borde en el eje x.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagBordX {
            get {
                return @"(?<tag>\\xbord\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "ybord", de borde en el eje y.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagBordY {
            get {
                return @"(?<tag>\\ybord\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "shad", de sombra.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagShad {
            get {
                return @"(?<tag>\\shad\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "xshad", de sombra en el eje x.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagShadX {
            get {
                return @"(?<tag>\\xshad\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "yshad", de sombra en el eje y.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagShadY {
            get {
                return @"(?<tag>\\yshad\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fsp", de espaciado.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagFsp {
            get {
                return @"(?<tag>\\fsp\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "frx", de rotación en el eje x.
        /// </summary>
        public static string regexTagFrx {
            get {
                return @"(?<tag>\\frx\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fry", de rotación en el eje y.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagFry {
            get {
                return @"(?<tag>\\fry\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "frz" o "fr", de rotación en el eje z.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagFrz {
            get {
                return @"(?<tag>\\(?:fr|frz)\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fax", de factor de distorsión en el eje x.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagFax {
            get {
                return @"(?<tag>\\fax\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fay", de factor de distorsión en el eje y.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagFay {
            get {
                return @"(?<tag>\\fay\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "k", de tiempo de karaoke.
        /// No confundir con "K", en mayúscula, que corresponde a "kf".
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagK {
            get {
                return @"(?<tag>\\k\s*(?<arg>-?\d+))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "kf" o "K", de tiempo de karaoke con efecto paulatino.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagKf {
            get {
                return @"(?<tag>\\(?:kf|K)\s*(?<arg>-?\d+))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "ko", de tiempo de karaoke con remoción de borde y sombra.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagKo {
            get {
                return @"(?<tag>\\ko\s*(?<arg>-?\d+))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "be", de difuminado de bordes.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagBe {
            get {
                return @"(?<tag>\\be\s*(?<arg>\d+))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "blur", de difuminado de bordes avanzado.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagBlur {
            get {
                return @"(?<tag>\\blur\s*(?<arg>\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fn", de fuente.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagFn {
            get {
                return @"(?<tag>\\fn(?<arg>.*))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fs", de tamaño de fuente.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagFs {
            get {
                return @"(?<tag>\\fs\s*(?<arg>\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fscx", de escala en el eje x.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagFscx {
            get {
                return @"(?<tag>\\fscx\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fscy", de escala en el eje y.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagFscy {
            get {
                return @"(?<tag>\\fscy\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fe", de codificación de fuente.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagFe {
            get {
                return @"(?<tag>\\fe(?<arg>(?:.*\(.*\))*[^\\]*))";
            }
        }

        /// <summary>
        /// Expresión regular para los tags de la forma \-TAG, destinados a grupos de karaoke.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagFx {
            get {
                return @"(?<tag>\\-(?<arg>(?:.*\(.*\))*[^\\]*))";
                //return @"(?<tag>\\-\s*(?<arg>\w+))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "1c", de color primario.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string regexTagColor1 {
            get {
                return @"(?<tag>\\(?:c|1c)\s*(?<arg>(?:&H)?[A-F,a-f,0-9]{1,6}&?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "2c", de color secundario.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string regexTagColor2 {
            get {
                return @"(?<tag>\\2c\s*(?<arg>(?:&H)?[A-F,a-f,0-9]{1,6}&?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "3c", de color de borde.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string regexTagColor3 {
            get {
                return @"(?<tag>\\3c\s*(?<arg>(?:&H)?[A-F,a-f,0-9]{1,6}&?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "4c", de color de sombra.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string regexTagColor4 {
            get {
                return @"(?<tag>\\4c\s*(?<arg>(?:&H)?[A-F,a-f,0-9]{1,6}&?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "alpha", de canal alfa total.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string regexTagAlpha {
            get {
                return @"(?<tag>\\alpha\s*(?:&H)?(?<arg>[A-F,a-f,0-9]{1,2})&?)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "1a", de canal alfa primario.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string regexTagAlpha1 {
            get {
                return @"(?<tag>\\1a\s*(?:&H)?(?<arg>[A-F,a-f,0-9]{1,2})&?)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "2a", de canal alfa secundario.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string regexTagAlpha2 {
            get {
                return @"(?<tag>\\2a\s*(?:&H)?(?<arg>[A-F,a-f,0-9]{1,2})&?)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "3a", de canal alfa de borde.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string regexTagAlpha3 {
            get {
                return @"(?<tag>\\3a\s*(?:&H)?(?<arg>[A-F,a-f,0-9]{1,2})&?)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "4a", de canal alfa de sombra.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string regexTagAlpha4 {
            get {
                return @"(?<tag>\\4a\s*(?:&H)?(?<arg>[A-F,a-f,0-9]{1,2})&?)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "a", de alineación, versión SSA.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagA {
            get {
                return @"(?<tag>\\a\s*(?<arg>[1-9]1?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "an", de alineación, versión ASS.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagAn {
            get {
                return @"(?<tag>\\an\s*(?<arg>[1-9]))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "q", de estilo de ajuste.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagQ {
            get {
                return @"(?<tag>\\q\s*(?<arg>[0-3]))";
            }
        }
        
        /// <summary>
        /// Expresión regular para el tag "r", de reinicio de estilo.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagR {
            get {
                return @"(?<tag>\\r(?<arg>(?:.*\(.*\))*[^\\]*))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "pos", de posición.
        /// Se recupera la captura con "tag" o "arg".
        /// Se recomienda filtrar el argumento con la expresión asociada a los argumentos de "pos".
        /// </summary>
        public static string regexTagPos {
            get {
                return @"(?<tag>\\pos\s*(?<arg>\(\s*-?\d+(?:\.\d+)?,\s*-?\d+(?:\.\d+)?\)))";
            }
        }

        /// <summary>
        /// Expresión regular para los argumentos del tag "pos".
        /// Se recupera la captura con "x" o "y".
        /// </summary>
        public static string regexArgsPos {
            get {
                return @"\((?<x>\s*-?\d+(?:\.\d+)?)(?:[^,])*,(?<y>\s*-?\d+(?:\.\d+)?)(?:[^,])*\)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "move", de movimiento.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagMove {
            get {
                return @"(?<tag>\\move\s*\((?<arg>\s*-?\d+(?:\.\d+)?,\s*-?\d+(?:\.\d+)?(?:,\s*-?\d+(?:\.\d+)?,\s*-?\d+(?:\.\d+)?){1,2})\))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "org", de origen.
        /// Se recupera la captura con "tag" o "arg".
        /// Se recomienda filtrar el argumento con la expresión asociada a los argumentos de "pos".
        /// </summary>
        public static string regexTagOrg {
            get {
                return @"(?<tag>\\org\s*(?<arg>\(\s*-?\d+(?:\.\d+)?,\s*-?\d+(?:\.\d+)?\)))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fade", de desvanecimiento avanzado.
        /// Se recupera la captura con "tag" o "arg".
        /// Se recomienda filtrar el argumento con la expresión asociada a los argumentos de "fade".
        /// </summary>
        public static string regexTagFade {
            get {
                return @"(?<tag>\\fade\s*(?<arg>\(\s*[0-9]{1,3}(?:[^,])*,\s*[0-9]{1,3}(?:[^,])*,\s*[0-9]{1,3}(?:[^,])*,\s*-?\d+(?:\.\d+)?(?:[^,])*,\s*-?\d+(?:\.\d+)?(?:[^,])*,\s*-?\d+(?:\.\d+)?(?:[^,])*,\s*-?\d+(?:\.\d+)?(?:[^,])*\)))";
            }
        }

        /// <summary>
        /// Expresión regular para los argumentos del tag "fade".
        /// Se recupera la captura con "alpha1", "alpha2", "alpha3", "t1", "t2", "t3" o "t4".
        /// </summary>
        public static string regexArgsFade {
            get {
                return @"\(\s*(?<alpha1>[0-9]{1,3})(?:[^,])*,\s*(?<alpha2>[0-9]{1,3})(?:[^,])*,\s*(?<alpha3>[0-9]{1,3})(?:[^,])*,\s*(?<t1>-?\d+)(?:[^,])*,\s*(?<t2>-?\d+)(?:[^,])*,\s*(?<t3>-?\d+)(?:[^,])*,\s*(?<t4>-?\d+)(?:[^,])*\)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fad", de desvanecimiento.
        /// Se recupera la captura con "tag" o "arg".
        /// Se recomienda filtrar el argumento con la expresión asociada a los argumentos de "fad".
        /// </summary>
        public static string regexTagFad {
            get {
                return @"(?<tag>\\fade?\s*(?<arg>\(\s*-?\d+(?:[^,])*,\s*-?\d+(?:[^,])*\)))";
            }
        }

        /// <summary>
        /// Expresión regular para los argumentos del tag "fad".
        /// Se recupera la captura con "t1" o "t2".
        /// </summary>
        public static string regexArgsFad {
            get {
                return @"\((?<t1>\s*-?\d+)(?:[^,])*,(?<t2>\s*-?\d+)(?:[^,])*\)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "t", de transformación.
        /// Se recupera la captura con "tag" o "arg".
        /// Se recomienda filtrar el argumento con la expresión asociada a los argumentos de "t".
        /// </summary>
        public static string regexTagT {
            get {
                // Gonxas:
                //return @"(?<tag>\\t\((?<arg>(?:[()]+?(?=\()\([()]*?(?=\))\))+[()]*?|[()]+?)\))";

                // Frost:
                //return @"\\t(?<arg>\((?:\s*(?:\d+,\s*\d+)?(?:,\d+(?:\.\d+)?)?,.*|.*)\))";

                // Frost v2:
                return @"(?<tag>\\t(?<arg>\((?:\s*(?:\d+,\s*\d+)?(?:,\d+(?:\.\d+)?)?,(?:.*\(.*\))*[^\(\)]*|(?:.*\(.*\))*[^\(\)]*)\)))";
            }
        }

        /// <summary>
        /// Expresión regular para los argumentos del tag "pos".
        /// Se recupera la captura con "t1", "t", "accel" o "arg".
        /// </summary>
        public static string regexArgsT {
            get {
                //return @"\((?:\s*(?:(?<t1>\d+),\s*(?<t2>\d+))?(?:,(?<accel>\d+(?:\.\d+)?))?,(?<arg>.*)|(?<arg>.*))\)";
                return @"\((?:\s*(?:(?<t1>\d+),\s*(?<t2>\d+))?(?:,(?<accel>\d+(?:\.\d+)?))?,(?<arg>(?:.*\(.*\))*[^\(\)]*)|(?<arg>(?:.*\(.*\))*[^\(\)]*))\)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "iclip", de corte vectorial.
        /// Se recupera la captura con "tag" o "arg".
        /// Se recomienda filtrar el argumento con la expresión asociada a los argumentos de "clip".
        /// </summary>
        public static string regexTagClipI {
            get {
                return @"(?<tag>\\iclip\s*(?<arg>\((?:(?:\s*\d+(?:[^,])*,)?\s*m (?:.*\(.*\))*[^\(\)]*|\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*)\)))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "clip", de corte rectangular.
        /// Se recupera la captura con "tag" o "arg".
        /// Se recomienda filtrar el argumento con la expresión asociada a los argumentos de "clip".
        /// </summary>
        public static string regexTagClip {
            get {
                return @"(?<tag>\\clip\s*(?<arg>\((?:(?:\s*\d+(?:[^,])*,)?\s*m (?:.*\(.*\))*[^\(\)]*|\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*)\)))";
            }
        }

        /// <summary>
        /// Expresión regular para los argumentos del tag "pos".
        /// Se recupera la captura con "escala", "comandos" o "arg".
        /// </summary>
        public static string regexArgsClip {
            get {
                return @"\((?:(?:\s*(?<escala>\d+)(?:[^,])*,)?\s*(?<comandos>m (?:.*\(.*\))*[^\(\)]*)|(?<arg>\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*))\)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "p", de escala de dibujo.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagP {
            get {
                return @"(?<tag>\\p\s*(?<arg>\d+))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "pbo", de ajuste en dibujo.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string regexTagPbo {
            get {
                return @"(?<tag>\\pbo\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para los estilos en sección [V4+ Styles] de un archivo ASS.
        /// Se recupera cada elemento con "fontName", "fontSize", "color1", "color2", "color3", "alpha1", "alpha2", "alpha3", "alpha4", "color4", "bold", "italic", "underline", "strikeout", "scaleX", "scaleY", "spacing", "angle", "borderStyle", "outline", "shadow", "alignment", "marginL", "marginR", "marginV" o "encoding".
        /// </summary>
        public static string regexStyle {
            get {
                return @"(?<name>.*)\s*,\s*(?<fontName>.*)\s*,\s*(?<fontSize>\d+)\s*,\s*&H(?<alpha1>[A-Fa-f0-9]{2})(?<color1>[A-Fa-f0-9]{6})\s*,\s*&H(?<alpha2>[A-Fa-f0-9]{2})(?<color2>[A-Fa-f0-9]{6})\s*,\s*&H(?<alpha3>[A-Fa-f0-9]{2})(?<color3>[A-Fa-f0-9]{6})\s*,\s*&H(?<alpha4>[A-Fa-f0-9]{2})(?<color4>[A-Fa-f0-9]{6})\s*,\s*(?<bold>0|-1)\s*,\s*(?<italic>0|-1)\s*,\s*(?<underline>0|-1)\s*,\s*(?<strikeout>0|-1)\s*,\s*(?<scaleX>\d+)\s*,\s*(?<scaleY>\d+)\s*,\s*(?<spacing>\d+)\s*,\s*(?<angle>\d+)\s*,\s*(?<borderStyle>1|3)\s*,\s*(?<outline>\d+)\s*,\s*(?<shadow>\d+)\s*,\s*(?<alignment>[1-9])\s*,\s*(?<marginL>\d+)\s*,\s*(?<marginR>\d+)\s*,\s*(?<marginV>\d+)\s*,\s*(?<encoding>\d+)";
            }
        }
    }
}