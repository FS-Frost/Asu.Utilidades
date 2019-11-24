using Asu.Utils.Constants;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa una sílaba de una línea en formato ASS.
    /// </summary>
    public class Syllabe {
        /// <summary>
        /// Obtiene o establece el grupo de tags de la sílaba.
        /// </summary>
        public TagGroup TagGroup { get; set; }

        /// <summary>
        /// Obtiene o establece el texto de la sílaba.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de karaoke de la sílaba.
        /// </summary>
        public KaraokeType Type {
            get {
                if (TagGroup.TagKf != null) {
                    return KaraokeType.Kf;
                } else if (TagGroup.TagK != null) {
                    return KaraokeType.K;
                } else if (TagGroup.TagKo != null) {
                    return KaraokeType.Ko;
                } else {
                    throw new System.InvalidOperationException("No hay un tag de karaoke definido.");
                }
            }

            set {
                switch (value) {
                    case KaraokeType.K:
                        TagGroup.TagK = new TagK(Length);
                        TagGroup.TagKf = null;
                        TagGroup.TagKo = null;
                        break;
                    case KaraokeType.Kf:
                        TagGroup.TagKf = new TagKf(Length);
                        TagGroup.TagK = null;
                        TagGroup.TagKo = null;
                        break;
                    case KaraokeType.Ko:
                        TagGroup.TagKo = new TagKo(Length);
                        TagGroup.TagK = null;
                        TagGroup.TagKf = null;
                        break;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la duración de la sílaba en centésimas de segundo.
        /// </summary>
        public int Length {
            get {
                if (TagGroup.TagKf != null) {
                    return TagGroup.TagKf.Argument;
                } else if (TagGroup.TagK != null) {
                    return TagGroup.TagK.Argument;
                } else if (TagGroup.TagKo != null) {
                    return TagGroup.TagKo.Argument;
                } else {
                    throw new System.InvalidOperationException("No hay un tag de karaoke definido.");
                }
            }
            set {
                if (TagGroup.TagKf != null) {
                    TagGroup.TagKf.Argument = value;
                } else if (TagGroup.TagK != null) {
                    TagGroup.TagK.Argument = value;
                } else if (TagGroup.TagKo != null) {
                    TagGroup.TagKo.Argument = value;
                } else {
                    throw new System.NullReferenceException("No hay un tag de karaoke definido.");
                }
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Syllabe"/>.
        /// </summary>
        public Syllabe() {
            TagGroup = new TagGroup();
            Text = "";
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Syllabe"/> en base a la duración, texto y tipo de karaoke indicados.
        /// </summary>
        /// <param name="duracion">Duración de la sílaba.</param>
        /// <param name="texto">Texto de la sílaba.</param>
        /// <param name="tipoKaraoke">Tipo de karaoke de la sílaba.</param>
        public Syllabe(int duracion, string texto, KaraokeType tipoKaraoke) {
            Text = texto;
            TagGroup = new TagGroup();

            switch (tipoKaraoke) {
                case KaraokeType.K:
                    TagGroup.TagK = new TagK(duracion);
                    break;
                case KaraokeType.Kf:
                    TagGroup.TagKf = new TagKf(duracion);
                    break;
                case KaraokeType.Ko:
                    TagGroup.TagKo = new TagKo(duracion);
                    break;
            }

            Length = duracion;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Syllabe"/> en base a la duración, texto, tipo de karaoke y grupo de tags indicados.
        /// </summary>
        /// <param name="duracion">Duración de la sílaba.</param>
        /// <param name="texto">Texto de la sílaba.</param>
        /// <param name="tipoKaraoke">Tipo de karaoke de la sílaba.</param>
        /// <param name="grupoTag">Grupo de tags de la sílaba.</param>
        public Syllabe(int tiempo, string texto, KaraokeType tipoKaraoke, TagGroup grupoTag) {
            var sil = new Syllabe() {
                Length = tiempo,
                Text = texto,
                TagGroup = grupoTag
            };

            switch (tipoKaraoke) {
                case KaraokeType.K:
                    sil.TagGroup.TagK = new TagK(tiempo);
                    break;
                case KaraokeType.Kf:
                    sil.TagGroup.TagKf = new TagKf(tiempo);
                    break;
                case KaraokeType.Ko:
                    sil.TagGroup.TagKo = new TagKo(tiempo);
                    break;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Syllabe"/>, copiando las propiedades de otra instancia.
        /// </summary>
        /// <param name="silaba">Silaba a copiar.</param>
        public Syllabe(Syllabe silaba) {
            TagGroup = silaba.TagGroup;
            Text = silaba.Text;
            Type = silaba.Type;
        }

        /// <summary>
        /// Devuelve una cadena de la forma: {comentario\tag1\tag2\...\tagN}Texto.
        /// </summary>
        public override string ToString() {
            return "{" + TagGroup + "}" + Text;
        }

        public static Syllabe operator +(Syllabe s1, Syllabe s2) {
            var s3 = s1;
            s3.Length += s2.Length;
            return s3;
        }

        public static Syllabe operator -(Syllabe s1, Syllabe s2) {
            var s3 = s1;
            s3.Length -= s2.Length;
            return s3;
        }
    }
}
