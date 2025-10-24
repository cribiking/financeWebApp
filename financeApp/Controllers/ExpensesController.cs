

using financeApp.Data;
using financeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using financeApp.Data.Services;
/*
Its not a good practic to acces the database inside the controler, we need to use services, a more secure place. 
*/


namespace financeApp.Controllers
{
    public class ExpensesController : Controller
    {

        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        public async Task<IActionResult> Index()
        {
            var expense = await _expensesService.GetAll();
            return View(expense);
        }

        // 💡 Solución: Define explícitamente el método GET para mostrar el formulario.
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // El método POST para recibir y guardar los datos.
        [HttpPost]
        [ValidateAntiForgeryToken] // Siempre buena práctica de seguridad
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {

                // 💡 SOLUCIÓN: Convierte la propiedad DateTime a UTC antes de guardarla.
                // Asumiendo que la propiedad de la fecha en Expense se llama 'Date' o similar.
                // Si la fecha fue ingresada por el usuario en su hora local, 
                // DateTime.ToUniversalTime() hace la conversión correcta.
                if (expense.Date.Kind != DateTimeKind.Utc)
                {
                    expense.Date = expense.Date.ToUniversalTime();
                }


                await _expensesService.Add(expense);
                return RedirectToAction("Index");
            }

            return View(expense);
        }

        //we will use a json file to get the data with Javascript
        public IActionResult GetChart()
        {
            var data = _expensesService.GetChartData();
            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var expense = await _expensesService.GetByIdAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _expensesService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var expense = await _expensesService.GetByIdAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Convert to UTC just like in Create
                if (expense.Date.Kind != DateTimeKind.Utc)
                {
                    expense.Date = expense.Date.ToUniversalTime();
                }

                await _expensesService.Update(expense);
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }
    }
}