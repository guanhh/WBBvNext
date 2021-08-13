using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBBvNext.Base;
using WBBvNext.School.Abstract;

namespace WBBvNext.School.Extension
{
    public class PinyinService : ISingletonService, IPinyinService
    {
        public string ConvertToAllSpell(string strChinese)
        {
            return PinYinHelper.ConvertToAllSpell(strChinese);
        }
    }
}
