<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JFSBCX.aspx.cs" Inherits="Web_GZJL.JFGL.JFSBCX" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>日志管理</title>
    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>
    
    <script language="javascript">
        var Picker = new PickerControl();

    </script>

    <style type="text/css">
        .style1
        {
            height: 50px;
        }
        .style2
        {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td height="492" valign="top" background="../img/zhong_6.jpg">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td class="zhong" colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 10px">
                            </td>
                            <td valign="top" align="left">
                                <br />
                                <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="500">
                                </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table id="Table2" cellspacing="0" cellpadding="0" border="0" width="50%">
                                            <tr align="center" >
                                                <td>
                                                    <h2>
                                                       日志管理</h2>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                                            <table id="Table1" cellspacing="0" cellpadding="0" style="border: 1px solid #aaaaaa;">
                                                <tr>
                                                    <td style="border-bottom: 1px solid #aaaaaa;">
                                                        <table border="0" cellpadding="3" cellspacing="0">
                                                            <tr>
                                                                <td align="left">
                                                                    操作者：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtshebeiming" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                <td align="left">
                                                                    <asp:Button ID="btn_select" runat="server" CssClass="btn1" Text="查 询" OnClick="btn_select1" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="4">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="height: 5px">
                                                        <table border="0" cellpadding="0" cellspacing="0" height="27" width="60%">
                                                            <tr>
                                                                <td align="right" height="21" width="3%">
                                                                    <img height="13" src="../img/left_2.gif" width="16" />
                                                                </td>
                                                                <td width="1%"></td>
                                                                <td class="moren" width="96%">当前位置：<a href="../Main.aspx">首页</a>&gt;<span style="color: #1F65AE"><%=t1 %>日志管理</span>&gt;<span style="color: #1F65AE"><%=t0 %></span></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="2" CellSpacing="1" CssClass="quanbu" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                            OnSelectedIndexChanging="GridView1_SelectedIndexChanging" AllowPaging="True"
                                                            PageSize="12" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Uid" runat="server" Text='<%#Bind("Uid") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="操作者">
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Name" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="菜单">
                                                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ActionType" runat="server" Text='<%#Bind("ActionType") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IP地址">
                                                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_ip" runat="server" Text='<%#Bind("UserIP") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="具体动作">
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Description" runat="server" Text='<%#Bind("Description") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CreateTime" HeaderText="登录时间" ApplyFormatInEditMode="True" DataFormatString="{0:yyyy-MM-dd}"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="70px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="密码">
                                                                    <ItemStyle HorizontalAlign="Center" Width="64px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="synx" runat="server" Text='<%#Bind("Pws") %>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="64px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                           
                                                                <asp:TemplateField HeaderText="查看" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                            CssClass="a2" Text="<div>查看</div>"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="dl" HorizontalAlign="Center" Width="50px" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle CssClass="dan" />
                                                            <HeaderStyle CssClass="biaoti" />
                                                            <AlternatingRowStyle CssClass="suang" />
                                                            <PagerStyle CssClass="biaoti" HorizontalAlign="Left" />
                                                            <FooterStyle CssClass="biaoti" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="middle">
                                                        <br />
                                                        <b><font color="red">记录数：
                                                            <asp:Label ID="lbl_heji" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;条</font></b>
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
                                            <br />
                                            <table cellspacing="0" cellpadding="8" align="left" border="1" style="border-collapse: collapse"
                                                bordercolor="#6c9ec1">
                                                <tr>
                                                    </td>
                                                    <td align="left" rowspan="2">
                                                        操作者
                                                    </td>
                                                    <td align="left" rowspan="2">
                                                        <asp:Label ID="name" runat="server" Width="240px"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        使用处室：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="ActionType" runat="server" Width="240px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        IP地址：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_IP" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" rowspan="2">
                                                        业务系统：
                                                    </td>
                                                    <td align="left" rowspan="2">
                                                        <asp:Label ID="Description" runat="server" Width="240px"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        够买时间：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_gmrq" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        使用年限：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_synx" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr height="20">
                                                    <td align="left" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr height="150">
                                                    <td align="left">
                                                        设备参数：
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <table cellspacing="0" cellpadding="8" border="0" style="border-collapse: collapse"
                                                            bordercolor="#6c9ec1">
                                                            <tr>
                                                                <td>
                                                                    设备型号：
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Uid" runat="server" Width="340px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    系统版本：
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lbl_xtbb" runat="server" Text="" Width="340px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    详细参数：
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lbl_xxcs" runat="server" Text="" Width="460px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr height="20">
                                                    <td align="left" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr height="150">
                                                    <td align="left">
                                                        供应商<br />
                                                        联系方式：
                                                    </td>
                                                    <td align="left" class="style2" colspan="3">
                                                        <table cellspacing="0" cellpadding="8" border="0" style="border-collapse: collapse"
                                                            bordercolor="#6c9ec1">
                                                            <tr>
                                                                <td>
                                                                    供应商：
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lbl_gys" runat="server" Text="" Width="460px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    联系电话：
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lbl_lxdh" runat="server" Text="" Width="340px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    联系人：
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lbl_lxr" runat="server" Text="" Width="340px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    技术支持：
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lbl_jszc" runat="server" Text="" Width="240px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" height="26">
                                                        <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                        <asp:Button ID="btn_QX" runat="server" Text="返 回" CssClass="btn1" OnClick="btn_QX_Click">
                                                        </asp:Button>
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
