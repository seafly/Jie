<%
dim lj1,lj2 
lj1=Server.MapPath("../help/")
lj2=lj1 & "\" & request("lj") & "\"
response.Redirect("right.asp?fatherpath="&lj1&"&folderpath="& lj2)
%>

