Public Class Frbz

    Private Sub Frbz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim a As String = "请购：" + vbCrLf + vbCrLf + "下面表：请购单是否生效未退单则该列为红色。" + vbCrLf + vbCrLf
        a += "采购：" + vbCrLf + vbCrLf + "上面表：补货则显示为黄色。" + vbCrLf + "下面表：补货则显示为黄色。" + vbCrLf + vbCrLf
        a += "到货跟踪：" + vbCrLf + vbCrLf + "上面表：若当前日期大于预计到货日期，则 '预计到货日期' 字段应显示红色。" + vbCrLf + "补货则显示为黄色" + vbCrLf + "下面表：只要'到货时效'字段为正数时，该字段显示红色。" + vbCrLf + "补货则显示为黄色" + vbCrLf + vbCrLf
        a += "验收：" + vbCrLf + vbCrLf + "上面表：当天日期超过 '验收时限'显示红色。" + vbCrLf + "补货则显示为黄色" + vbCrLf + "下面表： '到货时效'或 '验收时效' 大于 0 则仅到货时效或验收时效 字段显红色。" + vbCrLf + "补货则显示为黄色"
        TextBox1.Text = a

    End Sub
End Class