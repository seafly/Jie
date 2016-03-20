using System;
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
    }
}
