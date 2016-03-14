<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>
<% dim wjm
wjm=request("id")
Dim fso1,aa,ts
Set fso1 = CreateObject("Scripting.FileSystemObject")
' '注意，true可以省，但是省后
 Set ts = fso1.OpenTextFile(server.MapPath("filebag/" & wjm), 1)
 aa=ts.readall 
  set ts=nothing
fso1.DeleteFile server.MapPath("filebag/" & wjm), True
  set fso1=nothing
 sub sctp(str,hcks)
  dim wz1,ks,wz2,tpzfc
 wz1=instr(hcks,str,"src=")
 if wz1=0 then
 exit sub
 end if
 wz2=instr(wz1+5,str,chr(34))
tpzfc=mid(str,wz1+5,wz2-wz1-5) '得到关联文档附件的文件名
Dim fso
Set fso = CreateObject("Scripting.FileSystemObject")
fso.DeleteFile server.MapPath("filebag/" & tpzfc), True
set fso=nothing
 call sctp(str,wz2)
  end sub
call sctp(aa,1)
response.Redirect("default.asp")%>
