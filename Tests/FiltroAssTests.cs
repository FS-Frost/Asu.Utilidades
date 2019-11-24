using Asu.Utils;
using Asu.Utils.Constants;
using NUnit.Framework;

namespace Asu.Tests {
    [TestFixture]
    public class FiltroAssTests {
        #region Casos de prueba
        static readonly object[] casosTagExiste = {
            // Tag: a.
            // Nulo
            new object[] {
                @"",
                Tags.A,
                false },
            // Normal.
            new object[] {
                @"Texto{\a1}Texto",
                Tags.A,
                true },
            // Inválido.
            new object[] {
                @"Texto{\a-}Texto",
                Tags.A,
                false },
            // Tag: alpha.
            // Nulo
            new object[] {
                @"",
                Tags.Alpha,
                false },
            // Normal.
            new object[] {
                @"Texto{\alpha&HFF&}Texto",
                Tags.Alpha,
                true },
            // Inválido.
            new object[] {
                @"Texto{\alpha&H-&}Texto",
                Tags.Alpha,
                false },
            // Tag: 1a.
            // Nulo
            new object[] {
                @"",
                Tags.Alpha1,
                false },
            // Normal.
            new object[] {
                @"Texto{\1a&HFF&}Texto",
                Tags.Alpha1,
                true },
            // Inválido.
            new object[] {
                @"Texto{\1a&H-&}Texto",
                Tags.Alpha1,
                false },
            // Tag: 2a.
            // Nulo
            new object[] {
                @"",
                Tags.Alpha2,
                false },
            // Normal.
            new object[] {
                @"Texto{\2a&HFF&}Texto",
                Tags.Alpha2,
                true },
            // Inválido.
            new object[] {
                @"Texto{\2a&H-&}Texto",
                Tags.Alpha2,
                false },
            // Tag: 3a.
            // Nulo
            new object[] {
                @"",
                Tags.Alpha3,
                false },
            // Normal.
            new object[] {
                @"Texto{\3a&HFF&}Texto",
                Tags.Alpha3,
                true },
            // Inválido.
            new object[] {
                @"Texto{\3a&H-&}Texto",
                Tags.Alpha3,
                false },
            // Tag: 4a.
            // Nulo
            new object[] {
                @"",
                Tags.Alpha4,
                false },
            // Normal.
            new object[] {
                @"Texto{\4a&HFF&}Texto",
                Tags.Alpha4,
                true },
            // Inválido.
            new object[] {
                @"Texto{\4a&H-&}Texto",
                Tags.Alpha4,
                false },
            // Tag: an.
            // Nulo
            new object[] {
                @"",
                Tags.An,
                false },
            // Normal.
            new object[] {
                @"Texto{\an1}Texto",
                Tags.An,
                true },
            // Inválido.
            new object[] {
                @"Texto{\an-}Texto",
                Tags.An,
                false },
            // Tag: b.
            // Nulo
            new object[] {
                @"",
                Tags.B,
                false },
            // Normal.
            new object[] {
                @"Texto{\b1}Texto",
                Tags.B,
                true },
            // Inválido.
            new object[] {
                @"Texto{\b-}Texto",
                Tags.B,
                false },
            // Tag: be.
            // Nulo
            new object[] {
                @"",
                Tags.Be,
                false },
            // Normal.
            new object[] {
                @"Texto{\be1}Texto",
                Tags.Be,
                true },
            // Inválido.
            new object[] {
                @"Texto{\be-}Texto",
                Tags.Be,
                false },
            // Tag: blur.
            // Nulo
            new object[] {
                @"",
                Tags.Blur,
                false },
            // Normal.
            new object[] {
                @"Texto{\blur1}Texto",
                Tags.Blur,
                true },
            // Inválido.
            new object[] {
                @"Texto{\blur-}Texto",
                Tags.Blur,
                false },
            // Tag: bord.
            // Nulo
            new object[] {
                @"",
                Tags.Bord,
                false },
            // Normal.
            new object[] {
                @"Texto{\bord1}Texto",
                Tags.Bord,
                true },
            // Inválido.
            new object[] {
                @"Texto{\bord-}Texto",
                Tags.Bord,
                false },
            // Tag: xbord.
            // Nulo
            new object[] {
                @"",
                Tags.BordX,
                false },
            // Normal.
            new object[] {
                @"Texto{\xbord1}Texto",
                Tags.BordX,
                true },
            // Inválido.
            new object[] {
                @"Texto{\xbord-}Texto",
                Tags.BordX,
                false },
            // Tag: ybord.
            // Nulo
            new object[] {
                @"",
                Tags.BordY,
                false },
            // Normal.
            new object[] {
                @"Texto{\ybord1}Texto",
                Tags.BordY,
                true },
            // Inválido.
            new object[] {
                @"Texto{\ybord-}Texto",
                Tags.BordY,
                false },
            // Tag: clip.
            // Nulo.
            new object[] {
                @"",
                Tags.Clip,
                false },
            // Normal: rectángulo.
            new object[] {
                @"Texto{\clip(0,0,0,0)}Texto",
                Tags.Clip,
                true },
            // Normal: comandos.
            new object[] {
                @"Texto{\clip(m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)}Texto",
                Tags.Clip,
                true },
            // Normal: comandos y escala.
            new object[] {
                @"Texto{\clip(1,m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)}Texto",
                Tags.Clip,
                true },
            // Inválido.
            new object[] {
                @"Texto{\clip(0)}Texto",
                Tags.Clip,
                false },
            // Tag: iclip.
            // Nulo.
            new object[] {
                @"",
                Tags.ClipI,
                false },
            // Normal: rectángulo.
            new object[] {
                @"Texto{\iclip(0,0,0,0)}Texto",
                Tags.ClipI,
                true },
            // Normal: comandos.
            new object[] {
                @"Texto{\iclip(m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)}Texto",
                Tags.ClipI,
                true },
            // Normal: comandos y escala.
            new object[] {
                @"Texto{\iclip(1,m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)}Texto",
                Tags.ClipI,
                true },
            // Inválido.
            new object[] {
                @"Texto{\iclip(0)}Texto",
                Tags.ClipI,
                false },
            // Tag: c.
            // Nulo
            new object[] {
                @"",
                Tags.Color1,
                false },
            // Normal.
            new object[] {
                @"Texto{\c&H123456&}Texto",
                Tags.Color1,
                true },
            // Inválido.
            new object[] {
                @"Texto{\c&H-&}Texto",
                Tags.Color1,
                false },
            // Tag: 1c.
            // Nulo
            new object[] {
                @"",
                Tags.Color1,
                false },
            // Normal.
            new object[] {
                @"Texto{\1c&H123456&}Texto",
                Tags.Color1,
                true },
            // Inválido.
            new object[] {
                @"Texto{\1c&H-&}Texto",
                Tags.Color1,
                false },
            // Tag: 2c.
            new object[] {
                @"",
                Tags.Color2,
                false },
            // Normal.
            new object[] {
                @"Texto{\2c&H123456&}Texto",
                Tags.Color2,
                true },
            // Inválido.
            new object[] {
                @"Texto{\2c&H-&}Texto",
                Tags.Color2,
                false },
            // Tag: 3c.
            new object[] {
                @"",
                Tags.Color3,
                false },
            // Normal.
            new object[] {
                @"Texto{\3c&H123456&}Texto",
                Tags.Color3,
                true },
            // Inválido.
            new object[] {
                @"Texto{\3c&H-&}Texto",
                Tags.Color3,
                false },
            // Tag: 4c.
            new object[] {
                @"",
                Tags.Color4,
                false },
            // Normal.
            new object[] {
                @"Texto{\4c&H123456&}Texto",
                Tags.Color4,
                true },
            // Inválido.
            new object[] {
                @"Texto{\4c&H-&}Texto",
                Tags.Color4,
                false },
            // Tag: fad.
            // Nulo
            new object[] {
                @"",
                Tags.Fad,
                false },
            // Normal.
            new object[] {
                @"Texto{\fad(0,0)}Texto",
                Tags.Fad,
                true },
            // Inválido.
            new object[] {
                @"Texto{\fad(0)}Texto",
                Tags.Fad,
                false },
            // Tag: fade.
            // Nulo
            new object[] {
                @"",
                Tags.Fade,
                false },
            // Normal.
            new object[] {
                @"Texto{\fade(0,0,0,0,0,0,0)}Texto",
                Tags.Fade,
                true },
            // Inválido.
            new object[] {
                @"Texto{\fade(0)}Texto",
                Tags.Fade,
                false },
            // Tag: fax.
            // Nulo
            new object[] {
                @"",
                Tags.Fax,
                false },
            // Normal.
            new object[] {
                @"Texto{\fax1}Texto",
                Tags.Fax,
                true },
            // Inválido.
            new object[] {
                @"Texto{\fax-}Texto",
                Tags.Fax,
                false },
            // Tag: fay.
            // Nulo
            new object[] {
                @"",
                Tags.Fay,
                false },
            // Normal.
            new object[] {
                @"Texto{\fay1}Texto",
                Tags.Fay,
                true },
            // Inválido.
            new object[] {
                @"Texto{\fay-}Texto",
                Tags.Fay,
                false },
            // Tag: fe.
            // Nulo
            new object[] {
                @"",
                Tags.Fe,
                false },
            // Normal.
            new object[] {
                @"Texto{\fe1}Texto",
                Tags.Fe,
                true },
            // La invalidez se da si la codificación no existe,
            // así que ese caso no se considera.

            // Tag: fn.
            // Nulo
            new object[] {
                @"",
                Tags.Fn,
                false },
            // Normal.
            new object[] {
                @"Texto{\fnArial}Texto",
                Tags.Fn,
                true },
            // La invalidez se da si la fuente no existe,
            // así que ese caso no se considera.

            // Tag: frx.
            // Nulo
            new object[] {
                @"",
                Tags.Frx,
                false },
            // Normal.
            new object[] {
                @"Texto{\frx1}Texto",
                Tags.Frx,
                true },
            // Inválido.
            new object[] {
                @"Texto{\frx-}Texto",
                Tags.Frx,
                false },
            // Tag: fry.
            // Nulo
            new object[] {
                @"",
                Tags.Fry,
                false },
            // Normal.
            new object[] {
                @"Texto{\fry1}Texto",
                Tags.Fry,
                true },
            // Inválido.
            new object[] {
                @"Texto{\fry-}Texto",
                Tags.Fry,
                false },
            // Tag: fr.
            // Nulo
            new object[] {
                @"",
                Tags.Frz,
                false },
            // Normal.
            new object[] {
                @"Texto{\fr1}Texto",
                Tags.Frz,
                true },
            // Inválido.
            new object[] {
                @"Texto{\fr-}Texto",
                Tags.Frz,
                false },
            // Tag: frz.
            // Nulo
            new object[] {
                @"",
                Tags.Frz,
                false },
            // Normal.
            new object[] {
                @"Texto{\frz1}Texto",
                Tags.Frz,
                true },
            // Inválido.
            new object[] {
                @"Texto{\frz-}Texto",
                Tags.Frz,
                false },
            // Tag: fs.
            // Nulo
            new object[] {
                @"",
                Tags.Fs,
                false },
            // Normal.
            new object[] {
                @"Texto{\fs1}Texto",
                Tags.Fs,
                true },
            // Inválido.
            new object[] {
                @"Texto{\fs-}Texto",
                Tags.Fs,
                false },
            // Tag: fscx.
            // Nulo
            new object[] {
                @"",
                Tags.Fscx,
                false },
            // Normal.
            new object[] {
                @"Texto{\fscx1}Texto",
                Tags.Fscx,
                true },
            // Inválido.
            new object[] {
                @"Texto{\fscx-}Texto",
                Tags.Fscx,
                false },
            // Tag: fscy.
            // Nulo
            new object[] {
                @"",
                Tags.Fscy,
                false },
            // Normal.
            new object[] {
                @"Texto{\fscy1}Texto",
                Tags.Fscy,
                true },
            // Inválido.
            new object[] {
                @"Texto{\fscy-}Texto",
                Tags.Fscy,
                false },
            // Tag: fsp.
            // Nulo
            new object[] {
                @"",
                Tags.Fsp,
                false },
            // Normal.
            new object[] {
                @"Texto{\fsp1}Texto",
                Tags.Fsp,
                true },
            // Inválido.
            new object[] {
                @"Texto{\fsp-}Texto",
                Tags.Fsp,
                false },
            // Tag: i.
            // Nulo
            new object[] {
                @"",
                Tags.I,
                false },
            // Normal.
            new object[] {
                @"Texto{\i1}Texto",
                Tags.I,
                true },
            // Inválido.
            new object[] {
                @"Texto{\i-}Texto",
                Tags.I,
                false },
            // Tag: k.
            // Nulo
            new object[] {
                @"",
                Tags.K,
                false },
            // Normal.
            new object[] {
                @"Texto{\k1}Texto",
                Tags.K,
                true },
            // Inválido.
            new object[] {
                @"Texto{\k-}Texto",
                Tags.K,
                false },
            // Tag: kf.
            // Nulo
            new object[] {
                @"",
                Tags.Kf,
                false },
            // Normal.
            new object[] {
                @"Texto{\kf1}Texto",
                Tags.Kf,
                true },
            // Inválido.
            new object[] {
                @"Texto{\kf-}Texto",
                Tags.Kf,
                false },
            // Tag: ko.
            // Nulo
            new object[] {
                @"",
                Tags.Ko,
                false },
            // Normal.
            new object[] {
                @"Texto{\ko1}Texto",
                Tags.Ko,
                true },
            // Inválido.
            new object[] {
                @"Texto{\ko-}Texto",
                Tags.Ko,
                false },
            // Tag: move.
            // Nulo
            new object[] {
                @"",
                Tags.Move,
                false },
            // Normal.
            new object[] {
                @"Texto{\move(0,0,0,0)}Texto",
                Tags.Move,
                true },
            // Inválido.
            new object[] {
                @"Texto{\move(0)}Texto",
                Tags.Move,
                false },
            // Tag: org.
            // Nulo
            new object[] {
                @"",
                Tags.Org,
                false },
            // Normal.
            new object[] {
                @"Texto{\org(0,0)}Texto",
                Tags.Org,
                true },
            // Inválido.
            new object[] {
                @"Texto{\org(0)}Texto",
                Tags.Org,
                false },
            // Tag: p.
            // Nulo
            new object[] {
                @"",
                Tags.P,
                false },
            // Normal.
            new object[] {
                @"Texto{\p1}Texto",
                Tags.P,
                true },
            // Inválido.
            new object[] {
                @"Texto{\p-}Texto",
                Tags.P,
                false },
            // Tag: pbo.
            // Nulo
            new object[] {
                @"",
                Tags.Pbo,
                false },
            // Normal.
            new object[] {
                @"Texto{\pbo1}Texto",
                Tags.Pbo,
                true },
            // Inválido.
            new object[] {
                @"Texto{\pbo-}Texto",
                Tags.Pbo,
                false },
            // Tag: pos.
            // Nulo
            new object[] {
                @"",
                Tags.Pos,
                false },
            // Normal.
            new object[] {
                @"Texto{\pos(0,0)}Texto",
                Tags.Pos,
                true },
            // Inválido.
            new object[] {
                @"Texto{\pos(0)}Texto",
                Tags.Pos,
                false },
            // Tag: q.
            // Nulo
            new object[] {
                @"",
                Tags.Q,
                false },
            // Normal.
            new object[] {
                @"Texto{\q1}Texto",
                Tags.Q,
                true },
            // Inválido.
            new object[] {
                @"Texto{\q-}Texto",
                Tags.Q,
                false },
            // Tag: r.
            // Nulo
            new object[] {
                @"",
                Tags.R,
                false },
            // Normal.
            new object[] {
                @"Texto{\rDefault}Texto",
                Tags.R,
                true },
            // La invalidez se da si el estilo no existe,
            // así que ese caso no se considera.

            // Tag: s.
            // Nulo
            new object[] {
                @"",
                Tags.S,
                false },
            // Normal.
            new object[] {
                @"Texto{\s1}Texto",
                Tags.S,
                true },
            // Inválido.
            new object[] {
                @"Texto{\s-}Texto",
                Tags.S,
                false },
            // Tag: shad.
            // Nulo
            new object[] {
                @"",
                Tags.Shad,
                false },
            // Normal.
            new object[] {
                @"Texto{\shad1}Texto",
                Tags.Shad,
                true },
            // Inválido.
            new object[] {
                @"Texto{\shad-}Texto",
                Tags.Shad,
                false },
            // Tag: xshad.
            // Nulo
            new object[] {
                @"",
                Tags.ShadX,
                false },
            // Normal.
            new object[] {
                @"Texto{\xshad1}Texto",
                Tags.ShadX,
                true },
            // Inválido.
            new object[] {
                @"Texto{\xshad-}Texto",
                Tags.ShadX,
                false },
            // Tag: yshad.
            // Nulo
            new object[] {
                @"",
                Tags.ShadY,
                false },
            // Normal.
            new object[] {
                @"Texto{\yshad1}Texto",
                Tags.ShadY,
                true },
            // Inválido.
            new object[] {
                @"Texto{\yshad-}Texto",
                Tags.ShadY,
                false },
            // Tag: t.
            // Nulo
            new object[] {
                @"",
                Tags.T,
                false },
            // Normal.
            new object[] {
                @"Texto{\t(\fs32)}Texto",
                Tags.T,
                true },
            // Inválido.
            new object[] {
                @"Texto{\t(()}Texto",
                Tags.T,
                false },
            // Tag: u.
            // Nulo
            new object[] {
                @"",
                Tags.U,
                false },
            // Normal.
            new object[] {
                @"Texto{\u1}Texto",
                Tags.U,
                true },
            // Inválido.
            new object[] {
                @"Texto{\u-}Texto",
                Tags.U,
                false },
        };

