#!/usr/bin/env bash

mono=${MONO:=0}
dotnet=${DOTNET:=0}

name=Multiformats.Hash.Tests
project=./test/$name/$name.csproj

case "$1" in
  dotnet)
    dotnet=1
    mono=0
    ;;
  mono)
    mono=1
    dotnet=0
    ;;
esac

echo "* settings: mono=$mono, dotnet=$dotnet"

set -e

if [ $dotnet -eq 1 ]; then
  echo "* building and testing dotnet"

  if [ "$TRAVIS_OS_NAME" == "osx" ]; then
    ulimit -n 1024
    dotnet restore $project --disable-parallel --runtime osx-x64
  else
    dotnet restore $project --runtime ubuntu-x64
  fi

  dotnet test $project -c Release -f netcoreapp2.0 --blame
fi

if [ $mono -eq 1 ]; then
  echo "* building and testing mono"
  export FrameworkPathOverride=$(dirname $(which mono))/../lib/mono/4.5/
  nuget restore
  msbuild $project /p:Configuration=Release /p:Platform=net461
  mono $HOME/.nuget/packages/xunit.runner.console/*/tools/net452/xunit.console.exe ./test/$name/bin/net461/Release/net461/$name.dll
fi
