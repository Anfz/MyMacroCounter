using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyMacroCounter.Models
{
    public class MacroSubType
    {
        public int MacroSubTypeId { get; set; }

        public String Name { get; set; }
        
        public int MacroTypeId { get; set; }

        public virtual MacroType MacroType { get; set; }
    }
}