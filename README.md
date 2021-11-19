# stackage-aws-lambda-dotnet-new

The `Stackage.Aws.Lambda.DotNetNew.Templates` package contains a template for `dotnet new` to create a solution with a skeleton AWS Lambda function.

## Installation

To install the `Stackage.Aws.Lambda.DotNetNew.Templates` package use the `dotnet new --install` command.

```
dotnet new --install Stackage.Aws.Lambda.DotNetNew.Templates
```

To update to the latest version of the `Stackage.Aws.Lambda.DotNetNew.Templates` package use the `dotnet new --update-apply` command.

```
dotnet new --update-apply --package Stackage.Aws.Lambda.DotNetNew.Templates
```

## Usage

To create a new solution containing an AWS Lambda function use the `dotnet new stackagelambda` command, replacing `{LAMBDA_NAME}` as required (eg. `Lambda.Function`). This will create both a folder and a project named `{LAMBDA_NAME}` for your AWS Lambda function.

```
dotnet new stackagelambda --name {LAMBDA_NAME}
```

## Contributing

If you would like to contribute, please read through the [CONTRIBUTING.md](./CONTRIBUTING.md) document.
