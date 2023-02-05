<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Web_GZJL.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="css/css.css" type="text/css" rel="stylesheet" />
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
                                                <tr id="zc" runat="server" style="display: none" bgcolor="#CCCCCC">
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
                                                                    资产总数（<asp:HyperLink ID="hpzc" runat="server" Font-Size="Large" ForeColor="red" NavigateUrl="~/ZCGL/ZCCX.aspx?type=all">[hpzc]</asp:HyperLink>
                                                                    ）使用中（<asp:HyperLink ID="hpzczc" runat="server" Font-Size="Large" ForeColor="red"
                                                                        NavigateUrl="~/ZCGL/ZCCX.aspx?type=0">[hpzczc]</asp:HyperLink>
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
                                                <tr id="sp" runat="server" style="display: none" bgcolor="#CCCCCC">
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
                                                <tr id="jf" runat="server" style="display: none" bgcolor="#CCCCCC">
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
                                                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="a1" Font-Size="11" NavigateUrl="~/Select/WDCX.aspx">文档查询 &nbsp;</asp:HyperLink>
                                                                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="a1" Font-Size="11" NavigateUrl="~/ZCGL/ZCCX.aspx?type=all"
                                                                        Visible="False">资产查询 &nbsp;</asp:HyperLink>
                                                                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="a1" Font-Size="11" NavigateUrl="~/SPGL/SPHYCX.aspx"
                                                                        Visible="False">视频会议查询 &nbsp;</asp:HyperLink>
                                                                    <asp:HyperLink ID="HyperLink5" runat="server" CssClass="a1" Font-Size="11" NavigateUrl="~/ZCGL/ZCCX.aspx?type=s"
                                                                        Visible="False">视频设备维修查询 &nbsp;</asp:HyperLink>
                                                                    <asp:HyperLink ID="HyperLink6" runat="server" CssClass="a1" Font-Size="11" NavigateUrl="~/JFGL/JCJFCX.aspx"
                                                                        Visible="False">机房出入查询 &nbsp;</asp:HyperLink>
                                                                    <asp:HyperLink ID="HyperLink7" runat="server" CssClass="a1" Font-Size="11" NavigateUrl="~/JFGL/JFWXCX.aspx"
                                                                        Visible="False">机房设备查询 &nbsp;</asp:HyperLink>
                                                                    <asp:HyperLink ID="HyperLink8" runat="server" CssClass="a1" Font-Size="11" NavigateUrl="~/RJZC/YWXTBGCX.aspx"
                                                                        Visible="False">业务系统数据修改查询 &nbsp;</asp:HyperLink>
                                                                    <asp:HyperLink ID="HyperLink9" runat="server" CssClass="a1" Font-Size="11" NavigateUrl="~/RJZC/YWXTSQCX.aspx"
                                                                        Visible="False">业务系统使用查询 &nbsp;</asp:HyperLink>
                                                                    <asp:HyperLink ID="HyperLink10" runat="server" CssClass="a1" Font-Size="11" NavigateUrl="~/RJZC/YWXTSQQZCX.aspx"
                                                                        Visible="False">业务系统变更查询</asp:HyperLink>
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
                                            <asp:GridView ID="gv_ryxx" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                                BorderWidth="0px" CellPadding="2" CellSpacing="1" ShowHeader="False" OnRowDataBound="gv_ryxx_RowDataBound"
                                                AllowPaging="True">
                                                <Columns>
                                                    <asp:BoundField DataField="xzqh">
                                                        <HeaderStyle BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" Width="90px" />
                                                        <ItemStyle BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" Width="90px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <table align="center" border="0" cellpadding="3" cellspacing="0" style="border-collapse: collapse"
                                                                width="100%">
                                                                <tr>
                                                                    <td align="left">
                                                                        详细地址：<asp:Label ID="lbl_add" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.czjadds") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                            BorderStyle="None" CellPadding="2" CellSpacing="1" OnRowDataBound="GridView1_RowDataBound">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="usrzhiwu" HeaderText="职务">
                                                                                    <ItemStyle Width="140px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                        BorderWidth="1px" />
                                                                                    <HeaderStyle Width="140px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                        BorderWidth="1px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="usrname" HeaderText="姓名">
                                                                                    <ItemStyle Width="90px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                        BorderWidth="1px" />
                                                                                    <HeaderStyle Width="90px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                        BorderWidth="1px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="shouji" HeaderText="手机">
                                                                                    <ItemStyle Width="100px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                        BorderWidth="1px" />
                                                                                    <HeaderStyle Width="100px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                        BorderWidth="1px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="bangongdh" HeaderText="办公电话">
                                                                                    <ItemStyle Width="100px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                        BorderWidth="1px" />
                                                                                    <HeaderStyle Width="100px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                        BorderWidth="1px" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="430px" BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" />
                                                        <ItemStyle Width="430px" BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="biaoti" HorizontalAlign="Left" />
                                            </asp:GridView>
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
