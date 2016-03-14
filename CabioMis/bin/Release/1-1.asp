<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>
<!--#include file="yz.asp" -->
<%dim buttonx
buttonx="<input name='Submit1' type='button' value='全选' onClick='vbscript:qx'> <input nam" _
&"e='Submit12' type='button' value='全不选' onclick='vbscript:qbx'>"
call openadodb
dim js
js=checkStr(request("js"))
if js="" then
response.end
end if
dim sql,rs
sql="select * from tb_js where tb_js_mc='"& js &"' "
set rs=cnn.execute(sql)
dim ylqx,yldljm'原来权限、原来登陆界面
ylqx=rs(2):yldljm=rs(3)
''''''''''''''''''''''''''''''
dim kk1 '显示登陆界面
kk1="<select name='select1'>"
set rs=cnn.execute("select * from tb_face")
do while not rs.eof
kk1=kk1 & mrdljm(rs(1),yldljm)
rs.movenext
loop
kk1=kk1 & "</select>"
set rs=nothing
closeadodb
'''''''''''''''''''''''''''''
function gzbgh(str)
dim tt
tt="<td>"& str &"</td><td>"& gzbgh2(ylqx,"查询"& str ) &"查询</td>"
tt=tt & "<td>"& gzbgh2(ylqx,"添加"& str ) & "添加</td>"
tt=tt & "<td>"& gzbgh2(ylqx,"修改"& str ) & "修改</td>"
tt=tt & "<td>"& gzbgh2(ylqx,"删除"& str ) & "删除</td>"
tt=tt & "<td>&nbsp;</td>"
gzbgh=tt
end function 
function gzbgh3(str)
dim tt
tt="<td>"& str &"</td><td>"& gzbgh2(ylqx,"查询"& str ) &"查询</td>"
tt=tt & "<td>"& gzbgh2(ylqx,"添加"& str ) & "添加</td>"
tt=tt & "<td>"& gzbgh2(ylqx,"修改"& str ) & "修改</td>"
tt=tt & "<td>&nbsp;</td>"
tt=tt & "<td>&nbsp;</td>"
gzbgh3=tt
end function 
''''''''''''''''''''''''''''
 function gzbgh2(str1,str2)
dim tt1,tt2
tt1="," & str1 & ","
tt2="," & str2 & ","
if instr(tt1,tt2)>0 then
gzbgh2="<input type='checkbox' CHECKED name='checkbox1' value='"& str2 &"'> "
ELSE
gzbgh2="<input type='checkbox' name='checkbox1' value='"& str2 &"'> "
end if
end function
function mrdljm(str1,str2)
if str1=str2 then
mrdljm="<option value='"& str1 &"'  selected>"& str1 &"</option>"
else
mrdljm="<option value='"& str1 &"'>"& str1 &"</option>"
end if
end function%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>设定角色</title>
<STYLE type=text/css>
 body {  font-size: 12px}
td {  font-size: 12px}
</STYLE>
<script type="text/vbscript">
dim a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12,a13,a14
sub qx
dim tt 
set tt=window.event.srcElement.parentElement.parentElement
dim i
for i=0 to tt.cells.length -1
cc=tt.cells(i).innerhtml
cc=replace(cc," type=checkbox"," type=checkbox CHECKED" )
tt.cells(i).innerhtml=cc
next
end sub
sub qbx
dim tt 
set tt=window.event.srcElement.parentElement.parentElement
dim i
for i=0 to tt.cells.length -1
cc=tt.cells(i).innerhtml
cc=replace(cc," CHECKED","" )
tt.cells(i).innerhtml=cc
next
end sub
SUB GBYS(STR)
dim jj
jj=DOCUMENT.ALL(STR).innerhtml
if jj="" then
select case str
case "MYTB1":jj=a1:case "MYTB2":jj=a2
case "MYTB3":jj=a3:case "MYTB4":jj=a4
case "MYTB5":jj=a5:case "MYTB6":jj=a6
case "MYTB7":jj=a7:case "MYTB8":jj=a8
case "MYTB9":jj=a9:case "MYTB10":jj=a10:case "MYTB11":jj=a11
case "MYTB12":jj=a12:case "MYTB13":jj=a13:case "MYTB14":jj=a14
end select
DOCUMENT.ALL(STR).innerhtml=jj
else
select case str
case "MYTB1":a1=jj:case "MYTB2":a2=jj
case "MYTB3":a3=jj:case "MYTB4":a4=jj
case "MYTB5":a5=jj:case "MYTB6":a6=jj
case "MYTB7":a7=jj:case "MYTB8":a8=jj
case "MYTB9":a9=jj:case "MYTB10":a10=jj:case "MYTB11":a11=jj
case "MYTB12":a12=jj:case "MYTB13":a13=jj:case "MYTB14":a14=jj
end select
DOCUMENT.ALL(STR).innerhtml=""
end if

