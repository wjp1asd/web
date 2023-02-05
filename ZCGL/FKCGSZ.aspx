<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FKCGSZ.aspx.cs" Inherits="Web_GZJL.ZCGL.FKCGSZ" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>报告网址设置</title>
    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

    <style type="text/css">
<!--
.STYLE1 {font-size: 12pt}
-->
    </style>
</head>
<body bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">

    <script language="javascript">        window.history.forward(1); </script>

    <form id="Form1" method="post" runat="server">
    <div>
        <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td background="../img/san_21.jpg">
                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="zhong">
                                <table border="0" cellpadding="0" cellspacing="0" height="27" width="60%">
                                    <tr>
                                        <td align="right" height="21" width="3%">
                                            <img height="13" src="../img/left_2.gif" width="16" />
                                        </td>
                                        <td width="1%">&nbsp;
                                            
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
                            <td height="15">&nbsp;
                                
                            </td>
                        </tr>
                        <tr>
                            <td height="15" align="center">&nbsp;
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 10px">
                                        </td>
                                        <td align="left">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="500">
                                            </asp:ScriptManager>
                                            <table cellspacing="0" cellpadding="0" border="0">
                                                <tr align="center" >
                                                    <td>
                                                        <h2>
                                                            报告网址设定</h2>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="height: 12px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <cc2:TabContainer ID="tc_info" runat="server" ActiveTabIndex="0" Width="100%">
                                                            <cc2:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                              <ContentTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <table cellpadding="0" cellspacing="0" class="td2" style="border-collapse: collapse">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                                            CellPadding="2" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
                                                                                            OnRowUpdating="GridView1_RowUpdating" BorderStyle="None" CellSpacing="1" CssClass="quanbu">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="报告系统网址">
                                                                                                    <EditItemTemplate>
                                                                                                        <asp:TextBox ID="txt_mc" runat="server" Text='<%# Bind("WangZhi") %>' Width="290px"
                                                                                                            MaxLength="100" Height="20px"></asp:TextBox>
                                                                                                    </EditItemTemplate>
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="500px" />
                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="500px" CssClass="dl" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("WangZhi") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                                                                                                    <EditItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                                                                            Text="保存" ToolTip="保存编辑"></asp:LinkButton>
                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                                            Text="取消" ToolTip="取消编辑"></asp:LinkButton>
                                                                                                    </EditItemTemplate>
                                                                                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                                                    <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="dl" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                                            Text="编辑" ToolTip="编辑信息"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <RowStyle CssClass="dan" />
                                                                                            <HeaderStyle CssClass="biaoti" />
                                                                                            <AlternatingRowStyle CssClass="suang" />
                                                                                            <PagerStyle CssClass="biaoti" HorizontalAlign="Left" />
                                                                                        </asp:GridView>                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse"
                                                                                            bordercolor="#6c9ec1">
                                                                                            <tr height="2px">
                                                                                                <td>                                                                                                </td>
                                                                                                <td>                                                                                                </td>
                                                                                                <td>                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td width="305" align="left">
                                                                                                    <asp:TextBox ID="txt_lbmc" runat="server" Width="501px" MaxLength="100"></asp:TextBox>                                                                                                </td>
                                                                                                <td align="center" width="60">
                                                                                                    <asp:LinkButton ID="btn_add" runat="server" ToolTip="添加信息" OnClick="btn_add_Click">&nbsp;&nbsp;添加网址</asp:LinkButton>                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ContentTemplate>
                                                                <HeaderTemplate ><span class="STYLE1">
                                                                 报告网址设置</span>                                                                </HeaderTemplate>
                                                            </cc2:TabPanel>
                                                            <cc2:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel1">
                                                                <ContentTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <ContentTemplate>
                                                                            <table cellpadding="0" cellspacing="0" class="td2" style="border-collapse: collapse">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                                            CellPadding="2" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowEditing="GridView2_RowEditing"
                                                                                            OnRowUpdating="GridView2_RowUpdating" BorderStyle="None" CellSpacing="1" CssClass="quanbu">
                                                                                           
                                                                                            <RowStyle CssClass="dan" />
                                                                                            <HeaderStyle CssClass="biaoti" />
                                                                                            <AlternatingRowStyle CssClass="suang" />
                                                                                            <PagerStyle CssClass="biaoti" HorizontalAlign="Left" />
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse"
                                                                                            bordercolor="#6c9ec1">
                                                                                            <tr height="2px">
                                                                                                <td>
                                                                                                </td>
                                                                                                <td>
                                                                                                </td>
                                                                                                <td>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td width="305" align="left">
                                                                                                    <asp:TextBox ID="txt_fkfs" runat="server" Width="501px" MaxLength="100"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="center" width="60">
                                                                                                    <asp:LinkButton ID="btn_fkfsadd" runat="server" ToolTip="添加信息" OnClick="btn_fkfsadd_Click">&nbsp;&nbsp;添加</asp:LinkButton>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ContentTemplate>
                                                                <HeaderTemplate>
                                                                <span class="STYLE1">付款方式设置</span>                                                                </HeaderTemplate>
                                                            </cc2:TabPanel>
                                                        </cc2:TabContainer>
                                                    </td>
                                                </tr>
                                            </table>
                                    
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
