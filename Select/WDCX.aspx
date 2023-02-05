<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WDCX.aspx.cs" Inherits="Web_GZJL.Select.WDCX" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>文档查询</title>
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../js/NumericF.js"></script>

    <script language="javascript">
        //下载
        function downLoadField(fieldpath) {
            window.open(fieldpath);
            return null;
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
                            <td style="width: 30px">
                            </td>
                            <td valign="top" align="left">
                                <br />
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                   <table  cellspacing="0" cellpadding="0" border="0" width="55%">
                                            <tr align="center" >
                                                <td>
                                                    <h2>
                                                        文档查询</h2>
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
                                                            标题：
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt_biaoti" runat="server" Width="200px"></asp:TextBox>
                                                        </td>
                                                        
                                                        <td>
                                                            文件类型：
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="DropDownList2" runat="server" Width="180px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            文档权限
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="DropDownList3" runat="server" Width="180px">
                                                                <asp:ListItem Value="全部">全部</asp:ListItem>
                                                                <asp:ListItem Value="0">个人文档</asp:ListItem>
                                                                <asp:ListItem Value="1">公开文档</asp:ListItem>
                                                            </asp:DropDownList>
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
                                            <td align="right" style="height: 5px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                    CellPadding="2" CellSpacing="1" CssClass="quanbu" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                    OnSelectedIndexChanging="GridView1_SelectedIndexChanging" AllowPaging="True"
                                                    OnRowDataBound="GridView1_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="标题">
                                                            <ItemStyle Width="450px" HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <a href='WDCX.aspx?idd=<%#Eval("id") %>'>
                                                                    <asp:Label ID="lbTitle" runat="server" Text='<%# Bind("filename") %>'></asp:Label></a>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="450px" HorizontalAlign="Center" CssClass="dl" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="wjlx" HeaderText="文件类型">
                                                            <ItemStyle Width="150px" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="wjqxaa" HeaderText="文件权限">
                                                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="shangcr" HeaderText="上传人">
                                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="tjriqi" HeaderText="添加日期" ApplyFormatInEditMode="True"
                                                            DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False">
                                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="查看" ShowHeader="False">
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
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
                                    <br />
                                    <table cellspacing="0" cellpadding="3" align="left" border="1" style="border-collapse: collapse" bordercolor="#6c9ec1">
                                        <tbody>
                                            <tr>
                                                <td align="center" style="height: 30px">
                                                    标&nbsp;&nbsp;&nbsp;&nbsp;题：
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lbl_biaoti" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 30px">
                                                    文件类型：
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lbl_wenjianlx" runat="server" Text=""></asp:Label>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 30px">
                                                    文&nbsp;&nbsp;&nbsp;&nbsp;号：
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lbl_wenhao" runat="server" Text=""></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 30px">
                                                    来文单位：
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lbl_laiwendanwei" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 30px">
                                                    编&nbsp;&nbsp;&nbsp;&nbsp;号：
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lbl_bianhao" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 30px">
                                                    内容简介：
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lbl_jianjie" runat="server" Width="640px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    上传附件：
                                                </td>
                                                <td align="left" nowrap="noWrap">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                    CellPadding="2" CellSpacing="1" CssClass="quanbu" 
                                                                     OnSelectedIndexChanging="GridView3_SelectedIndexChanging">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="附件名称">
                                                                            <ItemStyle Width="580px" HorizontalAlign="Center" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="580px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("mingcheng") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderText="路径" Visible="false">
                                                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_lujing" runat="server" Text='<%# Bind("lujing") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="下载" ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="linkbtn"  runat="server" CausesValidation="False" CommandName="Select"
                                                                                    CssClass="a2" Text="<div>下载</div>"  ></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle CssClass="dl" HorizontalAlign="Center" Width="50px" />
                                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
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
                                                                <table border="0" cellpadding="2" cellspacing="0" style="border-right: #C6E7B5 1px solid;
                                                                    border-left: #C6E7B5 1px solid; border-bottom: #C6E7B5 1px solid; border-collapse: collapse">
                                                                    <tr>
                                                                        <td width="580" style="border-right: #c6e7b5 1px solid; border-collapse: collapse;
                                                                            border-bottom: #c6e7b5 1px solid;">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="53px" style="border-left: #c6e7b5 1px solid; border-collapse: collapse;
                                                                            border-bottom: #c6e7b5 1px solid;" align="center">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" height="26">
                                                    <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                    <asp:Button ID="btn_qx" runat="server" Text="返 回" CssClass="btn1" OnClick="btn_QX_Click">
                                                    </asp:Button>
                                                    <asp:Button ID="btn_qx2" runat="server" Text="返 回" CssClass="btn1" OnClick="btn_QX_Click2">
                                                    </asp:Button>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:Panel>
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
