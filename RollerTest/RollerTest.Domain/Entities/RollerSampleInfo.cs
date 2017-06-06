using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RollerTest.Domain.Entities
{
    public class RollerSampleInfo
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int RollerSampleInfoID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int RollerProjectInfoId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public virtual RollerProjectInfo RollerProjectInfo { get; set; }
        public string SampleID { get; set; }
        public string SampleName { get; set; }
        
        public string TestStation { get; set; }
        public int UpLimit { get; set; }
        public int DnLimit { get; set; }
        public int SetValue { get; set; }
        public virtual ICollection<RollerTestreportInfo> RollerTestreportInfo { get; set; }
        public virtual ICollection<RollerRecordInfo> RollerRecordInfo { get; set; }
        public virtual ICollection<RollerRealtimeInfo> RollerRealtimeInfo { get; set; }



    }
}
