using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cabio.BLL.Base;
using Cabio.Model.Crafts;
using Cabio.DLL.Crafts;

namespace Cabio.BLL.Crafts
{
    public class CraftsSettingBll : BllBase<tb_gxsz>
    {
        public CraftsSettingBll()
        {
            base.Dao = new CraftsSettingDll();
        }
    }
}
