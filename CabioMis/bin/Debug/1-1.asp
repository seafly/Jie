<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>
<!--#include file="yz.asp" -->
<%dim buttonx
buttonx="<input name='Submit1' type='button' value='ȫѡ' onClick='vbscript:qx'> <input nam" _
&"e='Submit12' type='button' value='ȫ��ѡ' onclick='vbscript:qbx'>"
call openadodb
dim js
js=checkStr(request("js"))
if js="" then
response.end
end if
dim sql,rs
sql="select * from tb_js where tb_js_mc='"& js &"' "
set rs=cnn.execute(sql)
dim ylqx,yldljm'ԭ��Ȩ�ޡ�ԭ����½����
ylqx=rs(2):yldljm=rs(3)
''''''''''''''''''''''''''''''
dim kk1 '��ʾ��½����
kk1="<select name='select1'>"
set rs=cnn.execute("select * from tb_face")
do while not rs.eof
kk1=kk1 & mrdljm(rs(1),yldljm)
rs.movenext
loop
kk1=kk1 & "</select>"
set rs=nothing
closeadodb
'''''''''''''''''''''''''''''
function gzbgh(str)
dim tt
tt="<td>"& str &"</td><td>"& gzbgh2(ylqx,"��ѯ"& str ) &"��ѯ</td>"
tt=tt & "<td>"& gzbgh2(ylqx,"���"& str ) & "���</td>"
tt=tt & "<td>"& gzbgh2(ylqx,"�޸�"& str ) & "�޸�</td>"
tt=tt & "<td>"& gzbgh2(ylqx,"ɾ��"& str ) & "ɾ��</td>"
tt=tt & "<td>&nbsp;</td>"
gzbgh=tt
end function 
function gzbgh3(str)
dim tt
tt="<td>"& str &"</td><td>"& gzbgh2(ylqx,"��ѯ"& str ) &"��ѯ</td>"
tt=tt & "<td>"& gzbgh2(ylqx,"���"& str ) & "���</td>"
tt=tt & "<td>"& gzbgh2(ylqx,"�޸�"& str ) & "�޸�</td>"
tt=tt & "<td>&nbsp;</td>"
tt=tt & "<td>&nbsp;</td>"
gzbgh3=tt
end function 
''''''''''''''''''''''''''''
 function gzbgh2(str1,str2)
dim tt1,tt2
tt1="," & str1 & ","
tt2="," & str2 & ","
if instr(tt1,tt2)>0 then
gzbgh2="<input type='checkbox' CHECKED name='checkbox1' value='"& str2 &"'> "
ELSE
gzbgh2="<input type='checkbox' name='checkbox1' value='"& str2 &"'> "
end if
end function
function mrdljm(str1,str2)
if str1=str2 then
mrdljm="<option value='"& str1 &"'  selected>"& str1 &"</option>"
else
mrdljm="<option value='"& str1 &"'>"& str1 &"</option>"
end if
end function%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>�趨��ɫ</title>
<STYLE type=text/css>
 body {  font-size: 12px}
td {  font-size: 12px}
</STYLE>
<script type="text/vbscript">
dim a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12,a13,a14
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
SUB GBYS(STR)
dim jj
jj=DOCUMENT.ALL(STR).innerhtml
if jj="" then
select case str
case "MYTB1":jj=a1:case "MYTB2":jj=a2
case "MYTB3":jj=a3:case "MYTB4":jj=a4
case "MYTB5":jj=a5:case "MYTB6":jj=a6
case "MYTB7":jj=a7:case "MYTB8":jj=a8
case "MYTB9":jj=a9:case "MYTB10":jj=a10:case "MYTB11":jj=a11
case "MYTB12":jj=a12:case "MYTB13":jj=a13:case "MYTB14":jj=a14
end select
DOCUMENT.ALL(STR).innerhtml=jj
else
select case str
case "MYTB1":a1=jj:case "MYTB2":a2=jj
case "MYTB3":a3=jj:case "MYTB4":a4=jj
case "MYTB5":a5=jj:case "MYTB6":a6=jj
case "MYTB7":a7=jj:case "MYTB8":a8=jj
case "MYTB9":a9=jj:case "MYTB10":a10=jj:case "MYTB11":a11=jj
case "MYTB12":a12=jj:case "MYTB13":a13=jj:case "MYTB14":a14=jj
end select
DOCUMENT.ALL(STR).innerhtml=""
end if

