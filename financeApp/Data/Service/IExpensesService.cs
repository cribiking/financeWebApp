using financeApp.Controllers;
using financeApp.Models;

namespace financeApp.Data.Services
{
    
    public interface IExpensesService
    {
        //We use task due to the methoths need to be asynchoronus
         Task<IEnumerable<Expense>> GetAll();
         Task Add(Expense expense);//Create method

         IQueryable GetChartData();
         
         // Get an expense by id
         Task<Expense?> GetByIdAsync(int id);

         // Delete an expense by id
         Task Delete(int id);

         // Update an existing expense
         Task Update(Expense expense);        //Task<Expense> GetByIdAsync(int id);
    }



}