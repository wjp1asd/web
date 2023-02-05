<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZCLBTJ.aspx.cs" Inherits="Web_GZJL.ZCGL.ZCLBTJ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>资产设备登记查询</title>
    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../js/NumericF.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

    <script language="javascript">
        var Picker = new PickerControl();    
    </script>

    <style type="text/css">
        .style1
        {
            height: 29px;
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
                                <table border="0" cellpadding="0" cellspacing="0" height="27" width="60%">
                                    <tr>
                                        <td align="right" height="21" width="3%">
                                            <img height="13" src="../img/left_2.gif" width="16" />
                                        </td>
                                        <td width="1%">
                                            &nbsp;
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
                            <td valign="top" align="left">
                                <br />
                                <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="500">
                                </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                       <table  cellspacing="0" cellpadding="0" border="0" width="40%">
                                            <tr align="center" >
                                                <td>
                                                    <h2>
                                                        资产设备统计查询</h2>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                                            <table id="Table1" cellspacing="0" cellpadding="0"  style="border: 1px solid #aaaaaa;">
                                            
                                                <tr>
                                                    <td style="border-bottom: 1px solid #aaaaaa;">
                                                        <table border="0" cellpadding="3" cellspacing="0">
                                                            <tr  style="height: 30px">
                                                                <td align="left" class="style1">
                                                                    <asp:Label ID="lbl_xuanze" runat="server" Text="选择县区："></asp:Label>
                                                                </td>
                                                                <td class="style1">
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" class="style1">
                                                                    &nbsp;&nbsp;&nbsp;
                                                                </td>
                                                                <td class="style1">
                                                                <td align="left" class="style1">
                                                                    <asp:Button ID="btn_select" runat="server" CssClass="btn1" Text="查 询" 
                                                                        onclick="btn_select_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:GridView ID="gv_zcxx" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                                            BorderWidth="0px" CellPadding="2" CellSpacing="1" ShowHeader="False" AllowPaging="True"
                                                            OnRowDataBound="gv_zcxx_RowDataBound" 
                                                            OnSelectedIndexChanging="gv_zcxx_SelectedIndexChanging"  OnPageIndexChanging="gv_zcxx_PageIndexChanging">
                                                            <Columns>
                                                                <asp:BoundField DataField="DEPARTNAME">
                                                                    <HeaderStyle BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" Width="180px" />
                                                                    <ItemStyle BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" Width="180px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                            CellPadding="2" CellSpacing="1" EmptyDataText="无数据" BorderStyle="None">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="czlbid" HeaderText="资产名称">
                                                                                    <ItemStyle Width="140px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                        BorderWidth="1px" />
                                                                                    <HeaderStyle Width="140px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                        BorderWidth="1px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="sl" HeaderText="资产数量">
                                                                                    <ItemStyle Width="90px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                        BorderWidth="1px" />
                                                                                    <HeaderStyle Width="90px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                        BorderWidth="1px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="xzqhid" Visible="False" />
                                                                                <asp:BoundField DataField="czlb" Visible="False" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="230px" BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" />
                                                                    <ItemStyle Width="230px" BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" />
                                                                </asp:TemplateField>
                                                                <asp:CommandField SelectText="查看详细" ShowCancelButton="False" ShowSelectButton="True">
                                                                    <HeaderStyle BorderColor="White" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                                                                        Width="100px" />
                                                                    <ItemStyle BorderColor="White" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                                                                        Width="100px" />
                                                                </asp:CommandField>
                                                            </Columns>
                                                            <PagerStyle CssClass="biaoti" HorizontalAlign="Left" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel2" runat="server" Width="100%" Visible="false">
                                            <br />
                                            <table cellspacing="0" cellpadding="8" align="left" border="1" style="border-collapse: collapse"
                                                bordercolor="#6c9ec1">
                                                <tr>
                                                    <td colspan="2">
                                                        <table border="0" cellpadding="3" cellspacing="0">
                                                            <tr>
                                                                <td align="left" class="style1">
                                                                    <asp:Label ID="Label1" runat="server" Text="选择资产类别："></asp:Label>
                                                                </td>
                                                                <td class="style1">
                                                                    <asp:DropDownList ID="DropDownList2" runat="server" Width="200px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" class="style1">
                                                                    &nbsp;&nbsp;&nbsp;
                                                                </td>
                                                                <td class="style1">
                                                                <td align="left" class="style1">
                                                                    <asp:Button ID="Button1" runat="server" CssClass="btn1" Text="查 询" onclick="Button1_Click" 
                                                                         />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_diqu" runat="server" Text=""></asp:Label>
                                                        <asp:Label ID="lbl_xzqhid" runat="server" Text="" Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                                            AutoGenerateColumns="False" BorderWidth="0px" CellPadding="2" CellSpacing="1" 
                                                            CssClass="quanbu" PageSize="12" EmptyDataText="没有数据" 
                                                            onpageindexchanging="GridView2_PageIndexChanging">
                                                            <Columns>
                                                                <asp:BoundField DataField="czmc" HeaderText="资产名称">      
                                                                    <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="140px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField ApplyFormatInEditMode="True" DataField="grsj" 
                                                                    DataFormatString="{0:yyyy-MM-dd}" HeaderText="购入时间" HtmlEncode="False">
                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="czlb" HeaderText="资产类别">
                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="xinghao" HeaderText="资产型号">
                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="zcid" HeaderText="序列号">
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="金额（元）">
                                                                    <ItemStyle HorizontalAlign="Right" Width="110px" />
                                                                    <ItemTemplate>
                                                                        <b>
                                                                        <asp:Label ID="lbl_je" runat="server" Text='<%#Eval("jiage","￥{0:N2}") %>'></asp:Label>
                                                                        </b>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="dl" HorizontalAlign="Center" Width="110px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="详细参数">
                                                                    <ItemStyle HorizontalAlign="Left" Width="240px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_xxcs" runat="server" Text='<%#Eval("xxcs") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="dl" HorizontalAlign="Center" Width="240px" />
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
                                                    <td>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button ID="btn_QX" runat="server" Text="返 回" CssClass="btn1" OnClick="btn_QX_Click"></asp:Button>
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