END SUB
sub tjbd
form1.submit
end sub
sub Freeall
call GBYS("MYTB1"):call GBYS("MYTB2"):call GBYS("MYTB3"):call GBYS("MYTB4")
call GBYS("MYTB5"):call GBYS("MYTB6"):call GBYS("MYTB7"):call GBYS("MYTB8")
call GBYS("MYTB9"):call GBYS("MYTB10"):call GBYS("MYTB11"):call GBYS("MYTB12"):call GBYS("MYTB13"):call GBYS("MYTB14")
end sub
</script>
</head>

<body style="font-size:10px"><form name="form1" action="sqx.asp" method="post" ><font style="font-size:15px" >�趨��ɫ��<%=js %>��Ĭ�ϵ�¼����</font>
<input name="js" type="hidden" value="<%=js %>">

<% 
response.Write(kk1) '��ʾ��½����
%>

<input type="button" name="ss_yes" id="ss_yes" value="�ύ" onClick="vbscript:call tjbd">
  <input name="ss_free" type="button"  value="ȫ��չ��" onClick="vbscript:call Freeall">
  <hr/>
<font ONCLICK="vbscript:CALL GBYS('MYTB1')" style="cursor:hand;font-size:15px">-�ͼ���</font>
<div ID="MYTB1">
<table width="95%" border="1" >
  <tr>
   <%= gzbgh3("С��") %><td><%= buttonx %></td>
  </tr>
    <tr>
   <%= gzbgh3("�й�") %><td><%= buttonx %></td>
  </tr>
    <tr>
   <%= gzbgh3("���") %><td><%= buttonx %></td>
  </tr>
     <tr>
    <td><%= gzbgh2(ylqx,"����ǹ�") %>����ǹ�</td>
     <td><%= gzbgh2(ylqx,"��ѯ�ǹ�") %>��ѯ�ǹ�</td>
   <td><%= gzbgh2(ylqx,"��Ӽ��") %>��Ӽ��</td>
        <td><%= gzbgh2(ylqx,"��ѯ���") %>��ѯ���</td>
    <td><%= gzbgh2(ylqx,"���CIP���") %>���CIP���</td>
     <td><%= gzbgh2(ylqx,"��ѯCIP���") %>��ѯCIP���</td>
	 <td><%= buttonx %></td>
  </tr>
       <tr>
    <td><%= gzbgh2(ylqx,"��ӷŹ�") %>��ӷŹ�</td>
     <td><%= gzbgh2(ylqx,"�޸ķŹ�") %>�޸ķŹ�</td>
  <td><%= gzbgh2(ylqx,"��ѯ�Ź�") %>��ѯ�Ź�</td>
      <td><%= gzbgh2(ylqx,"���MV��Һ") %>���MV��Һ</td>
   <td>��</td>
 <td>��</td>
	<td>��</td>
  </tr>
    <tr>
   <%= gzbgh3("ë��") %><td><%= buttonx %></td>
  </tr>
      <tr>
  <td>ë�͵���</td>

   <td><%= gzbgh2(ylqx,"��ѯë�͵���") %>��ѯë�͵���</td>
     <td><%= gzbgh2(ylqx,"����ë�͵���") %>����ë�͵���</td>
   <td><%= gzbgh2(ylqx,"���ë�͵���") %>���ë�͵���</td>
    <td><%= gzbgh2(ylqx,"�ֹ�ë�͵���") %>�ֹ�ë�͵���</td>
     <td>��</td>
	 <td><%= buttonx %></td>
  </tr>
    <tr>
    <td>����</td>
  <td><%= gzbgh2(ylqx,"��ѯ����") %>��ѯ����</td>
   <td>��</td>
   <td><%= gzbgh2(ylqx,"�޸ľ���") %>�޸ľ���</td>
    <td>��</td>
     <td>��</td>
	 <td><%= buttonx %></td>
  </tr>
    <tr>
   <%= gzbgh3("��Ʒ��") %><td><%= buttonx %></td>
  </tr>
   <tr><%= gzbgh("�ֳ���鷢�������ϵͳ") %><td><%= buttonx %></td></tr>
     <tr><%= gzbgh("5S���÷�ͳ��") %><td><%= buttonx %></td></tr>
