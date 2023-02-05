<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SelLwdw.aspx.cs" Inherits="Web_GZJL.Select.SelLwdw" %>

<%@ Register Assembly="HFSoft.Web" Namespace="HFSoft.Web" TagPrefix="cc2" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>来往单位</title>
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../js/NumericF.js" type="text/javascript"></script>

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

    <script language="javascript">
        var Picker = new PickerControl();    
    </script>

    <script language="JavaScript" src="../js/main.js" type="text/javascript"></script>

    <script language="javascript">
		function opwin(url)
			{
				window.open(url,'','height=300, width=500'); 
			}
			

function onRowClick(name,id,dw,gg,count,phone){
	parent.Picker.pick(name,id,dw,gg,count,phone);	
}  

function DoHL()
{
var e=window.event.srcElement;
 e.className='mdr';
}

function DoLL()
{
var e=window.event.srcElement;

e.className='dan';
}

function DoLLS()
{
var e=window.event.srcElement;

e.className='suang';
}


    </script>

</head>
<body bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">

    <script language="javascript">window.history.forward(1); </script>

    <form id="Form1" method="post" runat="server">
        <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td background="../img/san_21.jpg">
                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="zhong">
                                <table border="0" cellpadding="0" cellspacing="0" height="27" width="100%">
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table id="Table1" border="0" cellpadding="0" cellspacing="0" class="table3" width="100%"
                                    style="border-collapse: collapse" bordercolor="#000000">
                                    <tr>
                                        <td align="center" valign="top">
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <table id="Table2" border="0" cellpadding="3" cellspacing="0" class="table3">
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                                    </asp:ScriptManager>
                                                                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    类别名称：</td>
                                                                                <td align="center">
                                                                                    <asp:TextBox ID="txt_mc" runat="server" Width="112px" Style="position: static;"></asp:TextBox></td>
                                                                                <td align="left">
                                                                                    <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" CssClass="btn1" />
                                                                                    </td>
                                                                                    <td align="right">
                                                                                    <asp:Button ID="btn_add" runat="server" CssClass="btn1" Text="添加" OnClick="btn_add_Click" />
                                                                                    
                                                                                    </td>
                                                                            </tr>
                                                                        </table>
                                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                            CellPadding="2" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" CellSpacing="1"
                                                                            CssClass="quanbu" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                                            PageSize="8" OnRowDataBound="GridView1_RowDataBound" Style="position: static"
                                                                            CaptionAlign="Left">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="zclbmc" HeaderText="资产类别">
                                                                                    <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="bz" HeaderText="备注">
                                                                                    <ItemStyle Width="150px" HorizontalAlign="Left" />
                                                                                    <HeaderStyle Width="150px" HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                               
                                                                            </Columns>
                                                                            <RowStyle CssClass="dan" BorderWidth="1px" />
                                                                            <HeaderStyle CssClass="biaoti" />
                                                                            <AlternatingRowStyle CssClass="suang" />
                                                                            <PagerStyle CssClass="biaoti" HorizontalAlign="Left" />
                                                                        </asp:GridView>
                                                                        <br />
                                                                        <asp:Button ID="Button2" runat="server" CausesValidation="False" Text="关闭并清空" OnClick="Button2_Click"
                                                                            CssClass="btn2" Style="left: -2px; top: 0px" />
                                                                    </asp:Panel>
                                                                    <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
                                                                        <table cellspacing="0" cellpadding="8" align="center" class="td1" style="border-collapse: collapse">
                                                                            <tr>
                                                                                <td align="left">
                                                                                    资产类别</td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txt_title" runat="server" Width="160px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    备&nbsp;&nbsp;&nbsp;&nbsp;注</td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txt_lxr" runat="server" Width="160px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="2" style="height: 22px">
                                                                                    <br />
                                                                                    <asp:Button ID="btn_save" runat="server" Text="  保 存" OnClick="btn_save_Click" CssClass="btn1">
                                                                                    </asp:Button><asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                                                    &nbsp;&nbsp;<asp:Button ID="btn_qx" runat="server"
                                                                                        Text="  返 回" CausesValidation="False" OnClick="btn_qx_Click" CssClass="btn1"></asp:Button>
                                                                                    </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
