using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Mvc;
using WBBvNext.Base;

namespace WBBvNext.Services
{
    public class WBBCSService
    {
        public static string GetCurrentCS(IBaseController controller)
        {
            var ns = controller.GetType().Namespace;
            if (Regex.IsMatch(ns, WBBSetting.PLUG_CONTROLLER_NS))
            {
                return ns.Split('.')[1];
            }
            return null;
        }

    }
}
