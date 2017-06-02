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
        public string Commission { get; set; }
        public string TestName { get; set; }
        public string TestLocation { get; set; }
        public string TestCondition { get; set; }
        public string TestStandard { get; set; }
        public string TestDevice { get; set; }
        public string TestPerson { get; set; }
    }
}
