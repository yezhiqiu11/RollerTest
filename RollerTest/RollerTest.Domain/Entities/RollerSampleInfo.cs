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
    public class RollerSampleInfo:IValidatableObject
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int RollerSampleInfoID { get; set; }
        [Required(ErrorMessage ="样品编号不能为空")]
        public string SampleID { get; set; }
        [Required(ErrorMessage = "样品名称不能为空")]
        public string SampleName { get; set; }
        [Required]
        public int UpLimit { get; set; }
        [Required]
        public int DnLimit { get; set; }
        [Required]
        public int SetValue { get; set; }
        [HiddenInput(DisplayValue = false)]
        public bool State { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Nullable<DateTime> StartTime { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Nullable<DateTime> EndTime { get; set; }


        public virtual ICollection<RollerTestreportInfo> RollerTestreportInfo { get; set; }
        public virtual ICollection<RollerRecordInfo> RollerRecordInfo { get; set; }
        public virtual ICollection<RollerRealtimeInfo> RollerRealtimeInfo { get; set; }

        [HiddenInput(DisplayValue = false)]
        [ForeignKey("RollerProjectInfo")]
        public int RollerProjectInfoID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public virtual RollerProjectInfo RollerProjectInfo { get; set; }

        [HiddenInput(DisplayValue = false)]
        [ForeignKey("RollerBaseStation")]
        [Required(ErrorMessage ="工位号不能为空")]
        public int RollerBaseStationID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public virtual RollerBaseStation RollerBaseStation { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            RollerSampleInfo rollersampleinfo = validationContext.ObjectInstance as RollerSampleInfo;
            if (rollersampleinfo.SetValue > rollersampleinfo.UpLimit || rollersampleinfo.SetValue < rollersampleinfo.DnLimit)
            {
                yield return new ValidationResult("设定值不符合要求",new string[] { "SetValue" });
            }
            if (rollersampleinfo.UpLimit < rollersampleinfo.SetValue || rollersampleinfo.UpLimit < rollersampleinfo.DnLimit)
            {
                yield return new ValidationResult("上限值不符合要求", new string[] { "UpLimit" });
            }
            if (rollersampleinfo.DnLimit > rollersampleinfo.SetValue || rollersampleinfo.UpLimit < rollersampleinfo.DnLimit)
            {
                yield return new ValidationResult("下限值不符合要求", new string[] { "DnLimit" });
            }
        }
    }
}
