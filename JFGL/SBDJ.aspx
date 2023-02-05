<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SBDJ.aspx.cs" EnableEventValidation="false"
    ValidateRequest="false" Inherits="Web_GZJL.JFGL.SBDJ" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>机房设备登记表</title>
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
                                            
                                        </td>
                                        <td class="moren" width="96%">
                                            当前位置：<a href="../Main.aspx">首页</a>&gt;<span style="color: #1F65AE"><%=t1 %>机房出入申请</span>&gt;<span style="color: #1F65AE"><%=t0 %></span>
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
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                                            <table id="Table1" cellspacing="0" cellpadding="0" border="0">
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="3" cellspacing="0">
                                                            <tr>
                                                                <td align="left">
                                                                    设备/配件名称：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_sbName" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                                <td>
                                                                    型号/序列号：
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_xhlx" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
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
                                                                <td align="center" colspan="4">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 17px">
                                                        <asp:Button ID="btn_add" runat="server" Text="添 加" OnClick="btn_add_Click" CssClass="btn1">
                                                        </asp:Button>
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
                                                            AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" PageSize="12" 
                                                            >
                                                            <Columns>
                                                                <asp:BoundField DataField="jrjfrq" HeaderText="进入机房日期" ApplyFormatInEditMode="True" DataFormatString="{0:yyyy-MM-dd}"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="设备/配件名称">
                                                                    <ItemStyle HorizontalAlign="Left" Width="180px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTITLE3" runat="server" Text='<%#Bind("sbname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="型号/序列号">
                                                                    <ItemStyle HorizontalAlign="Left" Width="180px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTITLE1" runat="server" Text='<%#Bind("xhxlh") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="进入机房原因">
                                                                    <ItemStyle HorizontalAlign="Left" Width="180px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTITLE" runat="server" Text='<%#Bind("jrjfyy") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="从机房取出日期">
                                                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_pjlx" runat="server" Text='<%#Bind("jfqcrq") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="从机房取出原因">
                                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTITLE2" runat="server" Text='<%#Bind("jfqcyy") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="sbghrq" HeaderText="设备归还日期">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="sbjqr" HeaderText="进机房设备确认">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="sbcqr" HeaderText="出机房设备确认">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="sbghqr" HeaderText="设备归还确认">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                                </asp:BoundField>
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
                                                        <br />
                                                        <hr />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
                                            <br />
                                            <table cellspacing="0" cellpadding="8" align="left" class="td1" style="border-collapse: collapse">
                                                <tr>
                                                    <td align="left" style="height: 30px">
                                                        登记表编号：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_djbh" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 30px" align="left">
                                                        设备/配件名称：
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_sbmc" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        型号/序列号：
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_sbxh" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        进入机房日期：
                                                    </td>
                                                    <td align="left">
                                                        <input id="jrsj" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                            onfocus="WdatePicker({isShowClear:false,readOnly:true})" 
                                                            style="width: 240px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        进入机房原因：
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddl_jryy" runat="server" Width="245px" CssClass="txt">
                                                            <asp:ListItem Selected="True" Value="0">新增</asp:ListItem>
                                                            <asp:ListItem Value="1">测试</asp:ListItem>
                                                            <asp:ListItem Value="2">存放</asp:ListItem>
                                                            <asp:ListItem Value="3">其他</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        从机房取出日期：
                                                    </td>
                                                    <td align="left">
                                                        <input id="qcsj" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                            onfocus="WdatePicker({isShowClear:false,readOnly:true})" 
                                                            style="width: 240px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        从机房取出原因：
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddl_qcyy" runat="server" Width="245px" CssClass="txt">
                                                            <asp:ListItem Value="0" Selected="True" >维修</asp:ListItem>
                                                            <asp:ListItem Value="1">淘汰</asp:ListItem>
                                                            <asp:ListItem Value="2">借出</asp:ListItem>
                                                            <asp:ListItem Value="3">其他</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        设备归还日期：
                                                    </td>
                                                    <td align="left">
                                                        <input id="ghsj" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                            onfocus="WdatePicker({isShowClear:false,readOnly:true})" 
                                                            style="width: 240px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        进机房设备确认：
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_jjfqr" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        出机房设备确认：
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_cjfqr" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        设备归还确认：
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_sbghqr" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" height="26">
                                                        <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
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
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
