using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBatisNet.DataAccess;
using com.uceip.DBUtility.iBatis.BaseImpl;
using Cabio.Model.Produce;

namespace Cabio.DLL.Produce
{
    public class ProduceDetailDao : BaseDao<tb_scxq>
    {
        public ProduceDetailDao(IDaoManager manager)
        {
            daoManager = manager;
            domainEntity = "tb_scxq";
        }
    }
}
