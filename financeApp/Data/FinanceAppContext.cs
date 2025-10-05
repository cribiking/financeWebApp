/*
Aquesta classe ens permet fer la connexió amb la base de dades, te els metodes i ptopietats
que ens permet fer peticions (query) ala base de dades, guardar dades (store).

Cal que especifiquem una instancia de cada model que em creat, d'aquesta manera podem
interactuar a la base de dades.

Cal instal·lar diversos nuget packages per poder realitzar aquestes accions. 
*/


using financeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace financeApp.Data
{
    public class FinanceAppContext : DbContext
    {
        public FinanceAppContext() { }
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options) : base(options) { }
        
        //Instance we'll use to interact with our data base
        DbSet<Expense> Expenses { get; set; }
    }
}