        // textoOriginal, textoNuevo, tagOriginal, tagNuevo
        static readonly object[] casosReemplazar = {
            // Tag: a.
            // Tag: alpha.
            // Tag: 1a.
            // Tag: 2a.
            // Tag: 3a.
            // Tag: 4a.
            // Tag: an.
            // Tag: b.
            new object[] {
                @"Texto{comentariob1\b1\tag}Texto{\pos(3,4)}",
                @"Texto{comentariob1\b0\tag}Texto{\pos(3,4)}",
                Tags.B,
                @"\b0" },
            new object[] {
                @"Texto{comentariob1\b1\tag}Texto{\pos(3,4)}",
                @"Texto{comentariob1\fs32\tag}Texto{\pos(3,4)}",
                Tags.B,
                @"\fs32" },
            new object[] {
                @"Texto{comentario\tag}Texto{\pos(3,4)}",
                @"Texto{comentario\tag}Texto{\pos(3,4)}",
                Tags.B,
                @"\fs32" },
            // Tag: be.
            // Tag: bord.
            // Tag: xbord.
            // Tag: ybord.
            // Tag: clip.
            // Tag: iclip.
            // Tag: c.
            // Tag: 1c.
            // Tag: 2c.
            // Tag: 3c.
            // Tag: 4c.
            // Tag: fad.
            // Tag: fade.
            // Tag: fax.
            // Tag: fay.
            // Tag: fe.
            // Tag: fn.
            // Tag: frx.
            // Tag: fry.
            // Tag: frz.
            // Tag: fs.
            new object[] {
                @"Texto{comentario\fs32\tag}Texto{\pos(3,4)}",
                @"Texto{comentario\fs72\tag}Texto{\pos(3,4)}",
                Tags.Fs,
                @"\fs72" },
            // Tag: fscx.
            // Tag: fscy.
            // Tag: fsp.
            // Tag: i.
            // Tag: k.
            // Tag: kf.
            // Tag: ko.
            // Tag: move.
            new object[] {
                @"Texto{comentario\pos(1,2)\tag}Texto{\move(1,2,3,4)}",
                @"Texto{comentario\pos(1,2)\tag}Texto{\move(6,5,4,3,2,1)}",
                Tags.Move,
                @"\move(6,5,4,3,2,1)" },
            // Tag: org.
            // Tag: p.
            // Tag: pbo.
            // Tag: pos.
            new object[] {
                @"Texto{comentario\pos(1,2)\tag}Texto{\pos(3,4)}",
                @"Texto{comentario\pos(100,50)\tag}Texto{\pos(3,4)}",
                Tags.Pos,
                @"\pos(100,50)" },
            // Tag: q.
            // Tag: r.
            // Tag: s.
            // Tag: shad.
            // Tag: xshad.
            // Tag: yshad.
            // Tag: t.
            new object[] {
                @"Texto{comentario\tag}{\t(\fs32\t(\fs42))}Texto{\pos(3,4)}",
                @"Texto{comentario\tag}{\t(\shad0)}Texto{\pos(3,4)}",
                Tags.T,
                @"\t(\shad0)" },
            new object[] {
                @"Texto{comentario\tag}{\t(\fs32\t(\fs42\t(\bord3)))}Texto{\pos(3,4)}",
                @"Texto{comentario\tag}{\t(\shad0)}Texto{\pos(3,4)}",
                Tags.T,
                @"\t(\shad0)" },
            // Tag: u.
        };

