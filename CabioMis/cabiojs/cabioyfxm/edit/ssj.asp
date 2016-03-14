<!--#include file="../../cnn.asp" -->
<%  
sub sxlb '刷新打开的父窗口
response.write "<script language='VBScript'>" & chr(13)
response.write "opener.location.reload" & chr(13)
response.write "window.close" & chr(13)
response.write "</script>"
end sub 
    Sub closewin(ByVal STR) '关闭窗体按钮
        Response.Write("<p></P><p></P><p></P>")
        Response.Write("<p align='center'>" & STR & "</p><p align='center'>")
       ' Response.Write("<input name='bb1' type='button' value='确定' onClick='window.close()'>")
        Response.Write("</p>")
        Response.End()
    End Sub
sub addsj()
   dim t1,t2
 t1 = Trim(Request("T1"))
 t1 = replace(t1,"'","‘")
 t2 = Trim(Request("content1"))
'  t2 = replace(t2,"'","‘")
 if t1="" or t2="" then
 call atlast("必须填写标题和内容")
 end if
 dim ygxm,yggh,mc ,lb,mm
 ygxm=Request("ygxm")'员工姓名
 yggh=Request("yggh")'工号
 mm=Request("pass1")'密码
 mc=Request("xmmc")'项目名称
 lb=Request("xmlb")'项目分类名称
 call openadodb
 dim sql,rs
sql="select tb_yg_id from tb_yg where tb_yg_pass='"& mm &"' and tb_yg_n430f='"& yggh &"'"
set rs=cnn.execute(sql)
if rs.eof then
 call atlast("密码错误")
end if
sql= "insert into tb_zclog(tb_zclog_gh,tb_zclog_xm,tb_zclog_sm,tb_zclog_lx)values"
sql=sql & "('" & yggh & "','" & ygxm & "','添加研发项目"& mc &"文档："& t1 &"','添加研发项目')"
cnn.execute(sql)'储存数据并记录日志
'sql="insert into tb_jyfxmsj(tb_jyfxmsj_mc,tb_jyfxmsj_fl,tb_jyfxmsj_wdbt,tb_jyfxmsj_wdlr,tb_jyfxmsj_czrgh)values"
'sql=sql & "('"& mc &"','"& lb &"','"& t1 &"','"& t2 &"','"& yggh &"')"

'response.Write(sql)
'response.End()
Set rs = CreateObject("ADODB.Recordset")
rs.open "tb_jyfxmsj",cnn,1,3
rs.addnew
rs("tb_jyfxmsj_mc")=mc
rs("tb_jyfxmsj_fl")=lb
rs("tb_jyfxmsj_wdbt")=t1
rs("tb_jyfxmsj_wdlr")=t2
rs("tb_jyfxmsj_czrgh")=yggh
rs.update
rs.Close() 
set rs=nothing


closeadodb

 end sub 
	call addsj
	call closewin("文档添加成功") 
	%>