</table>
</div>
<font ONCLICK="vbscript:CALL GBYS('MYTB2')" style="cursor:hand;font-size:15px">-�ۼ���</font>
<div ID="MYTB2"><table width="95%" border="1" >
   <tr>
    <td>�ۼ����ϵ���</td>

   <td><%= gzbgh2(ylqx,"��ѯ�ۼ����ϵ���") %>��ѯ�ۼ����ϵ���</td>
     <td><%= gzbgh2(ylqx,"���зۼ����ϵ���") %>���зۼ����ϵ���</td>
   <td><%= gzbgh2(ylqx,"��ɷۼ����ϵ���") %>��ɷۼ����ϵ���</td>
    <td><%= gzbgh2(ylqx,"�ֹ��ۼ�����") %>�ֹ��ۼ�����</td>
     <td>��</td>
	 <td><%= buttonx %></td>
  </tr>
     <tr>
    <td>�ۼ�������</td>
  <td></td>
   <td>��</td>
   <td><%= gzbgh2(ylqx,"��ӷۼ�������") %>��ӷۼ�������</td>
    <td>��</td>
     <td>��</td>
	 <td><%= buttonx %></td>
  </tr>
       <tr>
      <td>С��</td>
  <td><%= gzbgh2(ylqx,"��ѯС��") %>��ѯС��</td>
   <td><%= gzbgh2(ylqx,"С������") %>С������</td>
   <td><%= gzbgh2(ylqx,"��ӳ�Ʒ�ۻ����ƻ�") %>��ӳ�Ʒ�ۻ����ƻ�</td>
    <td><%= gzbgh2(ylqx,"�޸ĳ�Ʒ�ۻ����ƻ�") %>�޸ĳ�Ʒ�ۻ����ƻ�</td>
     <td>��</td>
	 <td><%= buttonx %></td>
  </tr>
       <tr>
  <td>��Ʒ��</td>
  <td><%= gzbgh2(ylqx,"��ѯ��Ʒ��") %>��ѯ��Ʒ��</td>
   <td><%= gzbgh2(ylqx,"��ӳ�Ʒ��") %>��ӳ�Ʒ��</td>
   <td><%= gzbgh2(ylqx,"�޸ĳ�Ʒ��") %>�޸ĳ�Ʒ��</td>
    <td>��</td>
     <td>��</td>
	 <td><%= buttonx %></td>
  </tr>
 
</table></div>
   <font ONCLICK="vbscript:CALL GBYS('MYTB14')" style="cursor:hand;font-size:15px">-������</font>
<div ID="MYTB14"><table width="95%" border="1"  >
                       <tr>
  <td><%= gzbgh2(ylqx,"�鿴�з���Ŀ����") %>�鿴�з���Ŀ����</td>
  <td><%= gzbgh2(ylqx,"����з���Ŀ����") %>����з���Ŀ����</td>
   <td><%= gzbgh2(ylqx,"����з���Ŀ") %>����з���Ŀ</td>
    <td><%= gzbgh2(ylqx,"�޸��з���Ŀ") %>�޸��з���Ŀ</td>
   <td><%= gzbgh2(ylqx,"ɾ���з���Ŀ") %>ɾ���з���Ŀ</td>
  <td><%= gzbgh2(ylqx,"����з���Ŀ����") %>����з���Ŀ����</td>
   <td><%= gzbgh2(ylqx,"�鿴�з���Ŀ����") %>�鿴�з���Ŀ����</td>
   <td><%= gzbgh2(ylqx,"ɾ���з���Ŀ�ĵ�") %>ɾ���з���Ŀ�ĵ�</td>
  </tr> 
   </table></div>
<font ONCLICK="vbscript:CALL GBYS('MYTB3')" style="cursor:hand;font-size:15px">-QC��</font>
<div ID="MYTB3"><table width="95%" border="1" >
   <tr><td>QC����</td>
  <td><%= gzbgh2(ylqx,"���QC") %>���QC</td>
   <td><%= gzbgh2(ylqx,"�޸�QC") %>�޸�QC</td>
   <td><%= gzbgh2(ylqx,"ɾ��QC") %>ɾ��QC</td>
    <td>��</td>
     <td>��</td>
	 <td><%= buttonx %></td></tr>
	   <tr><%= gzbgh("����΢������") %><td><%= buttonx %></td></tr>
	      <tr><%= gzbgh("��ˮ����¼") %><td><%= buttonx %></td></tr>
		     <tr><%= gzbgh("�����Ŀ��¼") %><td><%= buttonx %></td></tr>
