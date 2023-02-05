<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JFWXCX.aspx.cs" Inherits="Web_GZJL.JFGL.JFWXCX" %>

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
        function history2()
        { 
           var str=document.getElementById("txt_sbmcid2").value;
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
                                            当前位置：<a href="../Main.aspx">首页</a>&gt;<span style="color: #1F65AE"><%=t1 %>机房出入申请</span>&gt;<span style="color: #1F65AE"><%=t0 %></span>
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
                                <asp:LinkButton ID="LinkButton1" runat="server"   onclick="LinkButton1_Click"><font color="red">设备维护查询</font></asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" runat="server"   onclick="LinkButton2_Click"><font color="red">设备维修查询</font></asp:LinkButton>
                                </td></tr>
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
                                    <table id="Table3" cellspacing="0" cellpadding="0" border="0" width="40%">
                                            <tr align="center">
                                                <td>
                                                    <h2 id="title" runat="server">
                                                        设备维护查询</h2>
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
                                                                    设备名称:</td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtsbmc1" runat="server"></asp:TextBox>
                                                                    &nbsp;
                                                                </td>
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
                                                    <td align="right" style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="0" CellSpacing="1" CssClass="quanbu" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                            OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                                                            AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" PageSize="10">
                                                            <Columns>
                                                                <asp:BoundField DataField="whrq" HeaderText="日期" ApplyFormatInEditMode="True" DataFormatString="{0:yyyy-MM-dd}"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="维修设备名称">
                                                                    <ItemStyle HorizontalAlign="Left" Width="160px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl2" runat="server" Text='<%#Bind("sbmc") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="负责维修单位">
                                                                    <ItemStyle HorizontalAlign="Left" Width="160px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl3" runat="server" Text='<%#Bind("jcdw") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="维修人员">
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
                                                            <%--<SelectedRowStyle BackColor="LavenderBlush" />--%>
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
                                                    
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
                                            <br />
                                            <table cellspacing="0" cellpadding="8" align="left" border="1"   style="border-collapse: collapse" bordercolor="#6c9ec1">
                                                <tr>
                                                    <td   align="left">
                                                        日期：
                                                    </td>
                                                    <td align="left">
                                                      
                                                        <asp:Label ID="lbl_rq" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        维修设备名称：
                                                    </td>
                                                    <td align="left">
                                                        
                                                        <asp:Label ID="lbl_sbmc" runat="server" Text="" Width="240px"></asp:Label>
                                                        <asp:TextBox ID="txt_sbmcid" runat="server" BackColor="Transparent" BorderStyle="None"
                                                                                ForeColor="transparent" Width="0"></asp:TextBox>
                                                        &nbsp;<a ID="history" runat="server" class="a2" href="#" onclick="history()">历史记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        负责维修单位：
                                                    </td>
                                                    <td align="left">
                                                        
                                                        <asp:Label ID="lbl_wxdw" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        维修人员：
                                                    </td>
                                                    <td align="left">
                                                        
                                                    <asp:Label ID="lbl_wxry" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        陪同人员
                                                    </td>
                                                    <td align="left">
                                                       <asp:Label ID="lbl_ptry" runat="server" Text="" Width="240px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2" height="30px">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <table cellpadding="0" cellspacing="0"  style="border-collapse: collapse">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                        CellPadding="2" CellSpacing="1" 
                                                                        CssClass="quanbu" >
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="维修项目">
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
                                                                            <asp:TemplateField HeaderText="维修结果">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txt_jiancejieguo" runat="server" Text='<%# Bind("jcjg") %>' Width="240px"
                                                                                        MaxLength="120" Height="20px"></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="360px" />
                                                                                <HeaderStyle HorizontalAlign="Center" Width="360px" CssClass="dl" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("jcjg") %>'></asp:Label>
                                                                                </ItemTemplate>
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
                                                    <td align="center">
                                                        备    注： 
                                                    </td>
                                                    <td align="left">
                                                     <asp:Label ID="lbl_beizhu" runat="server" Text="" Width="360px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr  >
                                                    <td align="center" colspan="2" height="26" >
                                                        <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                       <asp:Button ID="btn_QX" runat="server" CssClass="btn1" 
                                                            OnClick="btn_QX_Click" Text="返 回" />
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        
                                         
                                    </ContentTemplate>
                                </asp:UpdatePanel>
            
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                       <asp:Panel ID="Panel3" runat="server" Width="100%" Visible="false">
                                            <table id="Table2" cellspacing="0" cellpadding="0"  style="border: 1px solid #aaaaaa;">
                                                <tr>
                                                    <td style="border-bottom: 1px solid #aaaaaa;">
                                                        <table border="0" cellpadding="3" cellspacing="0">
                                                            <tr>
                                                            <td align="left">
                                                                    设备名称:</td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtsbmc2" runat="server"></asp:TextBox>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    日期：
                                                                </td>
                                                                <td>
                                                                      <input id="startTime2" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                                        onfocus="WdatePicker({isShowClear:true,readOnly:true})" />
                                                                </td>
                                                                <td align="left">
                                                                    至
                                                                </td>
                                                                <td align="left">
                                                                    <input id="endTime2" runat="server" class="Wdate" type="text" onclick="WdatePicker()"
                                                                        onfocus="WdatePicker({isShowClear:ture,readOnly:true})" />
                                                                </td>
                                                                    <td align="left">
                                                                        <asp:Button ID="but_chaxun" runat="server" CssClass="btn1" Text="查 询" 
                                                                            onclick="but_chaxun_Click"  />
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
                                                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="0" CellSpacing="1" CssClass="quanbu" OnPageIndexChanging="GridView3_PageIndexChanging"
                                                             OnSelectedIndexChanging="GridView3_SelectedIndexChanging"
                                                            AllowPaging="True" OnRowDataBound="GridView3_RowDataBound" PageSize="10">
                                                            <Columns>
                                                                <asp:BoundField DataField="whrq" HeaderText="日期" ApplyFormatInEditMode="True" DataFormatString="{0:yyyy-MM-dd}"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
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
                                                                            CssClass="a2" Text="<div>查看</div>"></asp:LinkButton>
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
                                                            <%--<SelectedRowStyle BackColor="LavenderBlush" />--%>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="middle">
                                                        <br />
                                                        <b><font color="red">总记录数：
                                                            <asp:Label ID="lbl_heji2" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;条</font></b>
                                                        
                                                     
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel4" runat="server" Visible="False" Width="100%">
                                            <br />
                                            <table cellspacing="0" cellpadding="8" align="left" border="1"   style="border-collapse: collapse" bordercolor="#6c9ec1">
                                                <tr>
                                                    <td   align="left">
                                                        日期：
                                                    </td>
                                                    <td align="left">
                                                        
                                                        <asp:Label ID="lbl_rq2" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        维护设备名称：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_sbmc2" runat="server" Text="" Width="240px"></asp:Label>
                                                        <asp:TextBox ID="txt_sbmcid2" runat="server" BackColor="Transparent" BorderStyle="None"
                                                                                ForeColor="transparent" Width="0"></asp:TextBox>
                                                        &nbsp;<a ID="history0" runat="server" class="a2" href="#" onclick="history2()">历史记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        负责检测单位：
                                                    </td>
                                                    <td align="left">
                                                         <asp:Label ID="lbl_jcdw2" runat="server" Text="" Width="240px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        检测人员：
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_jcry2" runat="server" Text="" Width="240px"></asp:Label>
                                                    
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        陪同人员
                                                    </td>
                                                    <td align="left">
                                                         <asp:Label ID="lbl_ptry2" runat="server" Text="" Width="240px"></asp:Label>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2" height="30px">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <table cellpadding="0" cellspacing="0"  style="border-collapse: collapse">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                        CellPadding="2" CellSpacing="1"
                                                                        CssClass="quanbu" >
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
                                                                                <ItemStyle HorizontalAlign="Left" Width="360px" />
                                                                                <HeaderStyle HorizontalAlign="Center" Width="360px" CssClass="dl" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("jcjg") %>'></asp:Label>
                                                                                </ItemTemplate>
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
                                                       <asp:Label ID="lbl_xgjy" runat="server" Text="" Width="360px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr  >
                                                    <td align="center" colspan="2" height="26" >
                                                        <asp:Label ID="lbl_id2" runat="server" Visible="False"></asp:Label>
                                                       <asp:Button ID="Button4" runat="server" CssClass="btn1" 
                                                            OnClick="btn_QX_Click2" Text="返 回" />
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