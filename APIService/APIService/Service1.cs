using System;
using System.IO;
using System.Net.Http;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;
using System.Diagnostics;

namespace CurrencyService
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer;
        private HttpClient httpClient;
        private string logFilePath;
        private readonly string valuteId = "R01235";
        private readonly string apiUrl = "http://www.cbr.ru/scripts/XML_daily.asp";

        public Service1()
        {
            InitializeComponent();
            this.ServiceName = "CurrencyService";
            this.CanStop = true;
            this.CanPauseAndContinue = false;
            this.AutoLog = true; // Включить логирование в EventLog
        }

        protected override void OnStart(string[] args)
        {
            // Инициализация HttpClient
            httpClient = new HttpClient();
            // Определяем путь для файла лога
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            logFilePath = Path.Combine(baseDir, "C:\\TempServices\\CurrencyLog.txt");

            // Настройка таймера на интервал 1 час (3600000 миллисекунд)
            timer = new Timer(3600000); // 1 час
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = true;
            timer.Start();

            // Сразу выполняем запрос при старте, чтобы не ждать час
            Task.Run(() => FetchAndLogData());
        }

        protected override void OnStop()
        {
            timer?.Stop();
            timer?.Dispose();
            httpClient?.Dispose();
        }

        private async void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            await FetchAndLogData();
        }

        private async System.Threading.Tasks.Task FetchAndLogData()
        {
            try
            {
                string xmlContent = await httpClient.GetStringAsync(apiUrl);
                if (!string.IsNullOrEmpty(xmlContent))
                {
                    // Парсим XML
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlContent);

                    // Ищем элемент Valute с атрибутом ID = "R01235"
                    XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);
                    // У документа может быть пространство имен по умолчанию, но в данном API его нет. 
                    // Поэтому просто ищем по XPath.
                    XmlNode valuteNode = doc.SelectSingleNode($"//Valute[@ID='{valuteId}']");

                    if (valuteNode != null)
                    {
                        // Получаем весь XML этого узла (включая сам тег)
                        string valuteXml = valuteNode.OuterXml;

                        // Формируем строку для записи: время и данные через пробел
                        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string logEntry = $"{timestamp} {valuteXml}";

                        // Запись в файл (добавляем новую строку)
                        File.AppendAllText(logFilePath, logEntry + Environment.NewLine);

                        // Можно также записать в EventLog успех
                        EventLog.WriteEntry("Currency data fetched and logged successfully.", System.Diagnostics.EventLogEntryType.Information);
                    }
                    else
                    {
                        EventLog.WriteEntry($"Valute with ID '{valuteId}' not found in XML.", System.Diagnostics.EventLogEntryType.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry($"Error in FetchAndLogData: {ex.Message}", System.Diagnostics.EventLogEntryType.Error);
            }
        }
    }
}