        static readonly object[] casosBuscarTag = {
            // Tag: a.
            new object[] {
                @"Texto{comentario\a4\tag}Texto{\a5}",
                Tags.A,
                @"\a4" },
            // Tag: alpha.
            new object[] {
                @"Texto{comentario\alpha&H25&\tag}Texto{\alpha&HFF&}",
                Tags.Alpha,
                @"\alpha&H25&" },
            // Tag: 1a.
            new object[] {
                @"Texto{comentario\1a&H25&\tag}Texto{\1a&HFF&}",
                Tags.Alpha1,
                @"\1a&H25&" },
            // Tag: 2a.
            new object[] {
                @"Texto{comentario\2a&H25&\tag}Texto{\2a&HFF&}",
                Tags.Alpha2,
                @"\2a&H25&" },
            // Tag: 3a.
            new object[] {
                @"Texto{comentario\3a&H25&\tag}Texto{\3a&HFF&}",
                Tags.Alpha3,
                @"\3a&H25&" },
            // Tag: 4a.
            new object[] {
                @"Texto{comentario\4a&H25&\tag}Texto{\4a&HFF&}",
                Tags.Alpha4,
                @"\4a&H25&" },
            // Tag: an.
            new object[] {
                @"Texto{comentario\an8\tag}Texto{\an5}",
                Tags.An,
                @"\an8" },
            // Tag: b.
            new object[] {
                @"Texto{comentario\b1\tag}Texto{\b0}",
                Tags.B,
                @"\b1" },
            // Tag: be.
            new object[] {
                @"Texto{comentario\be1\tag}Texto{\be0}",
                Tags.Be,
                @"\be1" },
            // Tag: bord.
            new object[] {
                @"Texto{comentario\bord1\tag}Texto{\bord0}",
                Tags.Bord,
                @"\bord1" },
            // Tag: xbord.
            new object[] {
                @"Texto{comentario\xbord1\tag}Texto{\xbord0}",
                Tags.BordX,
                @"\xbord1" },
            // Tag: ybord.
            new object[] {
                @"Texto{comentario\ybord1\tag}Texto{\ybord0}",
                Tags.BordY,
                @"\ybord1" },
            // Tag: clip.
            new object[] {
                @"Texto{comentario\clip(1,2,3,4)\tag}Texto{\clip(4,3,2,1)}",
                Tags.Clip,
                @"\clip(1,2,3,4)" },
            new object[] {
                @"Texto{comentario\clip(1,m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)\tag}Texto{\clip(4,3,2,1)}",
                Tags.Clip,
                @"\clip(1,m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)" },
            new object[] {
                @"Texto{comentario\clip(m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)\tag}Texto{\clip(4,3,2,1)}",
                Tags.Clip,
                @"\clip(m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)" },
            // Tag: iclip.
            new object[] {
                @"Texto{comentario\iclip(1,2,3,4)\tag}Texto{\iclip(4,3,2,1)}",
                Tags.ClipI,
                @"\iclip(1,2,3,4)" },
            new object[] {
                @"Texto{comentario\iclip(1,m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)\tag}Texto{\iclip(4,3,2,1)}",
                Tags.ClipI,
                @"\iclip(1,m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)" },
            new object[] {
                @"Texto{comentario\iclip(m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)\tag}Texto{\iclip(4,3,2,1)}",
                Tags.ClipI,
                @"\iclip(m 50 0 b 100 0 100 100 50 100 b 0 100 0 0 50 0)" },
            // Tag: c.
            new object[] {
                @"Texto{comentario\c&H123456&\tag}Texto{\c&H654321&}",
                Tags.Color1,
                @"\c&H123456&" },
            // Tag: 1c.
            new object[] {
                @"Texto{comentario\1c&H123456&\tag}Texto{\1c&H654321&}",
                Tags.Color1,
                @"\1c&H123456&" },
            // Tag: 2c.
            new object[] {
                @"Texto{comentario\2c&H123456&\tag}Texto{\2c&H654321&}",
                Tags.Color2,
                @"\2c&H123456&" },
            // Tag: 3c.
            new object[] {
                @"Texto{comentario\3c&H123456&\tag}Texto{\3c&H654321&}",
                Tags.Color3,
                @"\3c&H123456&" },
            // Tag: 4c.
            new object[] {
                @"Texto{comentario\4c&H123456&\tag}Texto{\4c&H654321&}",
                Tags.Color4,
                @"\4c&H123456&" },
            // Tag: fad.
            new object[] {
                @"Texto{comentario\fad(1,2)\tag}Texto{\fad(2,1)}",
                Tags.Fad,
                @"\fad(1,2)" },
            // Tag: fade.
            new object[] {
                @"Texto{comentario\fade(0,16,32,0,1,2,3)\tag}Texto{\fade(1,2,3,4,5,6)}",
                Tags.Fade,
                @"\fade(0,16,32,0,1,2,3)" },
            // Tag: fax.
            new object[] {
                @"Texto{comentario\fax-2.1\tag}Texto{\fax-1.2}",
                Tags.Fax,
                @"\fax-2.1" },
            // Tag: fay.
            new object[] {
                @"Texto{comentario\fay-2.1\tag}Texto{\fay-1.2}",
                Tags.Fay,
                @"\fay-2.1" },
            // Tag: fe.
            new object[] {
                @"Texto{comentario\fe128\tag}Texto{\fe0}",
                Tags.Fe,
                @"\fe128" },
            // Tag: fn.
            new object[] {
                @"Texto{comentario\feArial Black\tag}Texto{\feArial}",
                Tags.Fe,
                @"\feArial Black" },
            // Tag: frx.
            new object[] {
                @"Texto{comentario\frx-2.1\tag}Texto{\frx-1.2}",
                Tags.Frx,
                @"\frx-2.1" },
            // Tag: fry.
            new object[] {
                @"Texto{comentario\fry-2.1\tag}Texto{\fry-1.2}",
                Tags.Fry,
                @"\fry-2.1" },
            // Tag: frz.
            new object[] {
                @"Texto{comentario\frz-2.1\tag}Texto{\frz-1.2}",
                Tags.Frz,
                @"\frz-2.1" },
            // Tag: fs.
            new object[] {
                @"Texto{comentario\fs2.1\tag}Texto{\fs1.2}",
                Tags.Fs,
                @"\fs2.1" },
            // Tag: fscx.
            new object[] {
                @"Texto{comentario\fscx-2.1\tag}Texto{\fscx-1.2}",
                Tags.Fscx,
                @"\fscx-2.1" },
            // Tag: fscy.
            new object[] {
                @"Texto{comentario\fscy-2.1\tag}Texto{\fscy-1.2}",
                Tags.Fscy,
                @"\fscy-2.1" },
            // Tag: fsp.
            new object[] {
                @"Texto{comentario\fsp-2.1\tag}Texto{\fsp-1.2}",
                Tags.Fsp,
                @"\fsp-2.1" },
            // Tag: i.
            new object[] {
                @"Texto{comentario\i1\tag}Texto{\i0}",
                Tags.I,
                @"\i1" },
            // Tag: k.
            new object[] {
                @"Texto{comentario\k32\tag}Texto{\k0}",
                Tags.K,
                @"\k32" },
            // Tag: kf.
            new object[] {
                @"Texto{comentario\kf32\tag}Texto{\kf0}",
                Tags.Kf,
                @"\kf32" },
            // Tag: ko.
            new object[] {
                @"Texto{comentario\ko32\tag}Texto{\ko0}",
                Tags.Ko,
                @"\ko32" },
            // Tag: move.
            new object[] {
                @"Texto{comentario\move(1,2,3,4,5,6)\tag}Texto{\move(6,5,4,3,2,1)}",
                Tags.Move,
                @"\move(1,2,3,4,5,6)" },
            // Tag: org.
            new object[] {
                @"Texto{comentario\org(1,2)\tag}Texto{\org(6,5)}",
                Tags.Org,
                @"\org(1,2)" },
            // Tag: p.
            new object[] {
                @"Texto{comentario\p1\tag}Texto{\p0}",
                Tags.P,
                @"\p1" },
            // Tag: pbo.
            new object[] {
                @"Texto{comentario\pbo-2.1\tag}Texto{\pbo-1.2}",
                Tags.Pbo,
                @"\pbo-2.1" },
            // Tag: pos.
            new object[] {
                @"Texto{comentario\pos(1,2)\tag}Texto{\org(6,5)}",
                Tags.Pos,
                @"\pos(1,2)" },
            // Tag: q.
            new object[] {
                @"Texto{comentario\q2\tag}Texto{\q0}",
                Tags.Q,
                @"\q2" },
            // Tag: r.
            new object[] {
                @"Texto{comentario\rDefault - Alt\tag}Texto{\rDefault}",
                Tags.R,
                @"\rDefault - Alt" },
            // Tag: s.
            new object[] {
                @"Texto{comentario\s1\tag}Texto{\s0}",
                Tags.S,
                @"\s1" },
            // Tag: shad.
            new object[] {
                @"Texto{comentario\shad-2.1\tag}Texto{\shad-1.2}",
                Tags.Shad,
                @"\shad-2.1" },
            // Tag: xshad.
            new object[] {
                @"Texto{comentario\xshad-2.1\tag}Texto{\xshad-1.2}",
                Tags.ShadX,
                @"\xshad-2.1" },
            // Tag: yshad.
            new object[] {
                @"Texto{comentario\yshad-2.1\tag}Texto{\yshad-1.2}",
                Tags.ShadY,
                @"\yshad-2.1" },
            // Tag: t.
            new object[] {
                @"Texto{comentario\t(\fs32)\tag}Texto{\t(\bord2)}",
                Tags.T,
                @"\t(\fs32)" },
            new object[] {
                @"Texto{comentario\t(\fs32\t(\fs42))\tag}Texto{\t(\bord2)}",
                Tags.T,
                @"\t(\fs32\t(\fs42))" },
            new object[] {
                @"Texto{comentario\t(\t(\t(\fs32)))\tag}Texto{\t(\bord2)}",
                Tags.T,
                @"\t(\t(\t(\fs32)))" },
            new object[] {
                @"Texto{comentario\t(\t(\t(\fs32))ASD\tag}Texto{\t(\bord2)}",
                Tags.T,
                @"\t(\t(\t(\fs32))" },
            new object[] {
                @"Texto{comentario\t(\t(\t(\fs32))\ASD )\tag}Texto{\t(\bord2)}",
                Tags.T,
                @"\t(\t(\t(\fs32))\ASD )" },
            new object[] {
                @"Texto{comentario\t(1,2,3,\t(\t(\fs32))\ASD )\tag}Texto{\t(\bord2)}",
                Tags.T,
                @"\t(1,2,3,\t(\t(\fs32))\ASD )" },
            // Tag: u.
            new object[] {
                @"Texto{comentario\u1\tag}Texto{\u0}",
                Tags.U,
                @"\u1" },
        };

