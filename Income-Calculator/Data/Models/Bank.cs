using System.Collections.Generic;

namespace Income_Calculator.Data.Models
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Total { get; set; }
        public ICollection<Registry> Registies { get; set; }
    }
}
