using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.Common.Exceptions;

namespace com.uceip.DBUtility.iBatis.BaseImpl
{
    public class SysTableIdDao
    {
        public int generatorId(string sourceName, ISqlMapper sqlMap)
        {
            int curValue = 0;
            try
            {
                SysTableId sysTableId = new SysTableId();
                sysTableId.SourceName = sourceName;
                curValue = sqlMap.QueryForObject<int>("getSysTableIdCurValue", sysTableId);
                if (curValue > 0)
                {
                    // 递增标识
                    sysTableId.CurValue = curValue + SysTableId.STEP;
                    sqlMap.Update("updateSysTableId", sysTableId);
                }
                else
                {
                    curValue = SysTableId.START_ID;
                    // 新建标识记录
                    sysTableId.CurValue = SysTableId.START_ID + SysTableId.STEP;
                    sqlMap.Insert("insertSysTableId", sysTableId);
                }
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query getSysTableIdCurValue for object.  Cause: " + e.Message, e);
            }
            return curValue;
        }
    }
}
