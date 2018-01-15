﻿using Asu.Utilidades.Constantes;
using System.Text.RegularExpressions;

namespace Asu.Utilidades.Clases {
    /// <summary>
    /// Representa un tag alpha de bordes del formato ASS.
    /// </summary>
    public class TagAlpha3 : TagTypeAlpha {
        public override string Nombre => "3a";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAlpha3"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagAlpha3(string texto) {
            var regex = new Regex(ExpresionesRegulares.regexTagAlpha3);
            var match = regex.Match(texto);
            if (match.Success) {
                var regex2 = new Regex(ExpresionesRegulares.regexAlpha);
                var match2 = regex2.Match(match.Groups["arg"].Value);
                if (match2.Success) {
                    var alpha = match2.Groups["arg"].Value;
                    if (alpha != "") {
                        Argumento = int.Parse(alpha, System.Globalization.NumberStyles.HexNumber);
                    } else {
                        Argumento = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagAlpha3"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagAlpha3(int arg) {
            Argumento = arg;
        }
    }
}
