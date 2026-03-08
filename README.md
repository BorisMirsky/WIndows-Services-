# WIndows-Services-
Пример создания службы Windows



_____________FileWatcherService_____________

Установка (инсталляция) службы
В cmd с правами админа:
1) cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319
2) InstallUtil.exe xxxxxxx\WIndows-Services-\FileWatcherService\WindowsService1\bin\Debug\WindowsService1.exe


Удаление службы
В cmd с правами админа:
InstallUtil.exe /u ххххххх\WIndows-Services-\FileWatcherService\WindowsService1\bin\Debug\WindowsService1.exe


Название в списке служб будет Service1.
Ручные Запуск\Остановка производятся из отдельного окна со Службами (не из Task Manager).
В корне С:\\ создана папка TempServices (тут будут происходить изменения) & файл templog.txt (куда будут писаться изменения).


Запуск службы
В списке службы вручную перевести статус службы с Stopped на Running.

_____________APIService_____________


Установка (инсталляция) службы
В cmd с правами админа:
1) cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319
2) InstallUtil.exe C:\Users\ххххххх\source\.Net\WIndows-Services-\APIService\APIService\bin\Debug\APIService.exe


Удаление службы
В cmd с правами админа:
InstallUtil.exe /u C:\Users\ххххххх\source\.Net\WIndows-Services-\APIService\APIService\bin\Debug\APIService.exe


Название в списке служб будет CurrencyService.


Запуск службы
В списке службы вручную перевести статус службы с Stopped на Running.
