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
    /// 工艺设置服务
    /// </summary>
    public class CraftsSettingService : BaseService<tb_gxsz>
    {
        public CraftsSettingService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            dao = new CraftsSettingDao(_daoManager);
        }

        /// <summary>
        /// 添加一条工艺信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns>0:失败；-1：程序出错；-2：已存在相同的工艺代码或工艺名称；大于0：成功</returns>
        public int Add(tb_gxsz model)
        {
            int result = 0;
            try
            {
                _daoManager.BeginTransaction();

                if (exists(model))
                {
                    result = -2;
                }
                else
                {
                    result = base.Insert(model);
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
        /// 删除工艺设置
        /// 删除工艺设置表、删除工艺附件信息表、删除工艺产出信息表
        /// </summary>
        /// <param name="id">工艺设置ID</param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            bool result = false;
            try
            {
                _daoManager.BeginTransaction();

                dao.Remove(id);
                new CraftsInfoDao(_daoManager).Remove(id);
                new CraftsProductDao(_daoManager).Remove(id);

                _daoManager.CommitTransaction();
                result = true;
            }
            catch
            {
                result = false;
                _daoManager.RollBackTransaction();
            }

            return result;
        }

        /// <summary>
        /// 是否存在相同的工艺设置
        /// </summary>
        /// <param name="t"></param>
        /// <returns>false:没有重复；true：重复</returns>
        private bool exists(tb_gxsz t)
        {
            Hashtable map = new Hashtable();
            map.Add("exist", "exist");
            map.Add("tb_gxsz_ID", t.tb_gxsz_ID);
            map.Add("tb_gxsz_mc", t.tb_gxsz_mc);
            map.Add("tb_gxsz_dm", t.tb_gxsz_dm);

            return dao.GetObject(map) == null ? false : true;
        }
    }
}
