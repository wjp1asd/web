<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleEdit.aspx.cs" Inherits="Web_GZJL.admin.RoleEdit" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>角色管理</title>
    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            height: 114px;
        }
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
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="15" align="center">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table style="width: 100%">
                                    <tr>
                                        <td align="left">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="500">
                                            </asp:ScriptManager>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="30">
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                    CellPadding="2" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
                                                                    OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound"
                                                                    BorderStyle="None" CellSpacing="1" CssClass="quanbu" BackColor="#336D93">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="角色名称">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_mc" runat="server" Text='<%# Bind("Rolename") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Rolename") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="备注">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_bz" runat="server" Text='<%# Bind("bz") %>' Width="290px" MaxLength="100"
                                                                                    Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle Width="300px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("bz") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                                                                            <EditItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                                                    Text="更新" ToolTip="更新编辑"></asp:LinkButton>
                                                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    Text="取消" ToolTip="取消编辑"></asp:LinkButton>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                    Text="编辑" ToolTip="编辑角色"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <RowStyle CssClass="dan" />
                                                                    <HeaderStyle CssClass="biaoti" />
                                                                    <AlternatingRowStyle CssClass="suang" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <table border="0" cellpadding="2" cellspacing="0" style="border-right: #C6E7B5 1px solid;
                                                                    border-left: #C6E7B5 1px solid; border-bottom: #C6E7B5 1px solid; border-collapse: collapse">
                                                                    <tr id="Tr1" runat="server">
                                                                        <td width="180" style="border-right: #c6e7b5 1px solid; border-collapse: collapse;
                                                                            border-bottom: #c6e7b5 1px solid;">
                                                                            <asp:TextBox ID="txt_mc" runat="server" Width="170px" MaxLength="50" Style="left: 0px"></asp:TextBox>
                                                                        </td>
                                                                        <td width="300" style="border-right: #c6e7b5 1px solid; border-collapse: collapse;
                                                                            border-bottom: #c6e7b5 1px solid;">
                                                                            <asp:TextBox ID="txt_bz" runat="server" Width="290px" MaxLength="100"></asp:TextBox>
                                                                        </td>
                                                                        <td align="center" width="60" style="border-left: #c6e7b5 1px solid; border-collapse: collapse;
                                                                            border-bottom: #c6e7b5 1px solid;">
                                                                            <asp:LinkButton ID="but_add" runat="server" ToolTip="添加角色" OnClick="but_add_Click">添加</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" align="left" class="style1">
                                                                            <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound1"
                                                                                DataKeyField="menuID">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MENUID") %>'  Visible="false" >
                                                                                    </asp:Label>
                                                                                   <asp:CheckBox ID="chbl" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"MENUNAME") %>'  Font-Bold="True" AutoPostBack="True"  oncheckedchanged="chbl_CheckedChanged" />
                                                                                       <div style="margin-bottom:5px;"></div>
                                                                                    <asp:CheckBoxList ID="cbl" runat="server" RepeatColumns="3">
                                                                                    </asp:CheckBoxList>
                                                                                   
                                                                                       <div style="margin-top: 10px;"></div>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
                                                                        </td>
                                                                    </tr>
                                                                   
                                                                </table>
                                                            </td> 
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="but_add" />
                                                    <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            &nbsp;
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
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
