<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>

<%Function ShowFileList
dim fso,f,s
Set fso = CreateObject("Scripting.FileSystemObject")'�������������ʵ��
Set f = fso.GetFolder(server.MapPath("filebag"))'�����Ӷ���(�ļ��ж���)����ʵ��
'ö���ļ�
 dim f1 '����f1��ʾ���ϵ�Ԫ��,������ַ���
dim k1 ,k2,i
i=0
For Each  f1 in f.Files
k1=f1.name
k2=left(k1,len(k1)-5)
if right(k1,5)=".html" then
i=i+1
s = s & "<tr><td ><a href='filebag/" & k1 & "' tile2='�鿴' target='_blank'> " & k2 & "</a></td><td><a href='del.asp?id=" & k1 & "' > ɾ��</a></td></tr>"
end if
Next 
s=s & "</table>" 
s="<table width='75%' border='1'> <tr> <td align='center' >�����ĵ�"& i &"��</td><td>����</td></tr>" & s
ShowFileList=s
set f=nothing:set fso=nothing
end function%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>�ޱ����ĵ�</title>
</head>

<body>
<p><FONT color=#000000 style="cursor : hand;" onclick="MyWindow=window.open('edit/test.asp','MyWindow','toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,width=800,height=500,top=0');">��Ӱ����ĵ�</font> </p>
<% 'Response.Write(ShowFileList) %>

</body>
</html>
