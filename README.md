# Brokenegg.io DotIni

![GitHub License](https://img.shields.io/github/license/brokenegg-io/Brokenegg.DotIni)
[![Version](https://img.shields.io/badge/version-0.0.4-brightgreen.svg)](https://semver.org)
![Actions](https://github.com/brokenegg-io/Brokenegg.DotIni/actions/workflows/ci.yml/badge.svg)
![Actions](https://github.com/brokenegg-io/Brokenegg.DotIni/actions/workflows/release.yml/badge.svg)
![GitHub branch checks state](https://img.shields.io/github/checks-status/brokenegg-io/Brokenegg.DotIni/dev)
![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/brokenegg-io/Brokenegg.DotIni)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Brokenegg.DotIni.svg)](https://www.nuget.org/packages/Brokenegg.DotIni/)

<img src="https://raw.githubusercontent.com/brokenegg-io/Brokenegg.DotIni/master/designs/dot_ini_transparent.png" alt="drawing" width="128"/>

DotIni is a library for .Net that allows you to serialize and deserialize INI files.
This is not a Json/XML (des)serializer in any way, shape or form, it is intended to work only with ini files as shown bellow:

```ini
[section]
attribute=value
```
We are currently in <strong>alpha version</strong> and we advise to not use in a production environment in any way whatsoever. 

## Quick links

* [Installation](#installation)
* [Usage](#usage)
    * [Serializing](#serializing)  
    * [Deserializing](#deserializing)
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
var content = iniFile.ToString();

```

The serialization value in the variable `content` should be this one:
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

- [x] Implement basic serialization and deserialization to be used. Planned to v0.0.4;
- [x] Cover at least 60% of the projects on unity tests. Planned to v0.1.0;
- [ ] Allow to convert any class into an INI file structure. Planned to v0.2.0;
- [ ] Start github wiki page and begin documentation;
- [ ] Convert values from Key-par values to String/Int/Decimal and Date. Planned to v0.3.0.

## License
[MIT](https://choosealicense.com/licenses/mit/)
