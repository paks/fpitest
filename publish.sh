#!/usr/bin/env bash
dotnet publish -r linux-arm /p:ShowLinkerSizeComparison=true
pushd ./bin/Debug/netcoreapp2.2/linux-arm/publish
scp -v -r . raspberrypi3b:/home/pi/Documents/Projects/fpitest
popd