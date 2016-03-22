using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace Cabio.Model.Produce
{
    public class tb_sc
    {
        /// <summary>
        /// 主键
        /// </summary>		
        public int tb_sc_ID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>		
        public DateTime tb_sc_ftime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>		
        public DateTime tb_sc_etime { get; set; }
        /// <summary>
        /// 操作人工号
        /// </summary>		
        public string tb_sc_czrgh { get; set; }
        /// <summary>
        /// 工艺标识
        /// </summary>		
        public int tb_sc_gxbs { get; set; }
        /// <summary>
        /// 生产单号
        /// </summary>		
        public string tb_sc_dh { get; set; }
        /// <summary>
        /// 状态
        /// </summary>		
        public string tb_sc_isEnd { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string tb_sc_bz { get; set; }

    }
}