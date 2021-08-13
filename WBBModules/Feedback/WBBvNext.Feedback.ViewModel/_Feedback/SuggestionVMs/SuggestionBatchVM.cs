using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WBBvNext.Feedback.Model;


namespace WBBvNext.ViewModel._Feedback.SuggestionVMs
{
    public partial class SuggestionBatchVM : BaseBatchVM<Suggestion, Suggestion_BatchEdit>
    {
        public SuggestionBatchVM()
        {
            ListVM = new SuggestionListVM();
            LinkedVM = new Suggestion_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Suggestion_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
