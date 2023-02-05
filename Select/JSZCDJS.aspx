<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSZCDJS.aspx.cs" Inherits="Web_GZJL.Select.JSZCDJS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
body 
{
	background-image: url(../img/left_14.jpg);
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #F7FAFD;
	color: #000000;
	font-family: "宋体";
	font-size: 11pt;
}

	
        .style1
        {
            width: 184px;
        }
        .style2
        {
            width: 204px;
        }
    .btn1 
{
	background-color:Transparent;
	font-family: "宋体";
	font-size: 12px;
	color: #336D93;
	text-decoration: none;
	border: none;
	background-image: url(../img/login_6.gif);
	height: 23px;
	width: 68px;
	line-height: 26px;
	text-indent: 10px;
}


input 
{
	font-family: "宋体";
	font-size: 12px;
	line-height: 18px;
	color: #000000;
	text-decoration: none;

	background-color: #FFFFFF;
	border: 1px solid #1777B4;
	}
	
	
	
.btn2 {
	background-color:Transparent;
	font-family: "宋体";
	font-size: 12px;
	color: #336D93;
	text-decoration: none;
	border: none;
	background-image: url(../img/login_60.gif);
	height: 23px;
	width: 108px;
	line-height: 26px;
	text-indent: 10px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    
                                            <table cellspacing="0" cellpadding="8" 
        align="left"  border="1" 
                                                style="border-collapse: collapse" 
        bordercolor="#6c9ec1">
                                                <tr align="center" >
                                                <td colspan="4"><h3>
                                                        技术支持内容登记表</h3></td></tr>
                                                <tr>
                                                    <td align="center" >
                                                        编号  
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <asp:Label ID="lbl_bianhao" runat="server" Text="lbl_bianhao"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        填表日期
                                                    </td>
                                                    <td align="left" class="style2">
                                                        <asp:Label ID="lbl_tianbiaorq" runat="server" Text="lbl_tianbiaorq"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        软件名称
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lbl_rjmc" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        登记人
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <asp:Label ID="lbl_dengjiren" runat="server" Text="lbl_dengjiren"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        登记时间
                                                    </td>
                                                    <td align="left" class="style2">
                                                        &nbsp;<asp:Label ID="lbl_dengjishijian" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        咨询人
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <asp:Label ID="lbl_zxr" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        联系方式
                                                    </td>
                                                    <td align="left" class="style2">
                                                        <asp:Label ID="lbl_lxfs" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        咨询人所<br />
                                                        在部门
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <asp:Label ID="lbl_zxrbm" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        解答时间
                                                    </td>
                                                    <td align="left" class="style2">
                                                        &nbsp;<asp:Label ID="lbl_jdsj" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        问题分类
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lbl_wtfl" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        问题内容<br />
                                                        描 述
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lbl_wtms" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        问题解答
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lbl_wtjd" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 20px">
                                                        备注
                                                    </td>
                                                    <td align="left" colspan="3" style="width:80">
                                                        <asp:Label ID="lbl_beizhu" runat="server"></asp:Label>
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" height="36">
                                     
                                               <asp:Button ID="btn_bohui" runat="server" Text="返 回" CssClass="btn1" OnClick="btn_bohui_Click" 
                                                            Visible="False"></asp:Button>  
                                                        <asp:Button ID="btn_QX" runat="server" CssClass="btn1" OnClick="btn_QX_Click" 
                                                            Text="返 回" Visible="False" />
                                                        <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                                                        <input class="btn1" runat="server" id="btfh" CssClass="btn1" onclick="javascript:window.history.go(-1);" 
                                                            type="button" value="返回" /><asp:Button ID="btn_word" runat="server" Text="生成Word打印" CssClass="btn2" 
                                                            onclick="btn_word_Click"></asp:Button>
                                                            &nbsp;</td>
                                                </tr>
                                            </table>
    </form>
</body>
</html>
