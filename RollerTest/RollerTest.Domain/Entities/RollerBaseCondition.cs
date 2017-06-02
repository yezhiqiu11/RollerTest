using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Entities
{
    public class RollerBaseCondition
    {
        [Key]
        public int RollerBaseConditonID { get; set; }
        public string Condition { get; set; }
    }
}
