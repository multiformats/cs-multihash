#!/usr/bin/env bash

nuget pack ./Multiformats.Hash/Multiformats.Hash.csproj -IncludeReferencedProjects -Properties Configuration=Release
nuget push ./Multiformats.Hash.$NUGET_VERSION.nupkg -ApiKey $NUGET_APIKEY