END SUB
sub tjbd
form1.submit
end sub
sub Freeall
call GBYS("MYTB1"):call GBYS("MYTB2"):call GBYS("MYTB3"):call GBYS("MYTB4")
call GBYS("MYTB5"):call GBYS("MYTB6"):call GBYS("MYTB7"):call GBYS("MYTB8")
call GBYS("MYTB9"):call GBYS("MYTB10"):call GBYS("MYTB11"):call GBYS("MYTB12"):call GBYS("MYTB13"):call GBYS("MYTB14")
end sub
</script>
</head>

<body style="font-size:10px"><form name="form1" action="sqx.asp" method="post" ><font style="font-size:15px" >设定角色：<%=js %>，默认登录界面</font>
<input name="js" type="hidden" value="<%=js %>">

<% 
response.Write(kk1) '显示登陆界面
%>

<input type="button" name="ss_yes" id="ss_yes" value="提交" onClick="vbscript:call tjbd">
  <input name="ss_free" type="button"  value="全部展开" onClick="vbscript:call Freeall">
  <hr/>
<font ONCLICK="vbscript:CALL GBYS('MYTB1')" style="cursor:hand;font-size:15px">-油剂部</font>
<div ID="MYTB1">
<table width="95%" border="1" >
  <tr>
   <%= gzbgh3("小罐") %><td><%= buttonx %></td>
  </tr>
    <tr>
   <%= gzbgh3("中罐") %><td><%= buttonx %></td>
  </tr>
    <tr>
   <%= gzbgh3("大罐") %><td><%= buttonx %></td>
  </tr>
     <tr>
    <td><%= gzbgh2(ylqx,"添加糖罐") %>添加糖罐</td>
     <td><%= gzbgh2(ylqx,"查询糖罐") %>查询糖罐</td>
   <td><%= gzbgh2(ylqx,"添加碱罐") %>添加碱罐</td>
        <td><%= gzbgh2(ylqx,"查询碱罐") %>查询碱罐</td>
    <td><%= gzbgh2(ylqx,"添加CIP碱罐") %>添加CIP碱罐</td>
     <td><%= gzbgh2(ylqx,"查询CIP碱罐") %>查询CIP碱罐</td>
	 <td><%= buttonx %></td>
  </tr>
       <tr>
    <td><%= gzbgh2(ylqx,"添加放罐") %>添加放罐</td>
     <td><%= gzbgh2(ylqx,"修改放罐") %>修改放罐</td>
  <td><%= gzbgh2(ylqx,"查询放罐") %>查询放罐</td>
      <td><%= gzbgh2(ylqx,"添加MV溶液") %>添加MV溶液</td>
   <td>　</td>
 <td>　</td>
	<td>　</td>
  </tr>
    <tr>
   <%= gzbgh3("毛油") %><td><%= buttonx %></td>
  </tr>
      <tr>
  <td>毛油调配</td>

   <td><%= gzbgh2(ylqx,"查询毛油调配") %>查询毛油调配</td>
     <td><%= gzbgh2(ylqx,"进行毛油调配") %>进行毛油调配</td>
   <td><%= gzbgh2(ylqx,"完成毛油调配") %>完成毛油调配</td>
    <td><%= gzbgh2(ylqx,"手工毛油调配") %>手工毛油调配</td>
     <td>　</td>
	 <td><%= buttonx %></td>
  </tr>
    <tr>
    <td>精炼</td>
  <td><%= gzbgh2(ylqx,"查询精炼") %>查询精炼</td>
   <td>　</td>
   <td><%= gzbgh2(ylqx,"修改精炼") %>修改精炼</td>
    <td>　</td>
     <td>　</td>
	 <td><%= buttonx %></td>
  </tr>
    <tr>
   <%= gzbgh3("成品油") %><td><%= buttonx %></td>
  </tr>
   <tr><%= gzbgh("现场检查发现项跟踪系统") %><td><%= buttonx %></td></tr>
     <tr><%= gzbgh("5S检查得分统计") %><td><%= buttonx %></td></tr>
