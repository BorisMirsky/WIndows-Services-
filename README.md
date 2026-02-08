# WIndows-Services-
Пример создания службы Windows



Реализованный пример с Метанита https://metanit.com/sharp/tutorial/21.2.php


Запуск службы

В cmd с правами админа делаем:

1) cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319

2) InstallUtil.exe xxxxxxx\WIndows-Services-\FileWatcherService\WindowsService1\bin\Debug\WindowsService1.exe



Удаление службы

InstallUtil.exe /u ххххххх\WIndows-Services-\FileWatcherService\WindowsService1\bin\Debug\WindowsService1.exe



Название в списке служб Service1.

Ручные Запуск\Остановка производятся из отдельного окна со Службами (не из Task Manager).

В корне С:\\ создана папка TempServices (тут будут происходить изменения) & файлик templog.txt (куда будут писаться изменения).





