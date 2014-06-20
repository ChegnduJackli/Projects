Set LogPath=C:/Users/lideng/Desktop/CMD/log/1.log
echo LogPath
echo 
echo start >>%LogPath%
echo end >>C:\Users\lideng\Desktop\CMD\log\1.log
echo %date% %time% >> C:\Users\lideng\Desktop\CMD\log\1.log

D:
cd D:\FTP\
@echo off
echo This batch program 
echo formats and checks 
echo new disks 
echo.

c:
cd C:\Users\lideng\Desktop\CMD\
Set TDate=%date:~10,4%%date:~4,2%%date:~7,2% 
copy "3.bat" "log\3_%TDate%.bat"
@echo off 
rem This batch program formats and checks new disks. 
rem It is named Checknew.bat. 
rem 
echo Insert new disk in drive B. 


pause