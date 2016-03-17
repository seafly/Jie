using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.uceip.DBUtility.iBatis.BaseImpl
{
    public class SysTableId
    {

        static SysTableId()
        {
            string initid = ServiceConfig.GetCustomConfigNode(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\uceip.config", "uceip", "initid");
            string step = ServiceConfig.GetCustomConfigNode(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\uceip.config", "uceip", "step");

            if (!string.IsNullOrEmpty(initid)) START_ID = int.Parse(initid);
            if (!string.IsNullOrEmpty(step)) STEP = int.Parse(step);
        }

        /**
         * 标识种子
         */
        public static int START_ID = 1001;

        /**
         * 标识递增量
         */
        public static int STEP = 1;

        /**
         * 表名
         */
        public string SourceName { get; set; }

        /**
         * Id当前值
         */
        public int CurValue { get; set; }
    }
}