</table>
</div>
<font ONCLICK="vbscript:CALL GBYS('MYTB2')" style="cursor:hand;font-size:15px">-粉剂部</font>
<div ID="MYTB2"><table width="95%" border="1" >
   <tr>
    <td>粉剂配料调配</td>

   <td><%= gzbgh2(ylqx,"查询粉剂配料调配") %>查询粉剂配料调配</td>
     <td><%= gzbgh2(ylqx,"进行粉剂配料调配") %>进行粉剂配料调配</td>
   <td><%= gzbgh2(ylqx,"完成粉剂配料调配") %>完成粉剂配料调配</td>
    <td><%= gzbgh2(ylqx,"手工粉剂调配") %>手工粉剂调配</td>
     <td>　</td>
	 <td><%= buttonx %></td>
  </tr>
     <tr>
    <td>粉剂配料批</td>
  <td></td>
   <td>　</td>
   <td><%= gzbgh2(ylqx,"添加粉剂配料批") %>添加粉剂配料批</td>
    <td>　</td>
     <td>　</td>
	 <td><%= buttonx %></td>
  </tr>
       <tr>
      <td>小批</td>
  <td><%= gzbgh2(ylqx,"查询小批") %>查询小批</td>
   <td><%= gzbgh2(ylqx,"小批喷雾") %>小批喷雾</td>
   <td><%= gzbgh2(ylqx,"添加成品粉混批计划") %>添加成品粉混批计划</td>
    <td><%= gzbgh2(ylqx,"修改成品粉混批计划") %>修改成品粉混批计划</td>
     <td>　</td>
	 <td><%= buttonx %></td>
  </tr>
       <tr>
  <td>成品粉</td>
  <td><%= gzbgh2(ylqx,"查询成品粉") %>查询成品粉</td>
   <td><%= gzbgh2(ylqx,"添加成品粉") %>添加成品粉</td>
   <td><%= gzbgh2(ylqx,"修改成品粉") %>修改成品粉</td>
    <td>　</td>
     <td>　</td>
	 <td><%= buttonx %></td>
  </tr>
 
</table></div>
   <font ONCLICK="vbscript:CALL GBYS('MYTB14')" style="cursor:hand;font-size:15px">-技术部</font>
<div ID="MYTB14"><table width="95%" border="1"  >
                       <tr>
  <td><%= gzbgh2(ylqx,"查看研发项目资料") %>查看研发项目资料</td>
  <td><%= gzbgh2(ylqx,"添加研发项目资料") %>添加研发项目资料</td>
   <td><%= gzbgh2(ylqx,"添加研发项目") %>添加研发项目</td>
    <td><%= gzbgh2(ylqx,"修改研发项目") %>修改研发项目</td>
   <td><%= gzbgh2(ylqx,"删除研发项目") %>删除研发项目</td>
  <td><%= gzbgh2(ylqx,"添加研发项目档案") %>添加研发项目档案</td>
   <td><%= gzbgh2(ylqx,"查看研发项目档案") %>查看研发项目档案</td>
   <td><%= gzbgh2(ylqx,"删除研发项目文档") %>删除研发项目文档</td>
  </tr> 
   </table></div>
<font ONCLICK="vbscript:CALL GBYS('MYTB3')" style="cursor:hand;font-size:15px">-QC部</font>
<div ID="MYTB3"><table width="95%" border="1" >
   <tr><td>QC管理</td>
  <td><%= gzbgh2(ylqx,"添加QC") %>添加QC</td>
   <td><%= gzbgh2(ylqx,"修改QC") %>修改QC</td>
   <td><%= gzbgh2(ylqx,"删除QC") %>删除QC</td>
    <td>　</td>
     <td>　</td>
	 <td><%= buttonx %></td></tr>
	   <tr><%= gzbgh("环境微生物检测") %><td><%= buttonx %></td></tr>
	      <tr><%= gzbgh("污水检测记录") %><td><%= buttonx %></td></tr>
		     <tr><%= gzbgh("外检项目记录") %><td><%= buttonx %></td></tr>
