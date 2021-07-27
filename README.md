# Brokenegg.io DotIni

DotIni is a library for .Net that allows you to read, convert and save ini files, important for envinronment variables.

## Installation

We are under avaliation by the Microsoft Team, so fo now there is our NugetPage
[brokenegg.io](https://www.nuget.org/profiles/brokenegg.io)

Use the package manager [NuGet](https://www.nuget.org/) to install DotIni.

```bash
nuget install brokenegg.dotini
```

## Usage

```csharp
using System.IO;
using Brokenegg.DotIni;

// reading a file
var file = File.ReadAllLines("test.ini");

//parsing file
var iniFile = IniConvert.DeserializeObject(file);

//adding section
iniFile.AddSection("section");

//adding key-par
iniFile .AddKeyParLastSection("lang", "enUS");

//parsing back to string
var newContent = inifile.ToString();

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

[bokenegg@outlook.com](mailto:bokenegg@outlook.com)

## License
[MIT](https://choosealicense.com/licenses/mit/)
