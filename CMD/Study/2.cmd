@echo off
:: %1 means the first one parameter.
if [%1]==[A] echo xiao
if "%2"=="B" echo tian
if "%3"=="C" echo xin

rem copy file
del /f /s /q /a  "C:\Users\lideng\Desktop\CMD\log"
:: del /?
xcopy  "C:\Users\lideng\Desktop\CMD1"  "C:\Users\lideng\Desktop\CMD\log"
:: the level must from big to small, otherwise has error.
if errorlevel 1 echo copy failed
if errorlevel 0 echo copy successfully

:: ### if [not] exit [dir\] filename 
:: if has file then return true ,else run next 

IF EXIST filename.txt (
    Echo deleting filename.txt
    Del filename.txt
    goto Syntax
 ) ELSE ( 
    Echo The file was not found.
    goto Bad
 )
 ::before ( has one space,otherwise wrong
IF EXIST 1.cmd (     
   echo file is here 
) else (
   echo file is not here   
)

::if go to here ,the upper statement will not run
:Syntax
Echo.
Echo good job
Echo file has deleted
:end   

:Bad
Echo.
Echo bad job
Echo file does not exist.
:end

IF NOT EXIST 3.CMD ECHO 3.CMD does not exist.
:: after in have to space ,otherwise has error
For %%i in (C:\Users\lideng\Desktop\GIT\Project\CMD\log\*.txt) do echo %%i
:: from start to end by step number series
::FOR /L %variable IN (start,step,end) DO command [command-parameters]
for /l %%i in (1,1,5) do @echo %%i
for /l %%i in (100,-20,1) do @echo %%i

:: for /r path_name %%i in(file_type) do
:: search file in folder(include sub folders)
echo Get all *.exe file from C:windows folder(include sub folder)
::for /r c:\windows %%i in (W*.exe) do echo %%i


:: for /d %variable in (set) do commend
:: Search only current folder
echo Get all folder name from current folder
for /d %%i in (c:\*) do echo %%i
:: show contains one to three characters folder name
echo get one to three characters 
for /d %%i in (C:\???) do echo %%i