</table></div>
<font ONCLICK="vbscript:CALL GBYS('MYTB4')" style="cursor:hand;font-size:15px">-QA��</font>
<div ID="MYTB4"><table width="95%" border="1" >

   <tr><td>QA����</td>
  <td><%= gzbgh2(ylqx,"���QA") %>���QA</td>
   <td>��</td>
   <td><%= gzbgh2(ylqx,"ɾ��QA") %>ɾ��QA</td>
    <td>��</td>
     <td>��</td>
	 <td><%= buttonx %></td></tr>

	     <tr><%= gzbgh("MOC̨��") %><td><%= buttonx %></td></tr>
	<tr><%= gzbgh("Customer complaints") %><td><%= buttonx %></td></tr>
	 <tr><%= gzbgh("ƫ��̨��") %><td><%= buttonx %></td></tr>
 <tr><%= gzbgh("ʳƷ��ȫ������FSQ����˸Ľ����ͳ�Ʊ�") %><td><%= buttonx %></td></tr>
    <tr><%= gzbgh("�ļ��嵥") %><td><%= buttonx %></td></tr>
	  <tr><%= gzbgh("�ͻ�Ͷ�߼�¼") %><td><%= buttonx %></td></tr>
	    <tr><%= gzbgh("��Ӧ���ֳ����̨��") %><td><%= buttonx %></td></tr>
		  <tr><%= gzbgh("��ѯFSQ����") %><td><%= buttonx %></td></tr>
		    <tr><%= gzbgh("�ⲿ������") %><td><%= buttonx %></td></tr>
  
 

</table></div>
<font ONCLICK="vbscript:CALL GBYS('MYTB5')" style="cursor:hand;font-size:15px">-�豸������</font>
<div ID="MYTB5"><table width="95%" border="1" >
   <tr><%= gzbgh("����������") %><td><%= buttonx %></td></tr>
   <tr><%= gzbgh("����ˮ") %><td><%= buttonx %></td></tr>
   <tr><%= gzbgh("��") %><td><%= buttonx %></td></tr>
     <tr><%= gzbgh("������������¼") %><td><%= buttonx %></td></tr>
</table></div>
<font ONCLICK="vbscript:CALL GBYS('MYTB6')" style="cursor:hand;font-size:15px">-EHS��</font>
<div ID="MYTB6"><table width="95%" border="1" >
   <tr><%= gzbgh("�ֳ���鰲�ű�") %><td><%= buttonx %></td></tr>
   <tr><%= gzbgh("�����¹ʱ���׷��ϵͳ") %><td><%= buttonx %></td></tr>
     <tr><%= gzbgh("EHSͳ���±�") %><td><%= buttonx %></td></tr>
</table></div>
 <font ONCLICK="vbscript:CALL GBYS('MYTB7')" style="cursor:hand;font-size:15px">-�ɹ���</font>
<div ID="MYTB7"><table width="95%" border="1" >      
        <tr><%= gzbgh("�ɹ�ƷͶ�ߴ���") %><td><%= buttonx %></td></tr>
        <tr><%= gzbgh("�빺����������") %><td><%= buttonx %></td></tr>
		<tr><%= gzbgh("������") %><td><%= buttonx %></td></tr>

        <tr><%= gzbgh("����") %><td><%= buttonx %></td></tr>
        <td><%= gzbgh2(ylqx,"�ɹ����빺����Ч��ƫ��") %>�ɹ����빺����Ч��ƫ��</td>
 </table></div>
<font ONCLICK="vbscript:CALL GBYS('MYTB8')" style="cursor:hand;font-size:15px">-������Դ��</font>
<div ID="MYTB8"><table width="95%" border="1" >
   <tr><%= gzbgh("CABIOԱ����ѵ����") %><td><%= buttonx %></td></tr>
 </table></div>
 <font ONCLICK="vbscript:CALL GBYS('MYTB9')" style="cursor:hand;font-size:15px">-���в�</font>
