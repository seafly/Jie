<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>
<!--#include file="cnn.asp" -->
<% 
function getqx(str)
dim tt ,pp
for each tt in request.form(str)
if tt<>"" then
pp=pp & tt & ","
end if
next
pp=left(pp,len(pp)-1)
getqx=pp
end function
dim gh ,qx1,qx2,qx3
gh=checkStr(request("gh"))
qx1=getqx("checkbox1")'查看权限
qx2=getqx("checkbox2")'修改权限
qx3=getqx("checkbox3")'删除权限
call openadodb
dim sql 
sql="update tb_yg set tb_yg_show='"& qx1 &"',tb_yg_update='"& qx2 &"',tb_yg_del='"& qx3 &"' where tb_yg_n430f='"& gh &"'"
cnn.execute(sql)
closeadodb
response.write "<div align='center'><br><br><br><br>权限设定成功！</div>"
%>