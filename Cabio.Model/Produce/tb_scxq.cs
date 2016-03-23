using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Runtime.InteropServices;

namespace Cabio.Model.Produce
{
    public class tb_scxq
    {
        /// <summary>
        /// 主键
        /// </summary>		
        public int tb_scxq_ID { get; set; }
        /// <summary>
        /// 文本
        /// </summary>		
        public string tb_scxq_text { get; set; }
        /// <summary>
        /// 值
        /// </summary>		
        public string tb_scxq_value { get; set; }
        /// <summary>
        /// 类型
        /// </summary>		
        public string tb_scxq_lx { get; set; }
        /// <summary>
        /// 工艺生产标识
        /// </summary>		
        public int tb_scxq_scbs { get; set; }
        /// <summary>
        /// 信息标识
        /// </summary>		
        public int tb_scxq_xxbs { get; set; }

        /// <summary>
        /// 原料类别
        /// </summary>
        public int lb { get; set; }

    }
}