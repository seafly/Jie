<%@LANGUAGE="VBSCRIPT" %>

<!--#include file="../../cnn.asp" -->
<html>
<head>
<META HTTP-EQUIV="pragma" CONTENT="no-cache"> 
<META HTTP-EQUIV="Cache-Control" CONTENT="no-cache, must-revalidate"> 
<META HTTP-EQUIV="expires" CONTENT="Wed, 26 Feb 1997 08:21:57 GMT"> 
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>文档</title>
</head>

<body>
 <%dim sid
 sid=int(request("id")) 
 call openadodb
dim sql,rs
sql="select tb_jyfxmsj_wdlr from tb_jyfxmsj where tb_jyfxmsj_id=" & sid
set rs=cnn.execute(sql) 
response.Write(rs(0))
  set rs=nothing
closeadodb  %>
</body>
</html>
