using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace Cabio.Model.QC
{
    public class tb_QcVa
    {
        /// <summary>
        /// 主键
        /// </summary>		
        public int tb_QcVa_ID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>		
        public string tb_QcVa_xmmc { get; set; }
        /// <summary>
        /// 项目结果
        /// </summary>		
        public string tb_QcVa_xmva { get; set; }
        /// <summary>
        /// QC标识
        /// </summary>		
        public int tb_QcVa_Qcbs { get; set; }

    }
}