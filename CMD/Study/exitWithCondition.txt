on error resume next 
dim WSHshellA 
set WSHshellA = wscript.createobject("wscript.shell") 
WSHshellA.run "cmd.exe /c shutdown -r -t 60 -c ""Say i am a pig,otherwise PC will shut down in one minutes, no believe? try"" ",0 ,true 
dim a 
do while(a <> "I am a pig") 
a = inputbox ("Say I am a pig then not shutdown ,Say""I am a pig"" ","say or not","no say",8000,7000) 
msgbox chr(13) + chr(13) + chr(13) + a,0,"MsgBox" 
loop 
msgbox chr(13) + chr(13) + chr(13) + "Say earlier is good,haha" 
dim WSHshell 
set WSHshell = wscript.createobject("wscript.shell") 
WSHshell.run "cmd.exe /c shutdown -a",0 ,true 
msgbox chr(13) + chr(13) + chr(13) + "hha,nothing is impossible~"