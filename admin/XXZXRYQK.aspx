<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="  XXZXRYQK.aspx.cs" EnableEventValidation="false"
    ValidateRequest="false" Inherits="Web_GZJL.admin.XXZXRYQK" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>信息中心人员情况</title>
    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../js/NumericF.js" type="text/javascript"></script>

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
                                    <table id="Table2" cellspacing="0" cellpadding="0" border="0" width="30%">
                                            <tr align="center" style="height: 40px">
                                                <td>
                                                    <h2>
                                                       信息中心人员情况</h2>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                                            <table id="Table1" cellspacing="0" cellpadding="0" border="0"  style="border: 1px solid #aaaaaa;">
                                                <tr>
                                                    <td  style="border-bottom: 1px solid #aaaaaa;">
                                                        <table border="0" cellpadding="3" cellspacing="0">
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="lbl_xuanze" runat="server" Text="选择县区："></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                <td align="left">
                                                                    <asp:Button ID="btn_select" runat="server" CssClass="btn1" Text="查 询" OnClick="btn_select_Click" />
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
                                                    <td align="left" style="height: 17px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:GridView ID="gv_ryxx" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                                            BorderWidth="0px" CellPadding="2" CellSpacing="1" ShowHeader="False" OnRowDataBound="gv_ryxx_RowDataBound"
                                                            AllowPaging="True" >
                                                            <Columns>
                                                                <asp:BoundField DataField="xzqh">
                                                                    <HeaderStyle BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" Width="90px" />
                                                                    <ItemStyle BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" Width="90px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <table align="center" border="1" cellpadding="3" cellspacing="0" style="border-collapse: collapse"
                                                                            width="100%">
                                                                            <tr>
                                                                                <td align="left">
                                                                                    详细地址：<asp:Label ID="lbl_add" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.czjadds") %>'></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                                        CellPadding="2" CellSpacing="1" OnRowDataBound="GridView1_RowDataBound">
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
