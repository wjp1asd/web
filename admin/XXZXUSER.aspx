<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XXZXUSER.aspx.cs" Inherits="Web_GZJL.admin.XXZXUSER" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server" >
  
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
                                <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="500">
                                </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table cellspacing="0" cellpadding="0" border="0" width="40%">
                                            <tr align="center">
                                                <td>
                                                    <h2>
                                                        信息中心人员情况表</h2>
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
                                                                    <asp:Label ID="lbl_xuanze" runat="server" Text="选择县区："></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                    <asp:Button ID="btn_add0" runat="server" CssClass="btn1" OnClick="btn_add_Click" Text="添 加" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Button ID="btn_select" runat="server" CssClass="btn1" Text="查 询" OnClick="btn_select_Click" />
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Button ID="btn_dacu" runat="server" CssClass="btn1" Text="导出" OnClick="da"  />
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
                                                        <asp:GridView ID="gv_ryxx" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                                            BorderWidth="0px" CellPadding="2" CellSpacing="1" ShowHeader="False" OnRowDataBound="gv_ryxx_RowDataBound"
                                                            AllowPaging="True" OnSelectedIndexChanging="gv_ryxx_SelectedIndexChanging">
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
                                                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                                                                        BorderWidth="0px" CellPadding="2" CellSpacing="1" OnRowDataBound="GridView1_RowDataBound">
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
                                                                                                <ItemStyle Width="90px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                                    BorderWidth="1px" />
                                                                                                <HeaderStyle Width="90px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                                    BorderWidth="1px" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="bangongdh" HeaderText="办公电话">
                                                                                                <ItemStyle Width="90px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                                    BorderWidth="1px" />
                                                                                                <HeaderStyle Width="90px" HorizontalAlign="Center" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                                                    BorderWidth="1px" />
                                                                                            </asp:BoundField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="410px" BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" />
                                                                    <ItemStyle Width="410px" BorderColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                            CssClass="a2" Text="<div>编辑</div>"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="dl" HorizontalAlign="Center" Width="50px" BorderColor="#FFFFFF"
                                                                        BorderStyle="Solid" BorderWidth="1px" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" BorderColor="#FFFFFF" BorderStyle="Solid"
                                                                        BorderWidth="1px" />
                                                                </asp:TemplateField>
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
                                                    <td>
                                                        详细地址
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_czjdz" runat="server" Width="400px">--这里填写财政局详细地址--</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        人员信息
                                                    </td>
                                                    <td>
                                                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="2" CellSpacing="1" CssClass="quanbu" OnRowCancelingEdit="GridView3_RowCancelingEdit"
                                                            OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating" OnRowDeleting="GridView3_RowDeleting"
                                                            OnRowDataBound="GridView3_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="职务">
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="DropDownList2" runat="server" Width="135px">
                                                                            <asp:ListItem Text="局长" Value="局长"></asp:ListItem>
                                                                            <asp:ListItem Text="主管局长" Value="主管局长"></asp:ListItem>
                                                                            <asp:ListItem Text="信息中心主任" Value="信息中心主任"></asp:ListItem>
                                                                            <asp:ListItem Text="科员" Value="科员"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:Label ID="lblZhiWu" runat="server" Text='<%# Eval("usrzhiwu") %>' Visible="False"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="140px" CssClass="dl" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_usrzhiwu" runat="server" Text='<%# Bind("usrzhiwu") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="姓名">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txt_usrname" runat="server" Text='<%# Bind("usrname") %>' Width="80px"
                                                                            Height="20px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="90px" CssClass="dl" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_usrname" runat="server" Text='<%# Bind("usrname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="手机号码">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txt_shouji" runat="server" Text='<%# Bind("shouji") %>' Width="90px"
                                                                            Height="20px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="90px" CssClass="dl" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_shouji" runat="server" Text='<%# Bind("shouji") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="办公电话">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txt_bangongdh" runat="server" Text='<%# Bind("bangongdh") %>' Width="90px"
                                                                            Height="20px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="90px" CssClass="dl" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_bangongdh" runat="server" Text='<%# Bind("bangongdh") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="照片" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="150px" />
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="dl" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_zhaopian" runat="server" Text='<%# Bind("zhaopian") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="linkbgengxin" runat="server" CausesValidation="True" CommandName="Update"
                                                                            Text="更新" ToolTip="更新"></asp:LinkButton>
                                                                        <asp:LinkButton ID="linkbqx" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                            Text="取消" ToolTip="取消编辑"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="dl" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                            Text="编辑" ToolTip="编辑信息"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="删除">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete"
                                                                            CssClass="a2" Text="删除" OnClientClick=" return confirm('确认删除吗')"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle CssClass="dan" />
                                                            <HeaderStyle CssClass="biaoti" />
                                                            <AlternatingRowStyle CssClass="suang" />
                                                            <PagerStyle CssClass="biaoti" />
                                                        </asp:GridView>
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr height="1px">
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddl_zhiwu" runat="server" Width="144px">
                                                                        <asp:ListItem Text="***请选择职务***" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="局长" Value="局长"></asp:ListItem>
                                                                        <asp:ListItem Text="主管局长" Value="主管局长"></asp:ListItem>
                                                                        <asp:ListItem Text="信息中心主任" Value="信息中心主任"></asp:ListItem>
                                                                        <asp:ListItem Text="科员" Value="科员"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td width="1px">
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_Uname" runat="server" Width="91px"></asp:TextBox>
                                                                </td>
                                                                <td width="1px">
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_shouji" runat="server" onkeyup="this.value=this.value.replace(/\D/g,'')"
                                                                        onafterpaste="this.value=this.value.replace(/\D/g,'')" Width="91px"></asp:TextBox>
                                                                </td>
                                                                <td width="1px">
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_zuoji" runat="server" onkeyup="this.value=this.value.replace(/\D/g,'')"
                                                                        onafterpaste="this.value=this.value.replace(/\D/g,'')" Width="90px"></asp:TextBox>
                                                                </td>
                                                                <td width="1px">
                                                                </td>
                                                                <td align="left" visible="false" runat="server">
                                                                    <asp:FileUpload ID="FileUpload2" runat="server" Width="150px" />
                                                                </td>
                                                                <td align="center" width="60px">
                                                                    <asp:LinkButton ID="but_addaa" CssClass="a2" runat="server" ToolTip="添加信息" OnClick="but_addaa_Click">添加</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" height="26">
                                                        &nbsp;&nbsp;
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
