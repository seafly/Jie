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
    public class CraftsProductDao : BaseDao<tb_gxcccp>
    {
        public CraftsProductDao(IDaoManager manager)
        {
            daoManager = manager;
            domainEntity = "tb_gxcccp";
        }

        /// <summary>
        /// 根据工艺设置删除工艺产出
        /// </summary>
        /// <param name="key">工艺设置ID</param>
        /// <returns></returns>
        public int RemoveByCraftsSetting(string key)
        {
            return Remove("deletetb_gxcccpByGxsz", key);
        }
    }
}
