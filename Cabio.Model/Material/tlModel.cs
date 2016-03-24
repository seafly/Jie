using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cabio.Model.Material
{
    public class tlModel
    {
        /// <summary>
        /// 生产信息标识
        /// </summary>
        public int xxbs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tb_scxq_text { get; set; }

        public string tb_scxq_value { get; set; }

        public int tb_wp_ID { get; set; }

        public string tb_wp_dm { get; set; }

        public string tb_syjl_wlph { get; set; }
        public decimal tb_syjl_zl { get; set; }
        public decimal tb_syjl_cjcl { get; set; }
        public int tb_syjl_ybs { get; set; }
    }
}
