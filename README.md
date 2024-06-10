# Agile Content

## Objectives:

Create application to format default Log to any format. Just in this case, only work with Agora format, but it is open to new format implementations.

## How to use:
- You will need the latest Visual Studio 2022 and the latest .NET Core SDK.
- The latest SDK and tools can be downloaded from https://dot.net/core.

Also you can run the Equinox Project in Visual Studio Code (Windows, Linux or MacOS).

## Technologies implemented:

- Microsoft.Extensions.DependencyInjection.Abstractions
- NUnit

## Architecture:
- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)

## How to run:

For to run this app, need to type `dotnet run http://logstorage.com/minhaCdn1.txt ./output/minhaCdn1.txt`

Exist 3 parameters to run:
- 1 parameter is Source Path, you can use local path or http url
- 2 parameter is local path in your machine to save file
- 3 parameter (optinal) is the name of Provider log

