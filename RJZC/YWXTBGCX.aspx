<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YWXTBGCX.aspx.cs" Inherits="Web_GZJL.RJZC.YWXTBGCX" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>业务系统数据修改查询</title>
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
                                <table cellspacing="0" cellpadding="0" border="0" width="57%">
                                    <tr align="center">
                                        <td>
                                            <h2>
                                                业务系统数据修改申请查询</h2>
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
                                                            软件名称：
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                        <td>
                                                            申请使用人：
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
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
                                                        <asp:BoundField DataField="ID" HeaderText="编号">
                                                            <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField ApplyFormatInEditMode="True" DataField="rjmc" HeaderText="软件名称" HtmlEncode="False">
                                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="申请人">
                                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_syr" runat="server" Text='<%#bind("syr") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="dl" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="所在处室">
                                                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_sybm" runat="server" Text='<%#bind("sybm") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="90px" CssClass="dl" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="数据要求">
                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_sjyq" runat="server" Text='<%#bind("sjyq") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="200px" CssClass="dl" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="业务部门审批">
                                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_bmsp" runat="server" Text='<%#bind("bmsp") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="审核状态">
                                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_spshzt" runat="server" Text='<%#bind("spshzt") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="dl" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="审核状态" Visible="false">
                                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_shzt" runat="server" Text='<%#bind("shzt") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="dl" />
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
                                                <asp:Label ID="txt_bh" runat="server" Text="" Width="240px"></asp:Label>
                                            </td>
                                            <td align="left">
                                                填表日期
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lbl_tbrq" runat="server" Text="lbl_tbrq"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="height: 20px">
                                                软件名称
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:Label ID="lbl_ruanjname" runat="server" Text="" Width="440px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="height: 20px">
                                                申请人
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lbl_sqr" runat="server" Text="" Width="240px"></asp:Label>
                                            </td>
                                            <td align="left">
                                                所属处室
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lbl_sscs" runat="server" Text="" Width="240px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="height: 20px">
                                                数据要求
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:Label ID="lbl_sjyq" runat="server" Text="" Width="594px"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="height: 20px">
                                                业务部门审批
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:Label ID="lbl_ywbmsq" runat="server" Text="" Width="594px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="Tr1" runat="server">
                                            <td align="center" style="height: 20px">
                                                信息中心审批
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:Label ID="txt_xxzx" runat="server" Text="" Width="594px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="height: 20px">
                                                备注
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:Label ID="txt_bz" runat="server" Text="" Width="594px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4" height="26">
                                                <input runat="server" id="btfh" class="btn1" cssclass="btn1" onclick="javascript:window.history.go(-1);"
                                                    type="button" value="返回" /><asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                <asp:Button ID="btn_bohui" runat="server" Text="返 回" CssClass="btn1" OnClick="btn_bohui_Click"
                                                    Visible="False"></asp:Button>
                                                <asp:Button ID="btn_word" runat="server" CssClass="btn2" OnClick="btn_word_Click"
                                                    Text="生成Word打印" />
                                                <br />
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
    </div>
    </form>
</body>
</html>
