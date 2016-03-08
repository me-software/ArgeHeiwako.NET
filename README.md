# ArgeHeiwako.NET
SDK für das Erstellen und Verarbeiten von Datenaustauschdateien nach ARGE-Heiwako (http://www.arge-heiwako.de/)

# Aktuelle Spezifikationen
Die aktuellen Spezifikationen, sowie die historischen Dokumente können hier heruntergeladen werden.
http://www.arge-heiwako.de/204-0-standard-datenaustausch.html

# Getting Started
Für den schnellen Einstieg und das Erstellen von Daten kann der folgende Code verwendet werden:

```csharp
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new FileStream("/path/to/file", FileMode.Open))
            {
                var file = ArgeHeiwako.IO.OrdnungsbegriffeFile.Load(stream);
                foreach(var ordnungsbegriffe in file.Ordnungsbegriffe)
                {
                    Console.WriteLine(ordnungsbegriffe.ToString());
                }
            }
        }
    }
}
```

# Links
Waffle-Agile-Board: https://waffle.io/me-software/ArgeHeiwako.NET

# Statistiken
[![Throughput Graph](https://graphs.waffle.io/me-software/ArgeHeiwako.NET/throughput.svg)](https://waffle.io/me-software/ArgeHeiwako.NET/metrics)
