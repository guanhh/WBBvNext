using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace WBBvNext.Feedback.Model
{
    [Table("Suggestions")]
    public class Suggestion : BasePoco
    {
        [Required]
        [DisplayName("Suggestion.Title")]
        [StringLength(20)]
        public string Title { get; set; }

        [DisplayName("Suggestion.Detail")]
        [StringLength(200)]
        public string Detail { get; set; }

        [DisplayName("Suggestion.QuestionType")]
        public QuestionTypeEnum QuestionType { get; set; }

        [DisplayName("Suggestion.UserName")]
        [StringLength(20)]
        public string UserName { get; set; }

        [DisplayName("Suggestion.Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [DisplayName("Suggestion.IsSolved")]
        public bool  IsSolved { get; set; }

        [DisplayName("Suggestion.Remark")]
        [StringLength(200)]
        public string Remark { get; set; }
    }

    public enum QuestionTypeEnum
    {
        Bug,
        Suggestion,
        Other
    }

}
