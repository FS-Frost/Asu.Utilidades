# Asu.Utilidades
Librería en .NET Framework para trabajar con el formato de subtítulos ASS.

## Requisitos para su uso
- Microsoft .Net Framework 4.0 o mayor.
- NUnit Framework 3.9.

## Ejemplos

### Leer un archivo ASS:
````csharp
const string ruta = "Mi Archivo.ass";
var archivoASS = ArchivoASS.Abrir(ruta);
````
### Generar un karaoke:
````csharp
const string lineaRaw = @"Comment: 0,0:01:47.02,0:01:53.69,Nexus,,0,0,0,karaoke,{\kf27}tsu{\kf23}ku{\kf18}ri{\kf25}mo{\kf46}no {\kf20}ja{\kf26}na{\kf26}i{\kf21} {\kf14}ha{\kf27}p{\kf25}pi{\kf25}i {\kf24}e{\kf24}n{\kf14}do {\kf282}he";

var linea = new Linea(lineaRaw);
var karaoke = new Karaoke(linea.ToString());
````
### Verificar fuentes de un archivo:
````csharp
const string ruta = "Mi archivo.ass";
var archivoASS = new ArchivoASS(ruta);
Console.WriteLine("Archivo cargado: {0}\n", archivoASS.Nombre);

foreach (var estilo in archivoASS.Styles) {
    try {
        var fuente = new FontFamily(estilo.FontName);
        Console.WriteLine("La fuente {0} existe.", estilo.FontName);
    } catch (Exception) {
        Console.WriteLine("La fuente {0} no existe.", estilo.FontName);
    }
}
````
