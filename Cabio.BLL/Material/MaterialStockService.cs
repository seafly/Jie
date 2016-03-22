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
    public class MaterialStockService : BaseService<tb_wlphck>
    {
        public MaterialStockService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            dao = new MaterialStockDao(_daoManager);
        }
    }
}