</table></div>
<font ONCLICK="vbscript:CALL GBYS('MYTB4')" style="cursor:hand;font-size:15px">-QA部</font>
<div ID="MYTB4"><table width="95%" border="1" >

   <tr><td>QA管理</td>
  <td><%= gzbgh2(ylqx,"添加QA") %>添加QA</td>
   <td>　</td>
   <td><%= gzbgh2(ylqx,"删除QA") %>删除QA</td>
    <td>　</td>
     <td>　</td>
	 <td><%= buttonx %></td></tr>

	     <tr><%= gzbgh("MOC台账") %><td><%= buttonx %></td></tr>
	<tr><%= gzbgh("Customer complaints") %><td><%= buttonx %></td></tr>
	 <tr><%= gzbgh("偏差台账") %><td><%= buttonx %></td></tr>
 <tr><%= gzbgh("食品安全质量（FSQ）审核改进情况统计表") %><td><%= buttonx %></td></tr>
    <tr><%= gzbgh("文件清单") %><td><%= buttonx %></td></tr>
	  <tr><%= gzbgh("客户投诉记录") %><td><%= buttonx %></td></tr>
	    <tr><%= gzbgh("供应商现场审核台账") %><td><%= buttonx %></td></tr>
		  <tr><%= gzbgh("查询FSQ内审") %><td><%= buttonx %></td></tr>
		    <tr><%= gzbgh("外部审核情况") %><td><%= buttonx %></td></tr>
  
 

</table></div>
<font ONCLICK="vbscript:CALL GBYS('MYTB5')" style="cursor:hand;font-size:15px">-设备动力部</font>
<div ID="MYTB5"><table width="95%" border="1" >
   <tr><%= gzbgh("蒸汽、柴油") %><td><%= buttonx %></td></tr>
   <tr><%= gzbgh("自来水") %><td><%= buttonx %></td></tr>
   <tr><%= gzbgh("电") %><td><%= buttonx %></td></tr>
     <tr><%= gzbgh("过滤器更换记录") %><td><%= buttonx %></td></tr>
</table></div>
<font ONCLICK="vbscript:CALL GBYS('MYTB6')" style="cursor:hand;font-size:15px">-EHS部</font>
<div ID="MYTB6"><table width="95%" border="1" >
   <tr><%= gzbgh("现场检查安排表") %><td><%= buttonx %></td></tr>
   <tr><%= gzbgh("幸免事故报告追踪系统") %><td><%= buttonx %></td></tr>
     <tr><%= gzbgh("EHS统计月报") %><td><%= buttonx %></td></tr>
</table></div>
 <font ONCLICK="vbscript:CALL GBYS('MYTB7')" style="cursor:hand;font-size:15px">-采购部</font>
<div ID="MYTB7"><table width="95%" border="1" >      
        <tr><%= gzbgh("采购品投诉处理") %><td><%= buttonx %></td></tr>
        <tr><%= gzbgh("请购及到货跟踪") %><td><%= buttonx %></td></tr>
		<tr><%= gzbgh("基础表") %><td><%= buttonx %></td></tr>

        <tr><%= gzbgh("验收") %><td><%= buttonx %></td></tr>
        <td><%= gzbgh2(ylqx,"采购及请购单生效及偏差") %>采购及请购单生效及偏差</td>
 </table></div>
<font ONCLICK="vbscript:CALL GBYS('MYTB8')" style="cursor:hand;font-size:15px">-人力资源部</font>
<div ID="MYTB8"><table width="95%" border="1" >
   <tr><%= gzbgh("CABIO员工培训档案") %><td><%= buttonx %></td></tr>
 </table></div>
 <font ONCLICK="vbscript:CALL GBYS('MYTB9')" style="cursor:hand;font-size:15px">-运行部</font>
