using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyMacroCounter.Models
{
    public class MacroType
    {
        public int MacroTypeId { get; set; }

        [Display(Name = "Macro")]
        public string Name { get; set; }
        
        [Display(Name = "Calories Per Gram")]
        public int CaloriePerGram { get; set; }
    }
}