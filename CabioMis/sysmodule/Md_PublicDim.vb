Module Md_PublicDim '公共变量定义
    Public G_cnnstr, G_cnnstrWH, G_cnnstr2 As String '数据库链接字符串
    Public G_zdinf As DataTable '所有字段列表
    Public G_biaoinf As DataTable '所有表列表
    Public G_bm As DataTable '部门表
    Public G_yg As DataTable '员工表
    Public G_face As DataTable '界面表
    Public G_dlr, G_dlrgh, G_dlqx, G_bumen, G_js As String '登录人姓名，登录人工号,登陆人权限,登录人部门，登录人角色

    Public G_dlrmm As String '登录人密码
    Public G_backimg As Image, G_icon, G_TJicon As Icon '图标、背景
    Public G_xdz, G_zdd, G_ddf As Integer '小大中，中到大，大到放的时间
    Public G_IPAdress As String = System.Net.Dns.GetHostEntry("").AddressList.GetValue(0).ToString '获得本机的IP
    Public G_TimeSession As Integer = 120 '储存员工发生操作的时刻
    Public G_qx1 As String = ""
    Public G_qx2 As String = ""
    Public G_qx3 As String = ""
    Public G_zdybbsql As String '自定义报表的名称，sql语句
    Public G_DriverNum As String '磁盘卷标

    Public G_FR_SPLASHSCREEN As SplashScreen1
    ''''''''''''''''''''''''
    '培训类别数组 
    Public G_PXLB As String() = {"SOP", "FS", "EHS", "其它", "外训"}
    ''''''''''''''''''''''''''''
    'MOC类别数组 
    Public G_MOCLB As String() = {"CG产能提升", "FSQ", "EHS", "PI工艺优化、改进", "Cost 成本"}
    '''''''''''''''''''''''''''''''''''''''''''
    '偏差类别数组
    Public G_PCLB As String() = {"工艺技术", "设备保障", "外部因素", "采购", "检测", "其它"}

    '''''''''''''''''''''''''''''''''''''''''''
    '报表的部门数组
    Public G_BBBMSZ As String() = {"工艺技术", "设备保障", "外部因素", "采购", "检测", "其它"}
    Public G_SYCPDMB As DataTable '所有产品代码基础表


End Module
