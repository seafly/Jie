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
    public class CraftsInfoDao : BaseDao<tb_gxfjxx>
    {
        public CraftsInfoDao(IDaoManager manager)
        {
            daoManager = manager;
            domainEntity = "tb_gxfjxx";
        }

        /// <summary>
        /// 根据工艺设置删除工艺附加信息
        /// </summary>
        /// <param name="key">工艺设置ID</param>
        /// <returns></returns>
        public int RemoveByCraftsSetting(string key)
        {
            return base.Remove("deletetb_gxfjxxByGxsz", key);
        }
    }
}
