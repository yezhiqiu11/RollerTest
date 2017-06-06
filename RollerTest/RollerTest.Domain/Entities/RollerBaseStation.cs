﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Entities
{
    public class RollerBaseStation
    {
        [Key]
        public int RollerBaseStationID { get; set; }
        public string Device { get; set; }
        public string Station { get; set; }

    }
}
