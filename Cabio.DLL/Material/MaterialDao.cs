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
    public class MaterialDao : BaseDao<tb_wlph>
    {
        public MaterialDao(IDaoManager manager)
        {
            daoManager = manager;
            domainEntity = "tb_wlph";
        }
    }
}
