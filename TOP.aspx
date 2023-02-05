<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TOP.aspx.cs" Inherits="Web_GZJL.TOP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>top</title>
    <style type="text/css">
        <!
        -- body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-color: #A2BFD7;
        }
        -- ></style>
    <link href="css/css.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" height="40" border="0" align="left" cellpadding="0" cellspacing="0"
            style="background-color:#4B4453">
            <tr>
                
                <td align="right" valign="bottom">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="760" style="color:white;font-size:24px;" align="left">
                               压力容器与管道壁厚数据管理系统
                                </td>
                            <td align="left" nowrap="nowrap">
                                <font style="color:Red; filter: shadow(color=black); font-family: 华文楷体; font-size: 17pt">
                                    欢迎<%=xzdq%>&nbsp;<%=name %>&nbsp;使用</font>
                            </td>
                            
                            <td align="right" nowrap="nowrap">
                               <a href="help/帮助文档.doc" target="main" > <img border="0" alt="" width="24" height="24" src="img/menu_bz.jpg" /><font style="color: Red;
                                    filter: shadow(color=black); font-family: 华文楷体; font-size: 12pt">帮助</font></a>
                            </td>
                            <td align="right" nowrap="nowrap" >
                                <a href="tooltip/exit.aspx"> <img border="0" alt="" width="24" height="24" src="img/menu_tc1.jpg" /><font style="color: Red;
                                    filter: shadow(color=black); font-family: 华文楷体; font-size: 12pt">退出</font></a>
                            </td>
                            <td width="20px"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
