<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JFWHJL.aspx.cs" Inherits="Web_GZJL.JFGL.JFWHJL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>机房维护记录</title>
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
                            <td style="width: 30px">
                            </td>
                            <td valign="top" align="left">
                                <br />
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/JFGL/JFWHJL.aspx"><font color="red">设备维护</font></asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/JFGL/JFWXJL.aspx"><font color="red">设备维修</font></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10px">
                            </td>
                            <td valign="top" align="left">
                                <hr />
                                <br />
                                <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="500">
                                </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table id="Table2" cellspacing="0" cellpadding="0" border="0" width="50%">
                                            <tr align="center">
                                                <td>
                                                    <h2>
                                                        设备维护表</h2>
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
                                                                    日期：
                                                                </td>
                                                                <td>
                                                                    <input id="startTime" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                                        onfocus="WdatePicker({isShowClear:true,readOnly:true})" />
                                                                </td>
                                                                <td align="left">
                                                                    至
                                                                </td>
                                                                <td align="left">
                                                                    <input id="endTime" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                                        onfocus="WdatePicker({isShowClear:true,readOnly:true})" />
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
                                                            CellPadding="0" CellSpacing="1" CssClass="quanbu" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                            OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                                                            AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" PageSize="10">
                                                            <Columns>
                                                                <asp:BoundField DataField="whrq" HeaderText="日期" ApplyFormatInEditMode="True" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle Width="120px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="维护设备名称">
                                                                    <ItemStyle HorizontalAlign="Left" Width="160px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl2" runat="server" Text='<%#Bind("sbmc") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="负责检测单位">
                                                                    <ItemStyle HorizontalAlign="Left" Width="160px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl3" runat="server" Text='<%#Bind("jcdw") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="检测人员">
                                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl4" runat="server" Text='<%#Bind("lfname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="陪同人员">
                                                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_pjlx" runat="server" Text='<%#Bind("whptry") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                            CssClass="a2" Text="<div>编辑</div>"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="dl" HorizontalAlign="Center" Width="50px" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="删除" ShowHeader="False" Visible="false">
                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                    <HeaderStyle CssClass="dl" HorizontalAlign="Center" Width="50px" />
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
                                                    <td align="left">
                                                        日期：
                                                    </td>
                                                    <td align="left">
                                                        <input id="rq" runat="server" type="text" readonly="readonly"
                                                            style="width: 240px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        维护设备名称：
                                                    </td>
                                                    <td align="left">
                                                        <%--<asp:TextBox ID="txt_sbmc" runat="server" Width="240px"></asp:TextBox>--%>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txt_sbmc" runat="server" AutoPostBack="True" Width="240px"></asp:TextBox>
                                                                            <asp:TextBox ID="txt_sbmcid" runat="server" BackColor="Transparent" BorderStyle="None"
                                                                                ForeColor="transparent" Width="0"></asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td>
                                                                    <font face="宋体">
                                                                        <img id="Img1" alt="请选择" onclick="Picker.show('../SELECT/Selzcsb.aspx',txt_sbmc,txt_sbmcid,'','','340','440');"
                                                                            src="../img/lookup.gif" />
                                                                        &nbsp;<a id="history" href="#" onclick="history()" runat="server" class="a2">历史记录</a>
                                                                        
                                                                        <%--<img id="Img2" alt="请选择" onclick="" src="../img/lookup.gif" />--%>
                                                                    </font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        负责检测单位：
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_jcdw" runat="server" Width="240px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        检测人员：
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddl_jcry" runat="server" Width="240px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        陪同人员
                                                    </td>
                                                    <td align="left">
                                                        <%--<asp:TextBox ID="txt_whptry" runat="server" Width="240px"></asp:TextBox>--%>
                                                        <asp:DropDownList ID="ddl_ptry" runat="server" Height="20px" Width="138px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2" height="30px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <table cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                        CellPadding="2" CellSpacing="1" OnRowCancelingEdit="GridView2_RowCancelingEdit"
                                                                        OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" CssClass="quanbu"
                                                                        OnRowDeleting="GridView2_RowDeleting">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="检测项目">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txt_mc" runat="server" Text='<%# Bind("jcxm") %>' Width="102px"
                                                                                        MaxLength="30" Height="20px"></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="110px" />
                                                                                <HeaderStyle HorizontalAlign="Center" Width="110px" CssClass="dl" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_bh" runat="server" Text='<%# Bind("jcxm") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="检测结果">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txt_jiancejieguo" runat="server" Text='<%# Bind("jcjg") %>' Width="240px"
                                                                                        MaxLength="120" Height="20px"></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                                                <HeaderStyle HorizontalAlign="Center" Width="250px" CssClass="dl" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("jcjg") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                                                                                <EditItemTemplate>
                                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                                                        Text="更新" ToolTip="更新"></asp:LinkButton>
                                                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                        Text="取消" ToolTip="取消编辑"></asp:LinkButton>
                                                                                </EditItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                                <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
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
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr height="2px">
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txt_jcxm" runat="server" Width="110px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 2px">
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txt_jcjg" runat="server" Width="250px"></asp:TextBox>
                                                                            </td>
                                                                            <td align="center" width="58px">
                                                                                <asp:LinkButton ID="but_add" CssClass="a2" runat="server" ToolTip="添加信息" OnClick="but_add_Click">添加</asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2" height="30px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        相关建议：
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_yijian" runat="server" Rows="4" TextMode="MultiLine" Width="360px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" height="26">
                                                        <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                        <asp:Button ID="btn_save" runat="server" CssClass="btn1" OnClick="btn_save_Click"
                                                            Text="保 存" />
                                                        &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="btn_QX" runat="server" CssClass="btn1"
                                                            OnClick="btn_QX_Click" Text="返 回" />
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
