using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace Cabio.Model.Material
{
    public class tb_syjl
    {

        /// <summary>
        /// 主键
        /// </summary>		
        public int tb_syjl_ID { get; set; }
        /// <summary>
        /// 物品代码
        /// </summary>		
        public string tb_syjl_wpdm { get; set; }
        /// <summary>
        /// 性质
        /// </summary>		
        public int tb_syjl_xz { get; set; }
        /// <summary>
        /// 操作标识
        /// </summary>		
        public string tb_syjl_czbs { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>		
        public DateTime tb_syjl_ftime { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>		
        public string tb_syjl_czlx { get; set; }
        /// <summary>
        /// 物料批号
        /// </summary>		
        public string tb_syjl_wlph { get; set; }
        /// <summary>
        /// 重量
        /// </summary>		
        public decimal tb_syjl_zl { get; set; }
        /// <summary>
        /// 源表
        /// </summary>		
        public string tb_syjl_yb { get; set; }
        /// <summary>
        /// 目标表
        /// </summary>		
        public string tb_syjl_mbb { get; set; }
        /// <summary>
        /// 源标识
        /// </summary>		
        public int tb_syjl_ybs { get; set; }
        /// <summary>
        /// 车间存量
        /// </summary>		
        public decimal tb_syjl_cjcl { get; set; }
        /// <summary>
        /// 北方办
        /// </summary>		
        public decimal tb_syjl_bfb { get; set; }
        /// <summary>
        /// 葛店冷库
        /// </summary>		
        public decimal tb_syjl_kdlk { get; set; }
        /// <summary>
        /// 庙山冷库
        /// </summary>		
        public decimal tb_syjl_storagemslk { get; set; }
        /// <summary>
        /// 外租冷库
        /// </summary>		
        public decimal tb_syjl_storagewzlk { get; set; }
        /// <summary>
        /// 物品标识
        /// </summary>		
        public int tb_syjl_wpbs { get; set; }
        /// <summary>
        /// 操作人工号
        /// </summary>		
        public string tb_syjl_czrgh { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>		
        public DateTime tb_syjl_ctime { get; set; }
    }
}