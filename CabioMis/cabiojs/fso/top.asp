<html>
<head>
<title>标题</title>
<script language="vbscript">
  sub showtime
    document.all("a").innerHTML=now()
    window.setTimeout  "showtime",1000
    end sub
</script>
</head>
<body topmargin=2 leftmargin=2  onLoad="showtime" bgcolor="#33CCCC">
<table bgcolor="#33CCCC" height="80">
<tr>
   <td align="center" width=42>　</td>
   <td align=center width=635 bordercolor="#C0C0C0" bgcolor="#33CCCC" bordercolorlight="#C0C0C0"><font color="#FFFFFF" face="华文彩云">
	<font  align="center" size="7">帮助</font><font size="7"><img src="img\topimg2.png" id="top1"></font><font  align="center" size="7">支持</font></font></td>
   <td align=center width=108>
	<img src="img\topimg1.gif" id="top2"></td>
   <td id="a" align=left width=200>　</td>   
</tr>
</table>
<hr size=4 color="#FFFFFF">
</body>
</html>