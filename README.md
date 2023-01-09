# Asu.Utilidades
Library on .NET Framework to work with subtitles on ASS format.

## Requirements
- Microsoft .Net Framework 4.0 or higher.
- NUnit Framework 3.9.

## Some use cases

### Read an ASS file:
````csharp
const string path = "Lucky Star S2 - 01.ass";
var assFile = AssFile.Open(path);
````
### Parse and modify a line:
````csharp
const string rawLine = @"Dialogue: 0,0:44:14.79,0:44:15.68,Default,Kota,0,0,0,,What?";

var line = new Line(rawLine);
var tag = new TagBe(5);
line.Content = string.Format("{{{0}}}{1}", tag.ToString(), line.Content);
````

### Parse a karaoke:
````csharp
const string rawLine = @"Comment: 0,0:01:47.02,0:01:53.69,Nexus,,0,0,0,karaoke,{\kf27}tsu{\kf23}ku{\kf18}ri{\kf25}mo{\kf46}no {\kf20}ja{\kf26}na{\kf26}i{\kf21} {\kf14}ha{\kf27}p{\kf25}pi{\kf25}i {\kf24}e{\kf24}n{\kf14}do {\kf282}he";

var line = new Line(rawLine);
var karaoke = new Karaoke(line.Content);
````
### Check fonts on an ASS file:
````csharp
const string path = "Boku wa Tomodachi ga Sukunai S3 - 02.ass";
var assFile = new AssFile(path);
Console.WriteLine("File loaded: {0}\n", assFile.Name);

foreach (var style in assFile.Styles) {
    try {
        var font = new System.Drawing.FontFamily(style.FontName);
        Console.WriteLine("The font {0} exists.", style.FontName);
    } catch (Exception) {
        Console.WriteLine("The font {0} doesn't exist.", style.FontName);
    }
}
````
### Modify tag \pos(x,y) on all non-commented dialogue lines:
````csharp
// Open the file.
const string path = "Darker than Black S3 - 01.ass";
var assFile = new AssFile(path);

// Filter the lines that have the target tag.
var targetLines = (
    from line in assFile.Events
    where line.Type == LineType.Dialogue
    where AssFilter.TagExists(line.Content, Tags.Pos) == true
    select line
);

// Modify the lines.
foreach (var line in targetLines) {
    var tagRaw = AssFilter.SearchTag(line.Content, Tags.Pos).Value;
    var tag = new TagPos(tagRaw);
    tag.X += 10;
    tag.Y -= 10;
    line.Content = AssFilter.ReplaceTag(line.Content, Tags.Pos, tag.ToString());
}

// Save the file.
assFile.Save(true);
````
