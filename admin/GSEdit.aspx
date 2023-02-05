<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GSEdit.aspx.cs" Inherits="Web_GZJL.admin.GSEdit" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>机构管理</title>
    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

</head>
<body style="color: #000000">
    <form id="form1" runat="server">
    <div>
     
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                    <tr>
                        <td background="../img/san_21.jpg">
                            <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="zhong" colspan="2">
                                        <table border="0" cellpadding="0" cellspacing="0" height="27" width="60%">
                                            <tr>
                                                <td align="right" height="21" width="3%">
                                                    <img height="13" src="../img/left_2.gif" width="16" />
                                                </td>
                                                <td width="1%">
                                        
                                                </td>
                                                <td class="moren" width="96%">
                                                    当前位置：<a href="../Main.aspx">首页</a>&gt;<span style="color: #1F65AE"><%=t1 %></span>&gt;<span style="color: #1F65AE"><%=t0 %></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="15">
                                    </td>
                                    <td height="15">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 13px">
                                    </td>
                                    <td height="15" align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                        <table align="left" border="0" cellpadding="9" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <div class="TreeView">
                                                        <div style="overflow: auto; width: 250px; height: 460px; border-top-width: 1px; border-left-width: 1px;
                                                            border-left-color: #5f9b2e; border-bottom-width: 1px; border-bottom-color: #5f9b2e;
                                                            border-top-color: #5f9b2e; border-right-width: 1px; border-right-color: #5f9b2e;"
                                                            align="left">
                                                            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"
                                                                ShowLines="True" ExpandDepth="1">
                                                                <HoverNodeStyle CssClass="HoverTreeNode" />
                                                                <SelectedNodeStyle CssClass="SelectedTreeNode" />
                                                                <NodeStyle CssClass="TreeNode" />
                                                            </asp:TreeView>
                                                        </div>
                                                        <table border="0" cellpadding="6" cellspacing="0" style="width: 90%; height: 30px"
                                                            align="center">
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="but_add" runat="server" Text="添 加" CssClass="btn1" OnClick="but_add_Click" />
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="but_del" runat="server" Text="删 除" CssClass="btn1" OnClick="but_del_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                                <td valign="top">
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" cellpadding="6" cellspacing="0">
                                            <tr>
                                                <td>
                                                    上 级：
                                                </td>
                                                <td align="left">
                                                    &nbsp;<asp:Label ID="lbl_depart" runat="server" Width="260px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    机构名称：
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtName" runat="server" MaxLength="16" Width="260px"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    机构地址：
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="16" Width="260px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   核准证书编号：
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_xzqh" runat="server" AutoPostBack="True" onkeyup="this.value=this.value.replace(/\D/g,'')"
                                                        onafterpaste="this.value=this.value.replace(/\D/g,'')" Width="260px" 
                                                        MaxLength="6" ReadOnly="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    序 号：
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_xuhao" runat="server" AutoPostBack="True" onkeyup="this.value=this.value.replace(/\D/g,'')"
                                                        onafterpaste="this.value=this.value.replace(/\D/g,'')" Width="260px" MaxLength="3"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    备 注：
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMessage" runat="server" MaxLength="25" Width="260px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" height="30">
                                                    &nbsp;<asp:Button ID="but_save" runat="server" CssClass="btn1" OnClick="but_save_Click"
                                                        Style="left: 5px" Text="保 存" />
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="but_qx" runat="server" CssClass="btn1" OnClick="but_qx_Click" Style="left: 0px"
                                                        Text="返 回" />
                                                    <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
