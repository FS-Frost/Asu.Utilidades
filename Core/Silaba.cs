using Asu.Utils.Constants;

namespace Asu.Utils.Core {
    /// <summary>
    /// Representa una sílaba de una línea en formato ASS.
    /// </summary>
    public class Silaba {
        /// <summary>
        /// Obtiene o establece el grupo de tags de la sílaba.
        /// </summary>
        public TagGroup GrupoTag { get; set; }

        /// <summary>
        /// Obtiene o establece el texto de la sílaba.
        /// </summary>
        public string Texto { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de karaoke de la sílaba.
        /// </summary>
        public KaraokeType Tipo {
            get {
                if (GrupoTag.TagKf != null) {
                    return KaraokeType.Kf;
                } else if (GrupoTag.TagK != null) {
                    return KaraokeType.K;
                } else if (GrupoTag.TagKo != null) {
                    return KaraokeType.Ko;
                } else {
                    throw new System.InvalidOperationException("No hay un tag de karaoke definido.");
                }
            }

            set {
                switch (value) {
                    case KaraokeType.K:
                        GrupoTag.TagK = new TagK(Duracion);
                        GrupoTag.TagKf = null;
                        GrupoTag.TagKo = null;
                        break;
                    case KaraokeType.Kf:
                        GrupoTag.TagKf = new TagKf(Duracion);
                        GrupoTag.TagK = null;
                        GrupoTag.TagKo = null;
                        break;
                    case KaraokeType.Ko:
                        GrupoTag.TagKo = new TagKo(Duracion);
                        GrupoTag.TagK = null;
                        GrupoTag.TagKf = null;
                        break;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la duración de la sílaba en centésimas de segundo.
        /// </summary>
        public int Duracion {
            get {
                if (GrupoTag.TagKf != null) {
                    return GrupoTag.TagKf.Argument;
                } else if (GrupoTag.TagK != null) {
                    return GrupoTag.TagK.Argument;
                } else if (GrupoTag.TagKo != null) {
                    return GrupoTag.TagKo.Argument;
                } else {
                    throw new System.InvalidOperationException("No hay un tag de karaoke definido.");
                }
            }
            set {
                if (GrupoTag.TagKf != null) {
                    GrupoTag.TagKf.Argument = value;
                } else if (GrupoTag.TagK != null) {
                    GrupoTag.TagK.Argument = value;
                } else if (GrupoTag.TagKo != null) {
                    GrupoTag.TagKo.Argument = value;
                } else {
                    throw new System.NullReferenceException("No hay un tag de karaoke definido.");
                }
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Silaba"/>.
        /// </summary>
        public Silaba() {
            GrupoTag = new TagGroup();
            Texto = "";
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Silaba"/> en base a la duración, texto y tipo de karaoke indicados.
        /// </summary>
        /// <param name="duracion">Duración de la sílaba.</param>
        /// <param name="texto">Texto de la sílaba.</param>
        /// <param name="tipoKaraoke">Tipo de karaoke de la sílaba.</param>
        public Silaba(int duracion, string texto, KaraokeType tipoKaraoke) {
            Texto = texto;
            GrupoTag = new TagGroup();

            switch (tipoKaraoke) {
                case KaraokeType.K:
                    GrupoTag.TagK = new TagK(duracion);
                    break;
                case KaraokeType.Kf:
                    GrupoTag.TagKf = new TagKf(duracion);
                    break;
                case KaraokeType.Ko:
                    GrupoTag.TagKo = new TagKo(duracion);
                    break;
            }

            Duracion = duracion;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Silaba"/> en base a la duración, texto, tipo de karaoke y grupo de tags indicados.
        /// </summary>
        /// <param name="duracion">Duración de la sílaba.</param>
        /// <param name="texto">Texto de la sílaba.</param>
        /// <param name="tipoKaraoke">Tipo de karaoke de la sílaba.</param>
        /// <param name="grupoTag">Grupo de tags de la sílaba.</param>
        public Silaba(int tiempo, string texto, KaraokeType tipoKaraoke, TagGroup grupoTag) {
            var sil = new Silaba() {
                Duracion = tiempo,
                Texto = texto,
                GrupoTag = grupoTag
            };

            switch (tipoKaraoke) {
                case KaraokeType.K:
                    sil.GrupoTag.TagK = new TagK(tiempo);
                    break;
                case KaraokeType.Kf:
                    sil.GrupoTag.TagKf = new TagKf(tiempo);
                    break;
                case KaraokeType.Ko:
                    sil.GrupoTag.TagKo = new TagKo(tiempo);
                    break;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Silaba"/>, copiando las propiedades de otra instancia.
        /// </summary>
        /// <param name="silaba">Silaba a copiar.</param>
        public Silaba(Silaba silaba) {
            GrupoTag = silaba.GrupoTag;
            Texto = silaba.Texto;
            Tipo = silaba.Tipo;
        }

        /// <summary>
        /// Devuelve una cadena de la forma: {comentario\tag1\tag2\...\tagN}Texto.
        /// </summary>
        public override string ToString() {
            return "{" + GrupoTag + "}" + Texto;
        }

        public static Silaba operator +(Silaba s1, Silaba s2) {
            var s3 = s1;
            s3.Duracion += s2.Duracion;
            return s3;
        }

        public static Silaba operator -(Silaba s1, Silaba s2) {
            var s3 = s1;
            s3.Duracion -= s2.Duracion;
            return s3;
        }
    }
}
