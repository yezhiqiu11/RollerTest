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
    public class RollerSampleInfo
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int RollerSampleInfoID { get; set; }
        public string SampleID { get; set; }
        public string SampleName { get; set; }
        public int UpLimit { get; set; }
        public int DnLimit { get; set; }
        public int SetValue { get; set; }
        [HiddenInput(DisplayValue = false)]
        public bool state { get; set; }
        public virtual ICollection<RollerTestreportInfo> RollerTestreportInfo { get; set; }
        public virtual ICollection<RollerRecordInfo> RollerRecordInfo { get; set; }
        public virtual ICollection<RollerRealtimeInfo> RollerRealtimeInfo { get; set; }

        [HiddenInput(DisplayValue = false)]
        [ForeignKey("RollerProjectInfo")]
        public int RollerProjectInfoID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public virtual RollerProjectInfo RollerProjectInfo { get; set; }

        [ForeignKey("RollerBaseStation")]
        public int RollerBaseStationID { get; set; }
        public virtual RollerBaseStation RollerBaseStation { get; set; }



    }
}
