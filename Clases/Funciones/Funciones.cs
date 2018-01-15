using Asu.Utilidades.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Net;
using System.Windows;

namespace Asu.Utilidades {
    /// <summary>
    /// Proporciona funciones estáticas y generales para trabajar.
    /// </summary>
    public static class Funciones {
        /// <summary>
        /// Establece la cultura del proceso actual para el uso de puntos decimales en vez de comas. Ideal para el sistema internacional.
        /// </summary>
        public static void CambiarCultura() {
            // Clonando cultura actual.
            var customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            // Cambiando separador de decimales a punto: #.###
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            // Estableciendo nueva cultura al proceso actual.
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        /// <summary>
        /// Establece la cultura del proceso actual para el uso de coma en vez de puntos.
        /// </summary>
        public static void RestaurarCultura() {
            // Clonando cultura actual.
            var customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            // Cambiando separador de decimales a punto: #.###
            customCulture.NumberFormat.NumberDecimalSeparator = ",";
            // Estableciendo nueva cultura al proceso actual.
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }
        
        /// <summary>
        /// Inicia el proceso de descarga de un archivo alojado en un servidor con protocolo FTP.
        /// </summary>
        /// <param name="url">Dirección del archivo.</param>
        /// <param name="directorioDestino">Directorio de destino.</param>
        public static void DescargarFtp(string url, string directorioDestino) {
            var solicitud = (FtpWebRequest)WebRequest.Create(url);
            solicitud.Method = WebRequestMethods.Ftp.DownloadFile;
            solicitud.Credentials = new NetworkCredential("", "");
            solicitud.UseBinary = true;

            using (var respuesta = (FtpWebResponse)solicitud.GetResponse()) {
                using (var rs = respuesta.GetResponseStream()) {
                    using (var ws = new FileStream(directorioDestino, FileMode.Create)) {
                        var buffer = new byte[2048];
                        var bytesRead = rs.Read(buffer, 0, buffer.Length);

                        while (bytesRead > 0) {
                            ws.Write(buffer, 0, bytesRead);
                            bytesRead = rs.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Devuelve la versión del sistema operativo.
        /// </summary>
        public static string ObtenerSO() {
            var result = string.Empty;
            var searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get()) {
                result = os["Caption"].ToString();
                break;
            }
            return result;
        }

        /// <summary>
        /// Coloca una lista de líneas en formato ASS en el portapapeles.
        /// </summary>
        /// <param name="lista"></param>
        public static void ClipboardSetLines(List<Linea> lista) {
            var resultado = "";
            foreach (var l in lista) {
                resultado += l.ToString() + Environment.NewLine;
            }

            Clipboard.SetText(resultado);
        }

        /// <summary>
        /// Coloca una arreglo de cadenas en el portapapeles.
        /// </summary>
        /// <param name="arreglo"></param>
        public static void ClipboardSetLines(string[] arreglo) {
            var resultado = "";
            foreach (var l in arreglo) {
                resultado += l.ToString() + Environment.NewLine;
            }

            Clipboard.SetText(resultado);
        }

        /// <summary>
        /// Coloca una lista de cadenas en el portapapeles.
        /// </summary>
        /// <param name="lista"></param>
        public static void ClipboardSetLines(List<string> lista) {
            ClipboardSetLines(lista.ToArray());
        }

        /// <summary>
        /// Devuelve el texto presente en el portapapeles.
        /// </summary>
        public static string ClipboardGet() {
            var texto = "";
            var iData = Clipboard.GetDataObject();

            if (iData.GetDataPresent(DataFormats.Text)) {
                texto = (string)iData.GetData(DataFormats.Text);
            }

            return texto;
        }

        /// <summary>
        /// Devuelve una matriz lineal con todas las líneas en el portapapeles.
        /// </summary>
        public static string[] ClipboardGetLines() {
            var lineas = ClipboardGet().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            return lineas;
        }
        
        #region Contructores Mensaje()
        /// <summary>
        /// Genera un diálogo de advertencia con el booleano ingresado.
        /// </summary>
        /// <param name="lista">Lista con elementos a mostrar.</param>
        public static void Mensaje(bool b) {
            MessageBox.Show("" + b, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con el texto ingresado.
        /// </summary>
        /// <param name="texto">Texto a mostrar.</param>
        public static void Mensaje(string texto) {
            var resultado = MessageBox.Show(texto, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con el texto ingresado.
        /// Permite argumentos para string.Format().
        /// </summary>
        /// <param name="texto">Texto a mostrar.</param>
        /// <param name="args">Argumentos para string.Format().</param>
        static public void Mensaje(string texto, params object[] args) {
            MessageBox.Show(String.Format(texto, args), "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con los elementos de una lista.
        /// </summary>
        /// <param name="lista">Lista con elementos a mostrar.</param>
        public static void Mensaje(IEnumerable<string> lista) {
            var texto = "";
            foreach (var l in lista) {
                texto += string.Format("\n{0}", l);
            }
            MessageBox.Show(texto, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con el número ingresado.
        /// </summary>
        /// <param name="lista">Lista con elementos a mostrar.</param>
        public static void Mensaje(double n) {
            MessageBox.Show("" + n, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con el número ingresado.
        /// </summary>
        /// <param name="lista">Lista con elementos a mostrar.</param>
        public static void Mensaje(decimal n) {
            MessageBox.Show("" + n, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con el número ingresado.
        /// </summary>
        /// <param name="lista">Lista con elementos a mostrar.</param>
        public static void Mensaje(int n) {
            MessageBox.Show("" + n, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con el número ingresado.
        /// </summary>
        /// <param name="lista">Lista con elementos a mostrar.</param>
        public static void Mensaje(float d) {
            MessageBox.Show("" + d, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con el número ingresado.
        /// </summary>
        /// <param name="lista">Lista con elementos a mostrar.</param>
        public static void Mensaje(Int16 n) {
            MessageBox.Show("" + n, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con el número ingresado.
        /// </summary>
        /// <param name="lista">Lista con elementos a mostrar.</param>
        public static void Mensaje(Int64 n) {
            MessageBox.Show("" + n, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con el número ingresado.
        /// </summary>
        /// <param name="lista">Lista con elementos a mostrar.</param>
        public static void Mensaje(UInt16 n) {
            MessageBox.Show("" + n, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con el número ingresado.
        /// </summary>
        /// <param name="lista">Lista con elementos a mostrar.</param>
        public static void Mensaje(UInt32 n) {
            MessageBox.Show("" + n, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con el número ingresado.
        /// </summary>
        /// <param name="lista">Lista con elementos a mostrar.</param>
        public static void Mensaje(UInt64 n) {
            MessageBox.Show("" + n, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con el número ingresado.
        /// </summary>
        /// <param name="lista">Lista con elementos a mostrar.</param>
        public static void Mensaje(byte n) {
            MessageBox.Show("" + n, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Genera un diálogo de advertencia con el número ingresado.
        /// </summary>
        /// <param name="lista">Lista con elementos a mostrar.</param>
        public static void Mensaje(SByte n) {
            MessageBox.Show("" + n, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        #endregion
    }
}
