using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.uceip.DBUtility.iBatis.BaseImpl;
using Cabio.DLL.Produce;
using Cabio.Model.Produce;
using Cabio.DLL.Material;
using Cabio.Model.Material;

namespace Cabio.BLL.Produce
{
    /// <summary>
    /// 生产服务
    /// </summary>
    public class ProduceService : BaseService<tb_sc>
    {
        public ProduceService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            dao = new ProduceDao(_daoManager);
        }

        /// <summary>
        /// 保存生产信息
        /// </summary>
        /// <param name="produce"></param>
        /// <param name="scxq_list"></param>
        /// <param name="wlphl_ist"></param>
        /// <returns></returns>
        public int Save(tb_sc produce, List<tb_scxq> fjxx_list, List<tb_scxq> tlxx_list, List<tb_scxq> ccxx_list, List<tb_wlph> wlphl_ist)
        {
            int result = 0;
            try
            {

                ProduceDetailDao detailDao = new ProduceDetailDao(_daoManager);
                MaterialStockDao materialStockDao = new MaterialStockDao(_daoManager);

                _daoManager.BeginTransaction();

                #region 保存生产信息

                if (exist(produce))
                {
                    //存在相同的单号
                    _daoManager.RollBackTransaction();
                    return -3;
                }

                int produceKey = 0;
                //保存生产信息
                if (produce.tb_sc_ID > 0)
                {
                    produceKey = dao.Update(produce);
                }
                else
                {
                    produceKey = dao.Insert(produce);
                }

                if (produceKey < 1)
                {
                    throw new Exception("保存生产信息出错");
                }

                #endregion

                #region 保存附加信息
                detailDao.RemoveByMap("附加信息", produce.tb_sc_ID.ToString());
                foreach (tb_scxq scxq in fjxx_list)
                {
                    scxq.tb_scxq_scbs = produceKey;
                    if (detailDao.Insert(scxq) < 1)
                    {
                        throw new Exception("保存附加信息出错");
                    }
                }
                #endregion

                #region 保存投料信息
                detailDao.RemoveByMap("投料", produce.tb_sc_ID.ToString());
                foreach (tb_scxq scxq in tlxx_list)
                {
                    if (scxq.lb == 1)
                    {

                    }
                    else
                    {

                    }
                    tb_syjl  syjl = new tb_syjl();

                    scxq.tb_scxq_scbs = produceKey;
                    if (detailDao.Insert(scxq) < 1)
                    {
                        throw new Exception("保存投料信息出错");
                    }
                }
                #endregion

                #region 保存产出信息
                detailDao.RemoveByMap("产出", produce.tb_sc_ID.ToString());
                foreach (tb_scxq scxq in ccxx_list)
                {
                    scxq.tb_scxq_scbs = produceKey;
                    if (detailDao.Insert(scxq) < 1)
                    {
                        throw new Exception("保存产出信息出错");
                    }
                }
                #endregion

                #region 保存物料批号

                MaterialDao material_Dao = new MaterialDao(_daoManager);
                MaterialStockDao material_stock_Dao = new MaterialStockDao(_daoManager);
                UseRecordDao user_record_Dao = new UseRecordDao(_daoManager);
                foreach (tb_wlph wlph in wlphl_ist)
                {
                    int wlphKey = material_Dao.Insert(wlph);
                    if (wlphKey < 1)
                    {
                        throw new Exception("保存物料批号报错");
                    }

                    wlph.wlphck.tb_wlphck_wlbs = wlphKey;
                    int wlphckKey = material_stock_Dao.Insert(wlph.wlphck);
                    if (wlphckKey < 1)
                    {
                        throw new Exception("保存物料批号库存报错");
                    }

                    tb_syjl syjl = new tb_syjl();
                    syjl.tb_syjl_wpbs = wlph.tb_wlph_wpbs;
                    syjl.tb_syjl_wpdm = wlph.tb_wlph_wpdm;
                    syjl.tb_syjl_xz = 1;
                    syjl.tb_syjl_yb = "tb_wlph";
                    syjl.tb_syjl_ybs = wlphKey;
                    syjl.tb_syjl_wlph = wlph.tb_wlph_wlph;
                    syjl.tb_syjl_zl = wlph.tb_wlph_sl;
                    syjl.tb_syjl_cjcl = wlph.tb_wlph_sl;
                    syjl.tb_syjl_czlx = "生产";
                    syjl.tb_syjl_mbb = "tb_wlphck";
                    syjl.tb_syjl_czbs = wlphckKey.ToString();
                    if (user_record_Dao.Insert(syjl) < 1)
                    {
                        throw new Exception("保存使用记录报错");
                    }
                }

                #endregion

                _daoManager.CommitTransaction();
                result = 1;
            }
            catch
            {
                result = -1;
                _daoManager.RollBackTransaction();
            }

            return result;
        }

        /// <summary>
        /// 是否存在相同的单号
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool exist(tb_sc t)
        {
            Hashtable map = new Hashtable();
            map.Add("exist", "exist");
            map.Add("tb_sc_ID", t.tb_sc_ID);
            map.Add("tb_sc_dh", t.tb_sc_dh);

            return dao.GetObject(map) == null ? false : true;
        }
    }
}
