using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RollerTest.Domain.Entities
{
    public class RollerProjectInfo
    {
        [Key]
        [HiddenInput(DisplayValue =false)]
        public int RollerProjectInfoID { get; set; }
        [Required]
        public string Commission { get; set; }
        [Required]
        public string TestName { get; set; }
        [Required]
        public string TestLocation { get; set; }
        [Required]
        public string TestCondition { get; set; }
        [Required]
        public string TestStandard { get; set; }
        [Required]
        public string TestDevice { get; set; }
        [Required]
        public string TestPerson { get; set; }

        public virtual ICollection<RollerSampleInfo> RollerSampleInfo { get; set; }
    }
}
