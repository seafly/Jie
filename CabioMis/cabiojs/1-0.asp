<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>
<!--#include file="yz.asp" -->
<head>
<meta HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=gb2312">
<title>��ɫ</title>
<script type="text/vbscript">
sub GBYS(str)
dim r
r=msgbox("ȷ��ɾ���ý�ɫ��" & str,1,"����")
if r=1 then
window.navigate "deljs.asp?js=" & str
end if
end sub
</script>
</head>

<body>
<form name="form1" method="post" action="sjs.asp">
  �½�ɫ
  <input type="text" name="js" id="js" size="10">
  <input type="submit" name="button" id="button" value="���">
</form>
<table width="90%" border="1" id="mytable">
  <tr>
    <td>��ɫ����</td>
    <td>����</td>
  </tr>
  <% call openadodb
dim sql,rs
sql="select tb_js_mc from tb_js order by tb_js_mc"
set rs=cnn.execute(sql) 
do while not rs.eof%>
  <tr>
    <td><a href="1-1.asp?js=<%= rs(0) %>"  target="main" ><%= rs(0) %></a></td>
    <td><font ONCLICK="vbscript:CALL GBYS('<%= rs(0) %>')" style="cursor:hand;">ɾ��</font></td>
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

