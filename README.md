# WIndows-Services-
Пример создания службы Windows



### FileWatcherService

Служба наблюдает за изменениями в папке 'C:\TempServices'. Все изменения заносятся в файл 'templog.txt'.

##### Установка.

В cmd с правами админа:
1) 'cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319'
2) 'InstallUtil.exe xxxxxxx\WIndows-Services-\FileWatcherService\WindowsService1\bin\Debug\WindowsService1.exe'


##### Удаление.

В cmd с правами админа:

'InstallUtil.exe /u ххххххх\WIndows-Services-\FileWatcherService\WindowsService1\bin\Debug\WindowsService1.exe'



##### Запуск\Остановка.

Название в списке служб будет 'Service1'.

Ручные 'Запуск\Остановка' производятся из отдельного окна служб.

В списке службы вручную перевести статус службы с 'Stopped' на 'Running'.


---

### APIService

Служба при своём запуске и потом раз в час обращается по API к интерфейсу ЦБ РФ и заносит текущий курс $ в локальный файл лога.


##### Установка.

В cmd с правами админа:
1) cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319
2) InstallUtil.exe C:\Users\ххххххх\source\.Net\WIndows-Services-\APIService\APIService\bin\Debug\APIService.exe


##### Удаление.

В cmd с правами админа:

InstallUtil.exe /u C:\Users\ххххххх\source\.Net\WIndows-Services-\APIService\APIService\bin\Debug\APIService.exe


##### Запуск.

Название в списке служб будет 'CurrencyService'.

В списке служб вручную перевести статус службы с 'Stopped' на 'Running'.

Ручные 'Запуск\Остановка' производятся из отдельного окна служб.

