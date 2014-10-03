@echo off
::IF [NOT] ERRORLEVEL number command
::IF [NOT] string1==string2 command
::IF [NOT] EXIST filename command

::    IF EXIST filename. (
::        del filename.
::    ) ELSE (
::        echo filename. missing.
::    )

:: else must be the same line of if last sentence
::try use below sample
IF EXIST 1.txt. (
	echo 1.txt deleted.
	del 1.txt.
) else (
	echo 1.txt. missing.
)
	
SET file1 = 2.txt
set dir = C:\Users\lideng\Desktop\GitHub\Projects\Projects\CMD\Study

if exist %dir%\%file1%. (
	echo %file1% deleted.
	del %file1%.
) else (
	echo %file1% missing.
)
::EQU - equal
::NEQ - not equal 
::LSS - less than 
::LEQ - less than or equal
::GTR - greater than 
::GEQ - greater than or equal

:: %1 means the first parameter.

::IF [/I] string1 compare-op string2 command
:: /I ignore case sensitive
echo [%1%]
if /I %1% equ good echo input is good.

