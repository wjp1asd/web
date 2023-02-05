<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main2.aspx.cs" Inherits="Web_GZJL.Main2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="css/css.css" type="text/css" rel="stylesheet" />
    <style>
        .yangshi3
        {
            font-size: 11pt;
        }
    </style>
</head>
<body id="Mybody" runat="server">
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
                                        <td align="right" height="21" width="4%">
                                            <img height="13" src="img/left_2.jpg" width="16" />
                                        </td>
                                        <td width="1%">
                                            &nbsp;
                                        </td>
                                        <td class="moren" width="95%">
                                            当前位置：首页&gt;<span style="color: #1F65AE"></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15px">
                            </td>
                            <td valign="top" align="left">
                                <table border="0" cellpadding="0" cellspacing="0" width="70%">
                                    <tr>
                                        <td colspan="2">
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                <tr bgcolor="#CCCCCC">
                                                    <td height="25" bgcolor="#FFFFFF">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                                            <tr>
                                                                <td width="50">
                                                                    <div align="center">
                                                                        <img src="img/2.gif" width="16" height="16" /></div>
                                                                </td>
                                                                <td width="80" style="border-right: 1px solid #aaaaaa;">
                                                                    资产管理：
                                                                </td>
                                                                <td>
                                                                    资产总数（<asp:HyperLink ID="hpzc" runat="server" Font-Size="Large" ForeColor="red" NavigateUrl="~/ZCGL/ZCCX.aspx?type=all">[hpzc]</asp:HyperLink>）使用中（<asp:HyperLink
                                                                        ID="hpzczc" runat="server" Font-Size="Large" ForeColor="red" NavigateUrl="~/ZCGL/ZCCX.aspx?type=0">[hpzczc]</asp:HyperLink>
                                                                    ） 已停用（<asp:HyperLink ID="hptyzc" runat="server" Font-Size="Large" ForeColor="red"
                                                                        NavigateUrl="~/ZCGL/ZCCX.aspx?type=2">[hptyzc]</asp:HyperLink>
                                                                    ） 维修中（<asp:HyperLink ID="hpwxzc" runat="server" Font-Size="Large" ForeColor="red"
                                                                        NavigateUrl="~/ZCGL/ZCCX.aspx?type=3">[hpwxzc]</asp:HyperLink>
                                                                    ） 已报废（<asp:HyperLink ID="hpbfzc" runat="server" Font-Size="Large" ForeColor="red"
                                                                        NavigateUrl="~/ZCGL/ZCCX.aspx?type=1">[hpbfzc]</asp:HyperLink>
                                                                    ）
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#CCCCCC">
                                                    <td height="25" bgcolor="#EBF8FC">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                                            <tr>
                                                                <td width="50">
                                                                    <div align="center">
                                                                        <img src="img/3.gif" width="16" height="16" /></div>
                                                                </td>
                                                                <td width="80" style="border-right: 1px solid #aaaaaa;">
                                                                    视频会议：
                                                                </td>
                                                                <td>
                                                                    视频会议待签字（<asp:HyperLink ID="hpspdqz" runat="server" Font-Size="Large" ForeColor="red"
                                                                        NavigateUrl="~/SPGL/SPHYSH.aspx">[hpspdqz]</asp:HyperLink>
                                                                    ）视频设备维修中（<asp:HyperLink ID="hpspdwx" runat="server" Font-Size="Large" ForeColor="red"
                                                                        NavigateUrl="~/ZCGL/ZCCX.aspx?type=s">[hpspdwx]</asp:HyperLink>
                                                                    ）
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#CCCCCC">
                                                    <td height="25" bgcolor="#FFFFFF">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                                            <tr>
                                                                <td width="50">
                                                                    <div align="center">
                                                                        <img src="img/4.gif" width="16" height="16" /></div>
                                                                </td>
                                                                <td width="80" style="border-right: 1px solid #aaaaaa;">
                                                                    机房管理：
                                                                </td>
                                                                <td>
                                                                    机房出入待审批（<asp:HyperLink ID="hpjcjfdqz" runat="server" Font-Size="Large" ForeColor="red"
                                                                        NavigateUrl="~/JFGL/JFCRSH.aspx">[hpjcjfdqz]</asp:HyperLink>
                                                                    ） 机房设备维修（<asp:HyperLink ID="hpjfsbwx" runat="server" Font-Size="Large" ForeColor="red"
                                                                        NavigateUrl="~/JFGL/JFWXCX.aspx?type=wx">[hpjfsbwx]</asp:HyperLink>
                                                                    ） 机房设备维护（<asp:HyperLink ID="hpjfsbwh" runat="server" Font-Size="Large" ForeColor="red"
                                                                        NavigateUrl="~/JFGL/JFWXCX.aspx?type=wh">[hpjfsbwh]</asp:HyperLink>
                                                                    ）
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#CCCCCC">
                                                    <td height="25" bgcolor="#EBF8FC">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                                            <tr>
                                                                <td width="50">
                                                                    <div align="center">
                                                                        <img src="img/5.gif" width="16" height="16" /></div>
                                                                </td>
                                                                <td width="80" style="border-right: 1px solid #aaaaaa;">
                                                                    我的文档：
                                                                </td>
                                                                <td>
                                                                    个人文档（<asp:HyperLink ID="hpwdwd" runat="server" Font-Size="Large" ForeColor="red"
                                                                        NavigateUrl="~/Select/WDCX.aspx?type=private">[hpwdwd]</asp:HyperLink>
                                                                    ） 公开文档（<asp:HyperLink ID="hpggwd" runat="server" Font-Size="Large" ForeColor="red"
                                                                        NavigateUrl="~/Select/WDCX.aspx?type=public">[hpggwd]</asp:HyperLink>
                                                                    ）
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#CCCCCC">
                                                    <td height="25" bgcolor="#FFFFFF">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                                            <tr>
                                                                <td width="50">
                                                                    <div align="center">
                                                                        <img src="img/6.gif" width="15" height="15" /></div>
                                                                </td>
                                                                <td width="80" style="border-right: 1px solid #aaaaaa;">
                                                                    查询功能：
                                                                </td>
                                                                <td>
                                                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="a1" Font-Size="11"   NavigateUrl="~/Select/WDCX.aspx">文档查询</asp:HyperLink>
                                                                   
                                                                    &nbsp;<asp:HyperLink ID="HyperLink3" runat="server" CssClass="a1" Font-Size="11"   NavigateUrl="~/ZCGL/ZCCX.aspx?type=all">资产查询</asp:HyperLink>
                                                                    &nbsp;<asp:HyperLink ID="HyperLink4" runat="server" CssClass="a1" Font-Size="11"   NavigateUrl="~/SPGL/SPHYCX.aspx">视频会议查询</asp:HyperLink>
                                                                    &nbsp;<asp:HyperLink ID="HyperLink5" runat="server" CssClass="a1" Font-Size="11"   NavigateUrl="~/ZCGL/ZCCX.aspx?type=s">视频设备维修查询</asp:HyperLink>
                                                                    &nbsp;<asp:HyperLink ID="HyperLink6" runat="server" CssClass="a1" Font-Size="11"   NavigateUrl="~/JFGL/JCJFCX.aspx">机房出入查询</asp:HyperLink>
                                                                    <asp:HyperLink ID="HyperLink7" runat="server" CssClass="a1" Font-Size="11"   NavigateUrl="~/JFGL/JFWXCX.aspx">机房设备查询</asp:HyperLink>
                                                                    &nbsp;<asp:HyperLink ID="HyperLink8" runat="server" CssClass="a1" Font-Size="11"  NavigateUrl="~/RJZC/YWXTBGCX.aspx"
                                                                        Visible="False">业务系统数据修改申请查询</asp:HyperLink>
                                                                    &nbsp;<asp:HyperLink ID="HyperLink9" runat="server" CssClass="a1" Font-Size="11"   NavigateUrl="~/RJZC/YWXTSQCX.aspx"
                                                                        Visible="False">业务系统使用申请查询 </asp:HyperLink>
                                                                    <asp:HyperLink ID="HyperLink10" runat="server" CssClass="a1" Font-Size="11"   NavigateUrl="~/RJZC/YWXTSQQZCX.aspx"
                                                                        Visible="False">业务系统变更查询  </asp:HyperLink>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="500">
                                            </asp:ScriptManager>
                                            <cc2:TabContainer ID="tc_info" runat="server" ActiveTabIndex="2" Width="100%">
                                                <cc2:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                    <HeaderTemplate>
                                                        &nbsp;&nbsp;<span class="yangshi3">机房进出审批</span> &nbsp;&nbsp;
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="2" CellSpacing="1" CssClass="quanbu" AllowPaging="True" PageSize="12"
                                                            Width="100%">
                                                            <Columns>
                                                                <asp:BoundField DataField="lfrq" HeaderText="来访日期" ApplyFormatInEditMode="True" DataFormatString="{0:yyyy-MM-dd}"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="来访人员">
                                                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl1" runat="server" Text='<%#Bind("lfname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="来访事由">
                                                                    <ItemStyle HorizontalAlign="Left" Width="260px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl2" runat="server" Text='<%#Bind("lfsy") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="260px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="携带物品">
                                                                    <ItemStyle HorizontalAlign="Left" Width="260px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl3" runat="server" Text='<%#Bind("xdwp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="260px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="陪同人员">
                                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl4" runat="server" Text='<%#Bind("ptry") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="dl" />
                                                                </asp:TemplateField>
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
                                                                <asp:TemplateField HeaderText="审核" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <a href='JFGL/JFCRSH.aspx?id=<%#Eval("ID") %>'>
                                                                            <asp:Label ID="lbl_shenhe" runat="server" Text="审核"></asp:Label></a>
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
                                                    </ContentTemplate>
                                                </cc2:TabPanel>
                                                <cc2:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel1">
                                                    <HeaderTemplate>
                                                        &nbsp;&nbsp;<span class="yangshi3">视频会议签字</span>&nbsp;&nbsp;
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                            BorderWidth="0px" CellPadding="2" CellSpacing="1" CssClass="quanbu" PageSize="12">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="会议名称">
                                                                    <ItemStyle HorizontalAlign="Left" Width="400px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblmeetName" runat="server" Text='<%#Bind("MeetName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="dl" HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField ApplyFormatInEditMode="True" DataField="starTime" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                                                    HeaderText="测试开始时间" HtmlEncode="False">
                                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField ApplyFormatInEditMode="True" DataField="overtime" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                                                    HeaderText="测试结束时间" HtmlEncode="False">
                                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField ApplyFormatInEditMode="True" DataField="fostartime" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                                                    HeaderText="会议开始时间" HtmlEncode="False">
                                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField ApplyFormatInEditMode="True" DataField="foovertime" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                                                    HeaderText="会议结束时间" HtmlEncode="False">
                                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="信息中心主任签字" Visible="false">
                                                                    <ItemStyle HorizontalAlign="center" Width="90px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldirector" runat="server" Text='<%#Bind("director") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="dl" HorizontalAlign="Center" Width="90px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="签字" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <a href='SPGL/SPHYSH.aspx?id=<%#Eval("id") %>'>
                                                                            <asp:Label ID="lbl_sphyqz" runat="server" Text="签字"></asp:Label></a>
                                                                        <asp:Label ID="lblpishi" runat="server" ForeColor="Green" Text="已签字" Visible="false"></asp:Label>
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
                                                    </ContentTemplate>
                                                </cc2:TabPanel>
                                                <cc2:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel1">
                                                    <HeaderTemplate>
                                                        &nbsp;&nbsp;<span class="yangshi3">资产设备维修签字</span>&nbsp;&nbsp;
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="2" CellSpacing="1" CssClass="quanbu" AllowPaging="True" PageSize="12">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="序号">
                                                                    <ItemStyle Width="35px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="35px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SBLB" HeaderText="资产类别">
                                                                    <ItemStyle Width="90px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="90px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SBMC" HeaderText="资产名称">
                                                                    <ItemStyle Width="140px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="140px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="xh" HeaderText="资产型号">
                                                                    <ItemStyle Width="90px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="90px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="xlh" HeaderText="序列号">
                                                                    <ItemStyle Width="110px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="110px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="金额（元）">
                                                                    <ItemStyle HorizontalAlign="Right" Width="110px" />
                                                                    <ItemTemplate>
                                                                        <b>
                                                                            <asp:Label ID="lbl_je" runat="server" Text='<%#Eval("jine","￥{0:N2}") %>'></asp:Label></b>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="110px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="grsj" HeaderText="购入时间" ApplyFormatInEditMode="True" DataFormatString="{0:yyyy-MM-dd}"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="70px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="zczt" HeaderText="资产状态">
                                                                    <ItemStyle Width="70px" HorizontalAlign="Center" ForeColor="Red" />
                                                                    <HeaderStyle Width="70px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="详细参数">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_xxcs" runat="server" Text='<%#Eval("xiangqing") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="200px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="false" HeaderText="审核状态">
                                                                    <ItemStyle HorizontalAlign="Center" Width="10px" ForeColor="Green" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_shztshuzi" runat="server" Text='<%#Eval("sbshzt") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="10px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="审核状态">
                                                                    <ItemStyle HorizontalAlign="Center" Width="70px" ForeColor="Green" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_shzt" runat="server" Text='<%#Eval("shzta") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="审核" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <a href='ZCGL/ZCTYBFSH.aspx?id=<%#Eval("ID") %>'>
                                                                            <asp:Label ID="lbl_zcwxsh" runat="server" Text="审核"></asp:Label></a>
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
                                                    </ContentTemplate>
                                                </cc2:TabPanel>
                                            </cc2:TabContainer>
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
