# Brokenegg.io DotIni

![GitHub](https://img.shields.io/github/license/brokenegg-io/Brokenegg.DotIni)
[![version](https://img.shields.io/badge/version-0.0.4-yellow.svg)](https://semver.org)
![fluxo de trabalho de exemplo](https://github.com/brokenegg-io/Brokenegg.DotIni/actions/workflows/ci.yml/badge.svg)
![GitHub branch checks state](https://img.shields.io/github/checks-status/brokenegg-io/Brokenegg.DotIni/master)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Brokenegg.DotIni.svg)](https://www.nuget.org/packages/Brokenegg.DotIni/)

<img src="https://raw.githubusercontent.com/brokenegg-io/Brokenegg.DotIni/master/dotini.png" alt="drawing" width="128"/>

DotIni is a library for .Net that allows you to serialize and deserialize INI files.
This is no a Json/XML (des)serializer in any way, shape or form, it is intended to work only with ini files as shown bellow:

```ini
[section]
attribute=value
```

## Quick links

* [Installation](#installation)
*  [Usage](#usage)
* [Contributing](#contributing)
* [Roadmap](#roadmap)
* [License](#license)

## Installation

Our profile on the NuGet library [brokenegg.io](https://www.nuget.org/profiles/brokenegg.io)

Use the package manager [NuGet](https://www.nuget.org/) to install DotIni.

```bash
nuget install brokenegg.dotini
```

## Usage


### Serializing

```csharp

using Brokenegg.DotIni;

//instantiating the inifile object
var iniFile = new IniFile();

//adding section
iniFile.AddSection("section");

//adding key-par
iniFile.AddKeyParLastSection("lang", "enUS");

//parsing to string
var newContent = iniFile.ToString();

```

The serialization value in the variable `newContent` should be this one:
```ini
[section]
lang=enUS
```

### Deserializing

```csharp
using System.IO;
using Brokenegg.DotIni;

// reading a file
var file = File.ReadAllLines("test.ini");

//parsing file
var iniFile = IniConvert.DeserializeObject(file);

```

`iniFile` will be the instance of Brokenegg.DotIni.IniFile, responsible for handling the sections and key-par values of an INI file.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

[get@brokenegg.io](mailto:get@brokenegg.io)

## Roadmap

- [x] Implement basic serialization and deserialization to be used. Planned to v0.0.5
- [ ] Allow to convert any class into an INI file structure.  Planned to v0.0.6
- [ ] Start github wiki page and begin documentation.
- [ ] Convert values from Key-par values to String/Int/Decimal and Date. Planned to v0.0.7

## License
[MIT](https://choosealicense.com/licenses/mit/)
