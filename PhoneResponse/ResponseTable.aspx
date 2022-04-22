<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResponseTable.aspx.cs" Inherits="PhoneResponse.ResponseTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="include/common_style.css" rel="stylesheet" type="text/css" />
<link href="include/ThisCss.css" rel="stylesheet" />
    <title>전화 민원 응대 실태 점검</title>

</head>
<script type="text/javascript">
    function f_register() {
        for(j=1; j<=4; j++) {
            state = false;
            for (i = 0; i < form1.elements["Q"+j].length; i++) {
                if (form1.elements["Q" + j][i].checked)
                    state = true;
            }
            if(state==false)
            {
                alert("Q" + j + "를 선택해주세요.");
                document.getElementById("Q"+j+"_1").focus();
                return false;
            }
        }
        form1.action = "DataRegist.aspx";
        form1.submit();
    }
    function f_checkbtn(num, val) {
        
        document.getElementById("span" + num).innerText = val;
        document.getElementById("spantotal").innerText = Number(document.getElementById("span1").innerText) + Number(document.getElementById("span2").innerText) + Number(document.getElementById("span3").innerText) + Number(document.getElementById("span4").innerText);
        f_checktotal(document.getElementById("spantotal").innerText);
    }
    function f_checktotal(num) {
        document.getElementById("spantotal").innerText = num;
        document.getElementById("htotal").value = num;
    }
    function f_checkdate(date) {
        document.getElementById("spandate").innerText = date;
    }
</script>


<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <center>
        <div style="width:900px;">
            <asp:Literal ID="ltlinfo" runat="server"></asp:Literal>
        </div>
        <br />
        <br />
        <br />
        <br />
        <div style="width:900px;">
            <asp:Literal ID="ltltable" runat="server"></asp:Literal>
            <asp:Literal ID="ltlscript" runat="server"></asp:Literal>
        </div>
        </center>
        
    </div>
        
    </form>
</body>
</html>