<div ID="MYTB9"><table width="95%" border="1" >
  <tr>
    <td><table width="95%" border="1" >
      <tr>
        <td><%= gzbgh2(ylqx,"����") %>����</td>
        <td><%= gzbgh2(ylqx,"����") %>����</td>
        <td><%= gzbgh2(ylqx,"�޸������Ϣ") %>�޸������Ϣ</td>
        <td><%= gzbgh2(ylqx,"�޸�ʣ����") %>�޸�ʣ����</td>
        <td><%= gzbgh2(ylqx,"��ӷ�����ԭ��ʹ��") %>��ӷ�����ԭ��ʹ��</td>
        <td><%= gzbgh2(ylqx,"ɾ��������ԭ��ʹ��") %>ɾ��������ԭ��ʹ��</td>
        <td><%= buttonx %></td>
      </tr>
      <tr>
        <td>ԭ�Ϲ���</td>
        <td><%= gzbgh2(ylqx,"���ԭ��") %>���ԭ��</td>
        <td><%= gzbgh2(ylqx,"�޸�ԭ��") %>�޸�ԭ��</td>
        <td><%= gzbgh2(ylqx,"��Чԭ��") %>��Чԭ��</td>
        <td><%= gzbgh2(ylqx,"���ԭ�����") %>���ԭ�����</td>
        <td><%= gzbgh2(ylqx,"��Чԭ�����") %>��Чԭ�����</td>
        <td><%= buttonx %></td>
      </tr>
      <tr>
        <td><%= gzbgh2(ylqx,"��ѯë������") %>��ѯë������</td>
        <td><%= gzbgh2(ylqx,"��ɷۼ����ϼƻ�") %>��ɷۼ����ϼƻ�</td>
        <td><%= gzbgh2(ylqx,"���Ϸۼ�����ִ��") %>���Ϸۼ�����ִ��</td>
        <td><%= gzbgh2(ylqx,"��ѯ�ۼ�����") %>��ѯ�ۼ�����</td>
        <td><%= gzbgh2(ylqx,"���ë�����ϼƻ�") %>���ë�����ϼƻ�</td>
        <td><%= gzbgh2(ylqx,"����ë������ִ��") %>����ë������ִ��</td>
        <td><%= buttonx %></td>
      </tr>
      <tr>
        <td><%= gzbgh2(ylqx,"��ӳ�Ʒ����ܱ�") %>��ӳ�Ʒ����ܱ�</td>
        <td><%= gzbgh2(ylqx,"ɾ����Ʒ����ܱ�") %>ɾ����Ʒ����ܱ�</td>
        <td><%= gzbgh2(ylqx,"�趨K3��Ʒ�¿�漰5S�ܷ�") %>�趨K3��Ʒ�¿�漰5S�ܷ�</td>
        <td><%= gzbgh2(ylqx,"��ѯK3��Ʒ�¿�漰5S�ܷ�") %>��ѯK3��Ʒ�¿�漰5S�ܷ�</td>
        <td><%= gzbgh2(ylqx,"����ÿ����Ҫ˵��") %>����ÿ����Ҫ˵��</td>
        <td><%= gzbgh2(ylqx,"ԭ�ϳ���") %>ԭ�ϳ���</td>
        <td><%= buttonx %></td>
      </tr>
  <td><%= gzbgh2(ylqx,"������ѯ") %>������ѯ</td>
    <td><%= gzbgh2(ylqx,"��������޸�") %>��������޸�</td>
    <td><%= gzbgh2(ylqx,"��������ʵʩ") %>��������ʵʩ</td>
    <td>  </td>
    <td>  </td>
    <td>  </td>
     <td><%= buttonx %></td>
      </tr>
  <tr><%= gzbgh("���мƻ�") %>
    <td><%= buttonx %></td>
  </tr>
  <tr><%= gzbgh("�����±�") %>
    <td><%= buttonx %></td>
  </tr>
  <tr>
    <td><%= gzbgh2(ylqx,"�趨�ܺļ۸�") %>�趨�ܺļ۸�</td>
    <td><%= gzbgh2(ylqx,"�趨�ܺķ�̯") %>�趨�ܺķ�̯</td>
    <td><%= gzbgh2(ylqx,"��ѯ�ܺļ۸�") %>��ѯ�ܺķ�̯</td>
    <td><%= gzbgh2(ylqx,"��ѯ�ܺķ�̯") %>��ѯ�ܺķ�̯</td>
    <td><%= gzbgh2(ylqx,"�����ӹ���") %>�����ӹ���</td>
    <td>��</td>
    <td><%= buttonx %></td>
  </tr>
  <tr>
    <td><%= gzbgh2(ylqx,"����⹺��Ʒ��") %>����⹺��Ʒ��</td>
    <td><%= gzbgh2(ylqx,"�޸��⹺��Ʒ��") %>�޸��⹺��Ʒ��</td>
    <td><%= gzbgh2(ylqx,"����⹺ë��") %>����⹺ë��</td>
    <td><%= gzbgh2(ylqx,"�޸��⹺ë��") %>�޸��⹺ë��</td>
    <td></td>
    <td>��</td>
    <td><%= buttonx %></td>
  </tr>
    </table></td>
  </tr>
