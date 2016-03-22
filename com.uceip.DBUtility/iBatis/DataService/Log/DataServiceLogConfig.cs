using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.uceip.DBUtility.iBatis.DataService.Log
{
    public class DataServiceLogConfig
    {
        public int ID { get; set; }
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 功能描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 添加时是否写入日志
        /// </summary>
        public int IsInsert { get; set; }
        /// <summary>
        /// 修改时是否写入日志
        /// </summary>
        public int IsUpdate { get; set; }
        /// <summary>
        /// 删除时是否写入日志
        /// </summary>
        public int IsDelete { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 组织ID
        /// </summary>
        public int OrganizeID { get; set; }
    }
}
