dotnet "C:\Program Files\dotnet\sdk\5.0.302\MSBuild.dll" /p:Configuration=Release
mkdir Release
cp ./AdofaiUtils/bin/Release/AdofaiUtils.dll ./Release/AdofaiUtils.dll
cp ./Info.json ./Release/Info.json
tar -acf AdofaiUtils-1.0.zip Release
rm -rf Release
pause