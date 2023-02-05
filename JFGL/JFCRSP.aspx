<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JFCRSP.aspx.cs" Inherits="Web_GZJL.JFGL.JFCRSP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>机房出入申请</title>
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
            height: 27px;
        }
    </style>
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
                                            <tr align="center">
                                                <td>
                                                    <h2>
                                                        机房出入申请表</h2>
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
                                                                    来访事由：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_idbh" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    来访人员：
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    日期：
                                                                </td>
                                                                <td>
                                                                    <input id="startTime" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                                        onfocus="WdatePicker({isShowClear:true,readOnly:true})" />
                                                                </td>
                                                                <td align="left">
                                                                    至
                                                                </td>
                                                                <td align="left">
                                                                    <input id="endTime" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                                        onfocus="WdatePicker({isShowClear:true,readOnly:true})" />
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Button ID="btn_select" runat="server" CssClass="btn1" Text="查 询" OnClick="btn_select_Click" />
                                                                </td>
                                                                <td align="left" style="height: 17px">
                                                                    <asp:Button ID="btn_add" runat="server" Text="添 加" OnClick="btn_add_Click" CssClass="btn1">
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
                                                            OnSelectedIndexChanging="GridView1_SelectedIndexChanging" AllowPaging="True"
                                                            OnRowDataBound="GridView1_RowDataBound" PageSize="12">
                                                            <Columns>
                                                                <asp:BoundField DataField="lfrq" HeaderText="来访日期" ApplyFormatInEditMode="True" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle Width="120px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="来访事由">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl2" runat="server" Text='<%#Bind("lfsy") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="200px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="来访人员">
                                                                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl1" runat="server" Text='<%#Bind("lfname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="65px" CssClass="dl" />
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
                                                                            CssClass="a2" Text="<div>编辑</div>"></asp:LinkButton>
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
                                                <tr>
                                                    <td align="left" style="height: 30px">
                                                        登记人：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_djuser" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 30px" align="left">
                                                        来访日期：
                                                    </td>
                                                    <td align="left">
                                                        <input id="tata_Lfrq" runat="server" type="text" style="width: 240px" readonly="readonly"/>
                                                    </td>
                                                    <td align="left">
                                                        来访人员：
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_lfname" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        来访事由：
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:TextBox ID="lfxx" runat="server" Rows="4" TextMode="MultiLine" Width="620px"
                                                            BorderWidth="1px" BorderColor="#3399FF"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style1">
                                                        携带物品：
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <asp:TextBox ID="txt_xdwp" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                    <td align="left" class="style1">
                                                        陪同人员：
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <%--<asp:TextBox ID="txt_ptry" runat="server" Width="240px"></asp:TextBox>--%>
                                                        <asp:DropDownList ID="ddl_ptry" runat="server" Height="20px" Width="138px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="tr_yincang2" runat="server" visible="false">
                                                    <td align="left">
                                                        进入机房时间：
                                                    </td>
                                                    <td align="left">
                                                        <input id="txt_jtime" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                            onfocus="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd  HH:mm'})" style="width: 240px" />
                                                    </td>
                                                    <td align="left">
                                                        离开机房时间：
                                                    </td>
                                                    <td align="left">
                                                        <input id="txt_lktime" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                            onfocus="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd  HH:mm'})" style="width: 240px" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_yincang3" runat="server" visible="false">
                                                    <td align="left">
                                                        带出物品：
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:TextBox ID="txt_dcwp" runat="server" Width="360px" BorderColor="#3399FF" BorderWidth="1px"
                                                            Rows="4" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        如果没有带出物品不用填写<br />
                                                        如果带出物品必填
                                                    </td>
                                                </tr>
                                                <tr id="tr_sh" runat="server" visible="false">
                                                    <td style="height: 20px">
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
                                                <tr>
                                                    <td align="center" colspan="4" height="26">
                                                        <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                        <asp:Button ID="btn_Tj" runat="server" ToolTip="提交给领导签字" Text="提 交" CssClass="btn1"
                                                            OnClick="btn_Tj_Click"></asp:Button>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                                                        <asp:Button ID="btn_save" runat="server" Text="保 存" CssClass="btn1" OnClick="btn_save_Click">
                                                        </asp:Button>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="btn_QX" runat="server"
                                                            Text="返 回" CssClass="btn1" OnClick="btn_QX_Click"></asp:Button>
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
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
