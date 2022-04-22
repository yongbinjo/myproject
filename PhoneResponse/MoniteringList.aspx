<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoniteringList.aspx.cs" Inherits="PhoneResponse.MoniteringList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>전화 민원 응대 실태 점검</title>
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <div style="text-align:right; width:900px; font-size:13px; font-family:맑은 고딕;"><b><asp:Literal ID="ltllog" runat="server"></asp:Literal></b>&nbsp;&nbsp;<input type="button" style="background-color:Black; color:White; font-size:13px; font-family:맑은 고딕;" value="로그아웃" onclick="f_logout();"/> </div>
            <table style="width:100%; font-family:맑은 고딕;">
                <tr style="height:100px;">
                    <td align="center"><div style="border:1px solid black; background-color:#2E75B6; color:White; width:900px; font-size:20px;"><b>국가보훈처 고객 만족도 조사_전화친절도</b></div></td>
                </tr>
                <tr style="height:50%">
                    <td style="align:center;">
                    
                    <center>
                        <table style="width:900px;">
                        <tr>
                            <asp:Literal ID="ltladmin" runat="server"></asp:Literal>
                            <td style="text-align:right;"><input type="text" id="search_text" name="search_text" value="" onkeydown="f_EnterKeyCheck();" style="width:130px;">&nbsp;&nbsp;<input type="button" id="search" style="background-color:Black; color:White;" name="search" onclick="f_search();" value="검  색"/></td>
                        </tr>
                        </table>
                        <asp:Literal ID="ltllist" runat="server"></asp:Literal>
                    </center>
                    </td>
                </tr>
                <tr style="height:20%">
                    <td>&nbsp;</td>
                </tr>
            </table>
            <input type="hidden" id="state" name="state" value="0" runat="server"/>
        </center>
    </div>
    </form>
</body>
<script type="text/javascript">
    function f_codeclick(code) {
        form1.action = "ResponseTable.aspx?tcode=" + code;
        form1.submit();
    }
    function f_search() {
        form1.action = "MoniteringList.aspx?search=" + document.getElementById("search_text").value;
        form1.submit();
    }
    function f_EnterKeyCheck() {
        if (event.keyCode == 13) { event.keyCode = 0; f_search(); }
    }
    function f_logout() {
        document.getElementById("state").value="1";
        form1.action = "MoniteringList.aspx";
        form1.submit();
    }
    function f_excel() {
        form1.action = "down/datadown.aspx";
        form1.submit();
    }
</script>
</html>
