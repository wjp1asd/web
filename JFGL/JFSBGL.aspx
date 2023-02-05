<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JFSBGL.aspx.cs" Inherits="Web_GZJL.JFGL.JFSBGL" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>机房设备管理</title>
    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

    <script language="javascript">
        var Picker = new PickerControl();   
        function history()
        { 
           var str=document.getElementById("txt_sbmcid").value;
           if(str=="" || str==" ")
           {
                alert("请先选择设备");
           }
           else
           {
                Picker.show('../SELECT/SelSBHistory.aspx?id='+str,'','','','','690','440');
           }
        } 
    </script>

    <style type="text/css">
        .style1
        {
            height: 50px;
        }
        .style2
        {
            height: 26px;
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
                                                        机房设备管理表</h2>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                                            <table id="Table1" cellspacing="0" cellpadding="0" style="border: 1px solid #aaaaaa;">
                                                <tr>
                                                    <td style="border-bottom: 1px solid #aaaaaa;">
                                                        <table border="0" cellpadding="3" cellspacing="0">
                                                            <tr>
                                                                <td align="left">
                                                                    设备名称：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtshebeiming" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                                <td>
                                                                    设备型号：
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtshebeixing" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                <td align="left">
                                                                    <asp:Button ID="btn_select" runat="server" CssClass="btn1" Text="查 询" OnClick="btn_select_Click" />
                                                                </td>
                                                                <td align="left" style="height: 17px">
                                                                    <asp:Button ID="btn_add" runat="server" Text="添 加" OnClick="btn_add_Click" CssClass="btn1">
                                                                    </asp:Button>
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
                                                    <td align="right" style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="2" CellSpacing="1" CssClass="quanbu" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                            OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                                                            AllowPaging="True" PageSize="12">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="设备型号">
                                                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_sbxh" runat="server" Text='<%#Bind("sbxh") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="设备名称">
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_sbmc" runat="server" Text='<%#Bind("sbmc") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="使用处室">
                                                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_sycs" runat="server" Text='<%#Bind("sycs") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IP地址">
                                                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_ip" runat="server" Text='<%#Bind("ip") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="业务系统">
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_yyyw" runat="server" Text='<%#Bind("yyyw") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="gmsj" HeaderText="购买时间" ApplyFormatInEditMode="True" DataFormatString="{0:yyyy-MM-dd}"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="70px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="使用年限">
                                                                    <ItemStyle HorizontalAlign="Center" Width="64px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="synx" runat="server" Text='<%#Bind("synx") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="64px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="供应商电话">
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_lxdh" runat="server" Text='<%#Bind("lxdh") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="lxuser" HeaderText="联系人" ApplyFormatInEditMode="True"
                                                                    DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False">
                                                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="60px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                            CssClass="a2" Text="编辑"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="dl" HorizontalAlign="Center" Width="50px" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="删除" ShowHeader="False" Visible="false">
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
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
                                            <br />
                                            <table cellspacing="0" cellpadding="8" align="left" border="1" style="border-collapse: collapse"
                                                bordercolor="#6c9ec1">
                                                <tr>
                                                    </td>
                                                    <td align="left" rowspan="2">
                                                        设备名称：
                                                    </td>
                                                    <td align="left" rowspan="2">
                                                        <%--<asp:TextBox ID="txt_sbmc" runat="server" Width="240px"></asp:TextBox>--%>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txt_sbmc" runat="server" AutoPostBack="True" Width="240px" 
                                                                                ontextchanged="txt_sbmc_TextChanged"></asp:TextBox>
                                                                            <asp:TextBox ID="txt_sbmcid" runat="server" BackColor="Transparent" BorderStyle="None"
                                                                                ForeColor="transparent" Width="0"></asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td>
                                                                    <font face="宋体">
                                                                        <img id="Img1" alt="请选择" onclick="Picker.show('../SELECT/Selzcsb.aspx',txt_sbmc,txt_sbmcid,txt_gmrq,txt_xxcs,'340','440');"
                                                                            src="../img/lookup.gif" />&nbsp;<a id="history" href="#" onclick="history()" runat="server" class="a2">历史记录</a>
                                                                    </font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="left">
                                                        使用处室：
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_sycs" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        IP地址：
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_IP" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" rowspan="2">
                                                        业务系统：
                                                    </td>
                                                    <td align="left" rowspan="2">
                                                        <asp:TextBox ID="txt_ywxt" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        购买时间：
                                                    </td>
                                                    <td align="left">
                                                        <%--<input id="txt_gmrq" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                            onfocus="WdatePicker({isShowClear:false,readOnly:true})" style="width: 240px" />--%>
                                                            
                                                           
                                                            
                                                        <asp:TextBox ID="txt_gmrq" runat="server" Width="240px" ReadOnly="true"></asp:TextBox>
                                                            
                                                           
                                                            
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        使用年限：
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_synx" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr height="20">
                                                    <td align="left" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr height="150">
                                                    <td align="left">
                                                        设备参数：
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <table cellspacing="0" cellpadding="8" border="0" style="border-collapse: collapse"
                                                            bordercolor="#6c9ec1">
                                                            <tr>
                                                                <td>
                                                                    设备型号：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_sbxh" runat="server" Width="485px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    系统版本：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_xtbb" runat="server" Width="485px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    详细参数：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_xxcs" runat="server" Width="485px" Rows="4" TextMode="MultiLine"
                                                                        BorderColor="#336D93" BorderWidth="1px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr height="20">
                                                    <td align="left" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr height="150">
                                                    <td align="left">
                                                        供应商<br />
                                                        联系方式：
                                                    </td>
                                                    <td align="left" class="style2" colspan="3">
                                                        <table cellspacing="0" cellpadding="8" border="0" style="border-collapse: collapse"
                                                            bordercolor="#6c9ec1">
                                                            <tr>
                                                                <td>
                                                                    供应商：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_gys" runat="server" Width="485px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    联系电话：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_lxdh" runat="server" Width="485px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    联系人：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_lxr" runat="server" Width="485px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    技术支持：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_jszc" runat="server" Width="485px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" height="26">
                                                        <asp:Button ID="btn_save" runat="server" Text="保 存" CssClass="btn1" OnClick="btn_save_Click">
                                                        </asp:Button>&nbsp;
                                                        <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                        &nbsp;&nbsp; &nbsp;<asp:Button ID="btn_QX" runat="server" Text="返 回" CssClass="btn1"
                                                            OnClick="btn_QX_Click"></asp:Button>
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
