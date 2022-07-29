using Income_Calculator.Data;
using Income_Calculator.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace Income_Calculator.Controllers
{
    public class RegistryController : Controller
    {
        private readonly AppDbContext _context;

        public RegistryController(AppDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Registry registry)
        {
            registry.Bank = _context.Banks
                .ToList()
                .FirstOrDefault(x => x.Id == registry.BankId);
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Registries.Add(registry);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(registry);
        }
    }
}
