using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace Cabio.Model.Material
{
    public class tb_wlphck
    {
        /// <summary>
        /// 主键
        /// </summary>		
        public int tb_wlphck_ID { get; set; }
        /// <summary>
        /// 物料标识
        /// </summary>		
        public int tb_wlphck_wlbs { get; set; }
        /// <summary>
        /// 物料批号
        /// </summary>		
        public string tb_wlphck_wlph { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>		
        public string tb_wlphck_cplb { get; set; }
        /// <summary>
        /// 产品代码
        /// </summary>		
        public string tb_wlphck_mingc { get; set; }
        /// <summary>
        /// 加工代码
        /// </summary>		
        public string tb_wlphck_jiagdm { get; set; }
        /// <summary>
        /// 车间存量
        /// </summary>		
        public decimal tb_wlphck_cjcl { get; set; }
        /// <summary>
        /// 北方办
        /// </summary>		
        public decimal tb_wlphck_bfb { get; set; }
        /// <summary>
        /// 葛店冷库
        /// </summary>		
        public decimal tb_wlphck_kdlk { get; set; }
        /// <summary>
        /// 庙山冷库
        /// </summary>		
        public decimal tb_wlphck_storagemslk { get; set; }
        /// <summary>
        /// 外租冷库
        /// </summary>		
        public decimal tb_wlphck_storagewzlk { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime tb_wlphck_ftime { get; set; }
        /// <summary>
        /// 总重量
        /// </summary>		
        public decimal tb_wlphck_zzl { get; set; }
        /// <summary>
        /// 可用重量
        /// </summary>		
        public decimal tb_wlphck_kyzl { get; set; }
        /// <summary>
        /// 物品标识
        /// </summary>		
        public int tb_wlphck_wpbs { get; set; }
        /// <summary>
        /// 计划用途
        /// </summary>		
        public string tb_wlphck_yt { get; set; }
    }
}