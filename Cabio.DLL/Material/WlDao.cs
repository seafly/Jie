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
    public class WlDao : BaseDao<tb_i259b>
    {
        public WlDao(IDaoManager manager)
        {
            daoManager = manager;
            domainEntity = "tb_i259b";
        }
    }
}
