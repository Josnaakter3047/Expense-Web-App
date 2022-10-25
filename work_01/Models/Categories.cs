using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace work_01.Models
{
    //[Index(nameof(CategoryName),IsUnique=true)]
    public class Categories
    {
        public int Id { get; set; }
        [Required,StringLength(50)]
        public string CategoryName { get; set; }
        //
        public virtual ICollection<Expenditures> Expenditures { get; set; }
    }
    


}

