using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cabio.Model.Code
{
    /// <summary>
    /// BC编码
    /// </summary>
    public class tb_bcbm
    {
        /// <summary>
        /// 主键
        /// </summary>		
        public int tb_bcbm_ID { get; set; }
        /// <summary>
        /// 对应表
        /// </summary>		
        public string tb_bcbm_tb { get; set; }
        /// <summary>
        /// 对应标识
        /// </summary>		
        public int tb_bcbm_bs { get; set; }
        /// <summary>
        /// 编码名称
        /// </summary>		
        public string tb_bcbm_bmmc { get; set; }
        /// <summary>
        /// 类型
        /// </summary>		
        public string tb_bcbm_lx { get; set; }
        /// <summary>
        /// 当前值
        /// </summary>		
        public string tb_bcbm_va { get; set; }
        /// <summary>
        /// 原始值
        /// </summary>		
        public string tb_bcbm_va2 { get; set; }
        /// <summary>
        /// 重新计数
        /// </summary>		
        public string tb_bcbm_zdbz { get; set; }
        /// <summary>
        /// 标值
        /// </summary>		
        public int tb_bcbm_xz { get; set; }

        /// <summary>
        /// 完整编码
        /// </summary>
        public string AllBm { get; set; }

    }
}
