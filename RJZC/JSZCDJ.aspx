<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSZCDJ.aspx.cs" Inherits="Web_GZJL.RJZC.JSZCDJ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
        <br />
        <br />
        <br />
        <br />
        <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td height="492" valign="top" background="../img/zhong_6.jpg">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="zhong" colspan="2">
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
                                                style="color: #1F65AE;"><%=t0 %></span>
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
                                <br />
                                <asp:Button ID="Button2" runat="server" Text="任务管理" Width="133px" />
                          &nbsp;<asp:Button ID="Button3" runat="server" Text="检测列表" Width="133px" />
                          &nbsp;<asp:Button ID="Button4" runat="server" Text="待检测" Width="133px" />
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table cellspacing="0" cellpadding="0" border="0" width="60%">
                                            <tr align="center" valign="middle">
                                                <td>
                                                    <h2>
                                                        管道检测列表</h2>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                                            <table id="Table1" cellspacing="0" cellpadding="0" style="border: 1px solid #aaaaaa;">
                                                <tr>
                                                    <td style="border-bottom: 1px solid #aaaaaa;">
                                                        <table border="0" cellpadding="3" cellspacing="0">
                                                            <tr style="height: 30px">
                                                                <td align="left">
                                                                    编号：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_rjmingcheng" runat="server" Width="140px"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                                <td>
                                                                    管道规格：
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddl_wentifenlei" runat="server" Width="140px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Button ID="btn_select" runat="server" CssClass="btn1" Text="查 询" OnClick="btn_select_Click" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Button ID="Button1" runat="server" Text="添 加" OnClick="btn_add_Click" CssClass="btn1">
                                                                    </asp:Button>
                                                                </td>
                                                                    <td align="left">
                                                                    <asp:Button ID="Button5" runat="server" Text="导出" OnClick="btn_add_Click" CssClass="btn1">
                                                                    </asp:Button>
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
                                                            OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                                                            OnRowDataBound="GridView1_RowDataBound" PageSize="10" AllowPaging="True">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="编号">
                                                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                                    <ItemTemplate>
                                                                        <a href='../select/JSZCDJ_C.aspx?idd=<%#Eval("gzrzid") %>'>
                                                                            <asp:Label ID="lbl_idhao" runat="server" Text='<%#bind("bianhao") %>'></asp:Label>
                                                                        </a>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="tbrq" HeaderText="委托日期" ApplyFormatInEditMode="True" DataFormatString="{0:yyyy-MM-dd}"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="任务名称">
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl1" runat="server" Text='<%#Bind("rjmca") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="检验员">
                                                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                                    <ItemTemplate>
                                                                        <%--<asp:Label ID="lbl_xzrjb" runat="server" Text='<%#Bind("zxrjb") %>'></asp:Label>
                                                                        &nbsp; --%>
                                                                        <asp:Label ID="lbl2" runat="server" Text='<%#Bind("zxr") %>'>

                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="所属部门">
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl3" runat="server" Text='<%#Bind("zxrbm") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="联系方式">
                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl4" runat="server" Text='<%#Bind("lxfs") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="90px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="管道规格">
                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="wtflname" runat="server" Text='<%#Bind("wtflname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="90px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="管道名称">
                                                                    <ItemStyle HorizontalAlign="Left" Width="230px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="wtms" runat="server" ToolTip='<%#Bind("wtms") %>' Text='<%#Bind("wtms") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="230px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="任务单号">
                                                                    <ItemStyle HorizontalAlign="Left" Width="230px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="wtjd" runat="server" ToolTip='<%#Bind("wtjd") %>' Text='<%#Bind("wtjd") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="230px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                            CssClass="a2" Text="<div>编辑</div>"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="dl" HorizontalAlign="Center" Width="50px" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                            CssClass="a2" OnClientClick="return confirm('确认删除此条记录吗')">删除</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerSettings Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
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
                                                <tr>
                                                    <td align="center">
                                                        编号
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_bianhao" runat="server" Text="lbl_bianhao"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        填表日期
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_tianbiaorq" runat="server" Text="lbl_tianbiaorq"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        软件名称
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:DropDownList ID="ddl_ruanjianming" runat="server" Width="594px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        登记人
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_dengjiren" runat="server" Text="lbl_dengjiren"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        登记时间
                                                    </td>
                                                    <td align="left">
                                                        <input id="txt_dengjishijian" runat="server" class="Wdate" type="text" onfocus="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd  HH:mm'})"
                                                            style="width: 230px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        咨询人
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_zxr" runat="server" Width="160px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        联系方式
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_lxfs" runat="server" Width="230px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--  <tr>
                                                    <td align="center" style="height: 20px">
                                                        联系方式
                                                    </td>
                                                    <td align="left" colspan="3">
                                                         <asp:TextBox ID="txt_lxfs" runat="server" Width="230px"></asp:TextBox>
                                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        咨询人所<br />
                                                        在部门
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddl_zxrjb" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_zxrjb_SelectedIndexChanged">
                                                            <asp:ListItem>局内</asp:ListItem>
                                                            <asp:ListItem>县区</asp:ListItem>
                                                            <asp:ListItem>预算单位</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddl_quhua" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_quhua_SelectedIndexChanged"
                                                            Width="110px">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddl_chushi" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left">
                                                        解答时间
                                                    </td>
                                                    <td align="left">
                                                        <input id="txt_jiedashijian" runat="server" class="Wdate" type="text" onfocus="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd  HH:mm'})"
                                                            style="width: 230px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        问题分类
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:DropDownList ID="ddl_wtfl" runat="server" Width="594px">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        问题内容<br />
                                                        描 述
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:TextBox ID="txt_wtms" runat="server" Width="594px" TextMode="MultiLine" Rows="5"
                                                            BorderWidth="1px" BorderColor="#3399FF"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        问题解答
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:TextBox ID="txt_wtjd" runat="server" Width="594px" TextMode="MultiLine" Rows="5"
                                                            BorderWidth="1px" BorderColor="#3399FF"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        备注
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:TextBox ID="txt_bz" runat="server" Width="594px" TextMode="MultiLine" Rows="5"
                                                            BorderWidth="1px" BorderColor="#3399FF"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" height="36">
                                                        <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                        <asp:Button ID="btn_save" runat="server" Text="保 存" CssClass="btn1" OnClick="btn_save_Click">
                                                        </asp:Button>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="btn_QX" runat="server"
                                                            Text="返 回" CssClass="btn1" OnClick="btn_QX_Click"></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
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
