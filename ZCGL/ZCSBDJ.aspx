<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZCSBDJ.aspx.cs" Inherits="Web_GZJL.ZCGL.ZCSBDJ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="NumericC" Namespace="NumericC" TagPrefix="cc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>资产设备登记</title>
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
                                        <table cellspacing="0" cellpadding="0" border="0" width="50%">
                                            <tr align="center">
                                                <td>
                                                    <h2>
                                                        资产登记表</h2>
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
                                                                    资产类别：
                                                                </td>
                                                                <td>
                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                                                    <ContentTemplate>
                                                                                        <asp:TextBox ID="txt_name" runat="server" Width="180px" AutoPostBack="True"></asp:TextBox><asp:TextBox
                                                                                            ID="txt_nameid" runat="server" BackColor="Transparent" BorderStyle="None" ForeColor="transparent"
                                                                                            Width="0"></asp:TextBox></ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                            <td>
                                                                                <font face="宋体">
                                                                                    <img id="Img1" alt="请选择" onclick="Picker.show('../SELECT/SelLwdw.aspx',txt_name,txt_nameid,'','','380','410');"
                                                                                        src="../img/lookup.gif" />
                                                                                </font>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                                <td>
                                                                    资产名称：
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_zcmcSelct" runat="server" Width="180px"></asp:TextBox>
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
                                                            OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                                                            AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" PageSize="12">
                                                            <Columns>
                                                                <asp:BoundField DataField="czmc" HeaderText="资产名称">
                                                                    <ItemStyle Width="140px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="140px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="grsj" HeaderText="购入时间" ApplyFormatInEditMode="True" DataFormatString="{0:yyyy-MM-dd}"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="70px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="czlb" HeaderText="资产类别">
                                                                    <ItemStyle Width="90px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="90px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="xinghao" HeaderText="资产型号">
                                                                    <ItemStyle Width="90px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="90px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="zcid" HeaderText="序列号">
                                                                    <ItemStyle Width="110px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="110px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="金额（元）">
                                                                    <ItemStyle HorizontalAlign="Right" Width="110px" />
                                                                    <ItemTemplate>
                                                                        <b>
                                                                            <asp:Label ID="lbl_je" runat="server" Text='<%#Eval("jiage","￥{0:N2}") %>'></asp:Label></b>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="110px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="详细参数">
                                                                    <ItemStyle HorizontalAlign="Left" Width="190px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_xxcs" runat="server" Text='<%#Eval("xxcs") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="190px" CssClass="dl" />
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
                                                            <RowStyle CssClass="dan" />
                                                            <HeaderStyle CssClass="biaoti" />
                                                            <AlternatingRowStyle CssClass="suang" />
                                                            <PagerStyle CssClass="biaoti" HorizontalAlign="Left" />
                                                            <FooterStyle CssClass="biaoti" />
                                                        </asp:GridView>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="middle">
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
                                                    <td align="center" style="height: 20px">
                                                        采购依据
                                                    </td>
                                                    <td align="left">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txt_cgyj" runat="server" Width="220px" AutoPostBack="True"></asp:TextBox><asp:TextBox
                                                                                ID="txt_cgyjid" runat="server" BackColor="Transparent" BorderStyle="None" ForeColor="transparent"
                                                                                Width="0"></asp:TextBox></ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td>
                                                                    <font face="宋体">
                                                                        <img id="Img2" alt="请选择" onclick="Picker.show('../SELECT/cgyj.aspx',txt_cgyj,txt_cgyjid,'','','340','380');"
                                                                            src="../img/lookup.gif" />
                                                                    </font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="left">
                                                        采购形式
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddl_cgxs" runat="server" Width="240px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        中标价格
                                                    </td>
                                                    <td align="left">
                                                        <cc1:NumberBox ID="num_code" runat="server" MinAmount="0" Width="240px">0.00</cc1:NumberBox>
                                                    </td>
                                                    <td align="left">
                                                        付款方式
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddl_fkfs" runat="server" Width="240px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        供货商
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_gys" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        供货商电话
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_gysdianhua" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        资产名称
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_zcmc" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        购入时间
                                                    </td>
                                                    <td align="left">
                                                        <input id="txt_grrq" runat="server" class="Wdate" onclick="WdatePicker()" onfocus="WdatePicker({isShowClear:false,readOnly:true})"
                                                            style="width: 240px" type="text" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        资产类别
                                                    </td>
                                                    <td align="left" style="position: relative">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txt_czlb" runat="server" Width="220px" AutoPostBack="True"></asp:TextBox><asp:TextBox
                                                                                ID="txt_czlbid" runat="server" BackColor="Transparent" BorderStyle="None" ForeColor="transparent"
                                                                                Width="0"></asp:TextBox></ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td>
                                                                    <font face="宋体">
                                                                        <img id="Img5" alt="请选择" onclick="Picker.show('../SELECT/SelLwdw.aspx',txt_czlb,txt_czlbid,'','','380','410');"
                                                                            src="../img/lookup.gif" />
                                                                    </font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="left">
                                                        序列号
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_xuliehao" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        资产型号
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_xinghao" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        设备负责人
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_sbfzr" runat="server" Width="240px"></asp:TextBox>
                                                        <font color="red">*</font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        详细参数
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:TextBox ID="txt_xxcs" runat="server" Width="300px" Rows="5" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        详细参数填写设备的详细参数<br />
                                                        如CPU型号个数，硬盘大小，内存大小<br />
                                                        安装的操作系统等参数
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        备注
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:TextBox ID="txt_beizhu" runat="server" Rows="5" TextMode="MultiLine" Width="600px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" height="26">
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
