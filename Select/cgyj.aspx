<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cgyj.aspx.cs" Inherits="Web_GZJL.Select.cgyj" %>

<%@ Register Assembly="HFSoft.Web" Namespace="HFSoft.Web" TagPrefix="cc2" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
				window.open(url,'','height=400, width=600'); 
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
                                                                                    编号：</td>
                                                                                <td align="center">
                                                                                    <asp:TextBox ID="txt_mc" runat="server" Width="112px" Style="position: static;"></asp:TextBox></td>
                                                                                <td align="left">
                                                                                    <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" CssClass="btn1" />
                                                                                    </td>
                                                                                    <td align="right">
                                                                                        &nbsp;</td>
                                                                            </tr>
                                                                        </table>
                                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                            CellPadding="2"  CellSpacing="1"
                                                                            CssClass="quanbu" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                                            PageSize="8" OnRowDataBound="GridView1_RowDataBound" Style="position: static"
                                                                            CaptionAlign="Left">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="filename" HeaderText="请示报告">
                                                                                    <HeaderStyle Width="240px" HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="bianhao" HeaderText="编号">
                                                                                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                                                                                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                               
                                                                            </Columns>
                                                                            <RowStyle CssClass="dan" BorderWidth="1px" />
                                                                            <HeaderStyle CssClass="biaoti" />
                                                                            <AlternatingRowStyle CssClass="suang" />
                                                                            <PagerStyle CssClass="biaoti" HorizontalAlign="Left" />
                                                                        </asp:GridView>
                                                                        <br />
                                                                        <asp:Button ID="Button2" runat="server" CausesValidation="False" Text="关闭" OnClick="Button2_Click"
                                                                            CssClass="btn1" Style="left: -2px; top: 0px" />
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
