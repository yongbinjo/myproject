<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="datadown.aspx.cs" Inherits="PhoneResponse.down.datadown" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
            <input type="button" value="excel down" />
        
            <div id="exceldata" runat="server">
                <asp:Literal ID="ltlexcel" runat="server"></asp:Literal>
            </div>
            </center>
        </div>
    </form>
</body>
</html>
