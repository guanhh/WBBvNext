using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBBvNext.Base;

namespace WBBvNext.WBB.Extension
{
    public class WBBModule : WBBModuleBase, IWBBModule
    {
        public override string Name => "WBB";

        public override string DisplayName => "WBBvNext模块代码生成";

        public override ModuleTypeEnum ModuleType => ModuleTypeEnum.Develop;

        public override string Desc => "快速创建WBBvNext平台模块基础结构代码";
    }
}
