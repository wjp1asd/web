<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSZCDJ_C.aspx.cs" Inherits="Web_GZJL.Select.JSZCDJ_C" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>技术支持内容登记查询</title>
    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

    <script language="javascript">
        var Picker = new PickerControl();    
    </script>

    <style type="text/css">
        .style1
        {
            width: 184px;
        }
        .style2
        {
            width: 204px;
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
                                <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
                                    <ContentTemplate>
                                    <table id="Table2" cellspacing="0" cellpadding="0" border="0" width="60%">
                                            <tr align="center" style="height: 40px">
                                                <td>
                                                    <h2>
                                                        技术支持内容登记表</h2>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                                            <table id="Table1" cellspacing="0" cellpadding="0"  style="border: 1px solid #aaaaaa;">
                                                <tr>
                                                    <td  style="border-bottom: 1px solid #aaaaaa;">
                                                        <table border="0" cellpadding="3" cellspacing="0">
                                                            <tr>
                                                                <td align="left">
                                                                    软件名称：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_rjmingcheng" runat="server" Width="140px"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                                <td>
                                                                    问题分类：
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_wentifenlei" runat="server" Width="140px"></asp:TextBox>
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
                                                            CellPadding="2" CellSpacing="1" CssClass="quanbu"  
                                                              OnPageIndexChanging="GridView1_PageIndexChanging" 
                                                              OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                                                            OnRowDataBound="GridView1_RowDataBound" PageSize="12" AllowPaging="True">
                                                            <Columns>
                                                           <asp:BoundField DataField="bianhao" HeaderText="编号">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="tbrq" HeaderText="填表日期" ApplyFormatInEditMode="True" DataFormatString="{0:yyyy-MM-dd}"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="软件名称">
                                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl1" runat="server" Text='<%#Bind("rjmca") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="资讯人">
                                                                    <ItemStyle HorizontalAlign="Left" Width="65px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl2" runat="server" Text='<%#Bind("zxr") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="65px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="所属部门">
                                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl3" runat="server" Text='<%#Bind("zxrbm") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="联系方式">
                                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl4" runat="server" Text='<%#Bind("lxfs") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="问题描述">
                                                                    <ItemStyle HorizontalAlign="Left" Width="240px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl5" runat="server" ToolTip='<%#Bind("wtms") %>' Text='<%#Bind("wtms") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="240px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="问题解答">
                                                                    <ItemStyle HorizontalAlign="Left" Width="240px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl6" runat="server" ToolTip='<%#Bind("wtjd") %>' Text='<%#Bind("wtjd") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="240px" CssClass="dl" />
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
                                                            <PagerSettings Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
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
                                            <table cellspacing="0" cellpadding="8" align="left"  border="1" style="border-collapse: collapse" bordercolor="#6c9ec1">
                                                <tr>
                                                    <td align="center" >
                                                        编号  
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <asp:Label ID="lbl_bianhao" runat="server" Text="lbl_bianhao"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        填表日期
                                                    </td>
                                                    <td align="left" class="style2">
                                                        <asp:Label ID="lbl_tianbiaorq" runat="server" Text="lbl_tianbiaorq"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        软件名称
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lbl_rjmc" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        登记人
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <asp:Label ID="lbl_dengjiren" runat="server" Text="lbl_dengjiren"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        登记时间
                                                    </td>
                                                    <td align="left" class="style2">
                                                        &nbsp;<asp:Label ID="lbl_dengjishijian" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        咨询人
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <asp:Label ID="lbl_zxr" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        联系方式
                                                    </td>
                                                    <td align="left" class="style2">
                                                        <asp:Label ID="lbl_lxfs" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        咨询人所<br />
                                                        在部门
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <asp:Label ID="lbl_zxrbm" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        解答时间
                                                    </td>
                                                    <td align="left" class="style2">
                                                        &nbsp;<asp:Label ID="lbl_jdsj" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        问题分类
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lbl_wtfl" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        问题内容<br />
                                                        描 述
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lbl_wtms" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        问题解答
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lbl_wtjd" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        备注
                                                    </td>
                                                    <td align="left" colspan="3" style="width:80">
                                                        <asp:Label ID="lbl_beizhu" runat="server"></asp:Label>
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" height="36">
                                     
                                               <asp:Button ID="btn_bohui" runat="server" Text="返 回" CssClass="btn1" OnClick="btn_bohui_Click" 
                                                            Visible="False"></asp:Button>  
                                                        <asp:Button ID="btn_QX" runat="server" CssClass="btn1" OnClick="btn_QX_Click" 
                                                            Text="返 回" Visible="False" />
                                                        <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                        <input class="btn1" runat="server" id="btfh" CssClass="btn1" onclick="javascript:window.history.go(-1);" 
                                                            type="button" value="返回" />&nbsp;&nbsp;<asp:Button ID="btn_word" runat="server" Text="生成Word打印" CssClass="btn2" 
                                                            onclick="btn_word_Click"></asp:Button>
                                                            &nbsp;</td>
                                                </tr>
                                            </table>
                                            <br />
                                        </asp:Panel>
                                    </ContentTemplate>
                                <%--</asp:UpdatePanel>--%>
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
