using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBBvNext.Base;

namespace WBBvNext.Feedback.Extension
{
    public class FeedbackModule : WBBModuleBase, IWBBModule
    {
        public override string Name => "Feedback";

        public override string DisplayName => "Feedback";

        public override ModuleTypeEnum ModuleType => ModuleTypeEnum.Business;

        public override string Desc => "Feedback描述";
    }
}
