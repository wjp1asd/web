<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="Web_GZJL.admin.UserEdit" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="MCombox2.ascx" TagName="MCombox2" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户管理</title>
    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

</head>
<body bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">

    <script language="javascript" type="text/javascript">        window.history.forward(1); </script>

    <form id="Form1" method="post" runat="server">
    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
        <tr>
            <td background="../img/san_21.jpg">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
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
                        <td style="width: 10px">
                        </td>
                        <td height="15">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" height="15">
                        </td>
                        <td height="15" align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        </td>
                        <td align="center">
                            <table id="Table3" cellspacing="0" cellpadding="3" border="0" align="left">
                                <tr>
                                    <td valign="top" align="left">
                                        <div style="width: 250px; height: 460px; overflow: auto" class="TreeView">
                                            <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="1" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"
                                                ShowLines="True">
                                                <SelectedNodeStyle CssClass="SelectedTreeNode" />
                                                <NodeStyle CssClass="TreeNode" />
                                            </asp:TreeView>
                                        </div>
                                    </td>
                                    <td valign="top" align="right">
                                       
                                                <asp:Panel ID="Panel1" runat="server" Width="100%">
                                                    <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td align="right">
                                                                姓名：
                                                                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                                                                <asp:Button ID="btnSelect" runat="server" CssClass="btn1" Text="  查 询" OnClick="btnSelect_Click" />
                                                                &nbsp;
                                                                <asp:Button ID="Button1" runat="server" Text="  添 加" OnClick="Button1_Click1" CssClass="btn1">
                                                                </asp:Button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <br />
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                    CellPadding="2" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" CellSpacing="1"
                                                                    CssClass="quanbu" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                                    OnRowDeleting="GridView1_RowDeleting">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="userid" HeaderText="登录名">
                                                                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                                            <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="username" HeaderText="姓名">
                                                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="depart" HeaderText="所属单位">
                                                                            <ItemStyle Width="140px" HorizontalAlign="Left" />
                                                                            <HeaderStyle Width="140px" HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="chushi" HeaderText="所属处室">
                                                                            <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                            <HeaderStyle Width="100px" HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="jsmc" HeaderText="角色">
                                                                            <ItemStyle Width="100px" Wrap="True" HorizontalAlign="Center" />
                                                                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                                    CssClass="a2" Text="<div>编辑</div>"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="50px" />
                                                                            <ItemStyle Width="50px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="删除" ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton2" OnClientClick="return confirm('确认删除该人员')" runat="server"
                                                                                    CausesValidation="False" CommandName="delete" CssClass="a2" Text="<div>删除</div>"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="50px" />
                                                                            <ItemStyle Width="50px" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <RowStyle CssClass="dan" />
                                                                    <HeaderStyle CssClass="biaoti" />
                                                                    <AlternatingRowStyle CssClass="suang" />
                                                                    <PagerStyle CssClass="biaoti" HorizontalAlign="Left" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                  
                                        <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
                                            <table id="Table2" cellspacing="0" cellpadding="8" width="100%" align="center" border="0">
                                                <tr>
                                                    <td align="left" width="90" style="height: 26px">
                                                        登&nbsp;&nbsp;录&nbsp;&nbsp;名：
                                                    </td>
                                                    <td align="left" style="height: 26px">
                                                        <asp:TextBox ID="txt_dlm" runat="server" Width="150px"></asp:TextBox><font color="#ff0000"></font>
                                                    </td>
                                                    <td align="left" width="90" style="height: 26px">
                                                        姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名：
                                                    </td>
                                                    <td align="left" width="150" style="height: 26px">
                                                        <asp:TextBox ID="txt_xm" runat="server" Width="150px" MaxLength="50"></asp:TextBox><font
                                                            color="#ff0000"></font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 26px" width="90">
                                                        所属单位：
                                                    </td>
                                                    <td align="left" style="height: 26px" colspan="3">
                                                        <asp:TextBox ID="txt_ssbm" runat="server" Width="438px" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="90">
                                                        所属处室：
                                                    </td>
                                                    <td colspan="3" align="left">
                                                        <asp:TextBox ID="txt_bz" runat="server" Width="438px" MaxLength="50" Text="信息中心"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="90">
                                                        角&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;色：
                                                    </td>
                                                    <td align="left" colspan="3" style="position: relative">
                                                        <uc2:MCombox2 ID="cmb_js" runat="server" Sql_fill="select * from sys_role" SText="rolename"
                                                            SValue="roleid" width="438" COLS="2" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="90">
                                                        权限设置：
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:DataList ID="DataList1" runat="server" DataKeyField="menuID" OnItemDataBound="DataList1_ItemDataBound1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"menuID") %>'
                                                                    Visible="false">
                                                                </asp:Label>
                                                                <asp:CheckBox ID="chbl" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"menuname") %>'
                                                                    Font-Bold="True" AutoPostBack="True" Enabled="false" />
                                                                <div style="margin-bottom: 5px;">
                                                                </div>
                                                                <asp:CheckBoxList ID="cbl" runat="server" RepeatColumns="3" Enabled="False">
                                                                </asp:CheckBoxList>
                                                                <div style="margin-top: 10px;">
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <br>
                                                        <asp:Button ID="Button2" runat="server" Text="  保 存" OnClick="Button2_Click1" CssClass="btn1">
                                                        </asp:Button>&nbsp;&nbsp;<asp:Button ID="Button4" runat="server" CausesValidation="False"
                                                            CssClass="btn2" OnClick="Button4_Click" Text="   密码初始化" />
                                                        &nbsp;
                                                        <asp:Button ID="Button3" runat="server" Text="  返 回" CausesValidation="False" OnClick="Button3_Click1"
                                                            CssClass="btn1"></asp:Button>
                                                        <asp:TextBox ID="txt_id" runat="server" Visible="False"></asp:TextBox>
                                                        <asp:TextBox ID="txt_bmid" runat="server" Visible="False"></asp:TextBox>
                                                        <asp:TextBox ID="txt_old" runat="server" Visible="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
