<!--#include file="cnn.asp" -->
<%
  dim poststr,gh 
  poststr=session("password")
  gh=session("czrgh")
  %>

<%
call openadodb
dim rs2,sql2
sql2="select tb_yg_pass from tb_yg where tb_yg_n430f='" & gh &"'"
set rs2 = cnn.execute(sql2)
if rs2.eof and rs2.bof then
Response.Write "您无权进入或长时间没有处理！"
response.end()
set rs2=nothing
end if
cnn.close
set conn=nothing

%>
