using System;
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
    }
}