        public static object[] CasosReemplazar => casosReemplazar;

        public static object[] CasosBuscarTag => casosBuscarTag;
        #endregion

        [SetUp]
        public void Iniciar() {
            Funciones.ChangeCulture();
        }

        [Test, Category("Funciones"), TestCaseSource("casosTagExiste")]
        public void FuncionesTagExiste(string texto, Tags t, bool esperado) {
            var real = AssFilter.TagExists(texto, t);
            Assert.AreEqual(esperado, real);
        }
        
        [Test, Category("Filtro")]
        public void FiltroAssFiltrarPropiedades() {
            var _tipo = "Dialogue";
            var _capa = "1";
            var _inicio = "2:22:22.22";
            var _fin = "3:33:33.33";
            var _estilo = "Default";
            var _actor = "Actor";
            var _efecto = "Efecto";
            var _margenI = "4";
            var _margenD = "5";
            var _margenV = "6";
            var _contenido = @"{\pos(100,0)}Con{\pos(0,0)}tenido";

            var s = @"Dialogue: 1,2:22:22.22,3:33:33.33,Default,Actor,4,5,6,Efecto,{\pos(100,0)}Con{\pos(0,0)}tenido";
            var p = AssFilter.FilterProperties(s);

            Assert.AreEqual(_tipo, p[PropertyInfo.PropiedadToString(Property.Type)].Value);

            Assert.AreEqual(_capa, p[PropertyInfo.PropiedadToString(Property.Layer)].Value);

            Assert.AreEqual(_inicio, p[PropertyInfo.PropiedadToString(Property.Start)].Value);

            Assert.AreEqual(_fin, p[PropertyInfo.PropiedadToString(Property.End)].Value);

            Assert.AreEqual(_estilo, p[PropertyInfo.PropiedadToString(Property.Style)].Value);

            Assert.AreEqual(_actor, p[PropertyInfo.PropiedadToString(Property.Actor)].Value);

            Assert.AreEqual(_efecto, p[PropertyInfo.PropiedadToString(Property.Effect)].Value);

            Assert.AreEqual(_margenI, p[PropertyInfo.PropiedadToString(Property.MarginLeft)].Value);

            Assert.AreEqual(_margenD, p[PropertyInfo.PropiedadToString(Property.MarginRight)].Value);

            Assert.AreEqual(_margenV, p[PropertyInfo.PropiedadToString(Property.MarginVertical)].Value);

            Assert.AreEqual(_contenido, p[PropertyInfo.PropiedadToString(Property.Content)].Value);
        }
        
        [Test, Category("Filtro"), TestCaseSource("casosBuscarTag")]
        public void FiltroAssBuscar(string texto, Tags tag, string esperado) {
            var resultado = AssFilter.SearchTag(texto, tag).Value;
            Assert.AreEqual(esperado, resultado);
        }
        
        [Test, Category("Filtro"), TestCaseSource("casosReemplazar")]
        public void PruebaReemplazar(string textoOriginal, string textoNuevo, Tags tagOriginal, string tagNuevo) {
            var resultado = AssFilter.ReplaceTag(textoOriginal, tagOriginal, tagNuevo);
            Assert.AreEqual(textoNuevo, resultado);
        }
    }
}
