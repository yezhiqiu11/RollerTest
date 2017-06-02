using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Entities
{
    public class RollerRealtimeInfo
    {
        [Key]
        public int RollerRealtimeInfoID { get; set; }
        public int RollerSampleInfoId { get; set; }
        public DateTime CurrentTime { get; set; }
        public TimeSpan TotalTime { get; set; }
        public float CurrentValue { get; set; }
    }
}
