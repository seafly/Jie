using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBatisNet.DataAccess;
using com.uceip.DBUtility.iBatis.BaseImpl;
using Cabio.Model.Material;

namespace Cabio.DLL.Material
{
   public class MaterialStockDao: BaseDao<tb_wlphck>
    {
       public MaterialStockDao(IDaoManager manager)
        {
            daoManager = manager;
            domainEntity = "tb_wlphck";
        }
    }
}
