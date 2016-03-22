<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>
<!--#include file="cnn.asp" -->
<%dim buttonx
buttonx="<input name='Submit1' type='button' value='全选' onClick='vbscript:qx'> <input nam" _
&"e='Submit12' type='button' value='全不选' onclick='vbscript:qbx'>"
call openadodb
dim js,gh'姓名、工号
js=checkStr(request("js"))
gh=checkStr(request("gh"))
if js="" then
response.end
end if

function gzbgh2(str1,str2,str3)
dim tt1,tt2
tt1="," & str1 & ","
tt2="," & str2 & ","
if instr(str1,str2)>0 then
gzbgh2="<input type='checkbox' CHECKED name='"& str3 &"' value='"& str2 &"'> "
ELSE
gzbgh2="<input type='checkbox' name='"& str3 &"' value='"& str2 &"'> "
end if
end function
%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>设定角色</title>
<script type="text/vbscript">
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
sub tjbd
form1.submit
end sub

</script>
</head>

<body style="font-size:10px"><form name="form1" action="sry.asp" method="post" >

  <table width="95%" border="1" id=mytable>
    <tr> 
      <td colspan="5"> 设定人员权限：<%=js %>
        <input name="Submit1" type="submit" id="Submit1" value="提交">
        <input name="gh" type="hidden" id="gh" value="<%=gh %>"></td>
    </tr>
	<% dim sql,rs
sql="select tb_yg_show,tb_yg_update,tb_yg_del from tb_yg where tb_yg_n430f='"& gh &"'"
set rs=cnn.execute(sql)
dim qx1,qx2,qx3'查看、修改、删除权限
qx1=rs(0):qx2=rs(1):qx3=rs(2)	
sql="select tb_yg_w779o,tb_yg_n430f from tb_yg where tb_yg_yx='有效'"
set rs=cnn.execute(sql)
do while not rs.eof %>
    <tr>
      <td><%= rs(0) %></td>
      <td><%= gzbgh2(qx1,rs(1),"checkbox1") %>查看</td>
      <td><%= gzbgh2(qx2,rs(1),"checkbox2") %>修改</td>
      <td><%= gzbgh2(qx3,rs(1),"checkbox3") %>删除</td>
      <td><%= buttonx %></td>
    </tr>
	<% rs.movenext
	loop 
	set rs=nothing
closeadodb%>
  </table>

</form>
 <script src="bgysstyle.txt" type="text/vbscript"></script>
<script type="text/vbscript">call tbys("mytable")</script>

</body>
</html>
