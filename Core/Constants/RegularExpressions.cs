namespace Asu.Utils.Constants {
    /// <summary>
    /// Expresiones regulares para filtrar el formato ASS.
    /// </summary>
    public static class RegularExpressions {
        /// <summary>
        /// Expresión regular para capturar las sílabas de un texto en romaji.
        /// Se recupera la captura con "sil".
        /// </summary>
        public static string RegexRomaji {
            get {
                return @"(?<sil>(?:sha|shi|shu|she|sho|cha|chi|chu|che|cho|tsu|kya|kyi|kyu|kye|kyo|gya|gyi|gyu|gye|gyo|sya|syu|syi|sye|syo|zya|zyu|zyi|zye|zyo|jya|jyu|jyi|jye|jyo|tya|tyi|tyu|tye|tyo|dya|dyi|dyu|dye|dyo|nya|nyi|nyu|nye|nyo|hya|hyi|hyu|hye|hyo|fya|fyi|fyu|fye|fyo|bya|byi|byu|bye|byo|pya|pyi|pyu|pye|pyo|mya|myi|myu|mye|myo|rya|ryi|ryu|rye|ryo|vya|vyi|vyu|vye|vyo|ka|ki|ku|ke|ko|ga|gi|gu|ge|go|sa|su|si|se|so|za|zu|zi|ze|zo|ja|ju|ji|je|jo|ta|ti|tu|te|to|da|di|du|de|do|na|ni|nu|ne|no|ha|hi|hu|he|ho|fa|fi|fu|fe|fo|ba|bi|bu|be|bo|pa|pi|pu|pe|po|ma|mi|mu|me|mo|ya|yi|yu|ye|yo|ra|ri|ru|re|ro|wa|wo|va|vi|vu|ve|vo|a|i|u|e|o|n|t)[^a-zA-Z\d\s:]*\s?)";
            }
        }

        /// <summary>
        /// Expresión regular para capturar los colores en hexadecimal.
        /// Se recupera la captura con "blue", "green" o "red".
        /// </summary>
        public static string RegexColor {
            get {
                return @"(?:&H)?(?<blue>[A-F,a-f,0-9]{1,2})(?<green>[A-F,a-f,0-9]{1,2})?(?<red>[A-F,a-f,0-9]{1,2})?&?";
            }
        }

        /// <summary>
        /// Expresión regular para capturar los tiempos en formato h:mm:ss:cs.
        /// Se recupera la captura con "h", "m" o "s".
        /// </summary>
        public static string RegexTime {
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
        public static string RegexAlpha {
            get {
                return "(?:&H)?(?<arg>[A-F,a-f,0-9]{1,2})&?";
            }
        }

        /// <summary>
        /// Expresión regular para capturar las propiedades de un archivo ASS.
        /// Se recupera la captura con "tipo", "capa", "inicio", "fin", "estilo", "actor", "margenI", "margenD", "margenV", "efecto" o "contenido".
        /// </summary>
        public static string RegexProperties {
            get {
                return @"(?<tipo>(?:Dialogue|Comment)): (?<capa>\d),(?<inicio>\d*:\d{2}:\d{2}\.\d{2}),(?<fin>\d:\d{2}:\d{2}\.\d{2}),(?<estilo>[^,]*),(?<actor>[^,]*),(?<margenI>\d*),(?<margenD>\d*),(?<margenV>\d*),(?<efecto>[^,]*),(?<contenido>.*)";
            }
        }

        /// <summary>
        /// Expresión regular para capturar grupos de la forma {grupo} y texto fuera de éstos.
        /// Se recupera la captura con "grupo" o "texto".
        /// </summary>
        public static string RegexGroups {
            get {
                return @"(?<grupo>{[^{}]*})|(?<texto>[^{}]*)";
            }
        }
        
        /// <summary>
        /// Expresión regular para el tag "i", de cursiva.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagI {
            get {
                return @"(?<tag>\\i\s*(?<arg>[0-1]))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "b", de negrita.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagB {
            get {
                return @"(?<tag>\\b\s*(?<arg>[0-1]))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "u", de subrayado.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagU {
            get {
                return @"(?<tag>\\u\s*(?<arg>[0-1]))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "s", de tachado.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagS {
            get {
                return @"(?<tag>\\s\s*(?<arg>[0-1]))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "bord", de borde.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagBord {
            get {
                return @"(?<tag>\\bord\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "xbord", de borde en el eje x.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagBordX {
            get {
                return @"(?<tag>\\xbord\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "ybord", de borde en el eje y.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagBordY {
            get {
                return @"(?<tag>\\ybord\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "shad", de sombra.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagShad {
            get {
                return @"(?<tag>\\shad\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "xshad", de sombra en el eje x.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagShadX {
            get {
                return @"(?<tag>\\xshad\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "yshad", de sombra en el eje y.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagShadY {
            get {
                return @"(?<tag>\\yshad\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fsp", de espaciado.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagFsp {
            get {
                return @"(?<tag>\\fsp\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "frx", de rotación en el eje x.
        /// </summary>
        public static string RegexTagFrx {
            get {
                return @"(?<tag>\\frx\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fry", de rotación en el eje y.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagFry {
            get {
                return @"(?<tag>\\fry\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "frz" o "fr", de rotación en el eje z.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagFrz {
            get {
                return @"(?<tag>\\(?:fr|frz)\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fax", de factor de distorsión en el eje x.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagFax {
            get {
                return @"(?<tag>\\fax\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fay", de factor de distorsión en el eje y.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagFay {
            get {
                return @"(?<tag>\\fay\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "k", de tiempo de karaoke.
        /// No confundir con "K", en mayúscula, que corresponde a "kf".
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagK {
            get {
                return @"(?<tag>\\k\s*(?<arg>-?\d+))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "kf" o "K", de tiempo de karaoke con efecto paulatino.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagKf {
            get {
                return @"(?<tag>\\(?:kf|K)\s*(?<arg>-?\d+))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "ko", de tiempo de karaoke con remoción de borde y sombra.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagKo {
            get {
                return @"(?<tag>\\ko\s*(?<arg>-?\d+))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "be", de difuminado de bordes.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagBe {
            get {
                return @"(?<tag>\\be\s*(?<arg>\d+))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "blur", de difuminado de bordes avanzado.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagBlur {
            get {
                return @"(?<tag>\\blur\s*(?<arg>\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fn", de fuente.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagFn {
            get {
                return @"(?<tag>\\fn(?<arg>.*))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fs", de tamaño de fuente.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagFs {
            get {
                return @"(?<tag>\\fs\s*(?<arg>\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fscx", de escala en el eje x.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagFscx {
            get {
                return @"(?<tag>\\fscx\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fscy", de escala en el eje y.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagFscy {
            get {
                return @"(?<tag>\\fscy\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fe", de codificación de fuente.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagFe {
            get {
                return @"(?<tag>\\fe(?<arg>(?:.*\(.*\))*[^\\]*))";
            }
        }

        /// <summary>
        /// Expresión regular para los tags de la forma \-TAG, destinados a grupos de karaoke.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagFx {
            get {
                return @"(?<tag>\\-(?<arg>(?:.*\(.*\))*[^\\]*))";
                //return @"(?<tag>\\-\s*(?<arg>\w+))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "1c", de color primario.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string RegexTagColor1 {
            get {
                return @"(?<tag>\\(?:c|1c)\s*(?<arg>(?:&H)?[A-F,a-f,0-9]{1,6}&?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "2c", de color secundario.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string RegexTagColor2 {
            get {
                return @"(?<tag>\\2c\s*(?<arg>(?:&H)?[A-F,a-f,0-9]{1,6}&?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "3c", de color de borde.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string RegexTagColor3 {
            get {
                return @"(?<tag>\\3c\s*(?<arg>(?:&H)?[A-F,a-f,0-9]{1,6}&?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "4c", de color de sombra.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string RegexTagColor4 {
            get {
                return @"(?<tag>\\4c\s*(?<arg>(?:&H)?[A-F,a-f,0-9]{1,6}&?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "alpha", de canal alfa total.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string RegexTagAlpha {
            get {
                return @"(?<tag>\\alpha\s*(?:&H)?(?<arg>[A-F,a-f,0-9]{1,2})&?)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "1a", de canal alfa primario.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string RegexTagAlpha1 {
            get {
                return @"(?<tag>\\1a\s*(?:&H)?(?<arg>[A-F,a-f,0-9]{1,2})&?)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "2a", de canal alfa secundario.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string RegexTagAlpha2 {
            get {
                return @"(?<tag>\\2a\s*(?:&H)?(?<arg>[A-F,a-f,0-9]{1,2})&?)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "3a", de canal alfa de borde.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string RegexTagAlpha3 {
            get {
                return @"(?<tag>\\3a\s*(?:&H)?(?<arg>[A-F,a-f,0-9]{1,2})&?)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "4a", de canal alfa de sombra.
        /// Se recupera la captura con "tag" o "arg". Se recomienda filtrar el argumento con la expresión asociada.
        /// </summary>
        public static string RegexTagAlpha4 {
            get {
                return @"(?<tag>\\4a\s*(?:&H)?(?<arg>[A-F,a-f,0-9]{1,2})&?)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "a", de alineación, versión SSA.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagA {
            get {
                return @"(?<tag>\\a\s*(?<arg>[1-9]1?))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "an", de alineación, versión ASS.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagAn {
            get {
                return @"(?<tag>\\an\s*(?<arg>[1-9]))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "q", de estilo de ajuste.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagQ {
            get {
                return @"(?<tag>\\q\s*(?<arg>[0-3]))";
            }
        }
        
        /// <summary>
        /// Expresión regular para el tag "r", de reinicio de estilo.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagR {
            get {
                return @"(?<tag>\\r(?<arg>(?:.*\(.*\))*[^\\]*))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "pos", de posición.
        /// Se recupera la captura con "tag" o "arg".
        /// Se recomienda filtrar el argumento con la expresión asociada a los argumentos de "pos".
        /// </summary>
        public static string RegexTagPos {
            get {
                return @"(?<tag>\\pos\s*(?<arg>\(\s*-?\d+(?:\.\d+)?,\s*-?\d+(?:\.\d+)?\)))";
            }
        }

        /// <summary>
        /// Expresión regular para los argumentos del tag "pos".
        /// Se recupera la captura con "x" o "y".
        /// </summary>
        public static string RegexArgsPos {
            get {
                return @"\((?<x>\s*-?\d+(?:\.\d+)?)(?:[^,])*,(?<y>\s*-?\d+(?:\.\d+)?)(?:[^,])*\)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "move", de movimiento.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagMove {
            get {
                return @"(?<tag>\\move\s*\((?<arg>\s*-?\d+(?:\.\d+)?,\s*-?\d+(?:\.\d+)?(?:,\s*-?\d+(?:\.\d+)?,\s*-?\d+(?:\.\d+)?){1,2})\))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "org", de origen.
        /// Se recupera la captura con "tag" o "arg".
        /// Se recomienda filtrar el argumento con la expresión asociada a los argumentos de "pos".
        /// </summary>
        public static string RegexTagOrg {
            get {
                return @"(?<tag>\\org\s*(?<arg>\(\s*-?\d+(?:\.\d+)?,\s*-?\d+(?:\.\d+)?\)))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fade", de desvanecimiento avanzado.
        /// Se recupera la captura con "tag" o "arg".
        /// Se recomienda filtrar el argumento con la expresión asociada a los argumentos de "fade".
        /// </summary>
        public static string RegexTagFade {
            get {
                return @"(?<tag>\\fade\s*(?<arg>\(\s*[0-9]{1,3}(?:[^,])*,\s*[0-9]{1,3}(?:[^,])*,\s*[0-9]{1,3}(?:[^,])*,\s*-?\d+(?:\.\d+)?(?:[^,])*,\s*-?\d+(?:\.\d+)?(?:[^,])*,\s*-?\d+(?:\.\d+)?(?:[^,])*,\s*-?\d+(?:\.\d+)?(?:[^,])*\)))";
            }
        }

        /// <summary>
        /// Expresión regular para los argumentos del tag "fade".
        /// Se recupera la captura con "alpha1", "alpha2", "alpha3", "t1", "t2", "t3" o "t4".
        /// </summary>
        public static string RegexArgsFade {
            get {
                return @"\(\s*(?<alpha1>[0-9]{1,3})(?:[^,])*,\s*(?<alpha2>[0-9]{1,3})(?:[^,])*,\s*(?<alpha3>[0-9]{1,3})(?:[^,])*,\s*(?<t1>-?\d+)(?:[^,])*,\s*(?<t2>-?\d+)(?:[^,])*,\s*(?<t3>-?\d+)(?:[^,])*,\s*(?<t4>-?\d+)(?:[^,])*\)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "fad", de desvanecimiento.
        /// Se recupera la captura con "tag" o "arg".
        /// Se recomienda filtrar el argumento con la expresión asociada a los argumentos de "fad".
        /// </summary>
        public static string RegexTagFad {
            get {
                return @"(?<tag>\\fade?\s*(?<arg>\(\s*-?\d+(?:[^,])*,\s*-?\d+(?:[^,])*\)))";
            }
        }

        /// <summary>
        /// Expresión regular para los argumentos del tag "fad".
        /// Se recupera la captura con "t1" o "t2".
        /// </summary>
        public static string RegexArgsFad {
            get {
                return @"\((?<t1>\s*-?\d+)(?:[^,])*,(?<t2>\s*-?\d+)(?:[^,])*\)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "t", de transformación.
        /// Se recupera la captura con "tag" o "arg".
        /// Se recomienda filtrar el argumento con la expresión asociada a los argumentos de "t".
        /// </summary>
        public static string RegexTagT {
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
        public static string RegexArgsT {
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
        public static string RegexTagClipI {
            get {
                return @"(?<tag>\\iclip\s*(?<arg>\((?:(?:\s*\d+(?:[^,])*,)?\s*m (?:.*\(.*\))*[^\(\)]*|\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*)\)))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "clip", de corte rectangular.
        /// Se recupera la captura con "tag" o "arg".
        /// Se recomienda filtrar el argumento con la expresión asociada a los argumentos de "clip".
        /// </summary>
        public static string RegexTagClip {
            get {
                return @"(?<tag>\\clip\s*(?<arg>\((?:(?:\s*\d+(?:[^,])*,)?\s*m (?:.*\(.*\))*[^\(\)]*|\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*)\)))";
            }
        }

        /// <summary>
        /// Expresión regular para los argumentos del tag "pos".
        /// Se recupera la captura con "escala", "comandos" o "arg".
        /// </summary>
        public static string RegexArgsClip {
            get {
                return @"\((?:(?:\s*(?<escala>\d+)(?:[^,])*,)?\s*(?<comandos>m (?:.*\(.*\))*[^\(\)]*)|(?<arg>\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*,\s*-?\d+(?:\.\d+)?\s*))\)";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "p", de escala de dibujo.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagP {
            get {
                return @"(?<tag>\\p\s*(?<arg>\d+))";
            }
        }

        /// <summary>
        /// Expresión regular para el tag "pbo", de ajuste en dibujo.
        /// Se recupera la captura con "tag" o "arg".
        /// </summary>
        public static string RegexTagPbo {
            get {
                return @"(?<tag>\\pbo\s*(?<arg>-?\d+(?:\.\d+)?))";
            }
        }

        /// <summary>
        /// Expresión regular para los estilos en sección [V4+ Styles] de un archivo ASS.
        /// Se recupera cada elemento con "fontName", "fontSize", "color1", "color2", "color3", "alpha1", "alpha2", "alpha3", "alpha4", "color4", "bold", "italic", "underline", "strikeout", "scaleX", "scaleY", "spacing", "angle", "borderStyle", "outline", "shadow", "alignment", "marginL", "marginR", "marginV" o "encoding".
        /// </summary>
        public static string RegexStyle {
            get {
                return @"(?<name>.*)\s*,\s*(?<fontName>.*)\s*,\s*(?<fontSize>\d+(?:\.\d+)?)\s*,\s*&H(?<alpha1>[A-Fa-f0-9]{2})(?<color1>[A-Fa-f0-9]{6})\s*,\s*&H(?<alpha2>[A-Fa-f0-9]{2})(?<color2>[A-Fa-f0-9]{6})\s*,\s*&H(?<alpha3>[A-Fa-f0-9]{2})(?<color3>[A-Fa-f0-9]{6})\s*,\s*&H(?<alpha4>[A-Fa-f0-9]{2})(?<color4>[A-Fa-f0-9]{6})\s*,\s*(?<bold>0|-1)\s*,\s*(?<italic>0|-1)\s*,\s*(?<underline>0|-1)\s*,\s*(?<strikeout>0|-1)\s*,\s*(?<scaleX>\d+(?:\.\d+)?)\s*,\s*(?<scaleY>\d+(?:\.\d+)?)\s*,\s*(?<spacing>\d+(?:\.\d+)?)\s*,\s*(?<angle>\d+(?:\.\d+)?)\s*,\s*(?<borderStyle>1|3)\s*,\s*(?<outline>\d+(?:\.\d+)?)\s*,\s*(?<shadow>\d+(?:\.\d+)?)\s*,\s*(?<alignment>[1-9])\s*,\s*(?<marginL>\d+)\s*,\s*(?<marginR>\d+)\s*,\s*(?<marginV>\d+)\s*,\s*(?<encoding>\d+)";
            }
        }
    }
}