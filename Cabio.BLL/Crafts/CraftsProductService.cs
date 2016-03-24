using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.uceip.DBUtility.iBatis.BaseImpl;
using Cabio.Model.Crafts;
using Cabio.DLL.Crafts;

namespace Cabio.BLL.Crafts
{
    /// <summary>
    /// 工艺产出产品服务
    /// </summary>
    public class CraftsProductService : BaseService<tb_gxcccp>
    {
        public CraftsProductService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            dao = new CraftsProductDao(_daoManager);
        }

        /// <summary>
        /// 添加工艺产出产品
        /// </summary>
        /// <param name="t"></param>
        /// <returns>0:失败；-1：程序出错；-2：已存在此产出产品；大于0：成功</returns>
        public override int Insert(tb_gxcccp t)
        {
            int result = 0;
            try
            {
                _daoManager.BeginTransaction();

                if (exist(t))
                {
                    result = -2;
                }
                else
                {
                    result = dao.Insert(t);
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

        /// <summary>
        /// 更新工艺产出产品
        /// </summary>
        /// <param name="t"></param>
        /// <returns>0:失败；-1：程序出错；-2：已存在此产出产品；大于0：成功</returns>
        public override int Update(tb_gxcccp t)
        {
            int result = 0;
            try
            {
                _daoManager.BeginTransaction();

                if (exist(t))
                {
                    result = -2;
                }
                else
                {
                    result = dao.Update(t);
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

        /// <summary>
        /// 获取工艺产出产品
        /// </summary>
        /// <param name="key">工艺标识</param>
        /// <returns></returns>
        public IList<tb_gxcccp> GetCraftsProductList(string key)
        {
            return GetListByQuery<tb_gxcccp>(new Hashtable { { "tb_gxcccp_gxbs", key } });
        }

        /// <summary>
        /// 工艺产出产品是否重复
        /// </summary>
        /// <param name="t"></param>
        /// <returns>false:没有重复；true：重复</returns>
        private bool exist(tb_gxcccp t)
        {
            Hashtable map = new Hashtable();
            map.Add("exist", "exist");
            map.Add("tb_gxcccp_ID", t.tb_gxcccp_ID);
            map.Add("tb_gxcccp_gxbs", t.tb_gxcccp_gxbs);
            map.Add("tb_gxcccp_wpbs", t.tb_gxcccp_wpbs);
            return dao.GetObject(map) == null ? false : true;
        }
    }
}
