using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBatisNet.DataAccess;
using com.uceip.DBUtility.iBatis.BaseImpl;
using Cabio.Model.Code;

namespace Cabio.DLL.Code
{
    public class CustomeizeCodeDao : BaseDao<tb_bcbm>
    {
        public CustomeizeCodeDao(IDaoManager manager)
        {
            daoManager = manager;
            domainEntity = "tb_bcbm";
        }
    }
}
