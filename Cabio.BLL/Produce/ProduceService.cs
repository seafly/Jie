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
        /// 获取生产信息
        /// </summary>
        /// <param name="gxbs">工艺标识</param>
        /// <returns></returns>
        public IList<tb_sc> GetScInfo(string gxbs)
        {
            Hashtable map = new Hashtable();
            map.Add("tb_sc_isEnd", "待定");
            map.Add("tb_sc_gxbs", gxbs);
            return new ProduceDao(_daoManager).GetScInfo(map);
        }

        /// <summary>
        /// 保存生产信息
        /// </summary>
        /// <param name="produce"></param>
        /// <param name="scxq_list"></param>
        /// <param name="wlphl_ist"></param>
        /// <returns></returns>
        public int Save(tb_sc produce, List<tb_scxq> fjxx_list, List<tlModel> tlxx_list, List<tb_scxq> ccxx_list, List<tb_wlph> wlphl_ist)
        {
            int result = 0;
            try
            {

                ProduceDetailDao detailDao = new ProduceDetailDao(_daoManager);
                MaterialStockDao materialStockDao = new MaterialStockDao(_daoManager);
                MaterialDao material_Dao = new MaterialDao(_daoManager);
                WlDao wl_Dao = new WlDao(_daoManager);
                UseRecordDao user_record_Dao = new UseRecordDao(_daoManager);


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
                foreach (tlModel tl in tlxx_list)
                {
                    tb_scxq scxq = new tb_scxq();
                    scxq.tb_scxq_xxbs = tl.xxbs;
                    scxq.tb_scxq_text = tl.tb_scxq_text;
                    scxq.tb_scxq_value = tl.tb_scxq_value;
                    scxq.tb_scxq_scbs = produceKey;
                    if (detailDao.Insert(scxq) < 1)
                    {
                        throw new Exception("保存投料信息出错");
                    }
                    string strYb = "";
                    string strCjcl = "";
                    if (scxq.lb == 1)
                    {
                        strYb = "tb_wlphck";
                        strCjcl = "tb_wlphck_cjcl";

                        tb_wlphck ck = materialStockDao.GetObject(1);
                        if (ck != null && ck.tb_wlphck_cjcl >= 1)
                        {
                            ck.tb_wlphck_cjcl = ck.tb_wlphck_cjcl - 1;
                            if (materialStockDao.Update(ck) < 1)
                            {
                                throw new Exception("保存投料信息出错");
                            }
                        }
                        else
                        {
                            //库存不足
                            _daoManager.RollBackTransaction();
                            return -5;
                        }

                    }
                    else
                    {
                        strYb = "tb_i259b";
                        strCjcl = "tb_i259b_p518h";

                        tb_i259b wl = wl_Dao.GetObject(1);
                        if (wl != null && wl.tb_i259b_p518h >= 1)
                        {
                            wl.tb_i259b_p518h = wl.tb_i259b_p518h - 1;
                            if (wl_Dao.Update(wl) < 1)
                            {
                                throw new Exception("保存投料信息出错");
                            }
                        }
                        else
                        {
                            //库存不足
                            _daoManager.RollBackTransaction();
                            return -5;
                        }
                    }
                    tb_syjl syjl = new tb_syjl();
                    syjl.tb_syjl_wpbs = tl.tb_wp_ID;
                    syjl.tb_syjl_wpdm = tl.tb_wp_dm;
                    syjl.tb_syjl_xz = 0;
                    syjl.tb_syjl_yb = strYb;
                    syjl.tb_syjl_wlph = tl.tb_syjl_wlph;
                    syjl.tb_syjl_zl = tl.tb_syjl_zl;
                    syjl.tb_syjl_cjcl = tl.tb_syjl_cjcl;
                    syjl.tb_syjl_ybs = tl.tb_syjl_ybs;
                    syjl.tb_syjl_czlx = "生产";
                    syjl.tb_syjl_mbb = "tb_wlph";
                    syjl.tb_syjl_czbs = "";

                    if (user_record_Dao.Insert(syjl) < 1)
                    {
                        throw new Exception("保存原料使用记录报错");
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
                foreach (tb_wlph wlph in wlphl_ist)
                {
                    int wlphKey = material_Dao.Insert(wlph);
                    if (wlphKey < 1)
                    {
                        throw new Exception("保存物料批号报错");
                    }

                    wlph.wlphck.tb_wlphck_wlbs = wlphKey;
                    int wlphckKey = materialStockDao.Insert(wlph.wlphck);
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