</table></div>
  <font ONCLICK="vbscript:CALL GBYS('MYTB10')" style="cursor:hand;font-size:15px">-ϵͳ����</font>
<div ID="MYTB10"><table width="95%" border="1"  >
   <tr>   <td>��ɫ��Ա����</td><td><%= gzbgh2(ylqx,"����ϵͳ����") %>����ϵͳ����</td><td><%= gzbgh2(ylqx,"��ɫ����") %>��ɫ����</td>
   <td><%= gzbgh2(ylqx,"��Ա����") %>��Ա����</td><td>��</td>
   <td>��</td><td><%= buttonx %></td></tr>
   <tr><td>���Ź���</td><td>��</td>
   <td><%= gzbgh2(ylqx,"���Ź���") %>���Ź���</td><td>��</td><td>��</td>
   <td>��</td><td><%= buttonx %></td></tr>
   <tr>
   <td>���Ź��ɹ���</td><td>��</td>
   <td><%= gzbgh2(ylqx,"���Ź��ɹ���") %>���Ź��ɹ���</td><td><%= gzbgh2(ylqx,"��������ʱ�����") %>��������ʱ�����</td>
   <td><%= gzbgh2(ylqx,"��Ӳ�Ʒ���") %>��Ӳ�Ʒ���</td>
   <td><%= gzbgh2(ylqx,"ɾ����Ʒ���") %>ɾ����Ʒ���</td>
   <td><%= buttonx %></td></tr>
    <tr><td>�ļ��ϴ�</td>
	<td><%= gzbgh2(ylqx,"�ļ��ϴ�") %>�ļ��ϴ�</td>
   <td><%= gzbgh2(ylqx,"ɾ���ļ�") %>ɾ���ļ�</td><td>��</td><td>��</td>
   <td><%= gzbgh2(ylqx,"�ļ�����") %>�ļ�����</td>
   <td><%= buttonx %></td></tr>
       <tr>
	   <td><%= gzbgh2(ylqx,"�����Զ��屨��") %>�����Զ��屨��</td>
   <td><%= gzbgh2(ylqx,"ɾ���Զ��屨��") %>ɾ���Զ��屨��</td>
   <td><%= gzbgh2(ylqx,"�趨�Զ����ѯ��Ȩ��") %>�趨�Զ����ѯ��Ȩ��</td>
   <td><%= gzbgh2(ylqx,"�趨����Ȩ��") %>�趨����Ȩ��</td>
     <td><%= gzbgh2(ylqx,"�༭�Զ��屨��Ȩ��") %>�༭�Զ��屨��Ȩ��</td>
	  <td><%= gzbgh2(ylqx,"��������") %>��������</td>
   <td><%= buttonx %></td></tr>
   </table></div>
   <font ONCLICK="vbscript:CALL GBYS('MYTB11')" style="cursor:hand;font-size:15px">-�������</font>
<div ID="MYTB11"><table width="95%" border="1"  >
       <tr>     
      	   <td><%= gzbgh2(ylqx,"�ͼ�������") %>�ͼ�������</td> <td><%= gzbgh2(ylqx,"�ۼ�������") %>�ۼ�������</td>
   <td><%= gzbgh2(ylqx,"����������") %>����������</td> <td><%= gzbgh2(ylqx,"QA����") %>QA����</td>
  <td><%= gzbgh2(ylqx,"QC����") %>QC����</td></tr>
 <tr>    <td><%= gzbgh2(ylqx,"EHS����") %>EHS����</td>
  <td><%= gzbgh2(ylqx,"�豸����������") %>�豸����������</td>   <td><%= gzbgh2(ylqx,"���в�����") %>���в�����</td>
<td><%= gzbgh2(ylqx,"�ɹ�������") %>�ɹ�������</td> <td><%= gzbgh2(ylqx,"������Դ������") %>������Դ������</td>

</tr>
   </table></div>
      <font ONCLICK="vbscript:CALL GBYS('MYTB12')" style="cursor:hand;font-size:15px">-ҵ�����ݵ���</font>
