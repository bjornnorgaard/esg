using System;
using System.Threading;
using Serilog;

namespace Console
{
    public class MoneyHandler
    {
        private readonly ILogger _logger;
        private readonly int _interval;
        private readonly Random _random;

        public MoneyHandler(ILogger logger, int interval)
        {
            _logger = logger;
            _interval = interval;
            _random = new Random();
        }

        public void Run()
        {
            while (true)
            {
                Transfer();
                MakeError();
                Thread.Sleep(_interval);
            }
        }

        private void MakeError()
        {
            var next = _random.Next(1, 40);

            if (next % 5 == 0)
                try
                {
                    throw new Exception("Error happened");
                }
                catch (Exception e)
                {
                    _logger.Warning(e, "Exception");
                }
            else if (next % 10 == 0)
            {
                try
                {
                    throw new ArgumentException("Invalid argument");
                }
                catch (Exception e)
                {
                    _logger.Warning(e, "Argument");
                }
            }
            else if (next % 15 == 0)
            {
                try
                {
                    throw new AggregateException("Other fail");
                }
                catch (Exception e)
                {
                    _logger.Warning(e, "Aggregate");
                }
            }
        }

        public void Transfer()
        {
            var mt = new MoneyTransfer
            {
                Id = _random.Next(1, 2000),
                Time = DateTime.Now,
                Amount = _random.Next(10, 1000000),
                FromId = _random.Next(1, 100),
                ToId = _random.Next(1, 100)
            };

            _logger.Information("{@MoneyTransfer}", mt);
        }
    }
}