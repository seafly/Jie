using System;
using System.Collections;
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

        /// <summary>
        /// 根据类型删除生产详情
        /// </summary>
        /// <param name="tb_scxq_lx">类型</param>
        /// <param name="tb_scxq_scbs">生产标识</param>
        /// <returns></returns>
        public int RemoveByMap(string tb_scxq_lx, string tb_scxq_scbs)
        {
            int result = 0;
            try
            {
                _daoManager.BeginTransaction();

                new ProduceDetailDao(_daoManager).RemoveByMap(tb_scxq_lx, tb_scxq_scbs);

                _daoManager.CommitTransaction();
                result = 1;
            }
            catch
            {
                result = -1;
                _daoManager.RollBackTransaction();
            }
            return result;
        }
    }
}