<div ID="MYTB9"><table width="95%" border="1" >
  <tr>
    <td><table width="95%" border="1" >
      <tr>
        <td><%= gzbgh2(ylqx,"进货") %>进货</td>
        <td><%= gzbgh2(ylqx,"出货") %>出货</td>
        <td><%= gzbgh2(ylqx,"修改入库信息") %>修改入库信息</td>
        <td><%= gzbgh2(ylqx,"修改剩余库存") %>修改剩余库存</td>
        <td><%= gzbgh2(ylqx,"添加非生产原料使用") %>添加非生产原料使用</td>
        <td><%= gzbgh2(ylqx,"删除非生产原料使用") %>删除非生产原料使用</td>
        <td><%= buttonx %></td>
      </tr>
      <tr>
        <td>原料管理</td>
        <td><%= gzbgh2(ylqx,"添加原料") %>添加原料</td>
        <td><%= gzbgh2(ylqx,"修改原料") %>修改原料</td>
        <td><%= gzbgh2(ylqx,"无效原料") %>无效原料</td>
        <td><%= gzbgh2(ylqx,"添加原料类别") %>添加原料类别</td>
        <td><%= gzbgh2(ylqx,"无效原料类别") %>无效原料类别</td>
        <td><%= buttonx %></td>
      </tr>
      <tr>
        <td><%= gzbgh2(ylqx,"查询毛油配料") %>查询毛油配料</td>
        <td><%= gzbgh2(ylqx,"完成粉剂配料计划") %>完成粉剂配料计划</td>
        <td><%= gzbgh2(ylqx,"作废粉剂配料执行") %>作废粉剂配料执行</td>
        <td><%= gzbgh2(ylqx,"查询粉剂配料") %>查询粉剂配料</td>
        <td><%= gzbgh2(ylqx,"完成毛油配料计划") %>完成毛油配料计划</td>
        <td><%= gzbgh2(ylqx,"作废毛油配料执行") %>作废毛油配料执行</td>
        <td><%= buttonx %></td>
      </tr>
      <tr>
        <td><%= gzbgh2(ylqx,"添加成品库存周报") %>添加成品库存周报</td>
        <td><%= gzbgh2(ylqx,"删除成品库存周报") %>删除成品库存周报</td>
        <td><%= gzbgh2(ylqx,"设定K3成品月库存及5S总分") %>设定K3成品月库存及5S总分</td>
        <td><%= gzbgh2(ylqx,"查询K3成品月库存及5S总分") %>查询K3成品月库存及5S总分</td>
        <td><%= gzbgh2(ylqx,"管理每月重要说明") %>管理每月重要说明</td>
        <td><%= gzbgh2(ylqx,"原料出库") %>原料出库</td>
        <td><%= buttonx %></td>
      </tr>
  <td><%= gzbgh2(ylqx,"订单查询") %>订单查询</td>
    <td><%= gzbgh2(ylqx,"订单添加修改") %>订单添加修改</td>
    <td><%= gzbgh2(ylqx,"订单发货实施") %>订单发货实施</td>
    <td>  </td>
    <td>  </td>
    <td>  </td>
     <td><%= buttonx %></td>
      </tr>
  <tr><%= gzbgh("运行计划") %>
    <td><%= buttonx %></td>
  </tr>
  <tr><%= gzbgh("发货月报") %>
    <td><%= buttonx %></td>
  </tr>
  <tr>
    <td><%= gzbgh2(ylqx,"设定能耗价格") %>设定能耗价格</td>
    <td><%= gzbgh2(ylqx,"设定能耗分摊") %>设定能耗分摊</td>
    <td><%= gzbgh2(ylqx,"查询能耗价格") %>查询能耗分摊</td>
    <td><%= gzbgh2(ylqx,"查询能耗分摊") %>查询能耗分摊</td>
    <td><%= gzbgh2(ylqx,"添加外加工油") %>添加外加工油</td>
    <td>　</td>
    <td><%= buttonx %></td>
  </tr>
  <tr>
    <td><%= gzbgh2(ylqx,"添加外购成品油") %>添加外购成品油</td>
    <td><%= gzbgh2(ylqx,"修改外购成品油") %>修改外购成品油</td>
    <td><%= gzbgh2(ylqx,"添加外购毛油") %>添加外购毛油</td>
    <td><%= gzbgh2(ylqx,"修改外购毛油") %>修改外购毛油</td>
    <td></td>
    <td>　</td>
    <td><%= buttonx %></td>
  </tr>
    </table></td>
  </tr>
