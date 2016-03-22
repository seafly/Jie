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
    /// 工艺附加信息服务
    /// </summary>
    public class CraftsInfoService : BaseService<tb_gxfjxx>
    {
        public CraftsInfoService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            dao = new CraftsInfoDao(_daoManager);
        }

        /// <summary>
        /// 添加工艺附加信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns>0:失败；-1：程序出错；-2：已存在此产出产品；大于0：成功</returns>
        public override int Insert(tb_gxfjxx t)
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
        /// 更新工艺附加信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns>0:失败；-1：程序出错；-2：已存在此产出产品；大于0：成功</returns>
        public override int Update(tb_gxfjxx t)
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
        /// 获取工艺附加信息
        /// </summary>
        /// <param name="key">工艺标识</param>
        /// <returns></returns>
        public IList<tb_gxfjxx> getCraftsInfoList(string key)
        {

            new CraftsInfoService().GetListByQuery<tb_gxcccp>(null);

            return base.GetListByQuery<tb_gxfjxx>(new Hashtable { { "tb_gxfjxx_gxbs", key } });
        }

        /// <summary>
        /// 是否存在重复的附加信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns>false:没有重复；true：重复</returns>
        private bool exist(tb_gxfjxx t)
        {
            Hashtable map = new Hashtable();
            map.Add("exist", "exist");
            map.Add("tb_gxfjxx_ID", t.tb_gxfjxx_ID);
            map.Add("tb_gxfjxx_gxbs", t.tb_gxfjxx_gxbs);
            map.Add("tb_gxfjxx_mc", t.tb_gxfjxx_mc);

            return dao.GetObject(map) == null ? false : true;
        }
    }
}
