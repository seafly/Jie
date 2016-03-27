using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace Cabio.Model.Crafts
{
    //tb_gxcccp
    public class tb_gxcccp
    {
        public string rowBs { get; set; }

        /// <summary>
        /// tb_gxcccp_ID
        /// </summary>		
        public int tb_gxcccp_ID { get; set; }
        /// <summary>
        /// tb_gxcccp_gxbs
        /// </summary>		
        public int tb_gxcccp_gxbs { get; set; }
        /// <summary>
        /// tb_gxcccp_wpbs
        /// </summary>		
        public int tb_gxcccp_wpbs { get; set; }
        /// <summary>
        /// tb_gxcccp_isdp
        /// </summary>		
        public string tb_gxcccp_isdp { get; set; }
        /// <summary>
        /// tb_gxcccp_ccps
        /// </summary>		
        public int tb_gxcccp_ccps { get; set; }

        #region 辅助属性
        /// <summary>
        /// 
        /// </summary>
        public string tb_wp_pm { get; set; }

        public string tb_wp_dm { get; set; }

        public int tb_wp_ID { get; set; }
        #endregion

    }
}