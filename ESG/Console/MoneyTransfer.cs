using System;

namespace Console
{
    public class MoneyTransfer
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int ToId { get; set; }
        public int FromId { get; set; }
        public DateTime Time { get; set; }
    }
}
