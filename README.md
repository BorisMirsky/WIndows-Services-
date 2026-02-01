# WIndows-Services-
Пример создания службы Windows



Пример с метанита https://metanit.com/sharp/tutorial/21.2.php


run in cmd as admin:
cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319
InstallUtil.exe C:\Users\Alexander\source\.Net\WIndows-Services-\FileWatcherService\WindowsService1\bin\Debug\WindowsService1.exe

delete service:
InstallUtil.exe /u C:\Users\Alexander\source\.Net\WIndows-Services-\FileWatcherService\WindowsService1\bin\Debug\WindowsService1.exe

В списке служб называется Service1

#############################################

API Service

todo:
1) продумать логику (что будет делать АПИ):
сбор данных о курсе валюты, о погоде, о восходе-закате солнца

2) помещение их в папку


3)


