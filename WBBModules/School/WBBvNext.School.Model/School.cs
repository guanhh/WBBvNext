using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace WBBvNext.School.Model
{
    public class School : BasePoco
    {
        [Display(Name = "School.SchoolCode")]
        [Required(ErrorMessage = "School.{0}required")]
        [RegularExpression("^[0-9]{3,3}$", ErrorMessage = "School.{0}3number")]
        [StringLength(3)]
        public string SchoolCode { get; set; }

        [Display(Name = "School.SchoolName")]
        [StringLength(50, ErrorMessage = "School.{0}stringmax{1}")]
        [Required(ErrorMessage = "School.{0}required")]
        public string SchoolName { get; set; }

        [Display(Name = "School.SchoolType")]
        [Required(ErrorMessage = "School.{0}required")]
        public SchoolTypeEnum? SchoolType { get; set; }

        [Display(Name = "School.PDFFile")]
        public Guid? PdfFileId { get; set; }
        public FileAttachment PdfFile { get; set; }

        [Display(Name = "School.Remark")]
        public string Remark { get; set; }
    }

    public enum SchoolTypeEnum
    {
        [Display(Name = "School.PUB")]
        PUB,
        [Display(Name = "School.PRI")]
        PRI
    }

}
