FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /lambda

RUN apt-get update \
   && apt-get install -y zip clang zlib1g-dev

COPY ./Stackage.LambdaPackage/Stackage.LambdaPackage.csproj ./Stackage.LambdaPackage/Stackage.LambdaPackage.csproj
COPY ./Stackage.LambdaPackage.Tests/Stackage.LambdaPackage.Tests.csproj ./Stackage.LambdaPackage.Tests/Stackage.LambdaPackage.Tests.csproj

RUN dotnet restore ./Stackage.LambdaPackage/Stackage.LambdaPackage.csproj
RUN dotnet restore ./Stackage.LambdaPackage.Tests/Stackage.LambdaPackage.Tests.csproj

COPY . .

RUN dotnet test ./Stackage.LambdaPackage.Tests/Stackage.LambdaPackage.Tests.csproj

# Amazon.Lambda.Tools doesn't yet support .NET 8, so reverting to dotnet publish and zip rather than dotnet lambda package
RUN dotnet publish --configuration Release --self-contained --runtime linux-x64 ./Stackage.LambdaPackage/Stackage.LambdaPackage.csproj

RUN cd /lambda/Stackage.LambdaPackage/bin/Release/net8.0/linux-x64/publish && zip -r /lambda/Stackage.LambdaPackage.zip .
