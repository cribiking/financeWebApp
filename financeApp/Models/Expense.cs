

/*
   Al crear un nou model, podem pensar com que estem creant una nova taula 
   a la base de dades. Per tant, els atributs de la classe, seran les columnes
   de la taula. 
   Podem especificar quines coulumnes seran obligatories, quina es la clau...
   */

using System.ComponentModel.DataAnnotations;

namespace financeApp.Models
{
    public class Expense
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0.01 , double.MaxValue, ErrorMessage ="Type a correct Amount")]
        public double Amount { get; set; }

        public string Category { get; set; } = null!;

        public DateTime Date { get; set; } = DateTime.Now;

    }
}