</table></div>
  <font ONCLICK="vbscript:CALL GBYS('MYTB10')" style="cursor:hand;font-size:15px">-系统管理</font>
<div ID="MYTB10"><table width="95%" border="1"  >
   <tr>   <td>角色人员管理</td><td><%= gzbgh2(ylqx,"进入系统界面") %>进入系统界面</td><td><%= gzbgh2(ylqx,"角色管理") %>角色管理</td>
   <td><%= gzbgh2(ylqx,"人员管理") %>人员管理</td><td>　</td>
   <td>　</td><td><%= buttonx %></td></tr>
   <tr><td>部门管理</td><td>　</td>
   <td><%= gzbgh2(ylqx,"部门管理") %>部门管理</td><td>　</td><td>　</td>
   <td>　</td><td><%= buttonx %></td></tr>
   <tr>
   <td>批号规律管理</td><td>　</td>
   <td><%= gzbgh2(ylqx,"批号规律管理") %>批号规律管理</td><td><%= gzbgh2(ylqx,"生产流程时间控制") %>生产流程时间控制</td>
   <td><%= gzbgh2(ylqx,"添加产品类别") %>添加产品类别　</td>
   <td><%= gzbgh2(ylqx,"删除产品类别") %>删除产品类别　</td>
   <td><%= buttonx %></td></tr>
    <tr><td>文件上传</td>
	<td><%= gzbgh2(ylqx,"文件上传") %>文件上传</td>
   <td><%= gzbgh2(ylqx,"删除文件") %>删除文件</td><td>　</td><td>　</td>
   <td><%= gzbgh2(ylqx,"文件下载") %>文件下载</td>
   <td><%= buttonx %></td></tr>
       <tr>
	   <td><%= gzbgh2(ylqx,"保存自定义报表") %>保存自定义报表</td>
   <td><%= gzbgh2(ylqx,"删除自定义报表") %>删除自定义报表</td>
   <td><%= gzbgh2(ylqx,"设定自定义查询表权限") %>设定自定义查询表权限</td>
   <td><%= gzbgh2(ylqx,"设定报表权限") %>设定报表权限</td>
     <td><%= gzbgh2(ylqx,"编辑自定义报表权限") %>编辑自定义报表权限</td>
	  <td><%= gzbgh2(ylqx,"锁定报表") %>锁定报表</td>
   <td><%= buttonx %></td></tr>
   </table></div>
   <font ONCLICK="vbscript:CALL GBYS('MYTB11')" style="cursor:hand;font-size:15px">-界面管理</font>
<div ID="MYTB11"><table width="95%" border="1"  >
       <tr>     
      	   <td><%= gzbgh2(ylqx,"油剂部界面") %>油剂部界面</td> <td><%= gzbgh2(ylqx,"粉剂部界面") %>粉剂部界面</td>
   <td><%= gzbgh2(ylqx,"技术部界面") %>技术部界面</td> <td><%= gzbgh2(ylqx,"QA界面") %>QA界面</td>
  <td><%= gzbgh2(ylqx,"QC界面") %>QC界面</td></tr>
 <tr>    <td><%= gzbgh2(ylqx,"EHS界面") %>EHS界面</td>
  <td><%= gzbgh2(ylqx,"设备动力部界面") %>设备动力部界面</td>   <td><%= gzbgh2(ylqx,"运行部界面") %>运行部界面</td>
<td><%= gzbgh2(ylqx,"采购部界面") %>采购部界面</td> <td><%= gzbgh2(ylqx,"人力资源部界面") %>人力资源部界面</td>

</tr>
   </table></div>
      <font ONCLICK="vbscript:CALL GBYS('MYTB12')" style="cursor:hand;font-size:15px">-业务数据导出</font>
