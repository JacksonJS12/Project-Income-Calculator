using Income_Calculator.Data.Models;
using System.Collections.Generic;

namespace Income_Calculator.Repository
{
    public interface IBankRepository
    {
        List<Bank> GetBanks();
    }
}
