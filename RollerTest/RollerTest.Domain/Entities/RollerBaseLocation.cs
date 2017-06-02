using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Entities
{
    public class RollerBaseLocation
    {
        [Key]
        public int RollerBaseLocationID { get; set; }
        public string Location { get; set; }
    }
}
