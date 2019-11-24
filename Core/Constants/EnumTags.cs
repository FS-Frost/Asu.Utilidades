using System;

namespace Asu.Utils.Constants {
    /// <summary>
    /// Especifica tags del formato ASS documentados en Aegisub.
    /// </summary>
    public enum Tags {
        I,
        B,
        U,
        S,
        Bord,
        BordX,
        BordY,
        Shad,
        ShadX,
        ShadY,
        Be,
        Blur,
        Fn,
        Fs,
        Fscx,
        Fscy,
        Fsp,
        Frz,
        Frx,
        Fry,
        Fax,
        Fay,
        Fe,
        Color1,
        Color2,
        Color3,
        Color4,
        Alpha,
        Alpha1,
        Alpha2,
        Alpha3,
        Alpha4,
        A,
        An,
        K,
        Kf,
        Ko,
        Q,
        Fx,
        R,
        Pos,
        Move,
        Org,
        Fade,
        Fad,
        T,
        ClipI,
        Clip,
        P,
        Pbo
    }

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="Tags"/>.
    /// </summary>
    public static class TagsInfo {
        /// <summary>
        /// Devuelve una cadena con la escritura textual del tag especificado.
        /// </summary>
        /// <param name="tag"></param>
        public static string TagToString(Tags tag) {
            switch (tag) {
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
        /// Devuelve el tag correspondiende a la cadena especificada.
        /// </summary>
        /// <param name="tag">Escritura textual del tag.</param>
        /// <returns></returns>
        public static Tags StringToTag(string tag) {
            switch (tag) {
                case "a":
                    return Tags.A;
                case "alpha":
                    return Tags.Alpha;
                case "1a":
                    return Tags.Alpha1;
                case "2a":
                    return Tags.Alpha;
                case "3a":
                    return Tags.Alpha;
                case "4a":
                    return Tags.Alpha;
                case "an":
                    return Tags.An;
                case "b":
                    return Tags.B;
                case "be":
                    return Tags.Be;
                case "blur":
                    return Tags.Blur;
                case "bord":
                    return Tags.Bord;
                case "xbord":
                    return Tags.BordX;
                case "ybord":
                    return Tags.BordY;
                case "clip":
                    return Tags.Clip;
                case "iclip":
                    return Tags.ClipI;
                case "1c":
                    return Tags.Color1;
                case "2c":
                    return Tags.Color2;
                case "3c":
                    return Tags.Color3;
                case "4c":
                    return Tags.Color4;
                case "fad":
                    return Tags.Fad;
                case "fade":
                    return Tags.Fade;
                case "fax":
                    return Tags.Fax;
                case "fay":
                    return Tags.Fay;
                case "fe":
                    return Tags.Fe;
                case "fn":
                    return Tags.Fn;
                case "frx":
                    return Tags.Frx;
                case "fry":
                    return Tags.Fry;
                case "frz":
                    return Tags.Frz;
                case "fs":
                    return Tags.Fs;
                case "fscx":
                    return Tags.Fscx;
                case "fscy":
                    return Tags.Fscy;
                case "fsp":
                    return Tags.Fsp;
                case "fx":
                    return Tags.Fx;
                case "i":
                    return Tags.I;
                case "k":
                    return Tags.K;
                case "kf":
                    return Tags.Kf;
                case "ko":
                    return Tags.Ko;
                case "move":
                    return Tags.Move;
                case "org":
                    return Tags.Org;
                case "p":
                    return Tags.P;
                case "pbo":
                    return Tags.Pbo;
                case "pos":
                    return Tags.Pos;
                case "q":
                    return Tags.Q;
                case "r":
                    return Tags.R;
                case "s":
                    return Tags.S;
                case "shad":
                    return Tags.Shad;
                case "xshad":
                    return Tags.ShadX;
                case "yshad":
                    return Tags.ShadY;
                case "t":
                    return Tags.T;
                case "u":
                    return Tags.U;
                default:
                    throw new ArgumentOutOfRangeException("s", tag, "El tag debe ser soportado por Aegisub.");
            }
        }
    }
}
