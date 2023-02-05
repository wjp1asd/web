<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WebMain.aspx.cs" Inherits="Web_GZJL.WebMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" src="js/jquery-1.3.2.min.js"></script>
    
    <script language="javascript">
 
    function fhref(hlink)
    {
        window.document.getElementById("main").src=hlink;
    }
</script>
<link href="css/css.css" rel="stylesheet" type="text/css">
</head>
<frameset rows="80,*" cols="*" frameborder="NO" border="0" framespacing="0">  
  <frame src="top.aspx" name="top" scrolling="NO" noresize >
  <frameset name="lf" cols="195,*" frameborder="NO" border="0" framespacing="0">
    <frame src="left.aspx" name="left" scrolling="NO" noresize>
    <frame src="Main.aspx" name="main" id="main">
  </frameset>
</frameset>
<noframes>
    <body>
    </body>
</noframes>
</html>
