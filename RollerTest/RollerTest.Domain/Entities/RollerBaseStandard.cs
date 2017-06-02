using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Entities
{
    public class RollerBaseStandard
    {
        [Key]
        public int RollerBaseStandardID { get; set; }
        public string Standard { get; set; }
    }
}
