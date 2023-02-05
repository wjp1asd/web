<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SPHYSH.aspx.cs" Inherits="Web_GZJL.SPGL.SPHYSH" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会议测试及开会签字</title>
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
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                     <table cellspacing="0" cellpadding="0" border="0" width="60%">
                                            <tr align="center">
                                                <td>
                                                    <h2>
                                                        会议测试及开会签字</h2>
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
                                                                    会议名称：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSearch" runat="server" Width="240px"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;<asp:Button ID="btn_select" runat="server" CssClass="btn1" OnClick="btn_select_Click"
                                                                        Text="查 询" />
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                <td align="left">
                                                                    <asp:Button ID="btn_clear" runat="server" CssClass="btn1" OnClick="btn_clear_Click"
                                                                        Text="清 空" />
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
                                                                <asp:TemplateField HeaderText="会议名称">
                                                                    <ItemStyle HorizontalAlign="Left" Width="350px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblmeetName" runat="server" Text='<%#Bind("MeetName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="starTime" HeaderText="测试开始时间" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                                                    ApplyFormatInEditMode="True" HtmlEncode="False">
                                                                    <ItemStyle Width="120px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="overtime" HeaderText="测试结束时间" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                                                    ApplyFormatInEditMode="True" HtmlEncode="False">
                                                                    <ItemStyle Width="120px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="fostartime" HeaderText="会议开始时间" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                                                    ApplyFormatInEditMode="True" HtmlEncode="False">
                                                                    <ItemStyle Width="120px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="foovertime" HeaderText="会议结束时间" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                                                    ApplyFormatInEditMode="True" HtmlEncode="False">
                                                                    <ItemStyle Width="120px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                              
                                                                <asp:TemplateField Visible="false"  HeaderText="信息中心主任签字">
                                                                    <ItemStyle HorizontalAlign="center" Width="90px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldirector" runat="server" Text='<%#Bind("director") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="90px" HorizontalAlign="Center" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="签字" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                            CssClass="a2" Text="签字"></asp:LinkButton>
                                                                        <asp:Label ID="lblpishi" ForeColor=Green  Visible="false" runat="server" Text="已签字"></asp:Label>
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
                                            <table cellspacing="0" cellpadding="6" align="left"  border="1" style="border-collapse: collapse"
                                                bordercolor="#6c9ec1">
                                                <tr>
                                                    <td align="center" >
                                                        会议名称：
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lblname" runat="server" Text="" Width="400px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" >
                                                        编号
                                                    </td>
                                                    <td align="center">
                                                        内容
                                                    </td>
                                                    <td align="center">
                                                        结果
                                                    </td>
                                                    <td align="center">
                                                        备注
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center"colspan="4">
                                                        视频测试
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        1
                                                    </td>
                                                    <td align="left">
                                                        开机测试时间
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblstartime" runat="server" Text="" Width="200px"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td align="center">
                                                        测试备注
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" >
                                                        2
                                                    </td>
                                                    <td align="left">
                                                        本地音视频情况
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbllocation" runat="server" Text="" Width="200px"></asp:Label>
                                                    </td>
                                                    <td align="left" rowspan="6">
                                                        <asp:TextBox ID="txtRemarks" runat="server" Rows="10" TextMode="MultiLine" Width="179px"
                                                            Height="200px" BorderWidth="1px" BorderColor="#3399FF" ReadOnly="True" 
                                                            Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" >
                                                        3
                                                    </td>
                                                    <td align="left">
                                                        上下级音视频测试
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblhigher" runat="server" Text="" Width="200px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" >
                                                        4
                                                    </td>
                                                    <td align="left">
                                                        是否有发言
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbltalker" runat="server" Text="" Width="200px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" >
                                                        5
                                                    </td>
                                                    <td align="left">
                                                        会议室卫生情况
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblhealth" runat="server" Text="" Width="200px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" >
                                                        6
                                                    </td>
                                                    <td align="left">
                                                        测试完成时间
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblovertime" runat="server" Text="" Width="200px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" >
                                                        7
                                                    </td>
                                                    <td align="left">
                                                        故障现像和解决情况
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblwrong" runat="server" Text="" Width="200px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center"  colspan="4">
                                                        正式开会
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        1
                                                    </td>
                                                    <td align="left">
                                                        会议召开时间
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblfostartime" runat="server" Text="" Width="200px"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td align="center">
                                                        开会备注
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" >
                                                        2
                                                    </td>
                                                    <td align="left">
                                                        会场音视频情况
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblmeeting" runat="server" Text="" Width="200px"></asp:Label>
                                                    </td>
                                                    <td align="left" rowspan="6">
                                                        <asp:TextBox ID="txtfoRemarks" runat="server" Rows="10" TextMode="MultiLine" Width="177px"
                                                            Height="200px" BorderWidth="1px" BorderColor="#3399FF" ReadOnly="True" 
                                                            Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        3
                                                    </td>
                                                    <td align="left">
                                                        参会单位
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbluint" runat="server" Text="" Width="200px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" >
                                                        4
                                                    </td>
                                                    <td align="left">
                                                        各县开会情况
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblcounty" runat="server" Text="" Width="200px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" >
                                                        5
                                                    </td>
                                                    <td align="left">
                                                        会议结束时间
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblfoovertime" runat="server" Text="" Width="200px"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" >
                                                        6
                                                    </td>
                                                    <td align="left">
                                                        关闭设备
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblcolse" runat="server" Text="" Width="200px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" >
                                                        7
                                                    </td>
                                                    <td align="left">
                                                        故障现像和解决情况
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblfowrong" runat="server" Text="" Width="200px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" >
                                                        8
                                                    </td>
                                                    <td align="left">
                                                        主任签字及意见：
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:TextBox ID="txtComments" runat="server" Height="90px" TextMode="MultiLine" Width="408px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="qianzi" runat="server"  visible="false">
                                                <td align="center">
                                                        9
                                                    </td>
                                                    <td >
                                                        信息中心主任签字
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:Label ID="lbldirector" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" height="26">
                                                        <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                        <asp:Button ID="btn_NO" runat="server" ToolTip="不同意驳回" Text="驳 回" CssClass="btn1"
                                                            OnClick="btn_NO_Click" Visible="false"></asp:Button>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:Button
                                                                ID="btn_Save" runat="server" Text="确 认" CssClass="btn1" OnClick="btn_Save_Click">
                                                            </asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btn_QX" runat="server" CssClass="btn1" OnClick="btn_QX_Click" Text="返 回" />
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
