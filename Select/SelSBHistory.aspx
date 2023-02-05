<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelSBHistory.aspx.cs" Inherits="Web_GZJL.Select.SelSBHistory" %>


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

    <style type="text/css">
        .style1
        {
            width: 586px;
        }
    </style>

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
                                                                <td colspan="3" class="style1">
                                                                    
                                                                    <asp:Panel ID="Panel1" runat="server" Width="107%">
                                                                        <asp:GridView ID="gvsbwhHistory" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                            CellPadding="2" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" CellSpacing="1"
                                                                            CssClass="quanbu" AllowPaging="True" 
                                                                            OnPageIndexChanging="GridView1_PageIndexChanging" 
                                                                            OnRowDataBound="GridView1_RowDataBound" Style="position: static; margin-left: 0px;"
                                                                            CaptionAlign="Left" width="100%"
                                                                            onselectedindexchanged="gvsbwhHistory_SelectedIndexChanged">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="whrq" HeaderText="维护时间">
                                                                                    <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                 <asp:BoundField DataField="lfname" HeaderText="维护人">
                                                                                    <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="jcxms" HeaderText="检测内容">
                                                                                    <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="jcjgs" HeaderText="检测结果">
                                                                                    <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                            <RowStyle CssClass="dan" BorderWidth="1px" />
                                                                            <HeaderStyle CssClass="biaoti" />
                                                                            <AlternatingRowStyle CssClass="suang" />
                                                                            <PagerStyle CssClass="biaoti" HorizontalAlign="Left" />
                                                                        </asp:GridView>
                                                                        <asp:Button ID="Button2" runat="server" CausesValidation="False" 
                                                                            CssClass="btn2" OnClick="Button2_Click" Style="left: -2px; top: 0px" 
                                                                            Text="关闭" />
                                                                        <br />
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
