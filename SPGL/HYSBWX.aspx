<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HYSBWX.aspx.cs" Inherits="Web_GZJL.SPGL.HYSBWX" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>视频设备维修申请</title>
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
                            <td style="width: 15px">
                            </td>
                            <td valign="top" align="left">
                                <br />
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                     <table id="Table2" cellspacing="0" cellpadding="0" border="0" width="60%">
                                            <tr align="center">
                                                <td>
                                                    <h2>
                                                        视频设备维修申请</h2>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                                            <table id="Table1" cellspacing="0" cellpadding="0" style="border: 1px solid #aaaaaa;">
                                                <tr>
                                                    <td  style="border-bottom: 1px solid #aaaaaa;">
                                                        <table border="0" cellpadding="3" cellspacing="0">
                                                            <tr style="height: 30px">
                                                                <td>
                                                                    资产名称：
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_zcmcSelct" runat="server" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    资产状态:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="DropDownList3" runat="server" Width="100px">
                                                                        <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                        <asp:ListItem Value="0">使用中</asp:ListItem>
                                                                        <asp:ListItem Value="1">报废</asp:ListItem>
                                                                        <asp:ListItem Value="2">停用</asp:ListItem>
                                                                        <asp:ListItem Value="3">维修</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
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
                                                            OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                                                            AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" PageSize="12">
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
                                                                    <ItemStyle HorizontalAlign="Left" Width="110px" />
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
                                                              <asp:TemplateField  Visible="false"  HeaderText="资产状态">
                                                                    <ItemStyle HorizontalAlign="Center" Width="70px" ForeColor="Green" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_zcztid" runat="server" Text='<%#Eval("zczt") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="资产状态">
                                                                    <ItemStyle HorizontalAlign="Center" Width="70px" ForeColor="Green" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_zczta" runat="server" Text='<%#Eval("zcztxs") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="详细参数">
                                                                    <ItemStyle HorizontalAlign="Left" Width="170px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_xxcs" runat="server" Text='<%#Eval("xiangqing") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="170px" CssClass="dl" />
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
                                                                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                            CssClass="a2" Text="操作"></asp:LinkButton>
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
                                                    <td align="center" style="height: 20px">
                                                        资产类别
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_zichanleibie" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        资产名称
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_zichanname" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        资产型号
                                                    </td>
                                                    <td align="left" style="position: relative">
                                                        <asp:Label ID="lbl_czxinghao" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        序列号
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_xuliehao" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        详细参数
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_xxcs" runat="server" Width="240px"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        资产备注
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_beizhu" runat="server" Width="240px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        供货商
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_gonghuoshang" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        供货商电话
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_gonghuosdinahua" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        采购依据
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_caigouyiju" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        采购形式
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_caigouxingshi" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        金额
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_czjine" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        设备负责人
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_sbfzr" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        购入时间
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_goururq" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        使用年限
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_shiyongnx" runat="server" onkeyup="this.value=this.value.replace(/\D/g,'')"
                                                            onafterpaste="this.value=this.value.replace(/\D/g,'')" Width="240px"></asp:TextBox><font
                                                                color="red">*</font>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        资产状态
                                                    </td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rbl" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="3" Selected="True">维修</asp:ListItem>
                                                            <asp:ListItem Value="1">报废</asp:ListItem>
                                                            <asp:ListItem Value="2">停用</asp:ListItem>
                                                            <asp:ListItem Value="0">正常</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td align="left">
                                                        申请日期
                                                    </td>
                                                    <td align="left">
                                                        <input id="txt_shenqingshijian" runat="server" class="Wdate" type="text" onfocus="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd'})"
                                                            style="width: 240px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        备注
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:TextBox ID="txt_xxcs" runat="server" Rows="5" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <font color="red">*</font>必填,请填写报废/停用/维修的原因
                                                    </td>
                                                </tr>
                                                <tr id="tr_sh" runat="server" visible="false">
                                                    <td align="center" style="height: 20px">
                                                        审核&nbsp;
                                                    </td>
                                                    <td align="left" colspan="3" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                                                        margin: 0px; padding-top: 0px" valign="middle">
                                                        <table align="center" cellpadding="3" cellspacing="0" width="100%">
                                                            <tr height="22">
                                                                <td align="left">
                                                                    审核结果：<b><asp:Label ID="lbl_shjg" runat="server" Text=""></asp:Label></b>
                                                                </td>
                                                                <td align="left">
                                                                    审核人：<b><asp:Label ID="lbl_shenheren" runat="server" Text=""></asp:Label></b>
                                                                </td>
                                                                <td align="left">
                                                                    审核日期：<b><asp:Label ID="lbl_shenheriqi" runat="server" Text=""></asp:Label></b>
                                                                </td>
                                                            </tr>
                                                            <tr style="border-top: 1px; border-top-color: #6c9ec1; border-bottom: 0px; border-left: 0px;
                                                                border-right: 0px; border-style: solid" height="22">
                                                                <td align="left"  colspan="3">
                                                                    审核意见：
                                                                    <b><asp:Label ID="lbl_shenheyijian" runat="server" Text="" Width="490px"></asp:Label></b>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" height="26">
                                                        <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                        <asp:Button ID="btn_save" runat="server" Text="保 存" CssClass="btn1" OnClick="btn_save_Click">
                                                        </asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_tj"
                                                            runat="server" Text="  提 交" CssClass="btn1" OnClick="btn_tj_Click"></asp:Button>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_QX" runat="server"
                                                            Text="返 回" CssClass="btn1" OnClick="btn_QX_Click"></asp:Button>
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                &nbsp;
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

