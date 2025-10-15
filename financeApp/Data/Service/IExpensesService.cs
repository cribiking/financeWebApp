using financeApp.Controllers;
using financeApp.Models;

namespace financeApp.Data.Services
{
    
    public interface IExpensesService
    {
        //We use task due to the methoths need to be asynchoronus
        Task<IEnumerable<Expense>> GetAll();
        Task Add(Expense expense);

        IQueryable GetChartData();
    }



}