

<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE5" />
<meta http-equiv="X-UA-Compatible" content="IE=5" />
		<TITLE>编辑文章</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<style>
BODY { FONT-SIZE: 9pt }
TD { FONT-SIZE: 9pt }
INPUT { FONT-SIZE: 9pt }
TEXTAREA { FONT-SIZE: 9pt }
</style>
	</HEAD>
	<BODY>
		<FORM method="post" name="myform" action="ssj.asp">
			<div align="center">
				<font color="#FF0000" id="wbbq">
					
				</font>
			</div>
			<TABLE border="0" cellpadding="2" cellspacing="1">
				<TR>
					<TD>标题：</TD>
					<TD>
						<INPUT name='t1' type='text' value='' size="60" >
					</TD>
				</TR>
				<TR>
					<TD>编辑内容：</TD>
					<TD>
						<INPUT type='hidden' name='content1'  value=''><IFRAME ID="eWebEditor1" src="edit.htm" frameborder="0" scrolling="no" width="550" height="350"></IFRAME>
				
					</TD>
				</TR>
				<TR>
					<TD colspan="2" align="right">
						<INPUT type="submit" name="b1" value="提交"> <INPUT type="reset" name="b2" value="重填">
					</TD>
				</TR>
			</TABLE>
			<font id="userinf"></font>
		</FORM>
	</BODY>
</HTML>
