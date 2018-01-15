using Asu.Utilidades.Constantes;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un grupo de tags contenido entre llaves {}, incluyendo un texto como comentario.
    /// </summary>
    public class GrupoTag {
        #region Propiedades
        /// <summary>
        /// Comentario al inicio del grupo.
        /// </summary>
        public string Comentario { get; set; }

        /// <summary>
        /// Lista con los tags como cadenas.
        /// </summary>
        private List<string> Tags { get; set; }

        /// <summary>
        /// Tag de alineación (legado).
        /// </summary>
        public TagA TagA { get; set; }

        /// <summary>
        /// Tag de alpha total.
        /// </summary>
        public TagAlpha TagAlpha { get; set; }

        /// <summary>
        /// Tag de alpha primario.
        /// </summary>
        public TagAlpha1 TagAlpha1 { get; set; }

        /// <summary>
        /// Tag de alpha secundario.
        /// </summary>
        public TagAlpha2 TagAlpha2 { get; set; }

        /// <summary>
        /// Tag de alpha de bordes.
        /// </summary>
        public TagAlpha3 TagAlpha3 { get; set; }

        /// <summary>
        /// Tag de alpha de sombra.
        /// </summary>
        public TagAlpha4 TagAlpha4 { get; set; }

        /// <summary>
        /// Tag de alineación.
        /// </summary>
        public TagAn TagAn { get; set; }

        /// <summary>
        /// Tag de negrita.
        /// </summary>
        public TagB TagB { get; set; }

        /// <summary>
        /// Tag de difuminado de bordes.
        /// </summary>
        public TagBe TagBe { get; set; }

        /// <summary>
        /// Tag de difuminado de bordes con kernel gaussiano.
        /// </summary>
        public TagBlur TagBlur { get; set; }

        /// <summary>
        /// Tag de borde total.
        /// </summary>
        public TagBord TagBord { get; set; }

        /// <summary>
        /// Tag de bordes verticales.
        /// </summary>
        public TagBordX TagBordX { get; set; }

        /// <summary>
        /// Tag de bordes horizontales.
        /// </summary>
        public TagBordY TagBordY { get; set; }

        /// <summary>
        /// Tag de recorte.
        /// </summary>
        public TagClip TagClip { get; set; }

        /// <summary>
        /// Tag de recorte opuesto
        /// </summary>
        public TagClipI TagClipI { get; set; }

        /// <summary>
        /// Tag de color primario.
        /// </summary>
        public TagColor1 TagColor1 { get; set; }

        /// <summary>
        /// Tag de color secundario.
        /// </summary>
        public TagColor2 TagColor2 { get; set; }

        /// <summary>
        /// Tag de color de bordes.
        /// </summary>
        public TagColor3 TagColor3 { get; set; }

        /// <summary>
        /// Tag de color de sombra.
        /// </summary>
        public TagColor4 TagColor4 { get; set; }

        /// <summary>
        /// Tag de desvanecimiento simple.
        /// </summary>
        public TagFad TagFad { get; set; }

        /// <summary>
        /// Tag de desvanecimiento complejo.
        /// </summary>
        public TagFade TagFade { get; set; }

        /// <summary>
        /// Tag de deformación lateral horizontal.
        /// </summary>
        public TagFax TagFax { get; set; }

        /// <summary>
        /// Tag de deformación lateral vertical.
        /// </summary>
        public TagFay TagFay { get; set; }

        /// <summary>
        /// Tag de codificación.
        /// </summary>
        public TagFe TagFe { get; set; }

        /// <summary>
        /// Tag de fuente.
        /// </summary>
        public TagFn TagFn { get; set; }

        /// <summary>
        /// Tag de rotación horizontal.
        /// </summary>
        public TagFrx TagFrx { get; set; }

        /// <summary>
        /// Ta de rotación vertical.
        /// </summary>
        public TagFry TagFry { get; set; }

        /// <summary>
        /// Tag de rotación perpendicular a la pantalla.
        /// </summary>
        public TagFrz TagFrz { get; set; }

        /// <summary>
        /// Tag de tamaño de fuente.
        /// </summary>
        public TagFs TagFs { get; set; }

        /// <summary>
        /// Tag de espaciado horizontal de fuente.
        /// </summary>
        public TagFscx TagFscx { get; set; }

        /// <summary>
        /// Tag de escalado vertical de fuente.
        /// </summary>
        public TagFscy TagFscy { get; set; }
        
        /// <summary>
        /// Tag de espaciado de fuente.
        /// </summary>
        public TagFsp TagFsp { get; set; }

        /// <summary>
        /// Tag de cursiva.
        /// </summary>
        public TagI TagI { get; set; }

        /// <summary>
        /// Tag de karaoke normal.
        /// </summary>
        public TagK TagK { get; set; }

        /// <summary>
        /// Tag de karaoke paulatino.
        /// </summary>
        public TagKf TagKf { get; set; }

        /// <summary>
        /// Tag de karaoke "ko".
        /// </summary>
        public TagKo TagKo { get; set; }

        /// <summary>
        /// Tag de movimiento.
        /// </summary>
        public TagMove TagMove { get; set; }

        /// <summary>
        /// Tag de origen.
        /// </summary>
        public TagOrg TagOrg { get; set; }

        /// <summary>
        /// Tag de modo de dibujo.
        /// </summary>
        public TagP TagP { get; set; }
        
        /// <summary>
        /// Tag de corrimiento de punto inicial de dibujo.
        /// </summary>
        public TagPbo TagPbo { get; set; }

        /// <summary>
        /// Tag de posición.
        /// </summary>
        public TagPos TagPos { get; set; }

        /// <summary>
        /// Tag de ajuste de línea.
        /// </summary>
        public TagQ TagQ { get; set; }

        /// <summary>
        /// Tag de reinicio de estilo.
        /// </summary>
        public TagR TagR { get; set; }

        /// <summary>
        /// Tag de tachado.
        /// </summary>
        public TagS TagS { get; set; }

        /// <summary>
        /// Tag de sombra total.
        /// </summary>
        public TagShad TagShad { get; set; }

        /// <summary>
        /// Tag de sombra horizontal.
        /// </summary>
        public TagShadX TagShadX { get; set; }

        /// <summary>
        /// Tag de sombra vertical.
        /// </summary>
        public TagShadY TagShadY { get; set; }

        /// <summary>
        /// Tag de transformación.
        /// </summary>
        public TagT TagT { get; set; }

        /// <summary>
        /// Tag de subrayado.
        /// </summary>
        public TagU TagU { get; set; }
        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GrupoTag"/>.
        /// </summary>
        public GrupoTag() {
            Comentario = "";
            Tags = new List<string>();

            // Los tags individuales quedan nulos.
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GrupoTag"/>, obteniendo los tags y el comentario existentes en el texto dado.
        /// </summary>
        /// <param name="texto">Texto con tags o comentario.</param>
        public GrupoTag(string texto) {
            Tags = new List<string>();

            var regex = new Regex(ExpresionesRegulares.regexGrupos);
            var match = regex.Match(texto);
            if (match.Success) {
                Comentario = match.Groups["texto"].Value;

                var tags = match.Groups["grupo"].Value;

                if (FiltroAss.TagExiste(tags, Constantes.Tags.A)) {
                    TagA = new TagA(tags);
                    Tags.Add(TagA.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Alpha)) {
                    TagAlpha = new TagAlpha(tags);
                    Tags.Add(TagAlpha.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Alpha1)) {
                    TagAlpha1 = new TagAlpha1(tags);
                    Tags.Add(TagAlpha1.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Alpha2)) {
                    TagAlpha2 = new TagAlpha2(tags);
                    Tags.Add(TagAlpha2.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Alpha3)) {
                    TagAlpha3 = new TagAlpha3(tags);
                    Tags.Add(TagAlpha3.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Alpha4)) {
                    TagAlpha4 = new TagAlpha4(tags);
                    Tags.Add(TagAlpha4.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.An)) {
                    TagAn = new TagAn(tags);
                    Tags.Add(TagAn.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.B)) {
                    TagB = new TagB(tags);
                    Tags.Add(TagB.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Be)) {
                    TagBe = new TagBe(tags);
                    Tags.Add(TagBe.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Blur)) {
                    TagBlur = new TagBlur(tags);
                    Tags.Add(TagBlur.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Bord)) {
                    TagBord = new TagBord(tags);
                    Tags.Add(TagBord.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.BordX)) {
                    TagBordX = new TagBordX(tags);
                    Tags.Add(TagBordX.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.BordY)) {
                    TagBordY = new TagBordY(tags);
                    Tags.Add(TagBordY.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Clip)) {
                    TagClip = new TagClip(tags);
                    Tags.Add(TagClip.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.ClipI)) {
                    TagClipI = new TagClipI(tags);
                    Tags.Add(TagClipI.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Color1)) {
                    TagColor1 = new TagColor1(tags);
                    Tags.Add(TagColor1.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Color2)) {
                    TagColor2 = new TagColor2(tags);
                    Tags.Add(TagColor2.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Color3)) {
                    TagColor3 = new TagColor3(tags);
                    Tags.Add(TagColor3.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Color4)) {
                    TagColor4 = new TagColor4(tags);
                    Tags.Add(TagColor4.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Fad)) {
                    TagFad = new TagFad(tags);
                    Tags.Add(TagFad.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Fade)) {
                    TagFade = new TagFade(tags);
                    Tags.Add(TagFade.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Fax)) {
                    TagFax = new TagFax(tags);
                    Tags.Add(TagFax.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Fay)) {
                    TagFay = new TagFay(tags);
                    Tags.Add(TagFay.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Fe)) {
                    TagFe = new TagFe(tags);
                    Tags.Add(TagFe.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Fn)) {
                    TagFn = new TagFn(tags);
                    Tags.Add(TagFn.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Frx)) {
                    TagFrx = new TagFrx(tags);
                    Tags.Add(TagFrx.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Fry)) {
                    TagFry = new TagFry(tags);
                    Tags.Add(TagFry.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Frz)) {
                    TagFrz = new TagFrz(tags);
                    Tags.Add(TagFrz.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Fs)) {
                    TagFs = new TagFs(tags);
                    Tags.Add(TagFs.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Fscx)) {
                    TagFscx = new TagFscx(tags);
                    Tags.Add(TagFscx.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Fscy)) {
                    TagFscy = new TagFscy(tags);
                    Tags.Add(TagFscy.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Fsp)) {
                    TagFsp = new TagFsp(tags);
                    Tags.Add(TagFsp.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.I)) {
                    TagI = new TagI(tags);
                    Tags.Add(TagI.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.K)) {
                    TagK = new TagK(tags);
                    Tags.Add(TagK.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Kf)) {
                    TagKf = new TagKf(tags);
                    Tags.Add(TagKf.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Ko)) {
                    TagKo = new TagKo(tags);
                    Tags.Add(TagKo.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Move)) {
                    TagMove = new TagMove(tags);
                    Tags.Add(TagMove.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Org)) {
                    TagOrg = new TagOrg(tags);
                    Tags.Add(TagOrg.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.P)) {
                    TagP = new TagP(tags);
                    Tags.Add(TagP.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Pbo)) {
                    TagPbo = new TagPbo(tags);
                    Tags.Add(TagPbo.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Pos)) {
                    TagPos = new TagPos(tags);
                    Tags.Add(TagPos.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Q)) {
                    TagQ = new TagQ(tags);
                    Tags.Add(TagQ.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.R)) {
                    TagR = new TagR(tags);
                    Tags.Add(TagR.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.S)) {
                    TagS = new TagS(tags);
                    Tags.Add(TagS.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.Shad)) {
                    TagShad = new TagShad(tags);
                    Tags.Add(TagShad.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.ShadX)) {
                    TagShadX = new TagShadX(tags);
                    Tags.Add(TagShadX.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.ShadY)) {
                    TagShadY = new TagShadY(tags);
                    Tags.Add(TagShadY.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.T)) {
                    TagT = new TagT(tags);
                    Tags.Add(TagT.ToString());
                }

                if (FiltroAss.TagExiste(tags, Constantes.Tags.U)) {
                    TagU = new TagU(tags);
                    Tags.Add(TagU.ToString());
                }
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GrupoTag"/>, copiando las propiedades de otra instancia.
        /// </summary>
        /// <param name="grupo">Grupo a copiar.</param>
        public GrupoTag(GrupoTag grupo) {
            Comentario = grupo.Comentario;
            Tags = grupo.Tags;
            TagA = grupo.TagA;
            TagAlpha = grupo.TagAlpha;
            TagAlpha1 = grupo.TagAlpha1;
            TagAlpha2 = grupo.TagAlpha2;
            TagAlpha3 = grupo.TagAlpha3;
            TagAlpha4 = grupo.TagAlpha4;
            TagAn = grupo.TagAn;
            TagB = grupo.TagB;
            TagBe = grupo.TagBe;
            TagBlur = grupo.TagBlur;
            TagBord = grupo.TagBord;
            TagBordX = grupo.TagBordX;
            TagBordY = grupo.TagBordY;
            TagClip = grupo.TagClip;
            TagClipI = grupo.TagClipI;
            TagColor1 = grupo.TagColor1;
            TagColor2 = grupo.TagColor2;
            TagColor3 = grupo.TagColor3;
            TagColor4 = grupo.TagColor4;
            TagFad = grupo.TagFad;
            TagFade = grupo.TagFade;
            TagFax = grupo.TagFax;
            TagFay = grupo.TagFay;
            TagFe = grupo.TagFe;
            TagFn = grupo.TagFn;
            TagFrx = grupo.TagFrx;
            TagFry = grupo.TagFry;
            TagFrz = grupo.TagFrz;
            TagFs = grupo.TagFs;
            TagFscx = grupo.TagFscx;
            TagFscy = grupo.TagFscy;
            TagFsp = grupo.TagFsp;
            TagI = grupo.TagI;
            TagK = grupo.TagK;
            TagKf = grupo.TagKf;
            TagKo = grupo.TagKo;
            TagMove = grupo.TagMove;
            TagOrg = grupo.TagOrg;
            TagP = grupo.TagP;
            TagPbo = grupo.TagPbo;
            TagPos = grupo.TagPos;
            TagQ = grupo.TagQ;
            TagR = grupo.TagR;
            TagS = grupo.TagS;
            TagShad = grupo.TagShad;
            TagShadX = grupo.TagShadX;
            TagShadY = grupo.TagShadY;
            TagT = grupo.TagT;
            TagU = grupo.TagU;
        }

        /// <summary>
        /// Devuelve una cadena de la forma: comentario\tag1\tag2\...\tagN.
        /// </summary>
        public override string ToString() {
            var texto = Comentario;

            if (TagA != null) texto += TagA;
            if (TagAlpha != null) texto += TagAlpha;
            if (TagAlpha1 != null) texto += TagAlpha1;
            if (TagAlpha2 != null) texto += TagAlpha2;
            if (TagAlpha3 != null) texto += TagAlpha3;
            if (TagAlpha4 != null) texto += TagAlpha4;
            if (TagAn != null) texto += TagAn;
            if (TagB != null) texto += TagB;
            if (TagBe != null) texto += TagBe;
            if (TagBlur != null) texto += TagBlur;
            if (TagBord != null) texto += TagBord;
            if (TagBordX != null) texto += TagBordX;
            if (TagBordY != null) texto += TagBordY;
            if (TagClip != null) texto += TagClip;
            if (TagClipI != null) texto += TagClipI;
            if (TagColor1 != null) texto += TagColor1;
            if (TagColor2 != null) texto += TagColor2;
            if (TagColor3 != null) texto += TagColor3;
            if (TagColor4 != null) texto += TagColor4;
            if (TagFad != null) texto += TagFad;
            if (TagFade != null) texto += TagFade;
            if (TagFax != null) texto += TagFax;
            if (TagFay != null) texto += TagFay;
            if (TagFe != null) texto += TagFe;
            if (TagFn != null) texto += TagFn;
            if (TagFrx != null) texto += TagFrx;
            if (TagFry != null) texto += TagFry;
            if (TagFrz != null) texto += TagFrz;
            if (TagFs != null) texto += TagFs;
            if (TagFscx != null) texto += TagFscx;
            if (TagFscy != null) texto += TagFscy;
            if (TagFsp != null) texto += TagFsp;
            if (TagI != null) texto += TagI;
            if (TagK != null) texto += TagK;
            if (TagKf != null) texto += TagKf;
            if (TagKo != null) texto += TagKo;
            if (TagMove != null) texto += TagMove;
            if (TagOrg != null) texto += TagOrg;
            if (TagP != null) texto += TagP;
            if (TagPbo != null) texto += TagPbo;
            if (TagPos != null) texto += TagPos;
            if (TagQ != null) texto += TagQ;
            if (TagR != null) texto += TagR;
            if (TagS != null) texto += TagS;
            if (TagShad != null) texto += TagShad;
            if (TagShadX != null) texto += TagShadX;
            if (TagShadY != null) texto += TagShadY;
            if (TagT != null) texto += TagT;
            if (TagU != null) texto += TagU;

            return texto;
        }
    }
}
