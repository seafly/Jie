
<html>

<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title></title>
<style>
A:link,A:visited ,A:active {TEXT-DECORATION: none;color:#0066FF}
A:hover {text-decoration : none; position : relative; top : 1px; left : 1px}
</style>
</head>
<%'文件夹目录列表
   Function folderList(folderpath)
   folderspec=replace(folderpath,"%20"," ")'改变路径中的空格字符编码
   dim fso,f,f1,fs
   set fso=CreateObject("Scripting.FileSystemObject")
   set f=fso.GetFolder(folderpath)
   set fs=f.subfolders
   For each f1 in fs
      s=s&"<IMG SRC='img\678.ico' width=14 height=14><a href='right.asp?fatherpath="&folderpath&"&folderpath="&folderpath&"\"&f1.name&"\' target='right'  title=查看此文件夹内的文件 > "&f1.name&"</a>"&"<br>"
   next
   folderList=s
   set sf=nothing
   set f=nothing
   set fso=nothing
  end Function
%>

<body  bgcolor="#cccccc">
<%
  response.write(folderList(Server.MapPath("../help/")))
%>
</body>

</html>