<div ID="MYTB12">
    <table width="95%" border="1"  >
      <tr> 
        <td><%= gzbgh2(ylqx,"导出小罐生产") %>导出小罐生产</td>
        <td><%= gzbgh2(ylqx,"导出中罐生产") %>导出中罐生产</td>
        <td><%= gzbgh2(ylqx,"导出大罐生产") %>导出大罐生产</td>
        <td><%= gzbgh2(ylqx,"导出毛油") %>导出毛油</td>
		<td><%= gzbgh2(ylqx,"导出精炼") %>导出精炼</td>
        <td><%= gzbgh2(ylqx,"导出成品油") %>导出成品油</td>
        <td><%= gzbgh2(ylqx,"导出毛油配料") %>导出毛油配料</td>
		 <td><%= gzbgh2(ylqx,"导出粉剂配料") %>导出粉剂配料</td>
		  <td></td>
      </tr>
		   <tr> 	 
		 <td><%= gzbgh2(ylqx,"导出配料批") %>导出配料批</td>
        <td><%= gzbgh2(ylqx,"导出粉剂小批") %>导出粉剂小批</td>
        <td><%= gzbgh2(ylqx,"导出成品粉") %>导出成品粉</td>
		 <td><%= gzbgh2(ylqx,"导出成品粉零头") %>导出成品粉零头</td>
		  <td><%= gzbgh2(ylqx,"导出成品粉混批计划") %>导出成品粉混批计划</td>
		 	 <td><%= gzbgh2(ylqx,"导出糖罐") %>导出糖罐</td>
        <td><%= gzbgh2(ylqx,"导出碱罐") %>导出碱罐</td>
        <td><%= gzbgh2(ylqx,"导出CIP碱罐") %>导出CIP碱罐</td>
		 <td><%= gzbgh2(ylqx,"导出外加工油粉") %>导出外加工油粉</td>
      </tr>
			  
      <tr> 
     <td><%= gzbgh2(ylqx,"导出小罐QC") %>导出小罐QC</td>
        <td><%= gzbgh2(ylqx,"导出中罐QC") %>导出中罐QC</td>
        <td><%= gzbgh2(ylqx,"导出大罐QC") %>导出大罐QC</td>
		 <td><%= gzbgh2(ylqx,"导出包材QC") %>导出包材QC</td>
		 <td><%= gzbgh2(ylqx,"导出包材QC") %>导出包材QC</td>
		   <td><%= gzbgh2(ylqx,"导出QC其它检测") %>导出QC其它检测</td>
		    <td><%= gzbgh2(ylqx,"导出环境微生物检测") %>导出环境微生物检测</td>
			 <td><%= gzbgh2(ylqx,"导出污水检测记录") %>导出污水检测记录</td>
			  <td><%= gzbgh2(ylqx,"导出外检项目记录") %>导出外检项目记录</td>
	  </tr>
		        <tr> 
     <td><%= gzbgh2(ylqx,"导出电") %>导出电</td>
        <td><%= gzbgh2(ylqx,"导出自来水") %>导出自来水</td>
        <td><%= gzbgh2(ylqx,"导出蒸汽、柴油") %>导出蒸汽、柴油</td>
			 <td><%= gzbgh2(ylqx,"导出过滤器更换记录") %>导出过滤器更换记录</td>
		 	 <td><%= gzbgh2(ylqx,"导出EHS统计月报") %>导出EHS统计月报</td>
		   <td><%= gzbgh2(ylqx,"导出偏差台账") %>导出偏差台账</td>
		    <td><%= gzbgh2(ylqx,"导出MOC台账") %>导出MOC台账</td>
			 <td><%= gzbgh2(ylqx,"导出5S检查得分统计") %>导出5S检查得分统计</td>
			  <td><%= gzbgh2(ylqx,"导出现场检查发现项跟踪系统") %>导出现场检查发现项跟踪系统</td>
		  </tr>
         <tr> 
      <tr> 
     <td><%= gzbgh2(ylqx,"导出现场检查安排表") %>导出现场检查安排表</td>
        <td><%= gzbgh2(ylqx,"导出采购品投诉处理") %>导出采购品投诉处理</td>
        <td><%= gzbgh2(ylqx,"导出食品安全质量（FSQ）审核改进情况统计表") %>导出食品安全质量（FSQ）审核改进情况统计表</td>
		<td><%= gzbgh2(ylqx,"导出Customer complaints") %>导出Customer complaints</td>
		 	 <td><%= gzbgh2(ylqx,"导出CABIO员工培训档案") %>导出CABIO员工培训档案</td>
		   <td><%= gzbgh2(ylqx,"导出员工") %>导出员工</td>
		    <td><%= gzbgh2(ylqx,"导出NET AA") %>导出NET AA</td>
			 <td><%= gzbgh2(ylqx,"导出K3成品月库存及5S总分") %>导出K3成品月库存及5S总分</td>
			  <td><%= gzbgh2(ylqx,"导出每月重要说明") %>导出每月重要说明</td>
	  </tr>
         <tr> 
        <td><%= gzbgh2(ylqx,"导出原料类别") %>导出原料类别</td>
        <td><%= gzbgh2(ylqx,"导出原料") %>导出原料</td>
		 <td><%= gzbgh2(ylqx,"导出原料理论表") %>导出原料理论表</td>
		 <td><%= gzbgh2(ylqx,"导出能耗价格") %>导出能耗价格</td>
		   <td><%= gzbgh2(ylqx,"导出能耗分摊") %>导出能耗分摊</td>
		    <td><%= gzbgh2(ylqx,"导出进出货") %>导出进出货</td>
			 <td><%= gzbgh2(ylqx,"导出成品库存周报") %>导出成品库存周报</td>
			  <td><%= gzbgh2(ylqx,"导出发货月报") %>导出发货月报</td>
			  <%= gzbgh2(ylqx,"导出Customer complaints") %>导出Customer complaints</td>
	  </tr>
    </table>
  </div>
   <font ONCLICK="vbscript:CALL GBYS('MYTB13')" style="cursor:hand;font-size:15px">-其它数据、报表导出</font>
