using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.uceip.DBUtility.iBatis.BaseImpl;
using Cabio.DLL.Produce;
using Cabio.Model.Produce;

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

        public int Save(tb_sc produce, List<tb_scxq> list)
        {
            int result = 0;
            try
            {
                _daoManager.BeginTransaction();

                //保存生产信息
                if (produce.tb_sc_ID > 0)
                {
                    result = dao.Update(produce);
                }
                else
                {
                    result = dao.Insert(produce);
                }

                //保存生产详情
                if (result > 0)
                {
                    ProduceDetailDao detailDao = new ProduceDetailDao(_daoManager);
                    detailDao.RemoveByMap("附加信息", produce.tb_sc_ID.ToString());
                    detailDao.RemoveByMap("投料", produce.tb_sc_ID.ToString());
                    detailDao.RemoveByMap("产出", produce.tb_sc_ID.ToString());

                    foreach (tb_scxq scxq in list)
                    {
                        if (detailDao.Insert(scxq) < 1)
                        {
                            _daoManager.RollBackTransaction();
                            return -3;
                        }
                    }

                    //保存物料信息

                }
                else
                {
                    _daoManager.RollBackTransaction();
                    return -2;
                }

                _daoManager.CommitTransaction();
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
