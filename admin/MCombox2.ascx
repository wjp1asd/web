<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MCombox2.ascx.cs" Inherits="Web_GZJL.admin.MCombox2" %>
<script language=javascript>
function <%=this.ClientID %>dispaly()
{
    var txt=document.getElementById("<%=TextBox1.ClientID%>"); 
    var doc = document.getElementById("<%=this.ClientID %>list"); 
    doc.style.top=txt.offsetTop+txt.offsetHeight;
    doc.style.left=txt.offsetLeft;
    doc.style.display = 
    (doc.style.display == "none"?"block":"none"); 
}



function Button1_onclick() {

}

</script>
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="height: 24px; width: 156px;">
            <asp:TextBox ID="TextBox1" runat="server" Width="169px"></asp:TextBox></td>
        <td style="height: 24px; width: 25px;">
            <input id="Button1" type="button" value="…" style="width: 24px; height: 19px" size=""  runat="server" onclick="return Button1_onclick()" />
            </td>
    </tr>
</table>
<DIV id="<%=this.ClientID %>list" style="Z-INDEX: 10000; WIDTH: 500px; POSITION: absolute; TOP: 45px; HEIGHT: 0px; display: none; border-right: darkgray 1px solid; border-top: darkgray 1px solid; border-left: darkgray 1px solid; border-bottom: darkgray 1px solid; background-color: #ffffff;" >
<asp:CheckBoxList ID="CheckBoxList1" runat="server" Width="100%" BackColor="#336D93">
</asp:CheckBoxList>
    <table align="center" style="background-color:#336D93" width="100%">
    <tr>
    <td align="center" >
        <asp:Button ID="Button2" runat="server" Text="选择完毕" CssClass="btn2" OnClick="Button2_ServerClick"/>
        </td>
    </tr>
    </table>
</DIV>
