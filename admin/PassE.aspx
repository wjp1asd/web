<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassE.aspx.cs" Inherits="Web_GZJL.admin.PassE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <title>密码修改</title>
  <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td height="492" valign="top" background="../img/zhong_6.jpg">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="zhong">
                                <table border="0" cellpadding="0" cellspacing="0" height="27" width="60%">
                                    <tr>
                                        <td align="right" height="21" width="3%">
                                            <img height="13" src="../img/left_2.gif" width="16" />
                                        </td>
                                        <td width="1%">
                                            &nbsp;
                                        </td>
                                        <td class="moren" width="96%">
                                            当前位置：<a href="../Main.aspx">首页</a>&gt;<span style="color: #1F65AE"><%=t1 %></span>&gt;<span
                                                style="color: #1F65AE"><%=t0 %></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="90%" border="0" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" style="height: 39px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="height: 216px">
                                            <table id="Table3" cellspacing="0" cellpadding="6" align="left" border="0">
                                                <tr>
                                                    <td width="100">
                                                    </td>
                                                    <td>
                                                        旧密码：
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_old" runat="server" Width="180px" TextMode="Password"></asp:TextBox><font
                                                            color="#ff0000">*</font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        新密码：
                                                    </td>
                                                    <td style="height: 30px">
                                                        <asp:TextBox ID="txt_new" runat="server" Width="180px" TextMode="Password" Style="left: 0px;
                                                            top: -1px"></asp:TextBox><font color="#ff0000">*</font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        密码确认：
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_qr" runat="server" Width="180px" TextMode="Password" Style="left: -1px;
                                                            top: -2px"></asp:TextBox><font color="#ff0000">*</font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        真实姓名：
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Uname" runat="server" Width="180px" Style="left: -1px; top: -2px"></asp:TextBox><font
                                                            color="#ff0000">*</font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="1" style="height: 44px">
                                                    </td>
                                                    <td align="center" colspan="2" style="height: 44px">
                                                        &nbsp; &nbsp; &nbsp; &nbsp;
                                                        
                                                        <asp:Button ID="Button3" runat="server" Text="  确 定" OnClick="Button3_Click" CssClass="btn1">
                                                        </asp:Button>&nbsp;&nbsp;
                                                        <asp:Button ID="Button4" runat="server" Text="  返 回" CssClass="btn1" OnClick="Button4_Click"
                                                            CausesValidation="False" ></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_new"
                                                ErrorMessage="密码确认与新密码不一致！" Display="None" ControlToValidate="txt_qr"></asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入密码确认！"
                                                Display="None" ControlToValidate="txt_qr"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入新密码！"
                                                Display="None" ControlToValidate="txt_new"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入旧密码！"
                                                Display="None" ControlToValidate="txt_old"></asp:RequiredFieldValidator>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="请输入真实姓名！"
                                                Display="None" ControlToValidate="txt_Uname"></asp:RequiredFieldValidator>
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False"></asp:ValidationSummary>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
