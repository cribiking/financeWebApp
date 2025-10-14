

using financeApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace financeApp.Controllers
{

    public class ExpensesController : Controller
    {
        //To  interact with our database
        private readonly FinanceAppContext _context;

        public ExpensesController(FinanceAppContext context)
        {
            _context = context;
        }
        public IActionResult Index()//Default method
        {
            //In order to take all the expenses from the database
            //Variable expenses will store all the expenses, but we rewuested from the databese =>
            //throught the FinanceaAppContext,cs file.
            var expenses = _context.Expenses.ToList();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }
        
    }
}