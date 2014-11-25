rem @echo off
@cls

Set TargetscriptsFolder=D:\Test\Scripts
Set TargetCodeFolder=D:\Test\SourceCode
Set TargetDataFolder=D:\Test\Data

Set SourceScriptFolder=D:\Test\Deployment\Scripts
Set SourceCodeFolder=D:\Test\Deployment\SourceCode
Set SourceDataFolder=D:\Test\Deployment\Data
rem  xcopy D:\Test  D:\Test\Deployment
rem mkdir needed folder
if not exist %TargetscriptsFolder% (
	mkdir %TargetscriptsFolder%
)
	
if not exist %TargetCodeFolder% (	
	mkdir %TargetCodeFolder%
)
	
if not exist %TargetDataFolder% (
	mkdir %TargetDataFolder%
)

rem move source folder to target folder
rem /F /R /L /E
xcopy /F /R /L /Y /T /S /E /H /I %SourceScriptFolder% %TargetscriptsFolder%  
xcopy /F /R /L /Y /T /S /E /H /I %SourceCodeFolder% %TargetCodeFolder%    
xcopy  /F /R /L /Y /T /S /E /H /I %SourceDataFolder% %TargetDataFolder%   
	


