using System;
using System.Threading;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                 .Enrich.FromLogContext()
                 .WriteTo.Console()
                 .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                 {
                     AutoRegisterTemplate = true,
                     IndexFormat = $"esg-log-{DateTime.Now:yyyy.MM.dd}",
                     ModifyConnectionSettings = x => x.BasicAuthentication("elastic", "changeme")
                 })
                 .CreateLogger();

            var ph = new MoneyHandler(Log.Logger, 500);
            var uh = new UserHandler(Log.Logger, 1500);

            var userThread = new Thread(uh.Run);
            var moneyThread = new Thread(ph.Run);

            userThread.Start();
            moneyThread.Start();
        }
    }

    public class UserHandler
    {
        private readonly ILogger _logger;
        private readonly int _interval;

        public UserHandler(ILogger logger, int interval)
        {
            _logger = logger;
            _interval = interval;
        }

        public void Run()
        {
            while (true)
            {
                Login();
                Thread.Sleep(_interval);
            }
        }

        private void Login()
        {
            var user = new User();
            _logger.Information("Login by {@User}", user);
        }
    }

    public class User
    {
        public User()
        {
            var random = new Random();
            Id = random.Next(1, 10000);
            Name = "Unknown Person";
            Age = random.Next(15, 99);
            Birthdate = DateTime.Now.Subtract(new TimeSpan(Age * 365, 0, 0, 0));
            Height = random.Next(140, 210);
            Weight = random.Next(40, 150);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
