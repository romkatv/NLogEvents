@echo off

REM This script must be run from the root of NLogEvents project (the current
REM directory must contain NLogEvents.sln). It builds the whole solution and
REM pushes a new version of NLog.Events to nuget.org.

SET DEVENV="C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\devenv.com"

cd NLogEvents || goto :error
%DEVENV% /rebuild Release NLogEvents.sln || goto :error
if exist *.nupkg (del *.nupkg || goto :error)
nuget pack NLogEvents.csproj -IncludeReferencedProjects -Prop Configuration=Release || goto :error
nuget push -Source https://nuget.org *.nupkg || goto :error
cd .. || goto :error

goto :EOF
:error
echo Failed with error #%errorlevel%.
exit /b %errorlevel%
