<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Web_GZJL._Default" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>压力容器与管道壁厚数据管理系统</title>
    <style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 80px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #A2BFD7;
}
-->
</style>
    <link href="css/css.css" rel="stylesheet" type="text/css">
</head>
<body>

    <script language="javascript">        window.history.forward(1); </script>

    <form id="Form1" method="post" runat="server" style="border-bottom">

        <table width="993" border="0" align="center"   cellpadding="0" cellspacing="0" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; padding-top: 0px">
            <tbody>
                <tr>
                    <td >
                        <img height="1" alt="" src="00000001_jpg.files/spacer.gif" width="396" border="0"></td>
                    <td>
                        <img height="1" alt="" src="00000001_jpg.files/spacer.gif" width="237" border="0"></td>
                    <td>
                        <img height="1" alt="" src="00000001_jpg.files/spacer.gif" width="360" border="0"></td>
                    <td>
                        <img height="1" alt="" src="00000001_jpg.files/spacer.gif" width="1" border="0"></td>
                </tr>
                <tr>
                    <td colspan="3">
                   
                        <img id="n00000001_r1_c1" height="166" alt="" src="img/login_1.jpg" width="993" border="0"
                            name="n00000001_r1_c1"></td>
                    <td>
                        <img height="166" alt="" src="00000001_jpg.files/spacer.gif" width="1" border="0"></td>
                </tr>
                <tr>
                    <td rowspan="2">
                        <img id="n00000001_r2_c1" height="294" alt="" src="img/login_2.jpg" width="396" border="0"
                            name="n00000001_r2_c1"></td>
                    <td  height="130px" background="img/login_5.jpg">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="27%" align="center" class="txt">
                                    账号：</td>
                                <td width="73%">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="sr" Width="142px"></asp:TextBox></td>
                            </tr>
                            <tr height="5px"><td></td><td></td></tr>
                            <tr>
                                <td align="center" class="txt">
                                  密码：</td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="sr" Width="142px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="5" colspan="2">
                                    <div align="left">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="23%">
                                                &nbsp;</td>
                                            <td width="78%">
                                                &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="登录" CssClass="btn1" OnClick="Button1_Click1"></asp:Button>
                                                <input name="Submit" type="reset" class="btn1" value="取消"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td rowspan="2">
                        <img id="n00000001_r2_c3" height="294" alt="" src="img/login_3.jpg" width="360" border="0"
                            name="n00000001_r2_c3"></td>
                    <td>
                        <img height="130" alt="" src="00000001_jpg.files/spacer.gif" width="1" border="0"></td>
                </tr>
                <tr>
                    <td>
                        <img id="n00000001_r3_c2" height="164" alt="" src="img/login_4.jpg" width="237" border="0"
                            name="n00000001_r3_c2"></td>
                    <td>
                        <img height="164" alt="" src="00000001_jpg.files/spacer.gif" width="1" border="0"></td>
                </tr>
            </tbody>
        </table>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="参数不能为空"
                Display="None" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="参数不能为空"
                Display="None" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                ShowMessageBox="True"></asp:ValidationSummary>

    </form>
</body>
</html>