<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>
<!--#include file="cnn.asp" -->
<% dim js ,dljm
js=checkStr(request("js"))
dljm=checkStr(request("select1"))
dim tt,mm
for each tt in request.form("checkbox1")
if tt<>"" then
mm=mm & tt & ","
end if
next
mm=left(mm,len(mm)-1)
call openadodb
dim sql 
sql="update tb_js set tb_js_qx='"& mm &"',tb_js_jm='"& dljm &"' where tb_js_mc='"& js &"'"
sql=sql & vbcrlf & "update tb_yg set tb_yg_quan='"& mm &"',tb_yg_dl='"& dljm &"' where tb_yg_js='"& js &"'"
cnn.execute(sql)
closeadodb
response.write "<div align='center'><br><br><br><br>"& js & "权限设定成功，"& js & "下次登陆时这些权限将会生效！</div>"
%>