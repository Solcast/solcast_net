#!/usr/bin/env bash
dotnet restore ./tests/zSolcast.Tests.csproj
dotnet build ./tests/zSolcast.Tests.csproj
dotnet test ./tests/zSolcast.Tests.csproj