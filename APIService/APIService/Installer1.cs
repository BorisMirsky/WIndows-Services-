using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace CurrencyService
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        private ServiceProcessInstaller processInstaller;
        private ServiceInstaller serviceInstaller;

        public Installer1()
        {
            InitializeComponent();

            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            // Настройки для процесса службы
            processInstaller.Account = ServiceAccount.LocalSystem; // Можно также LocalService или NetworkService

            // Настройки для службы
            serviceInstaller.ServiceName = "CurrencyService";
            serviceInstaller.DisplayName = "Currency Service";
            serviceInstaller.Description = "Служба для получения курса доллара США с сайта ЦБ РФ и записи в файл.";
            serviceInstaller.StartType = ServiceStartMode.Manual; // Запуск вручную

            // Добавляем установщики в коллекцию
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}