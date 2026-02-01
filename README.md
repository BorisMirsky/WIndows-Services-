# WIndows-Services-
Пример создания службы Windows



Пример с метанита https://metanit.com/sharp/tutorial/21.2.php


Запускать в cmd как админу:
cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319
InstallUtil.exe C:\Users\Alexander\source\.Net\WIndows-Services-\FileWatcherService\WindowsService1\bin\Debug\WindowsService1.exe

грохнуть служба:
InstallUtil.exe /u C:\Users\Alexander\source\.Net\WIndows-Services-\FileWatcherService\WindowsService1\bin\Debug\WindowsService1.exe

В списке служб называется Service1

Ручаная Запуск\Остановка не из Диспетчера, а из спец. окна со Службами

В корне D:\\ создан папка TempServices (тут будут происходить изменения) & файлик templog.txt (куда будут писаться изменения).


#############################################
'windows service pet project with api'
'windows service pet project ideas'


API Service

todo:
1) продумать логику (что будет делать АПИ):
сбор данных о курсе валюты, о погоде, о восходе-закате солнца

2) помещение их в папку


3)


