using Income_Calculator.Data;
using Income_Calculator.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Income_Calculator.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly AppDbContext _context;
        public BankRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Bank> GetBanks()
        {
            return _context.Banks.Select(x => new Bank()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
