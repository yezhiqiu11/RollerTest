using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Entities
{
    public class RollerTestreportInfo
    {
        [Key]
        public int RollerTestReportInfoID { get; set; }
        [ForeignKey("RollerSampleInfo")]
        public int RollerSampleInfoID { get; set; }
        public virtual RollerSampleInfo RollerSampleInfo { get; set; }
        public bool StartStatus { get; set; }
        public string StartText { get; set; }
        public bool EndStatus { get; set; }
        public string EndText { get; set; }
        public bool FinalStatus { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
