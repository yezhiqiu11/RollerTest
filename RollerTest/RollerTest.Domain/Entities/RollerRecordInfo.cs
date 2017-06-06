using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Entities
{
    public class RollerRecordInfo
    {
        [Key]
        public int RollerRecordInfoID { get; set; }
        public int RollerSampleInfoId { get; set; }
        public virtual RollerSampleInfo RollerSampleInfo { get; set; }
        public bool SampleStatus { get; set; }
        public DateTime CurrentTime { get; set; }
        public TimeSpan TotalTime { get; set; }
        public string RecordInfo { get; set; }
    }
}