<div ID="MYTB13">
    <table width="95%" border="1"  >
      <tr> 
        <td><%= gzbgh2(ylqx,"导出运行计划") %>导出运行计划</td>
        <td><%= gzbgh2(ylqx,"导出操作日志") %>导出操作日志</td>
        <td><%= gzbgh2(ylqx,"导出综合查询") %>导出综合查询</td>
        <td><%= gzbgh2(ylqx,"导出组合查询") %>导出组合查询</td>
		 <td><%= gzbgh2(ylqx,"导出原料综合查询") %>导出原料综合查询</td>
        <td><%= gzbgh2(ylqx,"导出粉剂生产周报") %>导出粉剂生产周报</td>
        <td><%= gzbgh2(ylqx,"导出油剂生产周报") %>导出油剂生产周报</td>

 
      </tr>
	        <tr> 
        <td><%= gzbgh2(ylqx,"导出粉剂生产月报") %>导出粉剂生产月报</td>
        <td><%= gzbgh2(ylqx,"导出员工培训统计") %>导出员工培训统计</td>
        <td><%= gzbgh2(ylqx,"导出幸免事故统计") %>导出幸免事故统计</td>
        <td><%= gzbgh2(ylqx,"导出EHS整改情况统计") %>导出EHS整改情况统计</td>
       <td><%= gzbgh2(ylqx,"导出食品安全质量（FSQ）审核改进情况统计表") %>食品安全质量（FSQ）审核改进情况统计表</td>
        <td><%= gzbgh2(ylqx,"导出偏差发现整改项统计") %>导出偏差发现整改项统计</td>
        <td><%= gzbgh2(ylqx,"导出MOC实施统计") %>导出MOC实施统计</td>
      </tr>
	     </tr>
	        <tr> 
			        <td><%= gzbgh2(ylqx,"导出成品库存周报") %>导出成品库存周报</td>
        <td><%= gzbgh2(ylqx,"导出油剂生产月报") %>导出油剂生产月报</td>
        <td><%= gzbgh2(ylqx,"导出工厂运行月报") %>导出工厂运行月报</td>
        <td><%= gzbgh2(ylqx,"导出能耗月报") %>导出能耗月报</td>
		 <td><%= gzbgh2(ylqx,"导出能耗周报") %>导出能耗周报</td>
        <td><%= gzbgh2(ylqx,"导出粉剂原料使用统计") %>导出粉剂原料使用统计</td>
        <td><%= gzbgh2(ylqx,"导出发酵&油剂原料使用统计") %>导出发酵&油剂原料使用统计</td>
      </tr>
    </table>
  </div>
</form>


</body>
</html>


