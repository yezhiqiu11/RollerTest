using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RollerTest.Domain.Entities
{
    public class RollerRecordInfo
    {
        [Key]
        public int RollerRecordInfoID { get; set; }
        public bool SampleStatus { get; set; }
        public DateTime CurrentTime { get; set; }
        public TimeSpan TotalTime { get; set; }
        public string RecordInfo { get; set; }

        [ForeignKey("RollerSampleInfo")]
        [HiddenInput(DisplayValue = false)]
        public int RollerSampleInfoID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public virtual RollerSampleInfo RollerSampleInfo { get; set; }
    }
}
