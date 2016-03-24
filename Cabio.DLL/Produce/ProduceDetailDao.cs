using System;
using System.Collections;
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

        /// <summary>
        /// 根据类型删除生产详情
        /// </summary>
        /// <param name="tb_scxq_lx">类型</param>
        /// <param name="tb_scxq_scbs">生产标识</param>
        /// <returns></returns>
        public int RemoveByMap(string tb_scxq_lx, string tb_scxq_scbs)
        {
            Hashtable map = new Hashtable();
            map.Add("tb_scxq_lx", tb_scxq_lx);
            map.Add("tb_scxq_scbs", tb_scxq_scbs);
            return Remove("deletetb_scxqByMap", map);
        }
    }
}
