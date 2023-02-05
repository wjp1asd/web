<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Left.aspx.cs" Inherits="Web_GZJL.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color:  #B0A8B9;

}
-->
</style>
    <link href="css/lcss.css" rel="stylesheet" type="text/css">

    <script language="javascript" src="js/jquery-1.3.2.min.js"></script>

    <script language="javascript">
        var lf = "";
    function show(obj)
    {
      $(".aaa").hide();
      if($(obj)[0].style.display=='none')
            $(obj)[0].style.display='block';
    }
    

function oa_tool(){
if(lf=="195,*"){
$("#menu").hide();
$(".left1").height(500);
$("#limg")[0].src="img/left_121.jpg";
$("#limg")[0].title="显示菜单栏";
lf="10,*";
}
else{
$("#limg")[0].src="img/left_12.jpg";
$("#limg")[0].title="隐藏菜单栏";
 $("#menu").toggle();
   // $("#menu").show(); 
$(".left1").height(0);
lf="195,*";}
}


    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="185" valign="top" id="menu">
                        <table width="185" border="0" cellpadding="0" cellspacing="0">
                            <%
                                int i = 1;
                                foreach (System.Data.DataRow dr in dtm.Rows)
                                {
                        
                            %>
                            <tr>
                                <td height="38" background="img/left_1.jpg" class="left">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="22%" align="center">
                                                <img src="img/<%=dr["imgpath"] %>" width="23" height="23"></td>
                                            <td width="49%">
                                                <a href="#" onclick="show(tr<%=i.ToString() %>);">
                                                    <%=dr["menuname"] %>
                                                </a>
                                            </td>
                                            <td width="29%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr<%=i.ToString() %>" class="aaa">
                                <td height="168" class="left" valign=top>
                                    <table border="0" align="right" cellpadding="0" cellspacing="0" style="width: 99%">
                                        <%
                                            System.Data.DataRow[] drl = dtl.Select("main_id='" + dr["menuid"].ToString() + "'");
                                            foreach (System.Data.DataRow drls in drl)
                                            {
                                        %>
                                        <tr>
                                            <td width="13%" align="center">
                                                <img src="img/left_1.gif" width="8" height="8"></td>
                                            <td width="189px" align="center">
                                                <a href="<%=drls["hlink"] %>" class="a1" target="<%=drls["target"] %>">
                                                    <%=drls["menuname"] %>
                                                </a>
                                            </td>
                                        </tr>
                                        <%} %>
                                    </table>
                                </td>
                            </tr>
                            <%
                    
                                i += 1;
                            } 
                            %>
                            <tr>
                                <td height="38" background="img/left_1.jpg" class="left">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="22%" align="center">
                                                <img src="img/left_10.jpg" width="22" height="24"></td>
                                            <td width="49%">
                                                <a href="tooltip/exit.aspx">退出系统</a></td>
                                            <td width="29%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            
                            <tr>
                                <td height="420"  class="left">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="22%" align="center">
                                               </td>
                                            <td width="49%">
                                                </td>
                                            <td width="29%">
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="10" background="img/left_11.jpg" class="left1">
                        <div align="center">
                        <img id ="limg" src="img/left_12.jpg" width="10" height="31" border="0" onclick="oa_tool()" title="隐藏菜单栏">

                            </div>
                    </td>
                </tr>
               
            </table>
            
        </div>
    </form>

    <script language="javascript">
     $(".aaa:not(#tr1)").hide();
    </script>

</body>
</html>
