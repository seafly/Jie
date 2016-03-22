using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.uceip.DBUtility.iBatis.BaseImpl;
using Cabio.Model.Material;
using Cabio.DLL.Material;
namespace Cabio.BLL.Material
{
    /// <summary>
    /// 使用记录服务
    /// </summary>
    public class UseRecordService : BaseService<tb_syjl>
    {
        public UseRecordService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            dao = new UseRecordDao(_daoManager);
        }
    }
}
