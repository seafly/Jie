using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.uceip.DBUtility.iBatis.BaseImpl;
using Cabio.Model.Crafts;
using Cabio.DLL.Crafts;

namespace Cabio.BLL.Crafts
{
    /// <summary>
    /// 工艺附加信息服务
    /// </summary>
    public class CraftsInfoService : BaseService<tb_gxfjxx>
    {
        public CraftsInfoService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            dao = new CraftsInfoDao(_daoManager);
        }

        /// <summary>
        /// 获取工艺附加信息
        /// </summary>
        /// <param name="key">工艺标识</param>
        /// <returns></returns>
        public IList<tb_gxfjxx> getCraftsInfoList(string key)
        {
            return base.GetListByQuery<tb_gxfjxx>(new Hashtable { { "tb_gxfjxx_gxbs", key } });
        }
    }
}
