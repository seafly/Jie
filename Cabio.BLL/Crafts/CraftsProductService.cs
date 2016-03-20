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
    /// 工艺产出产品服务
    /// </summary>
    public class CraftsProductService : BaseService<tb_gxcccp>
    {
        public CraftsProductService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            dao = new CraftsProductDao(_daoManager);
        }

        /// <summary>
        /// 获取工艺产出产品
        /// </summary>
        /// <param name="key">工艺标识</param>
        /// <returns></returns>
        public IList<tb_gxcccp> GetCraftsProductList(string key)
        {
            return base.GetListByQuery<tb_gxcccp>(new Hashtable { { "tb_gxcccp_gxbs", key } });
        }
    }
}
