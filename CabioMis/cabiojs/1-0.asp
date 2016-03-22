<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>
<!--#include file="yz.asp" -->
<head>
<meta HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=gb2312">
<title>角色</title>
<script type="text/vbscript">
sub GBYS(str)
dim r
r=msgbox("确定删除该角色：" & str,1,"警告")
if r=1 then
window.navigate "deljs.asp?js=" & str
end if
end sub
</script>
</head>

<body>
<form name="form1" method="post" action="sjs.asp">
  新角色
  <input type="text" name="js" id="js" size="10">
  <input type="submit" name="button" id="button" value="添加">
</form>
<table width="90%" border="1" id="mytable">
  <tr>
    <td>角色名称</td>
    <td>管理</td>
  </tr>
  <% call openadodb
dim sql,rs
sql="select tb_js_mc from tb_js order by tb_js_mc"
set rs=cnn.execute(sql) 
do while not rs.eof%>
  <tr>
    <td><a href="1-1.asp?js=<%= rs(0) %>"  target="main" ><%= rs(0) %></a></td>
    <td><font ONCLICK="vbscript:CALL GBYS('<%= rs(0) %>')" style="cursor:hand;">删除</font></td>
  </tr>
  <% rs.movenext
  loop
 %>
</table>
 <script src="bgysstyle.txt" type="text/vbscript"></script>
<script type="text/vbscript"> 
call tbys("mytable"):call tbys("mytable2")
</script>
</body>
</html>

