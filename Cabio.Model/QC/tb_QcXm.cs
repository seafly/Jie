using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace Cabio.Model.QC
{
    public class tb_QcXm
    {
        /// <summary>
        /// 主键
        /// </summary>		
        public int tb_QcXm_ID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>		
        public string tb_QcXm_xmmc { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>		
        public string tb_QcXm_wldm { get; set; }
        /// <summary>
        /// 类型
        /// </summary>		
        public string tb_QcXm_lx { get; set; }
        /// <summary>
        /// 最小值
        /// </summary>		
        public decimal tb_QcXm_vamin { get; set; }
        /// <summary>
        /// 最小值
        /// </summary>		
        public decimal tb_QcXm_vamax { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>		
        public string tb_QcXm_vadef { get; set; }
        /// <summary>
        /// 待选值
        /// </summary>		
        public string tb_QcXm_dxz { get; set; }
        /// <summary>
        /// QC类型
        /// </summary>		
        public int tb_QcXm_qclx { get; set; }
        /// <summary>
        /// 物品标识
        /// </summary>		
        public int tb_QcXm_wpbs { get; set; }
    }
}