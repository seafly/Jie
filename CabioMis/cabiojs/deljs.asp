<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>
<!--#include file="cnn.asp" -->
<% dim js 
js=checkStr(request("js"))
 call openadodb
dim sql,rs
sql="select tb_yg_id from tb_yg where tb_yg_js='"& js &"'"
set rs=cnn.execute(sql) 
if not rs.eof then
  set rs=nothing
closeadodb
atlast("数据库内已经有该角色人员存在，不能删除！")
end if
sql="delete from tb_js where tb_js_mc='"& js &"'"
cnn.execute(sql) 
  set rs=nothing
closeadodb
response.Redirect("1-0.asp")
%>