<div ID="MYTB12">
    <table width="95%" border="1"  >
      <tr> 
        <td><%= gzbgh2(ylqx,"����С������") %>����С������</td>
        <td><%= gzbgh2(ylqx,"�����й�����") %>�����й�����</td>
        <td><%= gzbgh2(ylqx,"�����������") %>�����������</td>
        <td><%= gzbgh2(ylqx,"����ë��") %>����ë��</td>
		<td><%= gzbgh2(ylqx,"��������") %>��������</td>
        <td><%= gzbgh2(ylqx,"������Ʒ��") %>������Ʒ��</td>
        <td><%= gzbgh2(ylqx,"����ë������") %>����ë������</td>
		 <td><%= gzbgh2(ylqx,"�����ۼ�����") %>�����ۼ�����</td>
		  <td></td>
      </tr>
		   <tr> 	 
		 <td><%= gzbgh2(ylqx,"����������") %>����������</td>
        <td><%= gzbgh2(ylqx,"�����ۼ�С��") %>�����ۼ�С��</td>
        <td><%= gzbgh2(ylqx,"������Ʒ��") %>������Ʒ��</td>
		 <td><%= gzbgh2(ylqx,"������Ʒ����ͷ") %>������Ʒ����ͷ</td>
		  <td><%= gzbgh2(ylqx,"������Ʒ�ۻ����ƻ�") %>������Ʒ�ۻ����ƻ�</td>
		 	 <td><%= gzbgh2(ylqx,"�����ǹ�") %>�����ǹ�</td>
        <td><%= gzbgh2(ylqx,"�������") %>�������</td>
        <td><%= gzbgh2(ylqx,"����CIP���") %>����CIP���</td>
		 <td><%= gzbgh2(ylqx,"������ӹ��ͷ�") %>������ӹ��ͷ�</td>
      </tr>
			  
      <tr> 
     <td><%= gzbgh2(ylqx,"����С��QC") %>����С��QC</td>
        <td><%= gzbgh2(ylqx,"�����й�QC") %>�����й�QC</td>
        <td><%= gzbgh2(ylqx,"�������QC") %>�������QC</td>
		 <td><%= gzbgh2(ylqx,"��������QC") %>��������QC</td>
		 <td><%= gzbgh2(ylqx,"��������QC") %>��������QC</td>
		   <td><%= gzbgh2(ylqx,"����QC�������") %>����QC�������</td>
		    <td><%= gzbgh2(ylqx,"��������΢������") %>��������΢������</td>
			 <td><%= gzbgh2(ylqx,"������ˮ����¼") %>������ˮ����¼</td>
			  <td><%= gzbgh2(ylqx,"���������Ŀ��¼") %>���������Ŀ��¼</td>
	  </tr>
		        <tr> 
     <td><%= gzbgh2(ylqx,"������") %>������</td>
        <td><%= gzbgh2(ylqx,"��������ˮ") %>��������ˮ</td>
        <td><%= gzbgh2(ylqx,"��������������") %>��������������</td>
			 <td><%= gzbgh2(ylqx,"����������������¼") %>����������������¼</td>
		 	 <td><%= gzbgh2(ylqx,"����EHSͳ���±�") %>����EHSͳ���±�</td>
		   <td><%= gzbgh2(ylqx,"����ƫ��̨��") %>����ƫ��̨��</td>
		    <td><%= gzbgh2(ylqx,"����MOC̨��") %>����MOC̨��</td>
			 <td><%= gzbgh2(ylqx,"����5S���÷�ͳ��") %>����5S���÷�ͳ��</td>
			  <td><%= gzbgh2(ylqx,"�����ֳ���鷢�������ϵͳ") %>�����ֳ���鷢�������ϵͳ</td>
		  </tr>
         <tr> 
      <tr> 
     <td><%= gzbgh2(ylqx,"�����ֳ���鰲�ű�") %>�����ֳ���鰲�ű�</td>
        <td><%= gzbgh2(ylqx,"�����ɹ�ƷͶ�ߴ���") %>�����ɹ�ƷͶ�ߴ���</td>
        <td><%= gzbgh2(ylqx,"����ʳƷ��ȫ������FSQ����˸Ľ����ͳ�Ʊ�") %>����ʳƷ��ȫ������FSQ����˸Ľ����ͳ�Ʊ�</td>
		<td><%= gzbgh2(ylqx,"����Customer complaints") %>����Customer complaints</td>
		 	 <td><%= gzbgh2(ylqx,"����CABIOԱ����ѵ����") %>����CABIOԱ����ѵ����</td>
		   <td><%= gzbgh2(ylqx,"����Ա��") %>����Ա��</td>
		    <td><%= gzbgh2(ylqx,"����NET AA") %>����NET AA</td>
			 <td><%= gzbgh2(ylqx,"����K3��Ʒ�¿�漰5S�ܷ�") %>����K3��Ʒ�¿�漰5S�ܷ�</td>
			  <td><%= gzbgh2(ylqx,"����ÿ����Ҫ˵��") %>����ÿ����Ҫ˵��</td>
	  </tr>
         <tr> 
        <td><%= gzbgh2(ylqx,"����ԭ�����") %>����ԭ�����</td>
        <td><%= gzbgh2(ylqx,"����ԭ��") %>����ԭ��</td>
		 <td><%= gzbgh2(ylqx,"����ԭ�����۱�") %>����ԭ�����۱�</td>
		 <td><%= gzbgh2(ylqx,"�����ܺļ۸�") %>�����ܺļ۸�</td>
		   <td><%= gzbgh2(ylqx,"�����ܺķ�̯") %>�����ܺķ�̯</td>
		    <td><%= gzbgh2(ylqx,"����������") %>����������</td>
			 <td><%= gzbgh2(ylqx,"������Ʒ����ܱ�") %>������Ʒ����ܱ�</td>
			  <td><%= gzbgh2(ylqx,"���������±�") %>���������±�</td>
			  <%= gzbgh2(ylqx,"����Customer complaints") %>����Customer complaints</td>
	  </tr>
    </table>
  </div>
   <font ONCLICK="vbscript:CALL GBYS('MYTB13')" style="cursor:hand;font-size:15px">-�������ݡ�������</font>
