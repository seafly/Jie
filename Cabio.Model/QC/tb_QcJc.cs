using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace Cabio.Model.QC
{
    public class tb_QcJc
    {
        /// <summary>
        /// 主键
        /// </summary>		
        public int tb_QcJc_ID { get; set; }
        /// <summary>
        /// 检测时间
        /// </summary>		
        public DateTime tb_QcJc_ftime { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>		
        public string tb_QcJc_sfsh { get; set; }
        /// <summary>
        /// 表标识
        /// </summary>		
        public int tb_QcJc_wlbs { get; set; }
        /// <summary>
        /// 操作人工号
        /// </summary>		
        public string tb_QcJc_czr { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>		
        public DateTime tb_QcJc_stime { get; set; }
        /// <summary>
        /// 请检编号
        /// </summary>		
        public string tb_QcJc_qjbh { get; set; }
        /// <summary>
        /// 请检时间
        /// </summary>		
        public DateTime tb_QcJc_qjtime { get; set; }
        /// <summary>
        /// 检测表
        /// </summary>		
        public string tb_QcJc_jcb { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>		
        public string tb_QCJc_sfwc { get; set; }

    }
}