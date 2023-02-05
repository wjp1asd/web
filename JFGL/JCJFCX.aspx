<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JCJFCX.aspx.cs" Inherits="Web_GZJL.JFGL.JC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>机房出入申请查询</title>
    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

    <script language="javascript">
        var Picker = new PickerControl();    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td height="492" valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
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
                                            当前位置：<a href="../Main.aspx">首页</a>&gt;<span style="color: #1F65AE"><%=t1 %>机房出入申请</span>&gt;<span
                                                style="color: #1F65AE"><%=t0 %></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
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
                                        <table id="Table2" cellspacing="0" cellpadding="0" border="0" width="60%">
                                            <tr align="center" style="height: 40px">
                                                <td>
                                                    <h2>
                                                        机房出入查询表</h2>
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
                                                                    来访事由：
                                                                    <asp:TextBox ID="txt_idbh" runat="server"></asp:TextBox>
                                                                    来访人员：
                                                                    <asp:TextBox ID="txt_lfry" runat="server"></asp:TextBox>
                                                                    陪同人员：
                                                                    <asp:TextBox ID="txt_ptry" runat="server"></asp:TextBox>
                                                                    <td align="left">
                                                                        &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    日&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 期：
                                                                    <input id="startTime" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                                        onfocus="WdatePicker({isShowClear:true,readOnly:true})" />
                                                                    至&nbsp;<input id="endTime" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                                        onfocus="WdatePicker({isShowClear:true,readOnly:true})" />
                                                                    状态:
                                                                    <asp:DropDownList ID="ddl_sbstate" runat="server" Width="100px">
                                                                        <asp:ListItem Value="-1">全部</asp:ListItem>
                                                                        <asp:ListItem Value="1">待审核</asp:ListItem>
                                                                        <asp:ListItem Value="2">驳回</asp:ListItem>
                                                                        <asp:ListItem Value="3">审核通过</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:Button ID="btn_select" runat="server" CssClass="btn1" 
                                                                        OnClick="btn_select_Click" Text="查 询" />
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
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="2" CellSpacing="1" CssClass="quanbu" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                            OnSelectedIndexChanging="GridView1_SelectedIndexChanging" AllowPaging="True"
                                                            OnRowDataBound="GridView1_RowDataBound" PageSize="12">
                                                            <Columns>
                                                                <asp:BoundField DataField="lfrq" HeaderText="来访日期" ApplyFormatInEditMode="True" DataFormatString="{0:yyyy-MM-dd}"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle Width="65px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="65px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="来访人员">
                                                                    <ItemStyle HorizontalAlign="Left" Width="65px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl1" runat="server" Text='<%#Bind("lfname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="65px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="来访事由">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl2" runat="server" Text='<%#Bind("lfsy") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="200px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="携带物品">
                                                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl3" runat="server" Text='<%#Bind("xdwp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="陪同人员">
                                                                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl4" runat="server" Text='<%#Bind("ptry") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="65px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="jrjfsj" HeaderText="进入机房时间" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="lkjfsq" HeaderText="离开机房时间" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="dcwp" HeaderText="带出物品">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="状态">
                                                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblspshzt" runat="server" Text='<%#Bind("spshzt") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="false" HeaderText="状态">
                                                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIsSubmit" runat="server" Text='<%#Bind("psjg") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                            CssClass="a2" Text="查看"></asp:LinkButton>
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
                                                        <b><font color="red">总记录数：
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
                                                <tr style="height: 30px">
                                                    <td align="left">
                                                        登记人：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_djuser" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="height: 30px">
                                                    <td align="left">
                                                        来访日期：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_lfrq" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        来访人员：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_lfry" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="height: 30px">
                                                    <td align="left">
                                                        来访事由：
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lbl_lfsy" runat="server" Text="" Width="620px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="height: 30px">
                                                    <td align="left">
                                                        携带物品：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_xdwp" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        陪同人员：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_ptry" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="height: 30px">
                                                    <td align="left">
                                                        进入机房时间：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_jrTime" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        离开机房时间：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_lkTime" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="height: 30px">
                                                    <td align="left">
                                                        带出物品：
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lbl_dcwp" runat="server" Text="" Width="620px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="height: 30px">
                                                    <td>
                                                        主任批示
                                                    </td>
                                                    <td align="left" colspan="3" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                                                        margin: 0px; padding-top: 0px" valign="middle">
                                                        <table align="center" cellpadding="3" cellspacing="0" width="100%">
                                                            <tr height="22">
                                                                <td align="left">
                                                                    批示结果：&nbsp;&nbsp;<b><asp:Label ID="lbl_shjg" runat="server" Text=""></asp:Label></b>
                                                                </td>
                                                                <td align="left">
                                                                    批示人：<b><asp:Label ID="lbl_shenheren" runat="server" Text=""></asp:Label></b>
                                                                </td>
                                                                <td align="left">
                                                                    批示日期：<b><asp:Label ID="lbl_shenheriqi" runat="server" Text=""></asp:Label></b>
                                                                </td>
                                                            </tr>
                                                            <tr style="border-top: 1px; border-top-color: #6c9ec1; border-bottom: 0px; border-left: 0px;
                                                                border-right: 0px; border-style: solid" height="22">
                                                                <td align="left" colspan="3">
                                                                    批示意见： <b>
                                                                        <asp:Label ID="lbl_shenheyijian" runat="server" Text="" Width="490px"></asp:Label></b>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr style="height: 30px">
                                                    <td align="center" colspan="4" height="26">
                                                        <br />
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
