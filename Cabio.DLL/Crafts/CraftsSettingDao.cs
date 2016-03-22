using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBatisNet.DataAccess;
using com.uceip.DBUtility.iBatis.BaseImpl;
using Cabio.Model.Crafts;

namespace Cabio.DLL.Crafts
{
    public class CraftsSettingDao : BaseDao<tb_gxsz>
    {
        public CraftsSettingDao(IDaoManager manager)
        {
            daoManager = manager;
            domainEntity = "tb_gxsz";
        }
    }
}
