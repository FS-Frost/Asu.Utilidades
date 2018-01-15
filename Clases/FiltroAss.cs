using Asu.Utilidades.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Asu.Utilidades {

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
        public static string FiltrarPropiedad(string texto, Propiedades propiedad) {
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
            var regex = new Regex(ExpresionesRegulares.regexPropiedades);
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
                case Propiedades.Tipo:
                    return tipo;

                case Propiedades.Capa:
                    return capa;

                case Propiedades.Inicio:
                    return inicio;

                case Propiedades.Fin:
                    return fin;

                case Propiedades.Estilo:
                    return estilo;

                case Propiedades.Actor:
                    return actor;

                case Propiedades.MargenIzquierdo:
                    return margenI;

                case Propiedades.MargenDerecho:
                    return margenD;

                case Propiedades.MargenVertical:
                    return margenV;

                case Propiedades.Efecto:
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
        public static GroupCollection FiltrarPropiedades(string texto) {
            // Buscando coincidencias.
            var regex = new Regex(ExpresionesRegulares.regexPropiedades);
            var match = regex.Match(texto);

            // Regresando resultados.
            return match.Groups;
        }

        /// <summary>
        /// Busca todos lo grupos de la forma {} dentro de la cadena.
        /// </summary>
        /// <param name="texto">Cadena donde buscar los grupos.</param>
        /// <returns>Lista de grupos de búsqueda Regex.</returns>
        public static List<Group> FiltrarGrupos(string contenido) {
            var regex = new Regex(ExpresionesRegulares.regexGrupos);
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
        public static Group BuscarTag(string texto, Tags tag) {
            // Caso específico para el tag \t.
            if (tag == Tags.T) {
                var grupos = FiltrarGrupos(texto);
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
                var patron2 = BuscarPatronTag(tag);
                
                // Generando la expresión regular.
                var regex2 = new Regex(patron2);

                // Buscando coincidencias.
                var matches2 = regex2.Match(texto2);

                // Retornando el resultado.
                return matches2.Groups["tag"];
            }
            
            // Obteniendo el patrón del tag.
            var patron = BuscarPatronTag(tag);

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
        public static string ReemplazarTag(string texto, Tags tagOriginal, string textoNuevo) {
            if (TagExiste(texto, tagOriginal)) {
                // Obteniendo el patrón del tag original.
                var regex = BuscarPatronTag(tagOriginal);

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
        public static bool TagExiste(string texto, Tags tag) {
            // Obteniendo el patrón del tag.
            var patron = BuscarPatronTag(tag);

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
        public static string BuscarPatronTag(Tags tag) {
            switch (tag) {
                case Tags.I:
                    return ExpresionesRegulares.regexTagI;
                case Tags.B:
                    return ExpresionesRegulares.regexTagB;
                case Tags.U:
                    return ExpresionesRegulares.regexTagU;
                case Tags.S:
                    return ExpresionesRegulares.regexTagS;
                case Tags.Bord:
                    return ExpresionesRegulares.regexTagBord;
                case Tags.BordX:
                    return ExpresionesRegulares.regexTagBordX;
                case Tags.BordY:
                    return ExpresionesRegulares.regexTagBordY;
                case Tags.Shad:
                    return ExpresionesRegulares.regexTagShad;
                case Tags.ShadX:
                    return ExpresionesRegulares.regexTagShadX;
                case Tags.ShadY:
                    return ExpresionesRegulares.regexTagShadY;
                case Tags.Be:
                    return ExpresionesRegulares.regexTagBe;
                case Tags.Blur:
                    return ExpresionesRegulares.regexTagBlur;
                case Tags.Fn:
                    return ExpresionesRegulares.regexTagFn;
                case Tags.Fs:
                    return ExpresionesRegulares.regexTagFs;
                case Tags.Fscx:
                    return ExpresionesRegulares.regexTagFscx;
                case Tags.Fscy:
                    return ExpresionesRegulares.regexTagFscy;
                case Tags.Fsp:
                    return ExpresionesRegulares.regexTagFsp;
                case Tags.Frz:
                    return ExpresionesRegulares.regexTagFrz;
                case Tags.Frx:
                    return ExpresionesRegulares.regexTagFrx;
                case Tags.Fry:
                    return ExpresionesRegulares.regexTagFry;
                case Tags.Fax:
                    return ExpresionesRegulares.regexTagFax;
                case Tags.Fay:
                    return ExpresionesRegulares.regexTagFay;
                case Tags.Fe:
                    return ExpresionesRegulares.regexTagFe;
                case Tags.Color1:
                    return ExpresionesRegulares.regexTagColor1;
                case Tags.Color2:
                    return ExpresionesRegulares.regexTagColor2;
                case Tags.Color3:
                    return ExpresionesRegulares.regexTagColor3;
                case Tags.Color4:
                    return ExpresionesRegulares.regexTagColor4;
                case Tags.Alpha:
                    return ExpresionesRegulares.regexTagAlpha;
                case Tags.Alpha1:
                    return ExpresionesRegulares.regexTagAlpha1;
                case Tags.Alpha2:
                    return ExpresionesRegulares.regexTagAlpha2;
                case Tags.Alpha3:
                    return ExpresionesRegulares.regexTagAlpha3;
                case Tags.Alpha4:
                    return ExpresionesRegulares.regexTagAlpha4;
                case Tags.A:
                    return ExpresionesRegulares.regexTagA;
                case Tags.An:
                    return ExpresionesRegulares.regexTagAn;
                case Tags.K:
                    return ExpresionesRegulares.regexTagK;
                case Tags.Kf:
                    return ExpresionesRegulares.regexTagKf;
                case Tags.Ko:
                    return ExpresionesRegulares.regexTagKo;
                case Tags.Q:
                    return ExpresionesRegulares.regexTagQ;
                case Tags.Fx:
                    return ExpresionesRegulares.regexTagFx;
                case Tags.R:
                    return ExpresionesRegulares.regexTagR;
                case Tags.Pos:
                    return ExpresionesRegulares.regexTagPos;
                case Tags.Move:
                    return ExpresionesRegulares.regexTagMove;
                case Tags.Org:
                    return ExpresionesRegulares.regexTagOrg;
                case Tags.Fade:
                    return ExpresionesRegulares.regexTagFade;
                case Tags.Fad:
                    return ExpresionesRegulares.regexTagFad;
                case Tags.T:
                    return ExpresionesRegulares.regexTagT;
                case Tags.ClipI:
                    return ExpresionesRegulares.regexTagClipI;
                case Tags.Clip:
                    return ExpresionesRegulares.regexTagClip;
                case Tags.P:
                    return ExpresionesRegulares.regexTagP;
                case Tags.Pbo:
                    return ExpresionesRegulares.regexTagPbo;
                default:
                    return "";
            }
        }
        
        /// <summary>
        /// Obtiene el nombre del tag especificado.
        /// </summary>
        /// <param name="t">Tag del cual obtener el nombre.</param>
        /// <returns>Cadena con el nombre del tag.</returns>
        public static string TagToString(Tags t) {
            switch (t) {
                case Tags.I:
                    return "i";
                case Tags.B:
                    return "b";
                case Tags.U:
                    return "u";
                case Tags.S:
                    return "s";
                case Tags.Bord:
                    return "bord";
                case Tags.BordX:
                    return "xbord";
                case Tags.BordY:
                    return "ybord";
                case Tags.Shad:
                    return "shad";
                case Tags.ShadX:
                    return "xshad";
                case Tags.ShadY:
                    return "yshad";
                case Tags.Be:
                    return "be";
                case Tags.Blur:
                    return "blur";
                case Tags.Fn:
                    return "fn";
                case Tags.Fs:
                    return "fs";
                case Tags.Fscx:
                    return "fscx";
                case Tags.Fscy:
                    return "fscy";
                case Tags.Fsp:
                    return "fsp";
                case Tags.Frz:
                    return "frz";
                case Tags.Frx:
                    return "frx";
                case Tags.Fry:
                    return "fry";
                case Tags.Fax:
                    return "fax";
                case Tags.Fay:
                    return "fay";
                case Tags.Fe:
                    return "fe";
                case Tags.Color1:
                    return "c1";
                case Tags.Color2:
                    return "c2";
                case Tags.Color3:
                    return "c3";
                case Tags.Color4:
                    return "c4";
                case Tags.Alpha:
                    return "alpha";
                case Tags.Alpha1:
                    return "1a";
                case Tags.Alpha2:
                    return "2a";
                case Tags.Alpha3:
                    return "3a";
                case Tags.Alpha4:
                    return "4a";
                case Tags.A:
                    return "a";
                case Tags.An:
                    return "an";
                case Tags.K:
                    return "k";
                case Tags.Kf:
                    return "kf";
                case Tags.Ko:
                    return "ko";
                case Tags.Q:
                    return "q";
                case Tags.Fx:
                    return "-";
                case Tags.R:
                    return "r";
                case Tags.Pos:
                    return "pos";
                case Tags.Move:
                    return "move";
                case Tags.Org:
                    return "org";
                case Tags.Fade:
                    return "fade";
                case Tags.Fad:
                    return "fad";
                case Tags.T:
                    return "t";
                case Tags.ClipI:
                    return "iclip";
                case Tags.Clip:
                    return "clip";
                case Tags.P:
                    return "p";
                case Tags.Pbo:
                    return "pbo";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Establece si un texto es un grupo de la forma {};
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static bool EsGrupoTag(string texto) {
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
        public static bool EsGrupoKaraoke(string texto) {
            if (EsGrupoTag(texto)) {
                var tagsKaraoke = new Tags[] { Tags.K, Tags.Kf, Tags.Ko };

                foreach (var tag in tagsKaraoke) {
                    if (TagExiste(texto, tag)) {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}
