SET MSBUILD_PATH="%ProgramFiles(x86)%\MSBuild\14.0\bin"

%MSBUILD_PATH%\msbuild src\ArgeHeiwako.NET.sln /p:Configuration="Release 4.0"
%MSBUILD_PATH%\msbuild src\ArgeHeiwako.NET.sln /p:Configuration="Release 4.5"
%MSBUILD_PATH%\msbuild src\ArgeHeiwako.NET.sln /p:Configuration="Release 4.6"

Pause