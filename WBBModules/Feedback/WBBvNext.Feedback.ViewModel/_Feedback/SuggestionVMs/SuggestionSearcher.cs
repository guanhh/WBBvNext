using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WBBvNext.Feedback.Model;


namespace WBBvNext.ViewModel._Feedback.SuggestionVMs
{
    public partial class SuggestionSearcher : BaseSearcher
    {
        [DisplayName("Suggestion.QuestionType")]
        public QuestionTypeEnum? QuestionType { get; set; }

        [DisplayName("Suggestion.IsSolved")]
        public Boolean? IsSolved { get; set; }

        protected override void InitVM()
        {
        }

    }
}
