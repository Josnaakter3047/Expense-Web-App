using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace work_01.Models
{
    public class Expenditures
    {
        public int Id { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        [Required,Display(Name ="Date of Expense"),DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime DateOfExpense { get; set; }
        [Required,Column(TypeName ="money"),Display(Name ="Total Amount")]
        public decimal TotalAmount { get; set; }
       
        //nev
        public virtual Categories Categories { get; set; }
    }
    public class ExpenseView
    {
        public int Id { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        [Required, Display(Name = "Date of Expense"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfExpense { get; set; }
        [Required, Column(TypeName = "money"), Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        public string CategoryName { get; set; }
    }
}
