using System;

namespace Income_Calculator.Data.Models
{
    public class Registry
    {
        public int Id { get; set; }
        public double Money { get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set; }
        public DateTime DateTime { get; set; }
        
    }
}
