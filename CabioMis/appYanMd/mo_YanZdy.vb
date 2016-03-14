Imports System.Reflection
Imports System.Collections
Imports System.Text

Public Module mo_YanZdy
    ''' <summary>
    ''' 物品分类
    ''' </summary>
    Public Enum en_wpfl As Integer
        <EnumDescription("A")> _
        备品备件
        <EnumDescription("B")> _
        原料
        <EnumDescription("C")> _
        包材
        <EnumDescription("Z")> _
        合成
        <EnumDescription("X")> _
        过程品
        <EnumDescription("Y")> _
        成品
    End Enum
    ''' <summary>
    ''' 原料详细列表
    ''' </summary>
    Public Enum en_Tjzd As Integer
        原料批号
        物料代码
        物料名称
        使用量
        操作类型
        操作对象
        对象名称
        操作时间
    End Enum
    ''' <summary>
    ''' 原料统计
    ''' </summary>
    Public Enum en_Yltj As Integer
        物料代码
        物料名称
        使用量
    End Enum
    ''' <summary>
    ''' 流程详情
    ''' </summary>
    Public Enum en_LcTj As Integer
        主键
        名称
        产品代码
        加工代码
        批号
        产出日期
        产出量
    End Enum
    ''' <summary>
    ''' 流程统计
    ''' </summary>
    Public Enum en_PcTj As Integer
        名称
        数量
        产出量
    End Enum
    ''' <summary>
    ''' 流程表名
    ''' </summary>
    Public Enum en_LcTableName As Integer
        <EnumDescription("tb_b970t")> _
        一级罐生产
        <EnumDescription("tb_b959t")> _
        二级罐生产
        <EnumDescription("tb_i234a")> _
        发酵罐生产
        <EnumDescription("tb_meijie")> _
        酶解
        <EnumDescription("tb_x825p")> _
        毛油
        <EnumDescription("tb_k306c")> _
        精炼
        <EnumDescription("tb_donghua")> _
        冬化
        <EnumDescription("tb_tuoxiu")> _
        脱臭
        <EnumDescription("tb_h195z")> _
        成品油
        <EnumDescription("tb_x823p")> _
        粉剂配料
        <EnumDescription("tb_n441f")> _
        配料批
        <EnumDescription("tb_p525h")> _
        粉剂小批
        <EnumDescription("tb_x832p")> _
        成品粉
    End Enum

    ''' <summary>
    ''' 存贮性质
    ''' </summary>
    Public Enum en_Bllx As Integer
        生产原料 = 0
        合成原料 = 1
    End Enum
    ''' <summary>
    ''' 系统类别
    ''' </summary>
    Public Enum en_xtLb As Integer
        QC项目
        统计报表
    End Enum
    ''' <summary>
    ''' 成品名称
    ''' </summary>
    Public Enum en_cpMc As Integer
        <EnumDescription("tb_x825p")> _
        毛油
        <EnumDescription("tb_h195z")> _
        成品油
        <EnumDescription("tb_x832p")> _
        成品粉
    End Enum
    ''' <summary>
    ''' qc类型
    ''' </summary>
    Public Enum en_QcLX As Integer
        物品
        成品
        工序
        工艺
    End Enum
    ''' <summary>
    ''' 保存报表
    ''' </summary>
    Public Enum en_saveBb As Integer
        <EnumDescription("bb_tb_x832p")> _
        成品粉生产进度
        <EnumDescription("bb_tb_x832p_2")> _
        成品粉生产进度2
    End Enum
    ''' <summary>
    ''' QA结果
    ''' </summary>
    Public Enum en_qaJg As Integer
        待定
        合格
        不合格
    End Enum
    ''' <summary>
    ''' QA用途建议
    ''' </summary>
    Public Enum en_qaYtJy As Integer
        返工
    End Enum
    ''' <summary>
    ''' 仓库列表
    ''' </summary>
    Public Enum en_cklist As Integer
        <EnumDescription("bfb")> _
        北方办
        <EnumDescription("kdlk")> _
        葛店冷库
        <EnumDescription("storagemslk")> _
        庙山冷库
        <EnumDescription("storagewzlk")> _
        外租冷库
    End Enum
    ''' <summary>
    ''' 附加信息类型
    ''' </summary>
    Public Enum en_fjxxLx
        数字
        文本
        选择
        批号
    End Enum
    ''' <summary>
    ''' 扩展批号类型
    ''' </summary>
    Public Enum en_phEx
        附加信息
    End Enum
    ''' <summary>
    ''' 生产状态
    ''' </summary>
    Public Enum en_sczt
        待定
        完成
        报废
    End Enum
    ''' <summary>
    ''' 库存用途
    ''' </summary>
    Public Enum en_kcyt
        生产
        报废
        实验
        返工
        销售
        其他
    End Enum
    ''' <summary>
    ''' LOAD图片
    ''' </summary>
    Public G_loadimg As Image = Image.FromFile(Application.StartupPath() & "\loading.gif")
End Module