<div ID="MYTB13">
    <table width="95%" border="1"  >
      <tr> 
        <td><%= gzbgh2(ylqx,"�������мƻ�") %>�������мƻ�</td>
        <td><%= gzbgh2(ylqx,"����������־") %>����������־</td>
        <td><%= gzbgh2(ylqx,"�����ۺϲ�ѯ") %>�����ۺϲ�ѯ</td>
        <td><%= gzbgh2(ylqx,"������ϲ�ѯ") %>������ϲ�ѯ</td>
		 <td><%= gzbgh2(ylqx,"����ԭ���ۺϲ�ѯ") %>����ԭ���ۺϲ�ѯ</td>
        <td><%= gzbgh2(ylqx,"�����ۼ������ܱ�") %>�����ۼ������ܱ�</td>
        <td><%= gzbgh2(ylqx,"�����ͼ������ܱ�") %>�����ͼ������ܱ�</td>

 
      </tr>
	        <tr> 
        <td><%= gzbgh2(ylqx,"�����ۼ������±�") %>�����ۼ������±�</td>
        <td><%= gzbgh2(ylqx,"����Ա����ѵͳ��") %>����Ա����ѵͳ��</td>
        <td><%= gzbgh2(ylqx,"���������¹�ͳ��") %>���������¹�ͳ��</td>
        <td><%= gzbgh2(ylqx,"����EHS�������ͳ��") %>����EHS�������ͳ��</td>
       <td><%= gzbgh2(ylqx,"����ʳƷ��ȫ������FSQ����˸Ľ����ͳ�Ʊ�") %>ʳƷ��ȫ������FSQ����˸Ľ����ͳ�Ʊ�</td>
        <td><%= gzbgh2(ylqx,"����ƫ���������ͳ��") %>����ƫ���������ͳ��</td>
        <td><%= gzbgh2(ylqx,"����MOCʵʩͳ��") %>����MOCʵʩͳ��</td>
      </tr>
	     </tr>
	        <tr> 
			        <td><%= gzbgh2(ylqx,"������Ʒ����ܱ�") %>������Ʒ����ܱ�</td>
        <td><%= gzbgh2(ylqx,"�����ͼ������±�") %>�����ͼ������±�</td>
        <td><%= gzbgh2(ylqx,"�������������±�") %>�������������±�</td>
        <td><%= gzbgh2(ylqx,"�����ܺ��±�") %>�����ܺ��±�</td>
		 <td><%= gzbgh2(ylqx,"�����ܺ��ܱ�") %>�����ܺ��ܱ�</td>
        <td><%= gzbgh2(ylqx,"�����ۼ�ԭ��ʹ��ͳ��") %>�����ۼ�ԭ��ʹ��ͳ��</td>
        <td><%= gzbgh2(ylqx,"��������&�ͼ�ԭ��ʹ��ͳ��") %>��������&�ͼ�ԭ��ʹ��ͳ��</td>
      </tr>
    </table>
  </div>
</form>


</body>
</html>


