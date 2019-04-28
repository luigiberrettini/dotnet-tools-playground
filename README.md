# dotnet-tools-playground

A tool based on the [dotnetsay sample](https://github.com/dotnet/core/tree/master/samples/dotnetsay) to experiment how to create and use [.NET Core Global Tools](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools)

A detailed [tutorial](https://natemcmaster.com/blog/2018/05/12/dotnet-global-tools/) ([PDF](tutorial-natemcmaster.pdf)) has been written by Nate McMaster ([@natemcmaster](https://github.com/natemcmaster))


## Project file

To [create](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools-how-to-create) a tool:
 - the project type must be a console application (`OutputType` set to `Exe`: `Library` will not run)
 - the target framework must be [.NET Core 2.1](https://dotnet.microsoft.com/download/dotnet-core/2.1) or higher (lower or .NET Standard do not work)
 - the `PackAsTool` property must be set to `true`
 - the `ToolCommandName` property can be specified not to name the tool after the project file

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.1</TargetFramework>
    <PackAsTool>true</PackAsTool>
  </PropertyGroup>
</Project>
```


## Starting from source code

Move to the root of the repository

```shell
cd say-default

# Create
dotnet pack sayd.csproj --configuration release --output nupkg

# Install
# The PackageId property defaults to the project file name
# On Linux and macOS replace backslash with forward slash

dotnet tool install sayd --add-source .\nupkg --global

# Run
# Open a new shell to refresh the PATH environment variable (tool directory added to it on first install)
sayd

# Uninstall
# The PackageId property defaults to the project file name
dotnet tool uninstall sayd --global
```


## Starting from a [NuGet](https://www.nuget.org/packages/dotnetsay/) package

```shell
# Install
dotnet tool install dotnetsay --global [--version <VERSION>]

# Run
# Open a new shell to refresh the PATH environment variable (tool directory added to it on first install)
dotnetsay

# Uninstall
dotnet tool uninstall dotnetsay --global
```


## Using a custom tool command name (only starting from source code info)

Move to the root of the repository

```shell
cd say-toolcommandname

# Create
dotnet pack saytcn.csproj --configuration release --output nupkg

# Install
# The PackageId property defaults to the project file name
# On Linux and macOS replace backslash with forward slash
dotnet tool install saytcn --add-source .\nupkg --global

# Run
# Open a new shell to refresh the PATH environment variable (tool directory added to it on first install)
dotnet-foobar
dotnet foobar

# Uninstall
# The PackageId property defaults to the project file name
dotnet tool uninstall saytcn --global
```


## Specifying a tool install path (only starting from source code info)

Move to the root of the repository

```shell
# Create
dotnet pack saytcn.csproj --configuration release --output nupkg

# Install
# The PackageId property defaults to the project file name
# On Linux and macOS replace backslash with forward slash
dotnet tool install saytcn --add-source .\nupkg --tool-path <PATH>

# Run
# Open a new shell to refresh the PATH environment variable (tool directory added to it on first install)
# On Linux and macOS replace backslash with forward slash
<PATH>\dotnet-foobar

# Uninstall
# The PackageId property defaults to the project file name
dotnet tool uninstall saytcn --tool-path <PATH>