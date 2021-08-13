using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBBvNext.Base;

namespace WBBvNext.WBB.Extension
{
    public class SchoolModule : WBBModuleBase, IWBBModule
    {
        public override string Name => "School";

        public override string DisplayName => "样例模块";

        public override ModuleTypeEnum ModuleType => ModuleTypeEnum.Sample;

        public override string Desc => "用于展示WBBvNext模块的基础功能";
    }
}
