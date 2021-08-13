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
    public partial class SuggestionTemplateVM : BaseTemplateVM
    {
        public ExcelPropety Title_Excel = ExcelPropety.CreateProperty<Suggestion>(x => x.Title);
        public ExcelPropety Detail_Excel = ExcelPropety.CreateProperty<Suggestion>(x => x.Detail);
        public ExcelPropety QuestionType_Excel = ExcelPropety.CreateProperty<Suggestion>(x => x.QuestionType);
        public ExcelPropety UserName_Excel = ExcelPropety.CreateProperty<Suggestion>(x => x.UserName);
        public ExcelPropety Email_Excel = ExcelPropety.CreateProperty<Suggestion>(x => x.Email);
        public ExcelPropety IsSolved_Excel = ExcelPropety.CreateProperty<Suggestion>(x => x.IsSolved);
        public ExcelPropety Remark_Excel = ExcelPropety.CreateProperty<Suggestion>(x => x.Remark);

	    protected override void InitVM()
        {
        }

    }

    public class SuggestionImportVM : BaseImportVM<SuggestionTemplateVM, Suggestion>
    {

    }

}
