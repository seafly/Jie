
<html>

<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>显示文件及内容</title>
<style>
A:link,A:visited ,A:active {TEXT-DECORATION: none;color:#CC00FF}
A:hover {text-decoration : none; position : relative; top : 1px; left : 1px}
</style>
</head>
<% ss=Trim(Request.QueryString("folderpath"))
   ss1=Trim(Request.QueryString("fatherpath"))
   ss2=replace(ss,ss1,"")
 %>

<%'文件目录列表
  Function fileList(folderpath)
  dim fso,f,f1,fs,n
  set fso=createobject("scripting.FileSystemObject")
  set f=fso.GetFolder(folderpath)
  for each f1 in f.Files '列出所有文件
    if right(f1.name,5)=".html" then '查找文件扩展名为.html的文件
    s=s&"<IMG SRC='img\32.ico' width=14 height=14>&nbsp;<a href='../help"&ss2&f1.name&"' target='_blank'>"&left(f1.name,len(f1.name)-5)&"</a><BR>"
    end if
  next
  fileList=s
  set f=nothing
  set fso=nothing
  end Function
%>

<script language="vbscript">
  sub backward
    window.history.back(1)
  end sub
  sub jump(ss)
    window.navigate ss
  end sub
  
</script>

<body background="img\bj1.jpg">
<div id="button"></div>

<% '打开文件夹时读出文件
  if ss<>"" then
  Response.Write(fileList(ss))
  end if%>
</body>
</html>
