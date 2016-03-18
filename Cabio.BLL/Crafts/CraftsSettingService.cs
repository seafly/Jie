﻿using System;
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
    }
}
