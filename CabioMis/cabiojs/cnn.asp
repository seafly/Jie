<%dim cnn,strcnn
strcnn="Provider=sqloledb; User ID=sa; Password=sa; Initial Catalog=cabiodb; Data Source=127.0.0.1"
sub openadodb
 Set Cnn = Server.CreateObject("ADODB.Connection")                          
     Cnn.ConnectionString = strcnn
     Cnn.Open 
end sub

sub closeadodb
cnn.close
set cnn=nothing
end sub

Function checkStr(str) 
checkStr = Replace(str, "'", "‘")
End Function
	
Sub atlast(str) '结窗窗口
Response.Write("<p></P><p></P><p></P>")
Response.Write("<p align='center'>" & str & "</p><p align='center'>")
Response.Write("<input name='bb1' type='button' value='确定' onClick='javascript:history.back(1)'>")
Response.Write("</p>")
Response.End()
End Sub


%>
