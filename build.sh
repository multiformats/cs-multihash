#!/usr/bin/env bash

mono=${MONO:=0}
dotnet=${DOTNET:=0}

test_name=Multiformats.Hash.Tests
test_project=./test/$test_name/$test_name.csproj
cli_name=Multiformats.Hash.CLI
cli_project=./src/$cli_name/$cli_name.csproj

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
    dotnet restore $test_project --disable-parallel --runtime osx-x64
    dotnet restore $cli_project --disable-parallel --runtime osx-x64
  else
    dotnet restore $test_project --runtime ubuntu-x64
    dotnet restore $cli_project --runtime ubuntu-x64
  fi

  dotnet test $test_project --configuration Release --framework netcoreapp2.0 --no-restore --blame
  dotnet build $cli_project --configuration Release --framework netcoreapp2.0 --no-restore
fi

if [ $mono -eq 1 ]; then
  echo "* building and testing mono"
  export FrameworkPathOverride=$(dirname $(which mono))/../lib/mono/4.5/
  msbuild $test_project /property:Configuration=Release,TargetFramework=net461,Platform=x64 /restore:true
  mono $HOME/.nuget/packages/xunit.runner.console/*/tools/net452/xunit.console.exe ./test/$test_name/bin/x64/Release/net461/$test_name.dll

  msbuild $cli_project /property:Configuration=Release,TargetFramework=net461,Platform=x64 /restore:true
fi
