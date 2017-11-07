#!/usr/bin/env bash
dotnet restore ./tests/Solcast.Tests.csproj
dotnet build ./tests/Solcast.Tests.csproj
dotnet test ./tests/Solcast.Tests.csproj