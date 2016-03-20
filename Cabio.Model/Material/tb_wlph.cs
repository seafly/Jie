using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace Cabio.Model.Material
{
    public class tb_wlph
    {
        /// <summary>
        /// 主键
        /// </summary>		
        public int tb_wlph_ID { get; set; }
        /// <summary>
        /// 物品标识
        /// </summary>		
        public int tb_wlph_wpbs { get; set; }
        /// <summary>
        /// 物品代码
        /// </summary>		
        public string tb_wlph_wpdm { get; set; }
        /// <summary>
        /// 物料批号
        /// </summary>		
        public string tb_wlph_wlph { get; set; }
        /// <summary>
        /// 创建方式
        /// </summary>		
        public string tb_wlph_cjfs { get; set; }
        /// <summary>
        /// 原始数量
        /// </summary>		
        public decimal tb_wlph_sl { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime tb_wlph_ftime { get; set; }
        /// <summary>
        /// 创建表
        /// </summary>		
        public string tb_wlph_cjtb { get; set; }
        /// <summary>
        /// 创建标识
        /// </summary>		
        public int tb_wlph_cjbs { get; set; }
    }
}