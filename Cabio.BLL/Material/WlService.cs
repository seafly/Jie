using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.uceip.DBUtility.iBatis.BaseImpl;
using Cabio.Model.Material;
using Cabio.DLL.Material;

namespace Cabio.BLL.Material
{
    public class WlService : BaseService<tb_i259b>
    {
        public WlService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            dao = new WlDao(_daoManager);
        }
    }
}
