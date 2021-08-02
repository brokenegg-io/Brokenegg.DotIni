# Brokenegg.io DotIni

DotIni is a library for .Net that allows you to read, convert and save ini files, important for envinronment variables.

[![Build Status](https://travis-ci.org/brokenegg-io/Brokenegg.DotIni.png?branch=master)](https://travis-ci.org/brokenegg-io/Brokenegg.DotIni)


## Installation

Our profile on the NuGet library [brokenegg.io](https://www.nuget.org/profiles/brokenegg.io)

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
iniFile.AddKeyParLastSection("lang", "enUS");

//parsing back to string
var newContent = iniFile.ToString();

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

[get@brokenegg.io](mailto:get@brokenegg.io)

## License
[MIT](https://choosealicense.com/licenses/mit/)
