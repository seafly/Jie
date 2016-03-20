using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.uceip.DBUtility.iBatis.BaseImpl;
using Cabio.Model.Produce;
using Cabio.DLL.Produce;

namespace Cabio.BLL.Produce
{
    /// <summary>
    /// 生产详情服务
    /// </summary>
    public class ProduceDetailService : BaseService<tb_scxq>
    {
        public ProduceDetailService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            dao = new ProduceDetailDao(_daoManager);
        }
    }
}
