For /F "tokens=2,3,4 delims=/ " %%A in ('Date /t') do @( 
       Set Current=%%B-%%A-%%C
 )

for /f %%i in (myfile.txt) do if %%i==%date%  echo "current days exist in files"

@echo off
rem ????????test.txt
echo ;A,B,C >test.txt
echo 111 121 131 141 151 161 >>test.txt
echo 211,221,231,241,251,261 >>test.txt
echo 311-321-331-341-351-361 >>test.txt
FOR /F "eol=; tokens=1,3* delims=,- " %%i in (test.txt) do echo %%i %%j %%k
Pause
Del test.txt

 echo %Current%
 echo %the_date%