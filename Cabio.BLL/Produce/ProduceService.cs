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
    /// 生产服务
    /// </summary>
    public class ProduceService : BaseService<tb_sc>
    {
        public ProduceService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            dao = new ProduceDao(_daoManager);
        }
    }
}
