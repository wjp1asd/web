  <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WLSBGL.aspx.cs" Inherits="Web_GZJL.WLGL.WLSBGL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网络设备档案</title>
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
                                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                                            <table id="Table1" cellspacing="0" cellpadding="0" border="0">
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="3" cellspacing="0">
                                                            <tr>
                                                                <td align="left">
                                                                    设备名称：
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_sName" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                                <td>
                                                                    设备型号：
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txt_sNum" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;<asp:Button ID="btn_select" runat="server" CssClass="btn1" 
                                                                        OnClick="btn_select_Click" Text="查 询" />
&nbsp;</td>
                                                                <td>
                                                                    <td align="left">
                                                                        <asp:Button ID="btn_clear" runat="server" CssClass="btn1" 
                                                                            OnClick="btn_clear_Click" Text="清 空" />
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
                                                            OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="900px"
                                                            AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" PageSize="12">
                                                            <Columns>
                                                                <asp:BoundField DataField="eName" HeaderText="设备名称">
                                                                    <ItemStyle Width="120px"  HorizontalAlign="Center" />
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="eVersion" HeaderText="设备型号">
                                                                    <ItemStyle Width="100px"  HorizontalAlign="Center" />
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ip" HeaderText="IP地址">
                                                                    <HeaderStyle HorizontalAlign="Center"  />
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="用途">
                                                                    <ItemStyle HorizontalAlign="Left" Width="160px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblusef" Text='<%#Bind("usef") %>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="设备状态">
                                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl4" Text='<%#Bind("equiState") %>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="dl" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="buytime" HeaderText="购买时间" DataFormatString="{0:yyyy-MM-dd}">
                                                                    <HeaderStyle HorizontalAlign="Center"  />
                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
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
                                                    <td align="center" style="height: 20px">
                                                        设备名称</td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtename" runat="server" Width="240px"></asp:TextBox> </td>
                                                    <td align="left">
                                                      
                                                        管理人</td>
                                                     <td align="left">
                                                          <asp:TextBox ID="txtusername" runat="server" Width="240px"></asp:TextBox> </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                       设备型号</td>
                                                    <td align="left">
                                                       <asp:TextBox ID="txteversion" runat="server" Width="240px"></asp:TextBox> </td>
                                                    <td align="left">
                                                      设备序列号
                                                       </td>
                                                     <td align="left">
                                                         <asp:TextBox ID="txtenumber" runat="server" Width="240px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        存放位置</td>
                                                    <td align="left">
                                                         <asp:TextBox ID="txtpostion" runat="server" Width="240px"></asp:TextBox></td>
                                                    <td align="left">
                                                      设备编号
                                                        </td>
                                                     <td align="left">
                                                          <asp:TextBox ID="txtnum" runat="server" Width="240px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                       购买时间 </td>
                                                    <td align="left">
                                                        <input id="buytime" runat="server" class="Wdate" type="text" onclick="WdatePicker()" onfocus="WdatePicker({isShowClear:false,readOnly:true})" style="width: 240px" /></td>
                                                    <td align="left">
                                                      保修截止日期
                                                        </td>
                                                     <td align="left">
                                                         <input id="overtime" runat="server" class="Wdate" type="text" onclick="WdatePicker()" onfocus="WdatePicker({isShowClear:false,readOnly:true})" style="width: 240px" /> 
                                                     </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                       供应商 </td>
                                                    <td align="left">
                                                       <asp:TextBox ID="txtsupplier" runat="server" Width="240px"></asp:TextBox> </td>
                                                    <td align="left">
                                                      供应商联系方式</td>
                                                     <td align="left">
                                                         <asp:TextBox ID="txtsupliertel" runat="server" Width="240px"></asp:TextBox> </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                       IP地址 </td>
                                                    <td align="left">
                                                         <asp:TextBox ID="txtip" runat="server" Width="240px"></asp:TextBox></td>
                                                    <td align="left">
                                                      网 关
                                                        </td>
                                                     <td align="left">
                                                         <asp:TextBox ID="txtgateway" runat="server" Width="240px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                       配置参数<br />存放路径</td>
                                                    <td align="left">
                                                         <asp:TextBox ID="txtparameter" runat="server" Width="240px"></asp:TextBox></td>
                                                    <td align="left">
                                                      用 途
                                                        </td>
                                                     <td align="left">
                                                         <asp:TextBox ID="txtusef" runat="server" Width="240px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                    设备状态

                                                        </td>
                                                    <td align="left" colspan="3">
                                                        <asp:TextBox ID="txtestate" runat="server" Width="601px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                         设备附件<br />模块配置</td>
                                                    <td align="left" colspan="3">
                                                         <asp:TextBox ID="txtanner" runat="server" Width="601px"></asp:TextBox></td>
                                                </tr>
                                                
                                                <tr>
                                                    <td align="center" colspan="4" height="26">
                                                        <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                        <asp:Button ID="btn_save" runat="server"  Text="保 存" CssClass="btn1"
                                                            OnClick="btn_save_Click" Height="23px"></asp:Button>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:Button
                                                                ID="btn_QX" runat="server" Text="返 回" CssClass="btn1" OnClick="btn_QX_Click">
                                                        </asp:Button>
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
