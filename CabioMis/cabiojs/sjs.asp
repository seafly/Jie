<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>
<!--#include file="cnn.asp" -->
<% dim js 
js=checkStr(request("js"))
 call openadodb
dim sql,rs
sql="select tb_js_mc from tb_js  where tb_js_mc='"& js &"'"
set rs=cnn.execute(sql) 
if not rs.eof then
  set rs=nothing
closeadodb
atlast("名称存在，请重新输入")
end if
sql="insert into tb_js(tb_js_mc)values('"& js &"')"
cnn.execute(sql) 
  set rs=nothing
closeadodb
response.Redirect("1-0.asp")
%>