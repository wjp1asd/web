<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WDSC.aspx.cs" Inherits="Web_GZJL.admin.GZZDGL"
    ValidateRequest="false" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>�ĵ��ϴ�</title>
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../js/NumericF.js"></script>

    <script type="text/javascript" src="ckeditor/ckeditor.js"></script>

    <script type="text/javascript" src="ckfinder/ckfinder.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td height="492" valign="top" >
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
                                            ��ǰλ�ã�<a href="../Main.aspx">��ҳ</a>&gt;<span style="color: #1F65AE"><%=t1 %></span>&gt;<span
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
                                <table cellspacing="0" cellpadding="0" border="0" width="50%">
                                    <tr align="center">
                                        <td>
                                            <h2>
                                                �ĵ��ϴ�</h2>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Panel ID="Panel1" runat="server" Width="100%">
                                    <table id="Table1" cellspacing="0" cellpadding="0"  style="border: 1px solid #aaaaaa;">
                                        <tr>
                                            <td style="border-bottom: 1px solid #aaaaaa;">
                                                <table border="0" cellpadding="3" cellspacing="0">
                                                    <tr style="height: 30px">
                                                        <td align="left">
                                                            ���⣺
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt_biaoti" runat="server" Width="200px"></asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                        <td>
                                                            �ļ����ͣ�
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="DropDownList2" runat="server" Width="180px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btn_select" runat="server" CssClass="btn1" OnClick="btn_select_Click"
                                                                Text="�� ѯ" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btn_add" runat="server" Text="�� ��" OnClick="btn_add_Click" CssClass="btn1">
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
                                                    AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="����">
                                                            <ItemStyle Width="450px" HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <a href='../Select/WDCX.aspx?id=<%#Eval("id") %>'>
                                                                    <asp:Label ID="lbTitle" runat="server" Text='<%# Bind("filename") %>'></asp:Label>
                                                                </a>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="450px" HorizontalAlign="Center" CssClass="dl" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="wjlx" HeaderText="�ļ�����">
                                                            <ItemStyle Width="120px" HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="wjqxaa" HeaderText="�ļ�Ȩ��">
                                                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="shangcr" HeaderText="�ϴ���">
                                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="tjriqi" HeaderText="�������" ApplyFormatInEditMode="True"
                                                            DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False">
                                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="�༭" ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                    CssClass="a2" Text="<div>�༭</div>"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="dl" HorizontalAlign="Center" Width="50px" />
                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ɾ��" ShowHeader="False">
                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                            <HeaderStyle CssClass="dl" HorizontalAlign="Center" Width="50px" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                    CssClass="a2" OnClientClick="return confirm('ȷ��ɾ��������¼��')">ɾ��</asp:LinkButton>
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
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
                                    <br />
                                    <table cellspacing="0" cellpadding="3" align="left" border="1" style="border-collapse: collapse"
                                        bordercolor="#6c9ec1">
                                        <tbody>
                                            <tr>
                                                <td align="center" style="height: 30px">
                                                    ��&nbsp;&nbsp;&nbsp;&nbsp;�⣺
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txt_title" runat="server" Width="650px" MaxLength="100"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 30px">
                                                    �ļ����ͣ�
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="183px">
                                                    </asp:DropDownList>
                                                    <br />
                                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="0" Selected="True">�����ĵ�</asp:ListItem>
                                                        <asp:ListItem Value="1">�����ĵ�</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 30px">
                                                    �ĺţ�
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txt_wenhao" runat="server" Width="180px"></asp:TextBox>
                                                    &nbsp; ���ĵ�λ��<asp:TextBox ID="txt_lwdanwei" runat="server" Width="160px"></asp:TextBox><font
                                                        size="2" color="red">ע����ͷ�ļ�����д�ĺź����ĵ�λ</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 30px">
                                                    ��ţ�
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txt_bianhao" runat="server" Width="180px"></asp:TextBox><font size="2"
                                                        color="red">ע����ʾ������д��ţ���������</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 30px">
                                                    ���ݼ�飺
                                                </td>
                                                <td align="left">
                                                    <%--<FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Width="650px" Height="360px">
                                                    </FCKeditorV2:FCKeditor>--%>
                                                    <asp:TextBox ID="txtcontents" runat="server" TextMode="MultiLine" Height="503px"
                                                        Width="100%" class="ckeditor"></asp:TextBox>

                                                    <script type="text/javascript">
                                                        //var instance=CKEDITOR.instance['txtcontents'];
                                                        //if(instance){CKEDITOR.remove(instance);}
                                                        CKEDITOR.replace('<%= txtcontents.ClientID %>', { skin: 'kama' });
                                                    </script>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    �ϴ�������
                                                </td>
                                                <td align="left" nowrap="noWrap">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                    CellPadding="2" CellSpacing="1" CssClass="quanbu" OnRowDeleting="GridView3_RowDeleting">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="��������">
                                                                            <ItemStyle Width="580px" HorizontalAlign="Center" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="580px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("mingcheng") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="ɾ��" ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="btn_delete" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                    Text="ɾ��" OnClientClick="return confirm('ȷ��ɾ��������ѵ������')"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                            <HeaderStyle Width="50px" HorizontalAlign="Center" CssClass="dl" />
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
                                                                            <asp:FileUpload ID="upFile" runat="server" Width="580px" />
                                                                        </td>
                                                                        <td width="53px" style="border-left: #c6e7b5 1px solid; border-collapse: collapse;
                                                                            border-bottom: #c6e7b5 1px solid;" align="center">
                                                                            <asp:LinkButton ID="but_add" runat="server" ToolTip="��Ӹ���" OnClick="but_add_Click">���</asp:LinkButton>
                                                                            <%--<asp:LinkButton ID="LinkButton3" runat="server" ToolTip="��Ӹ���" 
                                                                                onclick="LinkButton3_Click" >���1</asp:LinkButton>--%>
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
                                                    <asp:Button ID="btn_save" runat="server" Text="�� ��" CssClass="btn1" OnClick="btn_save_Click">
                                                    </asp:Button>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="btn_QX" runat="server"
                                                        Text="�� ��" CssClass="btn1" OnClick="btn_QX_Click"></asp:Button>
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
