using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.uceip.DBUtility.iBatis.DataService.Log
{
    public class DataServiceLog
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 操作内容
        /// </summary>
        public string OperateContent { get; set; }
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 数据ID
        /// </summary>
        public int DataID { get; set; }
        /// <summary>
        /// 操作类型
        /// 1:insert;2:update;3:delete;
        /// </summary>
        public int OperateType { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperateDate { get; set; }

        /// <summary>
        /// 操作人名称-虚拟字段
        /// </summary>
        public string UserName { get; set; }
    }
}
