using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.uceip.DBUtility.iBatis.BaseImpl;
using Cabio.Model.Code;
using Cabio.DLL.Code;

namespace Cabio.BLL.Code
{
    /// <summary>
    /// 自定义批号服务
    /// </summary>
    public class CustomeizeCodeService : BaseService<tb_bcbm>
    {
        public CustomeizeCodeService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            dao = new CustomeizeCodeDao(_daoManager);
        }

        public List<tb_bcbm> GetBmList()
        {
            List<tb_bcbm> result = new List<tb_bcbm>();

            IList List = base.GetListByQuery(null, "querytb_bcbm_bmmcList");


            return result;
        }

        /// <summary>
        /// 获取完整编码
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        private string getAllBm(IList list)
        {
            string result = "";

            foreach (tb_bcbm bm in list)
            {
                switch (bm.tb_bcbm_lx)
                {
                    case "文本":
                        break;
                    case "当前年":
                        result += DateTime.Now.ToString("yyyy");
                        break;
                    case "当前年(2位)":
                        result += DateTime.Now.ToString("yy");
                        break;
                    case "当前月":
                        result += DateTime.Now.ToString("MM");
                        break;
                    case "当前日":
                        result += DateTime.Now.ToString("dd");
                        break;
                    case "随机数":
                        string strMd = "";
                        int len = bm.tb_bcbm_va.Length;
                        if (len == 0)
                        {
                            len = 3;
                        }
                        else
                        {
                            for (int i = 0; i < len; i++)
                            {
                                strMd += "9";
                            }
                        }

                        result += new Random().Next(int.Parse(strMd));
                        break;
                    case "累加数":
                        string strLj = "";
                        int iXz = 0;
                        switch (bm.tb_bcbm_zdbz)
                        {
                            case "年":
                                break;
                            case "月":
                                break;
                            case "日":
                                break;
                            default:
                                break;
                        }

                        break;
                    case "1":
                        break;
                }
            }
        }
    }
}
