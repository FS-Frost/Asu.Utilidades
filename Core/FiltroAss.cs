using Asu.Utils.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Asu.Utils {

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con el formato ASS.
    /// </summary>
    public static class FiltroAss {

        /// <summary>
        /// Busca la propiedad especificada dentro de la cadena.
        /// </summary>
        /// <param name="texto">Cadena con propiedades del formato ASS.</param>
        /// <param name="propiedad">Propiedad del formato ASS.</param>
        /// <returns>Cadena con la propiedad especificada.</returns>
        public static string FilterProperty(string texto, Property propiedad) {
            // Propiedades de una línea.
            var tipo = string.Empty;
            var capa = string.Empty;
            var inicio = string.Empty;
            var fin = string.Empty;
            var estilo = string.Empty;
            var actor = string.Empty;
            var margenI = string.Empty;
            var margenD = string.Empty;
            var margenV = string.Empty;
            var efecto = string.Empty;
            var contenido = string.Empty;

            // Buscando coincidencias.
            var regex = new Regex(RegularExpressions.RegexProperties);
            var match = regex.Match(texto);

            // En caso de haber coincidencias...
            if (match.Success) {
                // Se obtienen los resultados.
                tipo = match.Groups["tipo"].Value;
                capa = match.Groups["capa"].Value;
                inicio = match.Groups["inicio"].Value;
                fin = match.Groups["fin"].Value;
                estilo = match.Groups["estilo"].Value;
                actor = match.Groups["actor"].Value;
                margenI = match.Groups["margenI"].Value;
                margenD = match.Groups["margenD"].Value;
                margenV = match.Groups["margenV"].Value;
                efecto = match.Groups["efecto"].Value;
                contenido = match.Groups["contenido"].Value;
            }

            // Entregando la propiedad solicitada.
            switch (propiedad) {
                case Property.Type:
                    return tipo;

                case Property.Layer:
                    return capa;

                case Property.Start:
                    return inicio;

                case Property.End:
                    return fin;

                case Property.Style:
                    return estilo;

                case Property.Actor:
                    return actor;

                case Property.MarginLeft:
                    return margenI;

                case Property.MarginRight:
                    return margenD;

                case Property.MarginVertical:
                    return margenV;

                case Property.Effect:
                    return efecto;

                default:
                    return contenido;
            }
        }
        
        /// <summary>
        /// Busca todas las propiedades del formato ASS dentro de la cadena.
        /// Las propiedades se obtienen con sus nombres: grupos["nombre"].
        /// </summary>
        /// <param name="texto">Cadena donde buscar las propiedades.</param>
        /// <returns>Colección de grupos de búsqueda Regex.</returns>
        public static GroupCollection FilterProperties(string texto) {
            // Buscando coincidencias.
            var regex = new Regex(RegularExpressions.RegexProperties);
            var match = regex.Match(texto);

            // Regresando resultados.
            return match.Groups;
        }

        /// <summary>
        /// Busca todos lo grupos de la forma {} dentro de la cadena.
        /// </summary>
        /// <param name="texto">Cadena donde buscar los grupos.</param>
        /// <returns>Lista de grupos de búsqueda Regex.</returns>
        public static List<Group> FilterGroups(string contenido) {
            var regex = new Regex(RegularExpressions.RegexGroups);
            var match = regex.Match(contenido);
            var grupos = new List<Group>();

            while (match.Success) {
                if (match.Groups["grupo"].Success && match.Groups["grupo"].Value != "") {
                    // Obteniendo el grupo.
                    grupos.Add(match.Groups["grupo"]);
                }
                // Pasando a la siguiente coincidencia.
                match = match.NextMatch();
            }
            return grupos;
        }

        /// <summary>
        /// Busca la primera coincidencia del tag especificado dentro de la cadena.
        /// </summary>
        /// <param name="texto">Cadena donde buscar el tag.</param>
        /// <param name="tag">Tag a buscar dentro de la cadena.</param>
        /// <returns>Grupo de búsqueda Regex.</returns>
        public static Group SearchTag(string texto, Tags tag) {
            // Caso específico para el tag \t.
            if (tag == Tags.T) {
                var grupos = FilterGroups(texto);
                var texto2 = "";
                foreach (var g in grupos) {
                    var s = g.Value;
                    if (s.Contains(@"\t(")) {
                        s = s.Substring(s.IndexOf(@"\t("));
                        if (s.Contains(')')) {
                            texto2 = g.Value;
                            break;
                        }
                    }
                }

                // Obteniendo el patrón del tag.
                var patron2 = GetTagPettern(tag);
                
                // Generando la expresión regular.
                var regex2 = new Regex(patron2);

                // Buscando coincidencias.
                var matches2 = regex2.Match(texto2);

                // Retornando el resultado.
                return matches2.Groups["tag"];
            }
            
            // Obteniendo el patrón del tag.
            var patron = GetTagPettern(tag);

            // Agregando validación para que el tag esté entre {}.
            var pre = @"\{[^{}]*";
            var post = @"[^{}]*\}";
            patron = string.Format("{0}{1}{2}", pre, patron, post);

            // Generando la expresión regular.
            var regex = new Regex(patron);

            // Buscando coincidencias.
            var match = regex.Match(texto);

            // Retornando el resultado.
            return match.Groups["tag"];
        }
        
        /// <summary>
        /// Reemplaza la primera coincidencia del tag especificado dentro de la cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag a reemplazar.</param>
        /// <param name="tagOriginal">Tag a reemplazar.</param>
        /// <param name="textoNuevo">Cadena a insertar en lugar del tag. Idealmente otro tag.</param>
        /// <returns>Cadena con el tag reemplazado.</returns>
        public static string ReplaceTag(string texto, Tags tagOriginal, string textoNuevo) {
            if (TagExists(texto, tagOriginal)) {
                // Obteniendo el patrón del tag original.
                var regex = GetTagPettern(tagOriginal);

                // Obteniendo tag original.
                var match = new Regex(regex).Match(texto);
                var tag = match.Groups["tag"].Value;

                // Quitando el tag original.
                var texto2 = texto.Remove(match.Index, match.Length);

                // Insertando el tag nuevo en la posición donde iniciaba el original.
                texto2 = texto2.Insert(match.Index, textoNuevo);

                return texto2;
            }

            return texto;
        }

        /// <summary>
        /// Verifica si un tag existe dentro de una cadena.
        /// </summary>
        /// <param name="texto">Cadena donde verificar el tag.</param>
        /// <param name="tag">Tag a verificar.</param>
        /// <returns></returns>
        public static bool TagExists(string texto, Tags tag) {
            // Obteniendo el patrón del tag.
            var patron = GetTagPettern(tag);

            // Generando expresión regular.
            var regex = new Regex(patron);
            var match = regex.Match(texto);

            // Buscando coincidencia.
            if (match.Success) {
                // Si hay al menos una.
                return true;
            } else {
                // Si no hay ninguna.
                return false;
            }
        }

        /// <summary>
        /// Busca el patrón Regex del tag especificado.
        /// </summary>
        /// <param name="tag">Tag del cual obtener el patrón.</param>
        /// <returns>Cadena con el patrón de tag.</returns>
        public static string GetTagPettern(Tags tag) {
            switch (tag) {
                case Tags.I:
                    return RegularExpressions.RegexTagI;
                case Tags.B:
                    return RegularExpressions.RegexTagB;
                case Tags.U:
                    return RegularExpressions.RegexTagU;
                case Tags.S:
                    return RegularExpressions.RegexTagS;
                case Tags.Bord:
                    return RegularExpressions.RegexTagBord;
                case Tags.BordX:
                    return RegularExpressions.RegexTagBordX;
                case Tags.BordY:
                    return RegularExpressions.RegexTagBordY;
                case Tags.Shad:
                    return RegularExpressions.RegexTagShad;
                case Tags.ShadX:
                    return RegularExpressions.RegexTagShadX;
                case Tags.ShadY:
                    return RegularExpressions.RegexTagShadY;
                case Tags.Be:
                    return RegularExpressions.RegexTagBe;
                case Tags.Blur:
                    return RegularExpressions.RegexTagBlur;
                case Tags.Fn:
                    return RegularExpressions.RegexTagFn;
                case Tags.Fs:
                    return RegularExpressions.RegexTagFs;
                case Tags.Fscx:
                    return RegularExpressions.RegexTagFscx;
                case Tags.Fscy:
                    return RegularExpressions.RegexTagFscy;
                case Tags.Fsp:
                    return RegularExpressions.RegexTagFsp;
                case Tags.Frz:
                    return RegularExpressions.RegexTagFrz;
                case Tags.Frx:
                    return RegularExpressions.RegexTagFrx;
                case Tags.Fry:
                    return RegularExpressions.RegexTagFry;
                case Tags.Fax:
                    return RegularExpressions.RegexTagFax;
                case Tags.Fay:
                    return RegularExpressions.RegexTagFay;
                case Tags.Fe:
                    return RegularExpressions.RegexTagFe;
                case Tags.Color1:
                    return RegularExpressions.RegexTagColor1;
                case Tags.Color2:
                    return RegularExpressions.RegexTagColor2;
                case Tags.Color3:
                    return RegularExpressions.RegexTagColor3;
                case Tags.Color4:
                    return RegularExpressions.RegexTagColor4;
                case Tags.Alpha:
                    return RegularExpressions.RegexTagAlpha;
                case Tags.Alpha1:
                    return RegularExpressions.RegexTagAlpha1;
                case Tags.Alpha2:
                    return RegularExpressions.RegexTagAlpha2;
                case Tags.Alpha3:
                    return RegularExpressions.RegexTagAlpha3;
                case Tags.Alpha4:
                    return RegularExpressions.RegexTagAlpha4;
                case Tags.A:
                    return RegularExpressions.RegexTagA;
                case Tags.An:
                    return RegularExpressions.RegexTagAn;
                case Tags.K:
                    return RegularExpressions.RegexTagK;
                case Tags.Kf:
                    return RegularExpressions.RegexTagKf;
                case Tags.Ko:
                    return RegularExpressions.RegexTagKo;
                case Tags.Q:
                    return RegularExpressions.RegexTagQ;
                case Tags.Fx:
                    return RegularExpressions.RegexTagFx;
                case Tags.R:
                    return RegularExpressions.RegexTagR;
                case Tags.Pos:
                    return RegularExpressions.RegexTagPos;
                case Tags.Move:
                    return RegularExpressions.RegexTagMove;
                case Tags.Org:
                    return RegularExpressions.RegexTagOrg;
                case Tags.Fade:
                    return RegularExpressions.RegexTagFade;
                case Tags.Fad:
                    return RegularExpressions.RegexTagFad;
                case Tags.T:
                    return RegularExpressions.RegexTagT;
                case Tags.ClipI:
                    return RegularExpressions.RegexTagClipI;
                case Tags.Clip:
                    return RegularExpressions.RegexTagClip;
                case Tags.P:
                    return RegularExpressions.RegexTagP;
                case Tags.Pbo:
                    return RegularExpressions.RegexTagPbo;
                default:
                    return "";
            }
        }
        
        /// <summary>
        /// Establece si un texto es un grupo de la forma {};
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static bool IsTagGroup(string texto) {
            if (texto.StartsWith("{") && texto.EndsWith("}")) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Establece si un texto es un grupo con al menos un tag de karaoke.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static bool IsKaraokeGroup(string texto) {
            if (IsTagGroup(texto)) {
                var tagsKaraoke = new Tags[] { Tags.K, Tags.Kf, Tags.Ko };

                foreach (var tag in tagsKaraoke) {
                    if (TagExists(texto, tag)) {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}
