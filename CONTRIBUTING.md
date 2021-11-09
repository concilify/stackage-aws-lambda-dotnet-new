# Contributing

## Developing Locally

It's possible to build and install the Lambda Template locally without having to push to the NuGet repository. There is no need to uninstall any previously installed version.

From the root of the repository, install the source directly.

```
dotnet new --install ./templates
```

From the root of the repository, build and install the Lambda Template package.

```
./build.ps1
dotnet new --install ./Stackage.Aws.Lambda.DotNetNew.Templates.{VERSION}.nupkg
```

Alternatively, if you've built a package which has been published to NuGet, you can install it from NuGet. You will need to specify the version number explicitly if you don't want the latest version or you want a pre-release version.

```
dotnet new --install Stackage.Aws.Lambda.DotNetNew.Templates[::{VERSION}]
```
