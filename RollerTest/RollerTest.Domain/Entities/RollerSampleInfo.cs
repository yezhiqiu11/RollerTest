using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.Entities
{
    public class RollerSampleInfo
    {
        [Key]
        public int RollerSampleInfoID { get; set; }
        public int RollerProjectInfoId { get; set; }
        public string SampleID { get; set; }
        public string SampleName { get; set; }
        
        public string TestStation { get; set; }
        public string TestSensor { get; set; }
        public int UpLimit { get; set; }
        public int DnLimit { get; set; }
        public int SetValue { get; set; }
    }
}
