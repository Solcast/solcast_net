#!/usr/bin/env bash
dotnet restore ./tests/solcast.tests.csproj
dotnet build ./tests/solcast.tests.csproj
dotnet test ./tests/solcast.tests.csproj